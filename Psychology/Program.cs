using Dto.account;
using Ioc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Psychology.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

ApiBootstrapper.ApiConfig(builder.Services);

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSetting>(appSettingsSection);
// IOC Configuration
#region IOC Configuration

// User & Role
builder.Services.AccountConfig(builder.Configuration.GetConnectionString("PsychologyConnection"),
    builder.Configuration["AppSettings:Secret"]);
// Comment & Patient & PatientExam & PatientFile & PatientResponses & PatientTurn
builder.Services.PatientConfig(builder.Configuration.GetConnectionString("PsychologyConnection"));
// Order & Discount
builder.Services.DOConfig(builder.Configuration.GetConnectionString("PsychologyConnection"));
/*
 * Psychologist &
 * PsychologistWorkingDateAndTime &
 * PsychologistWorkingDays &
 * PsychologistWorkingHours &
 * TypeOfConsultation 
 */
builder.Services.PsychologistConfig(builder.Configuration.GetConnectionString("PsychologyConnection"));
// Test & Question & Answer
builder.Services.TestConfig(builder.Configuration.GetConnectionString("PsychologyConnection"));

#endregion

builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(option =>
    {
        option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(option =>
    {
        option.LoginPath = new PathString("/Accounts/Login");
        option.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Psychology API V1");
        // c.SwaggerEndpoint("/swagger/v2/swagger.json", "Your API V2"); // «÷«›Â ò—œ‰ Ê—é‰ 2 »Â Swagger UI
    });
}

app.UseRequestRateLimit(50, TimeSpan.FromMinutes(1));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseCors("Psychology");
app.Run();
