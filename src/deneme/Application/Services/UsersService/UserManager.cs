using System.Linq.Expressions;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Services.UsersService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserManager(IUserRepository userRepository, UserBusinessRules userBusinessRules,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>?> GetListAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _userRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);

        return deletedUser;
    }

    public async Task<Guid> GetUserIdIntoAccessToken(IHttpContextAccessor _httpContextAccessor)
    {
        var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        // Token'dan user ID'yi (sub claim) al
        var userIdClaim =
            jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier || claim.Type == "sub");

        return new Guid(userIdClaim.Value);
    }

    public async Task<Claim> GetClaimAsync(IHttpContextAccessor _HttpContextAccessor)
    {
        var token = _HttpContextAccessor.HttpContext?.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        // Token'dan role claim'ini al
        var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role || claim.Type == "role");

        return roleClaim;
    }

    public async Task EnsureAdminOrUserOwnership(Guid id)
    {

        var claim = await GetClaimAsync(_httpContextAccessor);
        var userId = await GetUserIdIntoAccessToken(_httpContextAccessor);

        await _userBusinessRules.EnsureAdminOrUserOwnership(id, userId, claim);

    }
}
