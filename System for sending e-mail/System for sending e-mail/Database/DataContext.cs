using Microsoft.EntityFrameworkCore;
using System_for_sending_e_mail.Emails.Models;

namespace System_for_sending_e_mail.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Email> Email { get; set; }
        public DbSet<Notification> Notifications { get; set; }


    }
}
