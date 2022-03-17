using Datos.Acessos;
using System;
using System.Windows.Forms;

namespace Ejercicio3_SeydiLara
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }

        /**
         * En el evento load mostramos la lista de usuarios regsitrados
         */
        private void Registros_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        //Declaracion de objeto 
        UsuarioAcceso usuarioAcceso = new UsuarioAcceso();


        /**
         * Método que a través de nuestro DataGridView nos manda a llamar los usuarios registrados
         */
        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioAcceso.ListarUsuarios();

        }


    }

    



}
