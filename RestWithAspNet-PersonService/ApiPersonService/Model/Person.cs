using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonService.Model;

[Table("person")]
public class Person
{
    [Column("id")]
    public long Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; } = null!;
    [Column("last_name")]
    public string LastName { get; set; } = null!;
    [Column("address")]
    public string Address { get; set; } = null!;
    [Column("gender")]
    public string Gender { get; set; } = null!;
}