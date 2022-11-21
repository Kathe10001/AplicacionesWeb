using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica.Negocio;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CancionController : ApiController
    {
        public IEnumerable<VOCancion> GetAllCancion([FromUri] Cancion cancion)
        {
            string nombre = cancion.Nombre;
            int anio = cancion.Anio;
            string generoMusical = cancion.GeneroMusical;
            return Fachada.Instancia.ListarCanciones(nombre, anio, generoMusical);
        }

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
