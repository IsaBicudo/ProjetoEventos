using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProjetoEventos.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        
        }
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Convidado> Convidado { get; set; }

        public DbSet<Local> Local { get; set; }

        public DbSet<Horario> Horario { get; set; }

        public DbSet<Decoracao> Decoracao { get; set; }

        public DbSet<Buffet> Buffet { get; set; }

        public DbSet<TipoEvento> TipoEvento { get; set; }

        public DbSet<TotalPagar> TotalPagar { get; set; }

    }
}
