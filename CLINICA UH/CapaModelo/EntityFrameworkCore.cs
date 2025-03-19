using Microsoft.EntityFrameworkCore;

namespace CLINICA_UH.CapaModelo
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

        public DbSet<ClsUsuario> Usuarios { get; set; }
    }
}
