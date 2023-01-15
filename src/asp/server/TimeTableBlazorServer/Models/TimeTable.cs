namespace TimeTableBlazorServer.Models;

public class TimeTable
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ICollection<Lesson> Lessons { get; set; } = null!;

    public bool Public { get; set; }

    public bool InternPublic { get; set; }
}
