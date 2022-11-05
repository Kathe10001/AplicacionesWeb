using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.VOs
{
    public class VOCalificar
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int Puntaje { get; set; }
        public String Comentario { get; set; }

        //falta agregar tipo Calificacion (enumerado)

    }
}
