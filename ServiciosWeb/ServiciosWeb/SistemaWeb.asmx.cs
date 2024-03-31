using ServiciosWeb.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWeb
{
    /// <summary>
    /// Descripción breve de SistemaWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SistemaWeb : System.Web.Services.WebService
    {

        [WebMethod(Description = "Metodo principal de Saludos")]
        public string Bienvenidos()
        {
            return "Servidor Jose Obeso - Bienvenidos - elPiquero.com";
        }


        [WebMethod(Description = "Metodo que permite Saludos al Invitado")]
        public string Saludos(string vNombre)
        {
            string Resultado = "Bienvenidos --- " + vNombre + " --- Que tengas un gran dia";
            return Resultado;
        }


        [WebMethod(Description = "Metodo que permite grabar el log")]
        public string GuardarLog(string Mensaje)
        {
            Funciones.Logs("ArchivoLogs", Mensaje);
            return "Guardado OK";
        }

        [WebMethod(Description = "Metodo que permite Sumar 2 enteros")]
        public int Sumar(int Numero1, int Numero2)
        {
            int Suma = Numero1 + Numero2;
            return Suma;
        }
               
        [WebMethod(Description = "Array de Frutas")]
        public string[] ObtenerFrutas()
        {
            string[] Fruta = new string[3];
            Fruta[0] = "Fresa";
            Fruta[1] = "Manzana";
            Fruta[2] = "Platano";
            return Fruta;
        }






    }
}
