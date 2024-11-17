using Certamen_3.Classes;
using Certamen_3.Model;
using Certamen_3.VIews;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Certamen_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                ShowErrorMessage("Por favor ingrese ambos campos.");
                return;
            }

            using (var db = new EVALUACION3Entities())
            {
                var user = db.USUARIOs.FirstOrDefault(u => u.NOM_USUARIO == usuario);

                if (user == null)
                {
                    ShowErrorMessage("Usuario no encontrado.");
                    return;
                }

                if (user.ID_ESTADO == 2) 
                {
                    ShowErrorMessage("El usuario está deshabilitado.");
                    return;
                }

                if (user.CONTRASEÑA_USUARIO == contraseña)
                {
                    MessageBox.Show($"Bienvenido, {user.NOMBRES_USUARIO} {user.APELLIDOS_USUARIO}",
                                    "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SessionManager.CurrentUsername = user.NOM_USUARIO;

                    this.Hide();
                    var mainForm = new Form2();
                    mainForm.Show();
                }
                else
                {
                    ShowErrorMessage("Contraseña incorrecta.");
                }
            }
        }


        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
