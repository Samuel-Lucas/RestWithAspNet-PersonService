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
        return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass))!;
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