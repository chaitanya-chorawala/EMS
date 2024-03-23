using ems.Common.Entities;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Core.Contract.Repository;
using ems.Persistence.Configuration;
using ems.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ems.Persistence.Repository;

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RegistrationResponse> GetUserDetail(int userid)
    {
        try
        {
            RegistrationResponse? user = await _context.Registration
                .Where(x => x.Id == userid)
                .Select(RegistrationResponse.ToDTO())
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? throw new NotFoundException("User not found"); ;

            return user;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<PaginationResponse<RegistrationResponse>> GetUserList(string? searchingParams, SortingParams sortingParams)
    {
        var users = new List<RegistrationResponse>().AsQueryable();
        if (searchingParams is not null)
        {
            users = _context.Registration
                    .Where(x => (x.UserName).ToLower().Contains(searchingParams.ToLower()                                    
                                    ))
                     .Select(RegistrationResponse.ToDTO())
                     .AsQueryable();
        }
        else
        {
            users = _context.Registration
                    .Select(RegistrationResponse.ToDTO())
                    .AsQueryable();
        }

        var totalCount = await users.CountAsync();
        double? pageCount = Math.Ceiling(totalCount / sortingParams.PageSize);

        var sortedData = SortingExtensions.ApplySorting(users, sortingParams.SortBy, sortingParams.IsSortAscending);

        var paginatedData = await SortingExtensions.ApplyPagination(sortedData, sortingParams.PageNumber, sortingParams.PageSize).ToListAsync();

        var userResponse = new PaginationResponse<RegistrationResponse>()
        {
            Values = paginatedData,
            Pagination = new Pagination()
            {
                CurrentPage = sortingParams.PageNumber,
                PageCount = (int)pageCount,
                TotalRecord = totalCount,
                PageSize = sortingParams.PageSize
            }
        };
        return userResponse;
    }
  
    public async Task<User> LoginAsync(Login model)
    {
        try
        {
            User? user = await _context.Registration
                .Where(x => x.UserName == model.Username && x.Password == model.Password)
                .Select(x => new User
                {
                    Id = x.Id,
                    FullName = x.UserName,
                    Email = x.Email,                    
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task<RegisterResponse> RegisterAsync(Registration registration)
    {
        try
        {           
            var userExists = await _context.Registration
                .AnyAsync(x => x.UserName == registration.UserName);

            if (userExists)
                throw new BadRequestException("UserName already exists!");

            await _context.Registration.AddAsync(registration);
            await _context.SaveChangesAsync();

            return new RegisterResponse() { Message = "Registration successful!" };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RegisterResponse> UpdateRegistration(Registration registration)
    {
        try
        {           
            var userExists = await _context.Registration
                .AnyAsync(x => x.Id != registration.Id  && x.UserName == registration.UserName);

            if (userExists)
                throw new BadRequestException("UserName already exists!");

            _context.Registration.Update(registration);
            await _context.SaveChangesAsync();

            return new RegisterResponse() { Message = "Employee updated successfully." };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RegisterResponse> DeleteRegistration(int id)
    {
        try
        {
            var existEmployee = await _context.Registration.FirstOrDefaultAsync(x => x.Id == id ) ?? throw new NotFoundException("Employee not found.");

            //existEmployee.DeletedAt = DateTimeOffset.UtcNow;
            //existEmployee.IsActive = false;

            _context.Registration.Update(existEmployee);
            await _context.SaveChangesAsync();

            return new RegisterResponse() { Message = "Employee deleted successfully." };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateRefreshTokenAsync(int userid, string refreshToken)
    {
        try
        {
            var existedRefreshToken = await _context.UserJwtRefreshToken
                .Where(x => 
                x.UserId == userid).FirstOrDefaultAsync();

            if (existedRefreshToken is not null)
            {
                existedRefreshToken.Token = refreshToken;
                existedRefreshToken.UpdatedDate = DateTime.Now;
                _context.Entry(existedRefreshToken).State = EntityState.Modified;
            }
            else
            {
                existedRefreshToken = new JwtRefreshToken() { UserId = userid, Token = refreshToken };
                await _context.UserJwtRefreshToken.AddAsync(existedRefreshToken);
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> VerifyRefreshTokenAsync(int userid, string refreshToken)
    {
        try
        {
            var token = await _context.UserJwtRefreshToken
                .Where(x =>  x.UserId == userid && x.Token == refreshToken)
                .Select(x => x.Token)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (token is null)
                throw new NotFoundException("User not found");
            return token;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<int> GetUserEmail(string emailId, int? id)
    {
        var user = await _context.Registration.Where(x => (id == null || x.Id != id) && x.Email == emailId).FirstOrDefaultAsync();
        if (user == null)
        {
            return 1;
        }
        return 0;
    }

    public async Task<Registration> GetRegistrationById(int id)
    {
        try
        {
            return await _context.Registration.Where(x => x.Id == id ).FirstOrDefaultAsync() ?? throw new NotFoundException("Employee not found for update.");
        }
        catch (Exception)
        {
            throw;
        }
    }
}


