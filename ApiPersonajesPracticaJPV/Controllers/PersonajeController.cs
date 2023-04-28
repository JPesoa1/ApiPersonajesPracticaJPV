using ApiPersonajesPracticaJPV.Models;
using ApiPersonajesPracticaJPV.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesPracticaJPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private RespositoryPersonaje repo;

        public PersonajeController(RespositoryPersonaje repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personajes>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{idpersonaje}")]
        public async Task<ActionResult<Personajes>> FindPersonaje(int idpersonaje)
        {
            return await this.repo.FindPersonajeAsync(idpersonaje);
        }

        [HttpPost]
        public async Task<ActionResult> PostPersonaje(Personajes personajes)
        {
            await this.repo.InsertPersonajeAsync(personajes.Nombre, personajes.Imagen, personajes.IdSerie);
            return Ok();
        }


        [HttpDelete("{idpersonaje}")]
        public async Task<ActionResult> DeletePersonaje(int idpersonaje)
        {
            await this.repo.DeletePersonajeAsync(idpersonaje);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personajes personajes)
        {
            await this.repo.UpdatePersonajeAsync(personajes.IdPersoanje, personajes.Nombre, personajes.Imagen, personajes.IdSerie);
            return Ok();
        }


    }
}
