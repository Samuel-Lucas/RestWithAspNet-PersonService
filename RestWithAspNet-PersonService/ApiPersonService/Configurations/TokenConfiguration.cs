namespace ApiPersonService.Configurations;

public class TokenConfiguration
{
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int Minutes { get; set; }
    public int DaysToExpire { get; set; }
}