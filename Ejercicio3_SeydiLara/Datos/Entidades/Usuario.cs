namespace Datos.Entidades
{
    public class Usuario
    {
        //Declaración de parámetros que contiene nuestra tabla
        public string IdUsuario{ get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Clave { get; set; }

        /**
         * Método contructor vacío
         */
        public Usuario()
        {
        }

        /**
        * Método contructor con parámetros
        */
        public Usuario(string idUsuario, string nombre, string rol, string clave)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Rol = rol;
            Clave = clave;
        }
    }
}
