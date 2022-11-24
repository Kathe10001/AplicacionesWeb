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

    }
}