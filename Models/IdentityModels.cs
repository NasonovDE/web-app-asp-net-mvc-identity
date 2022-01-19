using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace web_app_asp_net_mvc_identity.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class KinoAfishaContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Film> Films { get; set; }
        public DbSet<Kino> Kinos { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<FilmCover> FilmCovers { get; set; }
       
        public DbSet<Format> Formats { get; set; }
        public KinoAfishaContext() : base("KinoAfishaEntity")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasOptional(x => x.FilmCover).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
        public static KinoAfishaContext Create()
        {
            return new KinoAfishaContext();
        }

    }

}