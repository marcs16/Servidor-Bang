using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class Jugador
    {
        public int id { get; set; }
        public bool turno { get; set; }        
        public int partida { get; set; }
        public bool estado { get; set; }
        public float velocidad_atacante { get; set; }
        public float angulo_atacante { get; set; }
    }
}