using ServiciosWeb.Sistema;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiciosWeb
{
    public class EnlaceSQLServer
    {

        private static SqlConnection conexion = null;
        public static SqlConnection Conexion
        {
            get { return EnlaceSQLServer.conexion; }
        }

        public static bool conectarSQLServer()
        {
            bool Estado = false;
            try
            {
                if (conexion == null)
                {
                    conexion = new SqlConnection();
                    conexion.ConnectionString = "Data Source =" + DatosEnlace.ipBaseDatos +
                        "; Initial Catalog = " + DatosEnlace.nombreBaseDatos +
                        "; User ID = " + DatosEnlace.usuarioBaseDatos +
                        "; Password = " + DatosEnlace.passwordBaseDatos +
                        "; MultipleActiveResultSets = true";
                    System.Threading.Thread.Sleep(750);
                }


                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }


                if (conexion.State == System.Data.ConnectionState.Broken)
                {
                    conexion.Close();
                    conexion.Open();

                }

                if (conexion.State == System.Data.ConnectionState.Connecting)
                {
                    while (conexion.State == System.Data.ConnectionState.Connecting)
                        System.Threading.Thread.Sleep(500);

                }

                Estado = true;





            }
            catch (Exception e)
            {
                Funciones.Logs("SQLError", "Este es el error : " + e.Message);
                Funciones.Logs("SQLDEBUG", "Este es la pista : " + e.StackTrace);
            }

            return Estado;
        }



    }
}