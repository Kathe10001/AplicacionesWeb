using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.VOs
{
    public class VOBanda
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public String GeneroMusical { get; set; }
        public List<VOCancion> Integrantes { get; set; }
        public int AnioSeparacion { get; set; }

    }

}
