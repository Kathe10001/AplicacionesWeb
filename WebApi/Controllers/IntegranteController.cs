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
    public class IntegranteController : ApiController
    {
        public IEnumerable<VOIntegrante> GetAllIntegrante()
        {
            return Fachada.Instancia.ListarIntegrante();
        }

        public IHttpActionResult GetIntegrante(int id)
        {
            var cancion = Fachada.Instancia.BuscarIntegrante(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }
        public IHttpActionResult PostIntegrante(VOIntegrante integrante)
        {
            try
            {
                Fachada.Instancia.AltaIntegrante(integrante);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException();
            }
            return Ok("Se guardó correctamente");
        }
    }
}
