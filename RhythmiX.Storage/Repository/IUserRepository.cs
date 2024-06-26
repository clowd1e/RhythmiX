﻿using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameTakenAsync(string username);
        Task AddUserAsync(User user);
        Task<bool> IsUserExistsAsync(string username);
        Task<bool> IsEmailTakenAsync(string email);
        Task<bool> IsPasswordCorrectAsync(string username, string password);
        Task<User> LoginUserAsync(string username, string password);
    }
}
