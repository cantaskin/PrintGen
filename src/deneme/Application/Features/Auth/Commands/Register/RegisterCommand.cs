using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;
using NArchitecture.Core.Security.OtpAuthenticator;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterExtendedDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }


    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterExtendedDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;
        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IUserOperationClaimService  userOperationClaimService
        )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
            await _authBusinessRules.UserPasswordShouldBeMatchWithPasswordConfirm(
                request.UserForRegisterDto.Password, request.UserForRegisterDto.PasswordConfirm);
            await _authBusinessRules.UserUserNameShouldBeNotExist(request.UserForRegisterDto.UserName);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    UserName = request.UserForRegisterDto.UserName,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PhoneNumber = request.UserForRegisterDto.PhoneNumber
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                createdUser,
                request.IpAddress
            );
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);


                UserOperationClaim userOperationClaim = new()
                {
                    OperationClaimId = AuthOperationClaims.UserId,
                    UserId = createdUser.Id
                };

                await _userOperationClaimService.AddAsync(userOperationClaim);

            
            
            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
