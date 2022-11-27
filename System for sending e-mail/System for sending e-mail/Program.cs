using Microsoft.EntityFrameworkCore;
using System_for_sending_e_mail.Database;
using System_for_sending_e_mail.EmailService;

namespace System_for_sending_e_mail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddDbContext<DataContext>(o =>
                {
                    o.UseSqlServer("Server=DESKTOP-K3NUSRU;Database=EmailService;Trusted_Connection=True;TrustServerCertificate=True;");
                },ServiceLifetime.Scoped)
                .AddMvc();

            builder.Services.AddControllers();
            var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, EmailSender>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=notification}/{action=list}");

            app.Run();
        }
    }
}