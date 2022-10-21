﻿using Identity.Infrastructure.Views;
using Identity.Models.Models;
using Identity.Shared.RequestModels;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User,UserRequest>
    {
        Task<User> GetUserAsync(string id);
        Task<Avatar> GetUserAvatarAsync(string id);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<List<UserAvatarsDTO>> GetAvatarsWihtUserName();
    }
}
