using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Models;
public class Lecturer
{
    public int LecturerID { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Workplace { get; set; }
    public string Address { get; set; }

    public ICollection<LecturerSubject> LecturerSubjects { get; set; }
}
public class Subject
{   
    public int SubjectID { get; set; }
    public string SubjectName { get; set; }

    public ICollection<LecturerSubject> LecturerSubjects { get; set; }
}

public class Position
{
    public int PositionID { get; set; }
    public string PositionName { get; set; }
    public decimal HourlyRate { get; set; }
}

public class LecturerSubject
{
    public int LecturerID { get; set; }
    public Lecturer Lecturer { get; set; }

    public int SubjectID { get; set; }
    public Subject Subject { get; set; }
}

public class ConnectionStrings
{
    public string MyDatabase { get; set; }
}

public class AppConfig
{
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class UniversityContext : DbContext
{
    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

    public DbSet<Lecturer> Lecturer { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<LecturerSubject> LecturerSubject { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lecturer>().ToTable("lecturer");
        modelBuilder.Entity<Subject>().ToTable("subject");
        modelBuilder.Entity<Position>().ToTable("position");
        modelBuilder.Entity<LecturerSubject>().ToTable("lecturersubject");

        modelBuilder.Entity<LecturerSubject>()
            .HasKey(ls => new { ls.LecturerID, ls.SubjectID });
    }
}



