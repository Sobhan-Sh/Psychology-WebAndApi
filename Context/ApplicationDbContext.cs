using Entity.DiscountAndOrder;
using Entity.Patient;
using Entity.Psychologist;
using Entity.Role;
using Entity.Test;
using Entity.User;
using Framework.Auth;
using Microsoft.EntityFrameworkCore;
using static Utility.SD;

namespace Context;

public class ApplicationDbContext : DbContext
{
    private PasswordHasher passwordHasher { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientExam> PatientExams { get; set; }
    public DbSet<PatientResponses> PatientResponsesExamies { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Psychologist> Psychologists { get; set; }
    public DbSet<PsychologistWorkingDays> PsychologistWorkingDays { get; set; }
    public DbSet<PsychologistWorkingHours> PsychologistWorkingHours { get; set; }
    public DbSet<TypeOfConsultation> TypeOfConsultation { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<PatientTurn> PatientTurn { get; set; }
    public DbSet<PatientFile> PatientFiles { get; set; }
    public DbSet<PsychologistWorkingDateAndTime> PsychologistWorkingDateAndTime { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
        {
            relation.DeleteBehavior = DeleteBehavior.Restrict;
        }

        passwordHasher = new();

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role() { Id = RoleName.Admin_Id, Name = RoleName.Admin, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = RoleName.Customer_Id, Name = RoleName.Customer, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = RoleName.Patient_Id, Name = RoleName.Patient, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = RoleName.Psychologist_Id, Name = RoleName.Psychologist, IsActive = true, CreatedAt = DateTime.Now },
        });

        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            FName = "مدیر",
            LName = "سیستم",
            Phone = UserName.Admin,
            Password = passwordHasher.HashPassword("Admin@10132023"),
            MobailActiveStatus = true,
            ActivationCode = Guid.NewGuid().ToString(),
            IsActive = true,
            RoleID = 1,
            CreatedAt = DateTime.Now
        });

        List<PsychologistWorkingHours> PsychologistWorkingHours = new List<PsychologistWorkingHours>();
        int h1 = 0, h2 = 1, num = 0;
        DateTime startDt, EndDt;
        for (int i = 0; i < 24; i++)
        {
            num++;
            startDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h1, 0, 0);
            EndDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h2, 0, 0);
            PsychologistWorkingHours.Add(new PsychologistWorkingHours() { Id = num, CreatedAt = startDt, EndTime = EndDt, IsActive = true, StartTime = DateTime.Now });
            h1++;
            if (h2 < 23) h2++;
            else h2 = 0;
        }
        modelBuilder.Entity(typeof(PsychologistWorkingHours)).HasData(PsychologistWorkingHours);
        modelBuilder.Entity(typeof(PsychologistWorkingDays)).HasData(new List<PsychologistWorkingDays>()
        {
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "شنبه",Id = 1,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "یکشنبه",Id = 2,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "دوشنبه",Id = 3,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "سه شنبه",Id = 4,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "چهار شنبه",Id = 5,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "پنج شنبه",Id = 6,IsActive = true},
            new PsychologistWorkingDays(){CreatedAt = DateTime.Now, Day = "جمعه",Id = 7,IsActive = true},
        });
    }
}
