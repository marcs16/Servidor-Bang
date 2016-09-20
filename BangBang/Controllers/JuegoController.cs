using BangBang.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BangBang.Controllers
{
    public class JuegoController : Controller
    {
        private string access_token = "1075448155884619|36f92fca67678fb00d2f516af2dbd942";
        // GET: Juego
        public JsonResult IniciarPartida(string token)
        {
            var client = new WebClient();
            string tokenJson = client.DownloadString("https://graph.facebook.com/debug_token?input_token=" + token + "&access_token=" + access_token);
            JObject jObject = JObject.Parse(tokenJson);            
            bool valid = (bool)jObject["data"]["is_valid"];
            Datos datos = new Datos();
            if (!valid)
            {
                return Json(datos, JsonRequestBehavior.AllowGet);
            }
            Estado estado = new Estado();
            datos =estado.InicioPartidaRegistro();
            datos.token = tokenJson;   
            //string a = new JavaScriptSerializer().Serialize(datos);
            return Json(datos, JsonRequestBehavior.AllowGet);
                
        }

        public JsonResult InicioPartida(string json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            var client = new WebClient();
            JObject jObject = JObject.Parse(client.DownloadString("https://graph.facebook.com/debug_token?input_token=" + datos.token + "&access_token=" + access_token));
            bool valid = (bool)jObject["data"]["is_valid"];            
            if (!valid)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            Estado estado = new Estado();            
            bool ans = estado.InicioPartida(datos);
            //string a = new JavaScriptSerializer().Serialize(ans);
            return Json(ans, JsonRequestBehavior.AllowGet);
        }

        public void Lanzar(string json)
        {
            DatosLanzamiento datos = new JavaScriptSerializer().Deserialize<DatosLanzamiento>(json);
            var client = new WebClient();
            JObject jObject = JObject.Parse(client.DownloadString("https://graph.facebook.com/debug_token?input_token=" + datos.token + "&access_token=" + access_token));
            bool valid = (bool)jObject["data"]["is_valid"];
            if (!valid)
            {
                return;
            }           
            Estado estado = new Estado();
            estado.Lanzamiento(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);            
        }

        public JsonResult Estado(string json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Jugador resultado = new Jugador();
            var client = new WebClient();
            JObject jObject = JObject.Parse(client.DownloadString("https://graph.facebook.com/debug_token?input_token=" + datos.token + "&access_token=" + access_token));
            bool valid = (bool)jObject["data"]["is_valid"];
            if (!valid)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            Estado estado = new Estado();
            resultado = estado.Turno(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}