using ems.Common.Entities;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Common.model.Event;
using ems.Core.Contract.Repository;
using ems.Persistence.Configuration;
using ems.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ems.Persistence.Repository
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

        public async Task<FilePath> GetFilePath(string type)
        {
            try
            {
                var filePath = await _context.FilePath.Where(x => x.Type == type).FirstOrDefaultAsync();

                if (filePath == null)
                {
                    filePath = new FilePath() { Path = AppDomain.CurrentDomain.BaseDirectory, Type = "Event" };
                }

                return filePath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RegisterResponse> AddEvent(Event eve)
        {
            try
            {
                await _context.Event.AddAsync(eve);
                await _context.SaveChangesAsync();

                return new RegisterResponse() { Message = "Event added successfully." };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RegisterResponse> UpdateEvent(Event eve)
        {
            try
            {
                _context.Event.Update(eve);
                await _context.SaveChangesAsync();

                return new RegisterResponse() { Message = "Event updated successfully." };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RegisterResponse> DeleteEvent(Event eve)
        {
            try
            {
                _context.Event.Remove(eve);
                await _context.SaveChangesAsync();

                return new RegisterResponse() { Message = "Event deleted successfully." };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Event> GetEventById(int id)
        {
            try
            {
                return await _context.Event.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("Event not found");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
