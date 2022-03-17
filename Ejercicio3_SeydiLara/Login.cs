using Datos.Acessos;
using Datos.Entidades;
using System;
using System.Windows.Forms;

/*
    Seydi Johana Lara Fuentes
    20201003422

    usuarios ingresados
    Id: JLARA
    Clave: 123456
    
    Id: NCASCO
    Clave: 123
    
    Id: SLARA
    Clave: 000
    
 */



namespace Ejercicio3_SeydiLara
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            
            //VALIDAR CON UN ERRORPROVIDER PARA QUE NO PASE AL SIGUIENTE SIN ANTES LLENAR EL CAMPO
            if (string.IsNullOrEmpty(UsuarioTextBox.Text))
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese el Id del usuario");
                UsuarioTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ClaveTextBox.Text))
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese la clave del usuario");
                ClaveTextBox.Focus();
                return;
            }



            //CREACION DE UN OBJETO DE TIPO USUARIO
            UsuarioAcceso usuarioAcceso = new UsuarioAcceso();
            Usuario usuario = new Usuario();

            //ASIGNACION DE LOS CAMPOS AL OBJETO USUARIO
            usuario = usuarioAcceso.Login(UsuarioTextBox.Text, ClaveTextBox.Text);

            //CONDICION CUANDO EL USUARIO SEA NULO
            if (usuario == null)
            {
                MessageBox.Show("DATOS ERRONEOS");
                LimpiarControles();
                return;
            }
            MessageBox.Show("DATOS CORRECTOS");
            LimpiarControles();
            

            //CREACION DE OBJETO
            Registros registros = new Registros();
            registros.Show();//LLAMADA DEL FORMULARIO REGISTRO


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();//CERRAR EL FORMULARIO
        }
        /*
         * Método que limpia los textbox
         */
        private void LimpiarControles()
        {
            UsuarioTextBox.Clear();
            ClaveTextBox.Clear();
            UsuarioTextBox.Focus();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            UsuarioTextBox.Focus();
        }
    }
}
