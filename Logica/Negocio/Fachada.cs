using Logica.VOs;
using Persistencia.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Negocio
{
    public class Fachada
    {
        private DAOAlbum daoAlbum;
        private DAOBanda daoBanda;
        private DAOCancion daoCancion;
        private DAOIntegrante daoIntegrante;
        private DAOUsuario daoUsuario;
        private DAOCalificacion daoCalificacion;

        private static readonly Fachada instancia = new Fachada();

        private Fachada()
        {
            daoAlbum = new DAOAlbum();
            daoBanda = new DAOBanda();
            daoCancion = new DAOCancion();
            daoIntegrante = new DAOIntegrante();
            daoUsuario = new DAOUsuario();
            daoCalificacion = new DAOCalificacion();
        }

        public static Fachada Instancia
        {
            get { return instancia; }
        }
        public List<VOAlbum> ListadoAlbum()
        {
            return daoAlbum.Listar();
        }

        public List<VOAlbum> ListarAlbum(string nombre, int anioCreacion, string generoMusical)
        {
            return daoAlbum.Listar(nombre, anioCreacion, generoMusical);
        }

        public void AltaAlbum(VOAlbum album)
        {
            daoAlbum.Insertar(album);
        }

        public void BajaAlbum(int idAlbum)
        {
            VOAlbum voa = daoAlbum.Buscar(idAlbum);
            if (voa != null)
            {
                daoAlbum.Borrar(idAlbum);
            }
            else
            {
                throw new ApplicationException("El album no existe");
            }
        }

        public void AgregarCancionAlbum(VOCancion cancion, VOAlbum album)
        {
            daoAlbum.AgregarCancion(album.Id, cancion.Id);
        }

        public void QuitarCancionAlbum(int idCancion, VOAlbum album)
        {
            daoAlbum.QuitarCancion(album.Id, idCancion);
        }

        public List<VOBanda> ListarBandas()
        {
            return daoBanda.Listar();
        }

        public List<VOBanda> ListarBandas(string nombre, string generoMusical)
        {
            return daoBanda.Listar(nombre, generoMusical);
        }

        public void AltaBanda(VOBanda banda)
        {
            daoBanda.Insertar(banda);
        }

        public void BajaBanda(int idBanda)
        {
            VOBanda vob = daoBanda.Buscar(idBanda);
            if (vob != null)
            {
                daoBanda.Borrar(idBanda);
            }
            else
            {
                throw new ApplicationException("La banda no existe");
            }
        }

        public void AgregarIntegranteBanda(VOIntegrante integrante, VOBanda banda)
        {
            daoBanda.AgregarIntegrante(banda.Id, integrante.Id);
        }

        public void QuitarIntegranteBanda(int idIntegrante, VOBanda banda)
        {
            daoBanda.QuitarIntegrante(idIntegrante, banda.Id);
        }

        public List<VOCancion> ListarCanciones()
        {
            return daoCancion.Listar();
        }

        public List<VOCancion> ListarCanciones(string nombre, int anio, string generoMusical)
        {
            return daoCancion.Listar(nombre, anio, generoMusical);
        }

        public void AltaCancion(VOCancion cancion)
        {
            daoCancion.Insertar(cancion);
        }

        public void BajaCancion(int idCancion)
        {

            VOCancion voc = daoCancion.Buscar(idCancion);
            if (voc != null)
            {
                daoCancion.Borrar(idCancion);
            }
            else
            {
                throw new ApplicationException("La cancion no existe");
            }

        }

        public List<VOIntegrante> ListarIntegrante()
        {
            return daoIntegrante.Listar();
        }

        public List<VOIntegrante> ListarIntegrante(string nombre, string apellido)
        {
            return daoIntegrante.Listar(nombre, apellido);
        }

        public void AltaIntegrante(VOIntegrante integrante)
        {
            daoIntegrante.Insertar(integrante);
        }

        public void BajaIntegrante(int idIntegrante)
        {
            VOIntegrante voi = daoIntegrante.Buscar(idIntegrante);
            if (voi != null)
            {
                daoIntegrante.Borrar(idIntegrante);
            }
            else
            {
                throw new ApplicationException("El integrante no existe");
            }
        }
        public void AltaCalificacion(VOCalificacion voc)
        {
            daoCalificacion.Alta(voc);
        }

        public void ModificarCalificacion(VOCalificacion voc)
        {
            daoCalificacion.Modificar(voc);
        }

        public VOCalificacion BuscarCalificacion(int idUsuario, int id, TipoCalificacion tipo)
        {
            return daoCalificacion.Buscar(idUsuario, id, (VOs.TipoCalificacion)tipo);
        }

        public VOCancion BuscarCancion(int idCancion)
        {
            return daoCancion.Buscar(idCancion);
        }

        public VOAlbum BuscarAlbum(int idAlbum)
        {
            return daoAlbum.Buscar(idAlbum);
        }

        public VOBanda BuscarBanda(int idBanda)
        {
            return daoBanda.Buscar(idBanda);
        }
        public VOIntegrante BuscarIntegrante(int idIntegrante)
        {
            return daoIntegrante.Buscar(idIntegrante);
        }

        public VOUsuario BuscarUsuario(String email)
        {
            return daoUsuario.Buscar(email);
        }

        public int InsertarUsuario(VOUsuario vou)
        {
            return daoUsuario.Insertar(vou);
        }

        public List<VOCancion> ListarCancionesAlbum(int idAlbum)
        {
            return daoAlbum.ListarCanciones(idAlbum);
        }

        public List<VOIntegrante> ListarIntegrantesBanda(int idBanda)
        {
            return daoBanda.ListarIntegrantes(idBanda);
        }

    }
}