using System.ComponentModel.DataAnnotations.Schema;
using ApiPersonService.Model.Base;

namespace ApiPersonService.Model;

[Table("person")]
public class Person : BaseEntity
{
    [Column("first_name")]
    public string FirstName { get; set; } = null!;
    [Column("last_name")]
    public string LastName { get; set; } = null!;
    [Column("address")]
    public string Address { get; set; } = null!;
    [Column("gender")]
    public string Gender { get; set; } = null!;
    [Column("enabled")]
    public bool Enabled { get; set; }
}