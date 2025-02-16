namespace ApiPersonService.Data.VO;

public class TokenVO
{
    public TokenVO(bool authenticated, string created, string expiration, string accessCode, string refreshToken)
    {
        Authenticated = authenticated;
        Created = created;
        Expiration = expiration;
        AccessCode = accessCode;
        RefreshToken = refreshToken;
    }

    public bool Authenticated { get; set; }
    public string Created { get; set; } = null!;
    public string Expiration { get; set; } = null!;
    public string AccessCode { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}