using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.VOs
{
    public class VOAlbum
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public int IdBanda { get; set; }
        public String GeneroMusical { get; set; }
        public List<VOCancion> Canciones { get; set; }

        public VOAlbum() { }

        public VOAlbum(String nombre, int anioCreacion, String generoMusical, int idBanda)
        {
            Nombre = nombre;
            AnioCreacion = anioCreacion;
            IdBanda = idBanda;
            GeneroMusical = generoMusical;
        }
    }
}
