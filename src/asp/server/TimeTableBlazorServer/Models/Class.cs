using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTableBlazorServer.Models;

public class Class
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string ShortName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [ForeignKey("MemberId")]
    public Teacher? Teacher { get; set; } = null!;

    public ICollection<Student>? Students { get; set; } = null!;
}
