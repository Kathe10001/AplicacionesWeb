using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Negocio
{
    class Banda
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public String GeneroMusica { get; set; }
        public List<Integrante> Integrantes { get; set; }
        public int AnioSeparacion { get; set; }
    }
}
