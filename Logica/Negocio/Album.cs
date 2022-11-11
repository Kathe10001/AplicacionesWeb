using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Negocio
{
    class Album
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public int IdBanda { get; set; }
        public String GeneroMusical { get; set; }
        public List<Cancion> Canciones { get; set; }
    }
}
