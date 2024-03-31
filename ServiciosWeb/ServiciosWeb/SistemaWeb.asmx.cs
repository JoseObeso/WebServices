using Newtonsoft.Json;
using ServiciosWeb.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

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

        [WebMethod(Description = "Guardar XML")]
        public string GuardarXML(string xml)
        {

            XmlDocument Data_Xml = new XmlDocument();

            Data_Xml.LoadXml(xml);

            XmlNode documento = Data_Xml.SelectSingleNode("Documento");

            string deporte = documento["deporte"].InnerText;

            Funciones.Logs("xml", deporte + "Equipos");

            return "Guardado Ok";
 
        }

        [WebMethod(Description = "Conjunto de JSON")]
        public string RetornoJSON()
        {

            dynamic Json = new Dictionary<string, dynamic>();
            Json.Add("deporte", "Futbol");

            List<Dictionary<string, string>> equipos = new List<Dictionary<string, string>>();

            Dictionary<string, string> equipo1 = new Dictionary<string, string>();
            equipo1.Add("nombre", "Manchester");
            equipo1.Add("pais", "Inglaterra");

            equipos.Add(equipo1);

            Dictionary<string, string> equipo2 = new Dictionary<string, string>();
            equipo2.Add("nombre", "Jose Galvez");
            equipo2.Add("pais", "Peru");


            equipos.Add(equipo2);


            Json.Add("equipos", equipos);

            return JsonConvert.SerializeObject(Json);







        }



    }
}
