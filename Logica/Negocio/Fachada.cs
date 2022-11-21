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

        public List<VOCancion> ListarCanciones(string Nombre, int Anio, string GeneroMusical) 
        {
            return daoCancion.Listar(Nombre, Anio, GeneroMusical);
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

        public void InsertarUsuario(VOUsuario vou)
        {
            daoUsuario.Insertar(vou);
        }

        public List<VOCancion> ListarCancionesAlbum(int idAlbum)
        {
            return daoAlbum.ListarCanciones(idAlbum);
        }

        public List<VOIntegrante> ListarIntegrantesBanda(int idBanda)
        {
            return daoBanda.ListarIntegrantes(idBanda);
        }

        public List<VOBanda> ListarBandasPorNombre(string nombre)
        {
            return daoBanda.ListarPorNombre(nombre);
        }
        public List<VOBanda> ListarBandasPorGenero(string genero)
        {
            return daoBanda.ListarPorGenero(genero);
        }
        public List<VOAlbum> ListarAlbumsPorNombre(string nombre)
        {
            return daoAlbum.ListarPorNombre(nombre);
        }
        public List<VOAlbum> ListarAlbumsPorGenero(string genero)
        {
            return daoAlbum.ListarPorGenero(genero);
        }
        public List<VOAlbum> ListarAlbumsPoranio(int anio)
        {
            return daoAlbum.ListarPorAnio(anio);
        }

        public List<VOIntegrante> ListarIntegrantePorNombre(string nombre)
        {
            return daoIntegrante.ListarPorNombre(nombre);
        }
        public List<VOIntegrante> ListarIntegrantePorApellido(string apellido)
        {
            return daoIntegrante.ListarPorApellido(apellido);
        }


    }
}
