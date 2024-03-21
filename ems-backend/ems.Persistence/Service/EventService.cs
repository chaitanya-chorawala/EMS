using AutoMapper;
using ems.Common.Entities;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Common.model.Event;
using ems.Core.Contract.Repository;
using ems.Core.Contract.Service;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ems.Persistence.Service;

public class EventService : IEventService
{
    private readonly IEventRepo _eventRepo;
    private readonly IMapper _mapper;
    private readonly IValidator<AddEventDto> _validator;

    public EventService(IEventRepo eventRepo, IMapper mapper, IValidator<AddEventDto> validator)
    {
        _eventRepo = eventRepo;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<PaginationResponse<EventResponse>> GetEvent(string? searchingParams, SortingParams sortingParams, bool? isCompleted)
    {
        return await _eventRepo.GetEvent(isCompleted, searchingParams, sortingParams);
    }

    private async Task<(string, string)> GetFileAndDirectoryPath()
    {
        string localPath = "";

        var filePath = await _eventRepo.GetFilePath("Rayna");

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
            mapEvent.EventFileList = UploadEventFiles(addEventDto.EventFiles, directoryPath, localPath);
        }        
        
        return await _eventRepo.AddEvent(mapEvent);
    }

    public async Task<RegisterResponse> UpdateEventAsync(int id, AddEventDto addEventDto)
    {
        var res = _validator.Validate(addEventDto);

        if (!res.IsValid)
        {
            throw new BadRequestException(string.Join('|', res.Errors.ToList()));
        }

        var existingEvent = await _eventRepo.GetEventById(id);

        _mapper.Map(addEventDto, existingEvent);

        if (addEventDto.EventFiles is not null)
        {
            var (directoryPath, localPath) = await GetFileAndDirectoryPath();
            existingEvent.EventFileList = UploadEventFiles(addEventDto.EventFiles, directoryPath, localPath);
        }

        return await _eventRepo.UpdateEvent(existingEvent);
    }

    public async Task<RegisterResponse> DeleteEventAsync(int id)
    {
        var existingEvent = await _eventRepo.GetEventById(id);
        return await _eventRepo.DeleteEvent(existingEvent);
    }

    public async Task<EventResponse> GetEventByIdAsync(int id)
    {
        var eve = await _eventRepo.GetEventById(id);
        return _mapper.Map<EventResponse>(eve);
    }
}

