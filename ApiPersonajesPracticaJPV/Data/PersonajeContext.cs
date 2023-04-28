using ApiPersonajesPracticaJPV.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPracticaJPV.Data
{
    public class PersonajeContext : DbContext
    {
        public PersonajeContext(DbContextOptions<PersonajeContext> options) : base(options)
        {
        }
        public DbSet<Personajes> Personajes { get; set; }
    }
}
