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
    [RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {
        public IEnumerable<VOAlbum> GetAllAlbum()
        {
            return Fachada.Instancia.ListadoAlbum();
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = Fachada.Instancia.BuscarAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [Route("{id:int}/canciones")]
        public IHttpActionResult GetCanciones(int id)
        {
            var cancion = Fachada.Instancia.ListarCancionesAlbum(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }


    }
}
