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
            VOUsuario usuario = Fachada.Instancia.BuscarUsuario(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        public IHttpActionResult PostUsuario(VOUsuario usuario)
        {
            int id;
            try
            {
                id = Fachada.Instancia.InsertarUsuario(usuario);

            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Error de registro");
            }
            return Ok(id);
        }
    }
}
