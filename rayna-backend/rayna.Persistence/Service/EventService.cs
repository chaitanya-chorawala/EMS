using AutoMapper;
using rayna.Common.Entities;
using rayna.Common.ExceptionHandler;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;
using rayna.Common.model.Rayna;
using rayna.Core.Contract.Repository;
using rayna.Core.Contract.Service;
using FluentValidation;

namespace rayna.Persistence.Service;

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

    public async Task<RegisterResponse> AddEventAsync(AddEventDto addEventDto)
    {
        var res = _validator.Validate(addEventDto);

        if (!res.IsValid)
        {
            throw new BadRequestException(string.Join('|', res.Errors.ToList()));
        }

        string? localPath = null;
        List<MailAttachment> mailAttachments = new List<MailAttachment>();
        List<MailMaster> mailMasters = new List<MailMaster>();

        var mapComplain = _mapper.Map<Event>(addEventDto);
        var filePath = await _eventRepo.GetFilePath("Rayna");
        var eventNo = await _eventRepo.GetComplainNo();        
        var mailConfiguration = await _eventRepo.GetMailConfiguration();
        var mailFormate = await _eventRepo.GetMailFormate("Email", "RegistrationUser");
        mapComplain.EventNo = eventNo;
        var additionalPath = "\\" + DateTime.Now.Year + "\\" + DateTime.Now.ToString("MMM") + "\\";

        var directoryPath = filePath.Path + additionalPath;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (addEventDto.EventFiles is not null)
        {
            List<EventFiles> eventFiles = new List<EventFiles>();

            foreach (var file in addEventDto.EventFiles)
            {
                EventFiles eventFile = new EventFiles();
                MailAttachment mailAttachment = new MailAttachment();

                var fileName = addEventDto.Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                localPath = Path.Combine(directoryPath + fileName);

                using (var fs = new FileStream(localPath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    file.CopyTo(fs);
                }
                
                eventFile.FileName = fileName;
                eventFile.FilePath = localPath;
                mailAttachment.AttachmentPath = localPath;

                eventFiles.Add(eventFile);
                mailAttachments.Add(mailAttachment);
            }
            mapComplain.EventFileList = eventFiles;
        }        

        MailMaster addUserMail = new MailMaster()
        {
            FromMail = mailConfiguration.MailId,
            ToMail = addEventDto.EmailId!,
            Subject = mailFormate.Subject!,
            MessageBody = mailFormate.Body!.Replace("#UserName", addEventDto.Name).Replace("#EventDetails", addEventDto.OtherDetails),            
            Attachments = mailAttachments
        };
        mailMasters.Add(addUserMail);

        mapComplain.MailMasters = mailMasters;

        return await _eventRepo.AddEvent(mapComplain);
    }
}

