using Microsoft.EntityFrameworkCore;
using PC.Utility;
using PC.Utility.Auth;
using PD.Entity.DiscountAndOrder;
using PD.Entity.Patient;
using PD.Entity.Psychologist;
using PD.Entity.Role;
using PD.Entity.Test;
using PD.Entity.User;

namespace PC.Context;

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
    public DbSet<Gender> Genders { get; set; }
    public DbSet<PsychologistTypeOfConsultation> PsychologistTypeOfConsultations { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<PsychologistAboutUs> PsychologistAboutUs { get; set; }

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
            new Role() { Id = SD.RoleName.Admin_Id, Name = SD.RoleName.Admin, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = SD.RoleName.Customer_Id, Name = SD.RoleName.Customer, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = SD.RoleName.Patient_Id, Name = SD.RoleName.Patient, IsActive = true, CreatedAt = DateTime.Now },
            new Role() { Id = SD.RoleName.Psychologist_Id, Name = SD.RoleName.Psychologist, IsActive = true, CreatedAt = DateTime.Now },
        });

        modelBuilder.Entity<Gender>().HasData(new List<Gender>
        {
            new Gender() { Id =SD.GenderName.Man_Id, Name = SD.GenderName.Man, IsActive = true, CreatedAt = DateTime.Now },
            new Gender() { Id = SD.GenderName.Lady_Id, Name = SD.GenderName.Lady, IsActive = true, CreatedAt = DateTime.Now },
            new Gender() { Id = SD.GenderName.Oder_Id, Name = SD.GenderName.Oder, IsActive = true, CreatedAt = DateTime.Now },
        });

        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            FName = "مدیر",
            LName = "سیستم",
            Phone = SD.UserName.Admin,
            Password = passwordHasher.HashPassword("Admin@10132023"),
            MobailActiveStatus = true,
            ActivationCode = Guid.NewGuid().ToString(),
            IsActive = true,
            RoleID = 1,
            CreatedAt = DateTime.Now,
            GenderId = SD.GenderName.Lady_Id,
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

        List<string> daysInPersian = new List<string>
        {
            "شنبه",
            "یک‌شنبه",
            "دو‌شنبه",
            "سه‌شنبه",
            "چهارشنبه",
            "پنج‌شنبه",
            "جمعه"
        };
        List<string> daysInEnglish = new List<string>
        {
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };
        List<PsychologistWorkingDays> psychologistWorkingDays = new List<PsychologistWorkingDays>();
        int numberDay = 1;
        for (int i = 0; i < daysInEnglish.Count; i++)
        {
            psychologistWorkingDays.Add(new PsychologistWorkingDays()
            {
                CreatedAt = DateTime.Now,
                Day = daysInPersian[i],
                DayEn = daysInEnglish[i],
                Id = numberDay,
                IsActive = true
            });
            numberDay++;
        }
        modelBuilder.Entity(typeof(PsychologistWorkingDays)).HasData(psychologistWorkingDays);
    }
}
