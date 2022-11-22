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
    public class CalificacionController : ApiController
    {
        public IHttpActionResult GetCalificacion([FromUri] Calificacion filtros)
        {

            int idUsuario = filtros.IdUsuario;
            int id = filtros.Id;
            Logica.Negocio.TipoCalificacion tipoCalificacion = filtros.Tipo;
            var calificacion = Fachada.Instancia.BuscarCalificacion(idUsuario, id, tipoCalificacion);
            if (calificacion == null)
            {
                return NotFound();
            }
            return Ok(calificacion);

        }

        public IHttpActionResult PostCalificacio(VOCalificacion calificacion)
        {
            try
            {
                Fachada.Instancia.AltaCalificacion(calificacion);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Error de registro");
            }
            return Ok("Se guardó correctamente");
        }

        public IHttpActionResult PutCalificacio(VOCalificacion calificacion)
        {
            try
            {
                Fachada.Instancia.ModificarCalificacion(calificacion);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Error de registro");
            }
            return Ok("Se guardó correctamente");
        }
    }
}

    