using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Datos.Acessos
{
    public class UsuarioAcceso
    {
        //Se crea la cadena de conexión a la base de datos en MySql
        readonly string cadena = "Server=127.0.0.1; Port=3306; Database=ejercicio#3_seydilara; Uid=root; Pwd=JohaAdmin26;";

        //variables para la conexión
        MySqlConnection conn;
        MySqlCommand cmd;

        /**
         * Método de tipo Uusario para ingresar a la base de datos mediante el Id y la clave
         */
        public Usuario Login(string idUsuario, string clave) 
        {
            //declaracion de una variable usuario como nula
            Usuario user = null;

            try
            {
                //cadena de conexión a la tabla usuarios de mi base de datos
                string sql = "SELECT * FROM usuarios WHERE IdUsuario=@IdUsuario AND Clave=@Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();//abre la conexión

                cmd = new MySqlCommand(sql, conn);
                //parámetros de la tabla necesarios para ingresar
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                //llamada de los datos de la tabla
                while (reader.Read())
                {
                    user = new Usuario();
                    user.IdUsuario = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Rol = reader[2].ToString();
                    user.Clave = reader[3].ToString();

                }
                reader.Close();
                conn.Close();//cierra conexión


            }
            catch (Exception ex)
            {
            }

            return user;
        }


        /**
         * Método para mostrar los usuarios agregados en la tabla usuarios de la base de datos en MySql
         */
        public DataTable ListarUsuarios()
        {
            //Creación de objetos para listar los usuarios
            DataTable listaUsuarios = new DataTable();
            try
            {
                //Cadena de llamada
                string sql = "SELECT * FROM usuarios;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuarios.Load(reader);
                reader.Close();
                conn.Close();

            }
            catch (Exception ex)
            {

            }
            return listaUsuarios;
        }








    }
}
