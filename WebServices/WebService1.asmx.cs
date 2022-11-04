using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace WebServices
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<VOAlbum> ListadoAlbum() { throw new NotImplementedException(); }

        [WebMethod]
        public void AltaAlbum(VOAlbum album) { }

        [WebMethod]
        public void BajaAlbum(int idAlbum) { }

        [WebMethod]
        public void AgregarCancionAlbum(VOCancion cancion, VOAlbum album) { }

        [WebMethod]
        public void QuitarCancionAlbum(int idCancion, VOAlbum album) { }

        [WebMethod]
        public List<VOBanda> ListarBandas(VOBanda banda) { throw new NotImplementedException(); }

        [WebMethod]
        public void AltaBanda(VOBanda banda) { }

        [WebMethod]
        public void BajaBanda(int idBanda) { }

        [WebMethod]
        public void AgregarIntegranteBanda(VOIntegrante integrante, VOBanda banda) { }

        [WebMethod]
        public void QuitarIntegranteBanda(int idIntegrante, VOBanda banda) { }

        [WebMethod]
        public List<VOCancion> ListarCanciones() { throw new NotImplementedException(); }

        [WebMethod]
        public void AltaCancion(VOCancion cancion) { }

        [WebMethod]
        public void BajaCancion(int idCancion) { }

        [WebMethod]
        public List<VOIntegrante> ListarIntegrante() { throw new NotImplementedException(); }

        [WebMethod]
        public void AltaIntegrante(VOIntegrante integrante) { }

        [WebMethod]
        public void BajaIntegrante(int idIntegrante) { }
    }
}
