using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Album
    {
        public string Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public string GeneroMusical { get; set; }
    }
}