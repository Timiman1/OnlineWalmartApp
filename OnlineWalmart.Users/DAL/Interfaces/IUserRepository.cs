using OnlineWalmart.Users.DAL.Entities;

namespace OnlineWalmart.Users.DAL.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task<bool> AddNewUserAsync(User user);
    bool UpdateUser(User user);
    bool DeleteUser(User user);
}
