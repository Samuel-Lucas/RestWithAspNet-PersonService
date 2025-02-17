using System.Security.Cryptography;
using System.Text;
using ApiPersonService.Data;
using ApiPersonService.Data.VO;
using ApiPersonService.Model;

namespace ApiPersonService.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User ValidateCredentials(UserVO user)
    {
        var pass = ComputeHash(user.Password, SHA256.Create());
        var userRetrieved = _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass))!;
        return userRetrieved;
    }

    public User RefreshUserInfo(User user)
    {
        if (!_context.Users.Any(u => u.Id == user.Id)) return null!;

        var result = _context.Users.SingleOrDefault(u => u.Id == user.Id);

        try
        {
            _context.Users.Entry(result!).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private string ComputeHash(string password, HashAlgorithm algorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

        var builder = new StringBuilder();

        foreach (var item in hashedBytes)
            builder.Append(item.ToString("x2"));

        return builder.ToString();
    }
}