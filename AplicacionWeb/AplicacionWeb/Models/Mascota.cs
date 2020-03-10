using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        //Para este ejercicio se agrega string a Edad en lugar de Int, debido a que se permitirá la entrada de texto, ejemplo : 2años
        public string Edad { set; get; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public bool Adoptada { get; set; }
    }
}