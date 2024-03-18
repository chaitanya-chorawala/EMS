using rayna.Common.Entities;
using rayna.Common.ExceptionHandler;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;
using rayna.Common.model.Rayna;
using rayna.Core.Contract.Repository;
using rayna.Persistence.Configuration;
using rayna.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace rayna.Persistence.Repository
{
    public class EventRepo : IEventRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<EventResponse>> GetEvent(bool? isCompleted, string? searchingParams, SortingParams sortingParams)
        {
            try
            {
                var events = new List<EventResponse>().AsQueryable();
                IQueryable<Event>? source;

                if (searchingParams is not null)
                {
                    source = _context.Event
                            .Where(x => x.Name.Contains(searchingParams));
                }
                else
                {
                    source = _context.Event;
                }

                events = _mapper.ProjectTo<EventResponse>(source).AsQueryable();

                var totalCount = await events.CountAsync();
                double? pageCount = Math.Ceiling(totalCount / sortingParams.PageSize);

                var sortedData = SortingExtensions.ApplySorting(events, sortingParams.SortBy, sortingParams.IsSortAscending);

                var paginatedData = await SortingExtensions.ApplyPagination(sortedData, sortingParams.PageNumber, sortingParams.PageSize).ToListAsync();

                var eventResponse = new PaginationResponse<EventResponse>()
                {
                    Values = paginatedData,
                    Pagination = new Pagination()
                    {
                        CurrentPage = sortingParams.PageNumber,
                        PageCount = (int)pageCount,
                        PageSize=sortingParams.PageSize,
                        TotalRecord=totalCount
                    }
                };

                return eventResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceConfiguration> GetMailConfiguration()
        {
            var mailConfiguration = await _context.ServiceConfiguration.FirstOrDefaultAsync() ?? throw new NotFoundException("Mail configuration not found.");

            return mailConfiguration;
        }

        public async Task<FormatConfiguration> GetMailFormate(string? type, string? status)
        {
            var mailFormate = await _context.FormatConfiguration.Where(x => x.Type == type && x.Status == status).FirstOrDefaultAsync() ?? throw new NotFoundException("Mail formate not found.");

            return mailFormate;
        }

        public async Task<FilePath> GetFilePath(string type)
        {
            try
            {
                var filePath = await _context.FilePath.Where(x => x.Type == type).FirstOrDefaultAsync();

                if (filePath == null)
                {
                    throw new NotFoundException("File Path Not Found");
                }

                return filePath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RegisterResponse> AddEvent(Event rayna)
        {
            try
            {
                await _context.Event.AddAsync(rayna);
                await _context.SaveChangesAsync();

                return new RegisterResponse() { Message = "Rayna added successfully." };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
