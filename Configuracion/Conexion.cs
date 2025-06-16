using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InstitutoEducativo.Configuracion
{
    internal class Conexion
    {
        private MySqlConnection conexion = null;

        private static string usuario = "root";
        private static string password = "root";
        private static string servidor = "localhost";
        private static string database = "db_cursos";
        private static string puerto = "3308";

        private string cadena_conexion = $"Server={servidor}; Port={puerto}; Database={database}; Uid={usuario}; Pwd={password};";

        public MySqlConnection EnlaceConexion ()
        {
            try
            {
                conexion = new MySqlConnection(cadena_conexion);
                conexion.Open ();
                //MessageBox.Show("Conexión éxitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la conexión, Error: " + ex.ToString());
            }

            return conexion;
        }

        public void CerrarConexion()
        {
            try
            {
                if(conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                //MessageBox.Show("Se cerro la conexion");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se cerro la conexion, por favor de revisar" + ex.ToString());
            }
        }
    }
}
