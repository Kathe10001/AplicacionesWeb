using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica.VOs;
using Logica.Negocio;

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
        public List<VOAlbum> ListadoAlbum()
        {
            return Fachada.Instancia.ListadoAlbum();
        }

        [WebMethod]
        public void AltaAlbum(String nombre, int anioCreacion, String generoMusical, int idBanda ) 
        {
            
            VOAlbum voa = new VOAlbum(nombre, anioCreacion, generoMusical, idBanda);
            Fachada.Instancia.AltaAlbum(voa);

        }

        [WebMethod]
        public void BajaAlbum(int idAlbum) 
        {
            
            Fachada.Instancia.BajaAlbum(idAlbum);
        }

        [WebMethod]
        public void AgregarCancionAlbum(int idCancion, int idAlbum) 
        {
            
            VOCancion voc = new VOCancion();
            VOAlbum voa = new VOAlbum();
            voc.Id = idCancion;
            voa.Id = idAlbum;
            Fachada.Instancia.AgregarCancionAlbum(voc,voa);
        }

        [WebMethod]
        public void QuitarCancionAlbum(int idCancion, int idAlbum) 
        {
            
            VOAlbum voa = new VOAlbum();
            voa.Id = idAlbum;
            Fachada.Instancia.QuitarCancionAlbum(idCancion, voa);
        }

        [WebMethod]
        public List<VOBanda> ListarBandas(VOBanda banda) 
        {
            
            return Fachada.Instancia.ListarBandas();
        }

        [WebMethod]
        public void AltaBanda(String nombre, String generoMusical, int anioC, int anioS) 
        {
            
            VOBanda vob = new VOBanda(nombre, generoMusical, anioC, anioS);
            Fachada.Instancia.AltaBanda(vob);
        }

        [WebMethod]
        public void BajaBanda(int idBanda) 
        {
            
            Fachada.Instancia.BajaBanda(idBanda);
        }

        [WebMethod]
        public void AgregarIntegranteBanda(int idIntegrante, int idBanda) 
        {
            
            VOIntegrante voi = new VOIntegrante();
            VOBanda vob = new VOBanda();
            voi.Id = idIntegrante;
            vob.Id = idBanda;
            Fachada.Instancia.AgregarIntegranteBanda(voi, vob);

        }

        [WebMethod]
        public void QuitarIntegranteBanda(int idIntegrante, int  idBanda) 
        {
            
            VOBanda vob = new VOBanda();
            vob.Id = idBanda;
            Fachada.Instancia.QuitarIntegranteBanda(idIntegrante,vob);
        }

        [WebMethod]
        public List<VOCancion> ListarCanciones() 
        {
            
            return Fachada.Instancia.ListarCanciones();
        }

        [WebMethod]
        //public void AltaCancion(VOCancion cancion) 
        public void AltaCancion(String nombre, int duracion, String genero, int cantante, int anio)
        {
            
            VOCancion voc = new VOCancion(nombre,duracion,genero,cantante,anio);
            Fachada.Instancia.AltaCancion(voc);
        }

        [WebMethod]
        public void BajaCancion(int idCancion) 
        {
            
            Fachada.Instancia.BajaCancion(idCancion);
        }

        [WebMethod]
        public List<VOIntegrante> ListarIntegrante() 
        {
            
            return Fachada.Instancia.ListarIntegrante();
        }

        [WebMethod]
        public void AltaIntegrante(String nombre, String apellido, DateTime fechaNacimiento) 
        {
            
            VOIntegrante voi = new VOIntegrante(nombre, apellido, fechaNacimiento);
            Fachada.Instancia.AltaIntegrante(voi);
        }

        [WebMethod]
        public void BajaIntegrante(int idIntegrante) 
        {
            Fachada.Instancia.BajaIntegrante(idIntegrante);
        }
    }
}
