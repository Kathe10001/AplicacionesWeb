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
    public class BandaController : ApiController
    {
        public IEnumerable<VOBanda> GetAllBanda()
        {
            return Fachada.Instancia.ListarBandas();
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
<<<<<<< HEAD
=======
        public IHttpActionResult PostBanda(VOBanda banda)
        {
            try
            {
                Fachada.Instancia.AltaBanda(banda);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException();
            }
            return Ok("Se guardó correctamente");
        }




>>>>>>> main
    }
}
