using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonService.Model.Base;

public class BaseEntity
{
    [Column("id")]
    public long Id { get; set; }
}