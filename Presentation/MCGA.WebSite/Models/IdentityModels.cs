using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MCGA.WebSite.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
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

        public System.Data.Entity.DbSet<MCGA.Entities.TipoSexo> TipoSexoes { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.TipoDia> TipoDias { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.Afiliado> Afiliadoes { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.TipoDocumento> TipoDocumentoes { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.Profesional> Profesionals { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.Especialidad> Especialidads { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.Agenda> Agenda { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.TipoReseva> TipoResevas { get; set; }

        public System.Data.Entity.DbSet<MCGA.Entities.Turno> Turnoes { get; set; }
    }
}