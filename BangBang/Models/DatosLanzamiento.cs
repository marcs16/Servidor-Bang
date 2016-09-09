using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class DatosLanzamiento
    {
        public int idUsr { get; set; }
        public int idPartida { get; set; }
        public float angulo { get; set; }
        public float velocidad { get; set; }
        public bool blanco { get; set; }
    }
}