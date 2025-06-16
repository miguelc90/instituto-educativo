using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InstitutoEducativo.Controlador
{
    internal class ControladorAlumnos
    {
        public void MostrarAlumnos(DataGridView tablaAlumnos)
        {
            Configuracion.Conexion establecer_conexion = new Configuracion.Conexion();
            Modelos.ModeloAlumnos alumnos = new Modelos.ModeloAlumnos();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("id", typeof(int));
            modelo.Columns.Add("nombre", typeof(string));
            modelo.Columns.Add("apellido", typeof(string));
            modelo.Columns.Add("dni", typeof(string));
            modelo.Columns.Add("fecha_nacimiento", typeof(DateTime));
            modelo.Columns.Add("telefono", typeof(string));

            tablaAlumnos.DataSource = modelo;

            string sql = "SELECT * FROM alumno";

            try
            {
                MySqlConnection conexion = establecer_conexion.EnlaceConexion();

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                DataSet ds = new DataSet();

                adaptador.Fill(ds);

                DataTable dt = ds.Tables[0];

                foreach(DataRow row in dt.Rows)
                {
                    alumnos.IdAlumno = Convert.ToInt32(row["idAlumno"]);
                    alumnos.Nombre = row["nombre"].ToString();
                    alumnos.Apellido = row["apellido"].ToString();
                    alumnos.Dni = row["dni"].ToString();
                    alumnos.Fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
                    alumnos.Telefono = row["telefono"].ToString();

                    modelo.Rows.Add(alumnos.IdAlumno,
                                    alumnos.Nombre,
                                    alumnos.Apellido,
                                    alumnos.Dni,
                                    alumnos.Fecha_nacimiento,
                                    alumnos.Telefono
                     );
                }

                tablaAlumnos.DataSource = modelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos" + ex.ToString());
            }
            finally
            {
                establecer_conexion.CerrarConexion();
            }
        }

        public void AgregarAlumno(TextBox nombre, TextBox apellido, TextBox dni, TextBox telefono, DateTimePicker fecha_nacimiento)
        {
            Configuracion.Conexion establecer_conexion = new Configuracion.Conexion();
            Modelos.ModeloAlumnos alumnos = new Modelos.ModeloAlumnos();

            string query = "INSERT INTO alumno(nombre, apellido, dni, fecha_nacimiento, telefono) VALUES (@nombre, @apellido, @dni, @fecha_nacimiento, @telefono);";

            try
            {
                alumnos.Nombre = nombre.Text;
                alumnos.Apellido = apellido.Text;
                alumnos.Dni = dni.Text;
                alumnos.Telefono = telefono.Text;
                alumnos.Fecha_nacimiento = fecha_nacimiento.Value;

                MySqlConnection conexion = establecer_conexion.EnlaceConexion();
                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@nombre", alumnos.Nombre);
                comando.Parameters.AddWithValue("@apellido", alumnos.Apellido);
                comando.Parameters.AddWithValue("@dni", alumnos.Dni);
                comando.Parameters.AddWithValue("@fecha_nacimiento", alumnos.Fecha_nacimiento);
                comando.Parameters.AddWithValue("@telefono", alumnos.Telefono);

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro, Error: " + ex.Message.ToString());
            }
            finally
            {
                establecer_conexion.CerrarConexion();
            }
        }

        public void Seleccionar(DataGridView tablaAlumnos, TextBox id, TextBox nombre, TextBox apellido, TextBox dni, DateTimePicker fecha_nacimiento, TextBox telefono)
        {
            int fila = tablaAlumnos.CurrentRow.Index;

            try
            {
                if(fila >= 0)
                {
                    id.Text = tablaAlumnos.Rows[fila].Cells[0].Value.ToString();
                    nombre.Text = tablaAlumnos.Rows[fila].Cells[1].Value.ToString();
                    apellido.Text = tablaAlumnos.Rows[fila].Cells[2].Value.ToString();
                    dni.Text = tablaAlumnos.Rows[fila].Cells[3].Value.ToString();
                    fecha_nacimiento.Text = tablaAlumnos.Rows[fila].Cells[4].Value.ToString();
                    telefono.Text = tablaAlumnos.Rows[fila].Cells[5].Value.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al seleccionar, Error: " + ex.ToString());
            }
        }

        public void ModificarAlumno(TextBox id, TextBox nombre, TextBox apellido, TextBox dni, DateTimePicker fecha_nacimiento, TextBox telefono)
        {
            Configuracion.Conexion establecer_conexion = new Configuracion.Conexion();
            Modelos.ModeloAlumnos alumnos = new Modelos.ModeloAlumnos();

            string query = "UPDATE alumno SET alumno.nombre=@nombre, alumno.apellido=@apellido, alumno.dni=@dni, alumno.fecha_nacimiento=@fecha_nacimiento, alumno.telefono=@telefono WHERE alumno.idAlumno=@id;";

            try
            {
                alumnos.IdAlumno = int.Parse(id.Text);
                alumnos.Nombre = nombre.Text;
                alumnos.Apellido = apellido.Text;
                alumnos.Dni = dni.Text;
                alumnos.Fecha_nacimiento = fecha_nacimiento.Value;
                alumnos.Telefono = telefono.Text;

                MySqlConnection conexion = establecer_conexion.EnlaceConexion();

                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@id", alumnos.IdAlumno);
                comando.Parameters.AddWithValue("@nombre", alumnos.Nombre);
                comando.Parameters.AddWithValue("@apellido", alumnos.Apellido);
                comando.Parameters.AddWithValue("@dni", alumnos.Dni);
                comando.Parameters.AddWithValue("@fecha_nacimiento", alumnos.Fecha_nacimiento);
                comando.Parameters.AddWithValue("@telefono", alumnos.Telefono);

                comando.ExecuteNonQuery();

                MessageBox.Show("El registro se modificó correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El registro no pudo ser modificado, Error: "+ex.ToString());
            }
            finally
            {
                establecer_conexion.CerrarConexion();
            }

        }  
        
        public void EliminarAlumno(TextBox id)
        {
            Configuracion.Conexion establecer_conexion = new Configuracion.Conexion();
            Modelos.ModeloAlumnos alumnos = new Modelos.ModeloAlumnos();

            string query = "DELETE FROM alumno WHERE alumno.idAlumno=@id;";

            try
            {
                alumnos.IdAlumno = int.Parse(id.Text);

                MySqlConnection conexion = establecer_conexion.EnlaceConexion();

                MySqlCommand comando = new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@id", alumnos.IdAlumno);
                comando.Parameters.AddWithValue("@nombre", alumnos.Nombre);
                comando.Parameters.AddWithValue("@apellido", alumnos.Apellido);
                comando.Parameters.AddWithValue("@dni", alumnos.Dni);
                comando.Parameters.AddWithValue("@fecha_nacimiento", alumnos.Fecha_nacimiento);
                comando.Parameters.AddWithValue("@telefono", alumnos.Telefono);

                comando.ExecuteNonQuery();

                MessageBox.Show("El registro se eliminó correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El registro no pudo ser eliminado, Error: "+ex.ToString());
            }
            finally
            {
                establecer_conexion.CerrarConexion();
            }

        }

    }
}
