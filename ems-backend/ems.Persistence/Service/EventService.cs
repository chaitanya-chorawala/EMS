using AutoMapper;
using ems.Common.Entities;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Common.model.Event;
using ems.Core.Contract.Repository;
using ems.Core.Contract.Service;
using ems.Persistence.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ems.Persistence.Service;

public class EventService : IEventService
{
    private readonly IRepoManager _repoManager;
    private readonly IMapper _mapper;
    private readonly IValidator<AddEventDto> _validator;

    public EventService(IRepoManager repoManager, IMapper mapper, IValidator<AddEventDto> validator)
    {
        _repoManager = repoManager;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<PaginationResponse<EventResponse>> GetEvent(string? searchingParams, SortingParams sortingParams, bool? isCompleted)
    {
        return await _repoManager.EventRepo.GetEvent(isCompleted, searchingParams, sortingParams);
    }

    private async Task<(string, string)> GetFileAndDirectoryPath()
    {
        string localPath = "";

        var filePath = await _repoManager.EventRepo.GetFilePath("Rayna");

        var additionalPath = "\\" + DateTime.Now.Year + "\\" + DateTime.Now.ToString("MMM") + "\\";

        var directoryPath = filePath.Path + additionalPath;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        return (directoryPath, localPath);
    }

    private IList<EventMedia> UploadEventFiles(IList<IFormFile> files, string directoryPath, string localPath) 
    {
        IList<EventMedia> eventFiles = new List<EventMedia>();

        foreach (var file in files)
        {
            EventMedia eventFile = new EventMedia();

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            localPath = Path.Combine(directoryPath + fileName);

            using (var fs = new FileStream(localPath, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                file.CopyTo(fs);
            }

            eventFile.Name = fileName;
            eventFile.Url = localPath;

            eventFiles.Add(eventFile);
        }

        return eventFiles;
    }

    public async Task<RegisterResponse> AddEventAsync(AddEventDto addEventDto)
    {
        var res = _validator.Validate(addEventDto);

        if (!res.IsValid)
        {
            throw new BadRequestException(string.Join('|', res.Errors.ToList()));
        }

        var mapEvent = _mapper.Map<Event>(addEventDto);

        if (addEventDto.EventFiles is not null)
        {
            var (directoryPath, localPath) = await GetFileAndDirectoryPath();            
            mapEvent.EventMediaList = UploadEventFiles(addEventDto.EventFiles, directoryPath, localPath);
        }        
        
        _repoManager.EventRepo.Create(mapEvent);
        await _repoManager.SaveChangesAsync();
        return new RegisterResponse() { Message = "Event added successfully." };
    }

    public async Task<RegisterResponse> UpdateEventAsync(int id, AddEventDto addEventDto)
    {
        var res = _validator.Validate(addEventDto);

        if (!res.IsValid)
        {
            throw new BadRequestException(string.Join('|', res.Errors.ToList()));
        }

        var existingEvent = await _repoManager.EventRepo.FindByConditionFirstOrDefault(x => x.EventId == id);

        _mapper.Map(addEventDto, existingEvent);

        if (addEventDto.EventFiles is not null)
        {
            var (directoryPath, localPath) = await GetFileAndDirectoryPath();
            existingEvent.EventMediaList = UploadEventFiles(addEventDto.EventFiles, directoryPath, localPath);
        }

        _repoManager.EventRepo.Update(existingEvent);
        await _repoManager.SaveChangesAsync();
        return new RegisterResponse() { Message = "Event updated successfully." };
    }

    public async Task<RegisterResponse> DeleteEventAsync(int id)
    {
        var existingEvent = await _repoManager.EventRepo.FindByConditionFirstOrDefault(x => x.EventId == id);
        
        _repoManager.EventRepo.Delete(existingEvent);
        await _repoManager.SaveChangesAsync();

        return new RegisterResponse() { Message = "Event deleted successfully." };
    }

    public async Task<EventResponse> GetEventByIdAsync(int id)
    {        
        var eve = await _repoManager.EventRepo.FindByConditionFirstOrDefault(x => x.EventId == id);
        return _mapper.Map<EventResponse>(eve);
    }
}

