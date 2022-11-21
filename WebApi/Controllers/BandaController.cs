using Logica.Negocio;
using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/banda")]
    public class BandaController : ApiController
    {

        public IEnumerable<VOBanda> GetAllBanda([FromUri] Banda banda)
        {
            string nombre = banda.Nombre;
            string generoMusical = banda.GeneroMusical;
            return Fachada.Instancia.ListarBandas(nombre, generoMusical);
        }

        public IHttpActionResult GetBanda(int id)
        {
            var cancion = Fachada.Instancia.BuscarBanda(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }

        [Route("{id:int}/integrantes")]
        public IHttpActionResult GetIntegrantes(int id)
        {
            var integrante = Fachada.Instancia.ListarIntegrantesBanda(id);
            if (integrante == null)
            {
                return NotFound();
            }
            return Ok(integrante);
        }
    }
}