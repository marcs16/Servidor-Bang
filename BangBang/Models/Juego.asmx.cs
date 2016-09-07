using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace BangBang.Models
{
    /// <summary>
    /// Summary description for Juego
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Juego : System.Web.Services.WebService
    {        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]        
        public string IniciarPartida()
        {
            Estado estado = new Estado();
            Datos datos = estado.InicioPartidaRegistro();
            string a = new JavaScriptSerializer().Serialize(datos);
            return a;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InicioPartida(string json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            bool ans=estado.InicioPartida(datos);            
            string a = new JavaScriptSerializer().Serialize(ans);
            return a;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Lanzar(string json)
        {
            DatosLanzamiento datos = new JavaScriptSerializer().Deserialize<DatosLanzamiento>(json);
            Estado estado = new Estado();
            estado.Lanzamiento(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);
            //return a;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Estado(String json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            Jugador resultado = estado.Turno(datos);
            string a = new JavaScriptSerializer().Serialize(resultado);
            return a;
        }
    }
}
