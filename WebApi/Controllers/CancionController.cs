using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica.Negocio;

namespace WebApi.Controllers
{
    public class CancionController : ApiController
    {
        public IEnumerable<VOCancion> GetAllCancion() {
            return Fachada.Instancia.ListarCanciones();}

        public IHttpActionResult GetCancion(int id)
        {
            var cancion = Fachada.Instancia.BuscarCancion(id);
            if (cancion == null)
            {
                  return NotFound();
            }
             return Ok(cancion);
        }

    }
}
