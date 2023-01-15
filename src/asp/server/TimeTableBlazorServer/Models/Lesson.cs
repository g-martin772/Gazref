using System.ComponentModel.DataAnnotations;

namespace TimeTableBlazorServer.Models;

public class Lesson
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!; 

    public string? Description { get; set; } = null!;

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = null!;

    public ICollection<Student> Students { get; set; } = null!;

    public Class? Class { get; set; } = null!;

    // Room
}
