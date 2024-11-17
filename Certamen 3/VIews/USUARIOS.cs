using Certamen_3.Classes;
using Certamen_3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certamen_3.VIews
{
    public partial class Form2 : Form
    {
        private const string DefaultPassword = "2024*";

        public Form2()
        {
            InitializeComponent();
            Cargarusuarios();
            string currentUser = SessionManager.CurrentUsername; 
            userNameLabel.Text = $"Logged in as: {currentUser}";           
        }
        private void Cargarusuarios()
        {
            using (var db = new EVALUACION3Entities())
            {
                var users = db.USUARIOs.Select(u => new
                {
                    Usuario = u.NOM_USUARIO,
                    Nombres = u.NOMBRES_USUARIO,
                    Apellidos = u.APELLIDOS_USUARIO,
                    Estado = u.ID_ESTADO == 1 ? "Habilitado" : "Deshabilitado"
                }).ToList();

                dgvUsuarios.DataSource = users;

                if (!dgvUsuarios.Columns.Contains("RestorePassword"))
                {
                    var restoreButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Restaurar Contraseña",
                        Name = "RestorePassword",
                        Text = "Restaurar",
                        UseColumnTextForButtonValue = true
                    };
                    dgvUsuarios.Columns.Add(restoreButton);
                }

                if (!dgvUsuarios.Columns.Contains("DisableUser"))
                {
                    var disableButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Deshabilitar Usuario",
                        Name = "DisableUser",
                        Text = "Deshabilitar",
                        UseColumnTextForButtonValue = true
                    };
                    dgvUsuarios.Columns.Add(disableButton);
                }

                if (!dgvUsuarios.Columns.Contains("EnableUser"))
                {
                    var enableButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Habilitar Usuario",
                        Name = "EnableUser",
                        Text = "Habilitar",
                        UseColumnTextForButtonValue = true
                    };
                    dgvUsuarios.Columns.Add(enableButton);
                }
            }
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string usuario = txtUsuario.Text.Trim();

            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new EVALUACION3Entities())
            {
                if (db.USUARIOs.Any(u => u.NOM_USUARIO == usuario))
                {
                    MessageBox.Show("El nombre de usuario ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newUser = new USUARIO
                {
                    NOMBRES_USUARIO = nombres,
                    APELLIDOS_USUARIO = apellidos,
                    NOM_USUARIO = usuario,
                    CONTRASEÑA_USUARIO = "2024*",
                    ID_ESTADO = 1 
                };

                db.USUARIOs.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Usuario agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            Cargarusuarios();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string usuario = dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

            if (e.ColumnIndex == dgvUsuarios.Columns["RestorePassword"].Index)
            {
                if (MessageBox.Show("¿Realmente desea restaurar la contraseña?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var db = new EVALUACION3Entities())
                    {
                        var user = db.USUARIOs.FirstOrDefault(u => u.NOM_USUARIO == usuario);
                        if (user != null)
                        {
                            user.CONTRASEÑA_USUARIO = DefaultPassword;
                            db.SaveChanges();
                            MessageBox.Show("Contraseña restaurada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Cargarusuarios();
                }
            }
            else if (e.ColumnIndex == dgvUsuarios.Columns["DisableUser"].Index)
            {
                if (MessageBox.Show("¿Realmente desea deshabilitar al usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var db = new EVALUACION3Entities())
                    {
                        var user = db.USUARIOs.FirstOrDefault(u => u.NOM_USUARIO == usuario);
                        if (user != null && user.ID_ESTADO == 1) 
                        {
                            user.ID_ESTADO = 2; 
                            db.SaveChanges();
                            MessageBox.Show("Usuario deshabilitado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Cargarusuarios();
                }
            }
            else if (e.ColumnIndex == dgvUsuarios.Columns["EnableUser"].Index)
            {
                if (MessageBox.Show("¿Realmente desea habilitar al usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var db = new EVALUACION3Entities())
                    {
                        var user = db.USUARIOs.FirstOrDefault(u => u.NOM_USUARIO == usuario);
                        if (user != null && user.ID_ESTADO == 2) 
                        {
                            user.ID_ESTADO = 1; 
                            db.SaveChanges();
                            MessageBox.Show("Usuario habilitado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Cargarusuarios();
                }
            }
        }

        private void ClearFields()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtUsuario.Clear();
        }

        private void aFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void aCREDITACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentUsername = string.Empty;

            foreach (Form openForm in Application.OpenForms.OfType<Form>().ToList())
            {
                if (openForm.Name != "Form1")
                {
                    openForm.Close();
                }
            }

            this.Hide();
            var loginForm = new Form1();
            loginForm.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changePasswordForm = new Cambiar_Clave();
            changePasswordForm.ShowDialog();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
