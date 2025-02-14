using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonService.Model;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_name")]
    public string UserName { get; set; } = null!;

    [Column("full_name")]
    public string FullName { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("refresh_token")]
    public string RefreshToken { get; set; } = null!;

    [Column("refresh_token_expire")]
    public DateTime RefreshTokenExpire { get; set; }
}