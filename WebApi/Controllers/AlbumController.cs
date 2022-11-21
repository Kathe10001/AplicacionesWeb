using Logica.Negocio;
using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AlbumController : ApiController
    {
        public IEnumerable<VOAlbum> GetAllAlbum()
        {
            return Fachada.Instancia.ListadoAlbum();
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var cancion = Fachada.Instancia.BuscarAlbum(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }
    }
}
