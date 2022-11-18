﻿using Logica.Negocio;
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

        public IHttpActionResult GetUsuario(int id)
        {
            var cancion = Fachada.Instancia.BuscarUsuario(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return Ok(cancion);
        }
        //public IHttpActionResult PostUsuario(VOUsuario usuario)
        //{
        //    try
        //    {
        //        Fachada.Instancia.(usuario);

        //    }
        //    catch (ApplicationException e)
        //    {
        //        throw new ApplicationException();
        //    }
        //    return Ok("Se guardó correctamente");
        //}
    }
}