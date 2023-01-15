using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTableBlazorServer.Models;

public abstract class OrganisationMember
{
    [Key]
    public int MemberId { get; set; }

    [Required]
    public DateTime Joined { get; set; } = DateTime.Now;

    [Required]
    public GazrefUser User { get; set; } = null!;

    [Required]
    public ICollection<TimeTable> TimeTables { get; set; } = null!;

    // Department
}
