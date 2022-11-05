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

        public String GeneroMusica { get; set; }
        public List<int> Canciones { get; set; }


    }
}
