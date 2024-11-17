using Certamen_3.Classes;
using Certamen_3.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Certamen_3.VIews
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            CargarDatosClientes();
            CargarAFP();
            string currentUser = SessionManager.CurrentUsername;
            userNameLabel.Text = $"Logged in as: {currentUser}";
        }

        private void CargarAFP()
        {
            using (var db = new EVALUACION3Entities())
            {
                try
                {
                    var afps = db.AFPs.ToList(); 

                    if (afps.Any())
                    {
                        cbAFP.DataSource = afps;               
                        cbAFP.DisplayMember = "NOM_AFP";       
                        cbAFP.ValueMember = "ID_AFP";          
                        cbAFP.SelectedIndex = -1;              
                        cbAFP.Enabled = true;                  
                    }
                    else
                    {
                        cbAFP.DataSource = null;               
                        cbAFP.Enabled = false;                 
                        MessageBox.Show("No AFP data found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading AFP data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarDatosClientes()
        {
            using (var db = new EVALUACION3Entities())
            {
                var clientes = db.CLIENTEs.Select(c => new
                {
                    RUT = c.RUT_CLIENTE + "-" + c.DV_CLIENTE,
                    c.NOMBRES_CLIENTE,
                    c.APELLIDOS_CLIENTE,
                    AFP = c.AFP.NOM_AFP,
                    REMUNERACION = c.REMUNERACION_CLIENTE
                }).ToList();

                var formattedClientes = clientes.Select(c => new
                {
                    c.RUT,
                    c.NOMBRES_CLIENTE,
                    c.APELLIDOS_CLIENTE,
                    c.AFP,
                    REMUNERACION = c.REMUNERACION.ToString("C0")
                }).ToList();

                dgvClientes.DataSource = formattedClientes;
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string rut = txtRUT.Text.Trim();
            string dv = txtDV.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string remuneracionText = txtRemuneracion.Text.Trim();

            if (string.IsNullOrEmpty(rut) || string.IsNullOrEmpty(dv) || string.IsNullOrEmpty(nombres) ||
                string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(remuneracionText) || cbAFP.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResaltarCamposVacios(); 
                return;
            }

            if (!long.TryParse(rut, out long rutCliente))
            {
                MessageBox.Show("El RUT debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dv.Length != 1)
            {
                MessageBox.Show("El DV debe ser un solo carácter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(remuneracionText, out decimal remuneracion))
            {
                MessageBox.Show("La remuneración debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAFP = (int)cbAFP.SelectedValue;

            using (var db = new EVALUACION3Entities())
            {
                try
                {
                    var newCliente = new CLIENTE
                    {
                        RUT_CLIENTE = (int)rutCliente,
                        DV_CLIENTE = dv,
                        NOMBRES_CLIENTE = nombres,
                        APELLIDOS_CLIENTE = apellidos,
                        FECHA_NACIMIENTO = dtpFechaNacimiento.Value,
                        REMUNERACION_CLIENTE = (int)remuneracion,
                        ID_AFP = idAFP
                    };

                    db.CLIENTEs.Add(newCliente);
                    db.SaveChanges();
                    MessageBox.Show("Cliente agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CargarDatosClientes();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtRUT.Clear();
            txtDV.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtRemuneracion.Clear();
            cbAFP.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            ResetearResaltadoCampos(); 
        }

        private void ResaltarCamposVacios()
        {
            txtRUT.BackColor = string.IsNullOrEmpty(txtRUT.Text) ? Color.LightCoral : Color.White;
            txtDV.BackColor = string.IsNullOrEmpty(txtDV.Text) ? Color.LightCoral : Color.White;
            txtNombres.BackColor = string.IsNullOrEmpty(txtNombres.Text) ? Color.LightCoral : Color.White;
            txtApellidos.BackColor = string.IsNullOrEmpty(txtApellidos.Text) ? Color.LightCoral : Color.White;
            txtRemuneracion.BackColor = string.IsNullOrEmpty(txtRemuneracion.Text) ? Color.LightCoral : Color.White;
        }

        private void ResetearResaltadoCampos()
        {
            txtRUT.BackColor = Color.White;
            txtDV.BackColor = Color.White;
            txtNombres.BackColor = Color.White;
            txtApellidos.BackColor = Color.White;
            txtRemuneracion.BackColor = Color.White;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void aFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void aCREDITACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void cierreSessionToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            this.Close();
        }
        
      
    }
}
