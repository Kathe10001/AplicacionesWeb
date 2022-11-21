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
    public class UsuarioController : ApiController
    {

        public IHttpActionResult GetUsuario(String email)
        {
            var cancion = Fachada.Instancia.BuscarUsuario(email);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }
        public IHttpActionResult PostUsuario(VOUsuario usuario)
        {
            try
            {
                Fachada.Instancia.InsertarUsuario(usuario);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Error de registro");
            }
            return Ok("Se guardó correctamente");
        }
    }
}
