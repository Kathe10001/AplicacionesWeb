using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Negocio
{
    class Fachada //hacer despues
    {


        public List<VOAlbum> ListadoAlbum() { throw new NotImplementedException(); }

        public void AltaAlbum(VOAlbum album) { }

        public void BajaAlbum(int idAlbum) { }

        public void AgregarCancionAlbum(VOCancion cancion, VOAlbum album) { }

        public void QuitarCancionAlbum(int idCancion, VOAlbum album) { }

        public List<VOBanda> ListarBandas(VOBanda banda) { throw new NotImplementedException(); }

        public void AltaBanda(VOBanda banda) { }

        public void BajaBanda(int idBanda) { }

        public void AgregarIntegranteBanda(VOIntegrante integrante, VOBanda banda) { }

        public void QuitarIntegranteBanda(int idIntegrante, VOBanda banda) { }

        public List<VOCancion> ListarCanciones() { throw new NotImplementedException(); }

        public void AltaCancion(VOCancion cancion) { }

        public void BajaCancion(int idCancion) { }

        public List<VOIntegrante> ListarIntegrante() { throw new NotImplementedException(); }

        public void AltaIntegrante(VOIntegrante integrante) { }

        public void BajaIntegrante(int idIntegrante) { }



    }
}
