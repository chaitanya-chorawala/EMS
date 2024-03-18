using AutoMapper;
using rayna.Common.Entities;
using rayna.Common.ExceptionHandler;
using rayna.Common.Helper;
using rayna.Common.model;
using rayna.Common.model.Auth;
using rayna.Core.Contract.Common;
using rayna.Core.Contract.Repository;
using rayna.Core.Contract.Service;
using FluentValidation;

namespace rayna.Persistence.Service;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    private readonly IValidator<Register> _validator;
    private readonly IValidator<RegisterDto> _updateValidator;

    public AuthService(ITokenGenerator tokenGenerator, IUserRepo userRepo, IValidator<Register> validator, IMapper mapper, IValidator<RegisterDto> updateValidator)
    {
        _tokenGenerator = tokenGenerator;
        _userRepo = userRepo;
        _validator = validator;
        _mapper = mapper;
        _updateValidator = updateValidator;
    }

    public async Task<RegistrationResponse> GetUser(int userid)

    {
        try
        {
            return await _userRepo.GetUserDetail(userid);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<LoginResponse> Login(Login model)
    {
        try
        {
            var user = await _userRepo.LoginAsync(model);
            return await _tokenGenerator.GenerateTokenAsync(user);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<LoginResponse> RefreshToken(LoginResponse model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.AccessToken) || string.IsNullOrEmpty(model.RefreshToken))
                throw new BadRequestException("Please provide both tokens");

            return await _tokenGenerator.RegenerateTokenAsync(model);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RegisterResponse> Register(Register model)
    {
        try
        {
            var checkEmail = await _userRepo.GetUserEmail(model.Email, null);
            if (checkEmail == 0)
            {
                throw new BadRequestException("Given email is already exsist");
            }
            var res = _validator.Validate(model);

            if (!res.IsValid)
            {
                throw new BadRequestException(string.Join('|', res.Errors.ToList()));
            }

            var mapUser = _mapper.Map<Registration>(model);            
            return await _userRepo.RegisterAsync(mapUser);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RegisterResponse> UpdateRegistration(int id, RegisterDto model)
    {
        try
        {
            var checkEmail = await _userRepo.GetUserEmail(model.Email, id);
            if (checkEmail == 0)
            {
                throw new BadRequestException("Given email is already exsist");
            }

            var res = _updateValidator.Validate(model);

            if (!res.IsValid)
            {
                throw new BadRequestException(string.Join('|', res.Errors.ToList()));
            }

            var existEmployee = await _userRepo.GetRegistrationById(id);
            
            _mapper.Map(model, existEmployee);            
            existEmployee.UpdatedDate = DateTime.UtcNow;
            return await _userRepo.UpdateRegistration(existEmployee);
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
            return await _userRepo.DeleteRegistration(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PaginationResponse<RegistrationResponse>> UserList(string? searchingParams, SortingParams sortingParams)
    {
        try
        {
            var users = await _userRepo.GetUserList(searchingParams, sortingParams);
            return users;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
