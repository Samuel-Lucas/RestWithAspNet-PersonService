using System.ComponentModel.DataAnnotations.Schema;
using ApiPersonService.Model.Base;

namespace ApiPersonService.Model;

[Table("book")]
public class Book : BaseEntity
{
    [Column("title")]
    public string Title { get; set; } = null!;
    [Column("author")]
    public string Author { get; set; } = null!;
    [Column("price")]
    public decimal Price { get; set; }
    [Column("launch_date")]
    public DateTime LaunchDate { get; set; }
}