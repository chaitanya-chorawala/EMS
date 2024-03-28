﻿using AutoMapper;
using ems.Common.Entities;
using ems.Common.ExceptionHandler;
using ems.Common.Helper;
using ems.Common.model;
using ems.Common.model.Auth;
using ems.Core.Contract.Common;
using ems.Core.Contract.Repository;
using ems.Core.Contract.Service;
using FluentValidation;

namespace ems.Persistence.Service;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IRepoManager _repoManager;
    private readonly IMapper _mapper;
    private readonly IValidator<Register> _validator;
    private readonly IValidator<RegisterDto> _updateValidator;

    public AuthService(ITokenGenerator tokenGenerator, IRepoManager repoManager, IValidator<Register> validator, IMapper mapper, IValidator<RegisterDto> updateValidator)
    {
        _tokenGenerator = tokenGenerator;
        _repoManager = repoManager;
        _validator = validator;
        _mapper = mapper;
        _updateValidator = updateValidator;
    }

    public async Task<RegistrationResponse> GetUser(int userid)

    {
        try
        {
            return await _repoManager.UserRepo.GetUserDetail(userid);
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
            var user = await _repoManager.UserRepo.LoginAsync(model);
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
            var checkEmail = await _repoManager.UserRepo.GetUserEmail(model.Email, null);
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
            return await _repoManager.UserRepo.RegisterAsync(mapUser);
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
            var checkEmail = await _repoManager.UserRepo.GetUserEmail(model.Email, id);
            if (checkEmail == 0)
            {
                throw new BadRequestException("Given email is already exsist");
            }

            var res = _updateValidator.Validate(model);

            if (!res.IsValid)
            {
                throw new BadRequestException(string.Join('|', res.Errors.ToList()));
            }

            var existEmployee = await _repoManager.UserRepo.GetRegistrationById(id);
            
            _mapper.Map(model, existEmployee);            
            existEmployee.UpdatedDate = DateTime.UtcNow;
            return await _repoManager.UserRepo.UpdateRegistration(existEmployee);
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
            return await _repoManager.UserRepo.DeleteRegistration(id);
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
            var users = await _repoManager.UserRepo.GetUserList(searchingParams, sortingParams);
            return users;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
