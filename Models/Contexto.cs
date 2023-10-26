using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProjetoEventos.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        
        }
    }
}
