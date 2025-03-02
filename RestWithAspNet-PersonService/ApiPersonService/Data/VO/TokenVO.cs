namespace ApiPersonService.Data.VO;

public class TokenVO
{
    public TokenVO(bool authenticated, string created, string expiration, string accessToken, string refreshToken)
    {
        Authenticated = authenticated;
        Created = created;
        Expiration = expiration;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public bool Authenticated { get; set; }
    public string Created { get; set; } = null!;
    public string Expiration { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}