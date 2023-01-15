namespace TimeTableBlazorServer.Models;

public class Teacher : OrganisationMember
{
    public string ShortName { get; set; } = null!;

    public Class? Class { get; set; }

    // Timetable
}
