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
    [RoutePrefix("api/integrante")]
    public class IntegranteController : ApiController
    {

        public IEnumerable<VOIntegrante> GetAllIntegrante([FromUri] Integrante integrante)
        {
            string nombre = integrante.Nombre;
            string apellido = integrante.Apellido;
            return Fachada.Instancia.ListarIntegrante(nombre, apellido);
        }

        [Route("{id}/bandas")]
        public IHttpActionResult GetBandas(int id)
        {
            var integrante = "";//Fachada.Instancia.ListarBandaIntegrantes(id);
            if (integrante == null)
            {
                return NotFound();
            }
            return Ok(integrante);
        }

    }
}