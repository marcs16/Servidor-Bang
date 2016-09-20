using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace BangBang.Models
{

    public class Estado
    {        
        private static Dictionary<int, Jugador[]> partidas=new Dictionary<int, Jugador[]>();
        private static int nroPartidas = 0;
        public Datos InicioPartidaRegistro()
        {           
            Jugador jugador = new Jugador();
            if (nroPartidas != 0)
            {
                if (partidas[nroPartidas][1] == null)
                {
                    jugador.id = 2;
                    jugador.turno = true;
                    jugador.partida = nroPartidas;
                    jugador.estado = true;                                     
                    partidas[nroPartidas][1] = jugador;
                    Datos datos = new Datos();
                    {
                        datos.idUsuario = 2;
                        datos.idPartida = nroPartidas;
                        datos.turno = true;                        
                    }
                    return datos;     
                    //retorno
                }
            }
            nroPartidas++;
            Jugador[] jugadores = { null, null };
            jugador.id = 1;
            jugador.turno = false;
            jugador.partida = nroPartidas;
            jugador.estado = true;                     
            jugadores[0] = jugador;
            partidas.Add(nroPartidas, jugadores);                        
            Datos datos2 = new Datos();
            {
                datos2.idUsuario = 1;
                datos2.idPartida = nroPartidas;
                datos2.turno = false;                
            }
            return datos2;           
            //retorno
        }

        public bool InicioPartida(Datos datos)
        {
            if (partidas[datos.idPartida][1] == null)
            {
                return false;
            }
            return true;
        }//retorna true si ya hay cupo completo en la partida y false aun falta un jugador

        public void Lanzamiento(DatosLanzamiento datos)
        {
            Jugador j_Mira = new Jugador();
            if (partidas[datos.idPartida][0].id == datos.idUsr)
            {
                j_Mira = partidas[datos.idPartida][1];
                partidas[datos.idPartida][0].turno = false;
                partidas[datos.idPartida][0].angulo_atacante = 0;
                partidas[datos.idPartida][0].velocidad_atacante = 0; 
            }
            else
            {
                j_Mira = partidas[datos.idPartida][0];
                partidas[datos.idPartida][1].turno = false;
                partidas[datos.idPartida][1].angulo_atacante = 0;
                partidas[datos.idPartida][1].velocidad_atacante = 0;
            }
            j_Mira.velocidad_atacante = datos.velocidad;
            j_Mira.angulo_atacante = datos.angulo;        
            if (datos.blanco)
            {
                j_Mira.estado = false;                
                //return true;
            }
            j_Mira.turno = true;
            //return false;
            //retorna true si dio en el blanco, false si no
        }

        public Jugador Turno(Datos datos)
        {
            Jugador j_Atacante = new Jugador();
            Jugador yo = new Jugador();
            if (partidas[datos.idPartida][0].id == datos.idUsuario)
            {
                j_Atacante = partidas[datos.idPartida][1];
                yo = partidas[datos.idPartida][0];
            }
            else
            {
                j_Atacante = partidas[datos.idPartida][0];
                yo = partidas[datos.idPartida][1];
            }
            return yo;
            //retornar todo el jugador que realiza la consulta para evaluar el turno, el estado y simular el lanzamiento en la pantalla de quien espera turno              
                    
        }
    }
}