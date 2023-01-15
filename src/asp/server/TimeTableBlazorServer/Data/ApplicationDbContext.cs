using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTableBlazorServer.Models;

namespace TimeTableBlazorServer.Data;

public class ApplicationDbContext : IdentityDbContext<GazrefUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<OrganisationMember> Members { get; set; }

	public DbSet<Teacher> Teachers { get; set; }

	public DbSet<Student> Students { get; set; }

	public DbSet<Class> Classes { get; set; }

	public DbSet<Lesson> Lessons { get; set; }

	public DbSet<TimeTable> TimeTables { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<OrganisationMember>().UseTpcMappingStrategy();
	}
}
