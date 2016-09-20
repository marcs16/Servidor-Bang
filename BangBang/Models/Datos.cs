using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class Datos
    {
        public int idUsuario { get; set; }
        public int idPartida { get; set; }
        public bool turno { get; set; }     
        public string token { get; set; }
    }
}