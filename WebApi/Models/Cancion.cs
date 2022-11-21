using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public string GeneroMusical { get; set; }
    }
}