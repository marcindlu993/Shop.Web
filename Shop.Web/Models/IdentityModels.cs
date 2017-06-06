using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<TypeResource> TypeResources { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<Shop.Web.Models.Resource> Resources { get; set; }
        public System.Data.Entity.DbSet<Shop.Web.Models.Author> Authors { get; set; }
        public System.Data.Entity.DbSet<Shop.Web.Models.TypeResource> TypeResources { get; set; }
        public System.Data.Entity.DbSet<Shop.Web.Models.PublishingHouse> PublishingHouses { get; set; }
    }
}