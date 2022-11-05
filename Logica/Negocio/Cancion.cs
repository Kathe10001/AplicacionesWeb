using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Negocio
{
    class Cancion
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Anio { get; set; }
        public String GeneroMusical { get; set; }
        public int Duracion { get; set; }
        public int IdCantante { get; set; }
    }
}
