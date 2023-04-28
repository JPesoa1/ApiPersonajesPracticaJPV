using ApiPersonajesPracticaJPV.Data;
using ApiPersonajesPracticaJPV.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPracticaJPV.Repositories
{
    public class RespositoryPersonaje
    {
        private PersonajeContext context;

        public RespositoryPersonaje(PersonajeContext context)
        {
            this.context = context;
        }


        private int GetMaxId()
        {
            return this.context.Personajes.Max(x => x.IdPersoanje) + 1;
        }
        public async Task<List<Personajes>> GetPersonajesAsync()
            => await this.context.Personajes.ToListAsync();

        public async Task<Personajes> FindPersonajeAsync(int id)
            => await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersoanje == id);

        public async Task InsertPersonajeAsync
            (string nombre,string imagen,int idserie)
        {
            Personajes personajes = new Personajes();
            personajes.IdPersoanje = this.GetMaxId();
            personajes.Nombre = nombre;
            personajes.Imagen = imagen;
            personajes.IdSerie = idserie;

            await this.context.Personajes.AddAsync(personajes);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync
            (int idpersonaje,string nombre, string imagen, int idserie)
            
        {
            Personajes personajes =await this.FindPersonajeAsync(idpersonaje);

            personajes.Nombre = nombre;
            personajes.Imagen = imagen;
            personajes.IdSerie = idserie;

            
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            Personajes personajes = await this.FindPersonajeAsync(idpersonaje);
            this.context.Personajes.Remove(personajes);
            await this.context.SaveChangesAsync();
        }


    }
}
