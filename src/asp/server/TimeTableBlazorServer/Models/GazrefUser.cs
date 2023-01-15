using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTableBlazorServer.Models;

public class GazrefUser : IdentityUser
{
    [ForeignKey("MemberId")]
    public OrganisationMember? Account { get; set; }
}
