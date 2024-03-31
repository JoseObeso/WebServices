using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServiciosWeb.Sistema
{
    public class Funciones
    {

        public static void Logs(String Nombre_Archivo, string Descripcion)
        {

            string Directorio = AppDomain.CurrentDomain.BaseDirectory + "Logs/" + DateTime.Now.Year.ToString() + "/" +
                DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            if (!Directory.Exists(Directorio))
            {
                Directory.CreateDirectory(Directorio);
            }
            StreamWriter Archivo = new StreamWriter(Directorio + "/" + Nombre_Archivo + ".txt", true);
            string Cadena = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + ">>>>" + Descripcion;

            Archivo.WriteLine(Cadena);
            Archivo.Close();





        }
    }

}