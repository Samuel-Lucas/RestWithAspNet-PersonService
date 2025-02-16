using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiPersonService.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace ApiPersonService.Services.Implementations;

public class TokenService : ITokenService
{
    private TokenConfiguration _configuration;

    public TokenService(TokenConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var options = new JwtSecurityToken(
            issuer: _configuration.Issuer,
            audience: _configuration.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_configuration.Minutes),
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(options);
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}