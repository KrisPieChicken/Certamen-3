using Certamen_3.Classes;
using Certamen_3.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Certamen_3.VIews
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitializeDataGridView();
            CargarDatosAFP();
            string currentUser = SessionManager.CurrentUsername;
            userNameLabel.Text = $"Logged in as: {currentUser}";
        }

        private void InitializeDataGridView()
        {
            // Define columns programmatically
            dgvAFP.AutoGenerateColumns = false;

            dgvAFP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_AFP",
                HeaderText = "ID AFP",
                DataPropertyName = "ID_AFP"
            });

            dgvAFP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NOM_AFP",
                HeaderText = "Nombre AFP",
                DataPropertyName = "NOM_AFP"
            });

            dgvAFP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Commission",
                HeaderText = "Comisión",
                DataPropertyName = "Commission"
            });
        }

        private void CargarDatosAFP()
        {
            using (var db = new EVALUACION3Entities())
            {
                var afps = db.AFPs
                    .Select(a => new
                    {
                        a.ID_AFP,
                        a.NOM_AFP,
                        a.COMISION
                    })
                    .ToList()
                    .Select(a => new
                    {
                        a.ID_AFP,
                        a.NOM_AFP,
                        Commission = (a.COMISION / 100).ToString()
                    })
                    .ToList();

                dgvAFP.DataSource = afps;
            }
        }
        private void btnAgregarAfp_Click_1(object sender, EventArgs e)
        {
            string nombreAFP = txtNombreAFP.Text.Trim();
            string comisionTexto = txtComisionAFP.Text.Trim();

            if (string.IsNullOrEmpty(nombreAFP) || string.IsNullOrEmpty(comisionTexto))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(comisionTexto, out decimal comisionDecimal))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la comisión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comisionDecimal < 0 || comisionDecimal > 100)
            {
                MessageBox.Show("La comisión debe estar entre 0% y 100%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int comisionInt = (int)(comisionDecimal * 100);

            try
            {
                using (var db = new EVALUACION3Entities())
                {
                    var newAFP = new AFP
                    {
                        NOM_AFP = nombreAFP,
                        COMISION = comisionInt
                    };

                    db.AFPs.Add(newAFP);
                    db.SaveChanges();

                    MessageBox.Show("AFP guardada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Details: {ex.ToString()}"); 
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarDatosAFP();
            LimpiarCampos();
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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

        private void LimpiarCampos()
        {
            txtNombreAFP.Clear();
            txtComisionAFP.Clear();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
