using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeTableBlazorServer.Areas.Identity;
using TimeTableBlazorServer.Data;
using TimeTableBlazorServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<GazrefUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<GazrefUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    SeedDatabase(scope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
}

app.Run();

void SeedDatabase(ApplicationDbContext context)
{
    if (context.TimeTables.Any())
    {
        Console.WriteLine("Database already seeded");
        return;
    }

    var myAccount = context.Users.FirstOrDefault();

    var myClass = new Class
    {
        Name = "2B Höhere IT",
        Description = "why",
        ShortName = "2BHIT",
    };

    context.Classes.Add(myClass);
    context.SaveChanges();

    var gabrielStudent = new Student
    {
        Class = myClass,
        User = myAccount
    };

    context.Students.Add(gabrielStudent);
    context.SaveChanges();

    var gabrielTeacher = new Teacher
    {
        Class = myClass,
        User = myAccount,
        ShortName = "GM",
    };

    context.Teachers.Add(gabrielTeacher);
    context.SaveChanges();

    myClass.Teacher = gabrielTeacher;
    myClass.Students = new List<Student>
    {
        gabrielStudent
    };

    context.SaveChanges();

    var Lesson1 = new Lesson
    {
        Name = "Software Entwicklung",
        ShortName = "SEW",
        Description = "Kaffeautomaten",
        Begin = DateTime.Parse("08/12/2018 07:10:00"),
        End = DateTime.Parse("08/12/2018 09:00:00"),
        Class = myClass,
        Teachers = new List<Teacher>
        {
            gabrielTeacher
        },
        Students = new List<Student>
        {
            gabrielStudent
        }
    };

    context.Lessons.Add(Lesson1);
    context.SaveChanges();

    var Lesson2 = new Lesson
    {
        Name = "Software Entwicklung",
        ShortName = "SEW",
        Description = "Kaffeautomaten",
        Begin = DateTime.Parse("08/12/2018 07:20:00"),
        End = DateTime.Parse("08/12/2018 08:10:00"),
        Class = myClass,
        Teachers = new List<Teacher>
        {
            gabrielTeacher
        },
        Students = new List<Student>
        {
            gabrielStudent
        }
    };

    context.Lessons.Add(Lesson2);
    context.SaveChanges();

    var table = new TimeTable
    {
        Name = "2BHIT TimeTable",
        Description = "Class Plan",
        InternPublic = true,
        Public = false,
        Lessons = new List<Lesson>
        {
            Lesson1,
            Lesson2
        }
    };


    context.TimeTables.Add(table);
    context.SaveChanges();
    
    gabrielStudent.TimeTables = new List<TimeTable> { table };
    gabrielTeacher.TimeTables = new List<TimeTable> { table };
    context.SaveChanges();
}
