using Microsoft.EntityFrameworkCore;
using OnlineWalmart.Users.Context;
using OnlineWalmart.Users.DAL.Entities;
using OnlineWalmart.Users.DAL.Interfaces;

namespace OnlineWalmart.Users.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context)
    {
        _context = context;
    }
    public async Task<bool> AddNewUserAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteUser(User user)
    {
        try
        {
            _context.Users.Remove(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Id == id) ?? null!;
    }

    public bool UpdateUser(User user)
    {
        try
        {
            _context.Users.Update(user);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
