namespace ApiPersonService.Data.VO;

public class PersonVO
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Gender { get; set; } = null!;
}