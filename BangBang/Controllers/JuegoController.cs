using BangBang.Models;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BangBang.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public JsonResult IniciarPartida()
        {
            Estado estado = new Estado();
            Datos datos = estado.InicioPartidaRegistro();
            //string a = new JavaScriptSerializer().Serialize(datos);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InicioPartida(string json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            Console.WriteLine(datos.idPartida);
            bool ans = estado.InicioPartida(datos);
            //string a = new JavaScriptSerializer().Serialize(ans);
            return Json(ans, JsonRequestBehavior.AllowGet);
        }
        
        public void Lanzar(string json)
        {
            DatosLanzamiento datos = new JavaScriptSerializer().Deserialize<DatosLanzamiento>(json);
            Estado estado = new Estado();
            estado.Lanzamiento(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);            
        }
        
        public JsonResult Estado(string json)
        {
            Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            Jugador resultado = estado.Turno(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}