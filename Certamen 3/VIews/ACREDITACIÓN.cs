using Certamen_3.Classes;
using Certamen_3.Model;
using Certamen_3.Views;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Certamen_3.VIews
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            dtpFechaContable.MinDate = DateTime.Today;
            CargarClientes();
            CargarTipoAcreditacion();
            MostrarDatos();
            string currentUser = SessionManager.CurrentUsername;
            userNameLabel.Text = $"Logged in as: {currentUser}";
            dgvDatos.CellClick += dataGridView1_CellClick;
        }

        private void CargarTipoAcreditacion()
        {
            using (var db = new EVALUACION3Entities())
            {
                var tiposAcreditacion = db.TIPO_ACREDITACION
                    .Select(t => new
                    {
                        t.ID_TIPO_ACREDITACION,
                        t.DESC_TIPO_ACREDITACION
                    })
                    .ToList();

                cbTipoAcreditacion.DisplayMember = "DESC_TIPO_ACREDITACION";
                cbTipoAcreditacion.ValueMember = "ID_TIPO_ACREDITACION";
                cbTipoAcreditacion.DataSource = tiposAcreditacion;
            }
        }

        private void CargarClientes()
        {
            using (var db = new EVALUACION3Entities())
            {
                var clientes = db.CLIENTEs
                    .Where(c => !db.ACREDITACIONs.Any(a => a.RUT_CLIENTE == c.RUT_CLIENTE
                        && a.TIPO_ACREDITACION.DESC_TIPO_ACREDITACION == "Simulación"
                        && a.FECHA_CONTABLE > DateTime.Today))
                    .ToList();

                cbCliente.DisplayMember = "NOMBRES_CLIENTE";
                cbCliente.ValueMember = "RUT_CLIENTE";
                cbCliente.DataSource = clientes;
                cbCliente.SelectedIndex = -1;
            }
        }

        private void CargarDatosClientes()
        {
            using (var db = new EVALUACION3Entities())
            {
                var clientes = db.CLIENTEs.ToList();

                cbCliente.DataSource = clientes;
                cbCliente.DisplayMember = "NOMBRES_CLIENTE";
                cbCliente.ValueMember = "RUT_CLIENTE";
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedItem != null)
            {
                var selectedClient = (CLIENTE)cbCliente.SelectedItem;

                txtNombreCompleto.Text = $"{selectedClient.NOMBRES_CLIENTE} {selectedClient.APELLIDOS_CLIENTE}";

                int rutCliente = selectedClient.RUT_CLIENTE;
                string dvCliente = selectedClient.DV_CLIENTE;

                using (var db = new EVALUACION3Entities())
                {
                    var clienteData = (from c in db.CLIENTEs
                                       join a in db.ACREDITACIONs on new { c.RUT_CLIENTE, c.DV_CLIENTE } equals new { RUT_CLIENTE = a.RUT_CLIENTE, DV_CLIENTE = a.DV_CLIENTE }
                                       where c.RUT_CLIENTE == rutCliente && c.DV_CLIENTE == dvCliente
                                       select new { c.REMUNERACION_CLIENTE, a.FECHA_CREADO })
                                      .FirstOrDefault();

                    if (clienteData != null)
                    {
                        decimal comision = 10m;
                        decimal remuneracionCliente = clienteData.REMUNERACION_CLIENTE;
                        decimal totalNCuotas = (remuneracionCliente * (comision / 100)) + remuneracionCliente;
                        txtTotalCuotas.Text = totalNCuotas.ToString("N0");

                        txtFechaCreado.Text = clienteData.FECHA_CREADO.ToString("d");
                    }
                    else
                    {
                        txtTotalCuotas.Text = "0";
                        txtFechaCreado.Text = string.Empty;
                    }
                }
            }
            else
            {
                txtTotalCuotas.Text = "0";
                txtFechaCreado.Text = string.Empty;
                txtNombreCompleto.Text = string.Empty;
            }
        }

        private void MostrarDatos()
        {
            using (var db = new EVALUACION3Entities())
            {
                var datos = db.ACREDITACIONs
                    .Select(a => new
                    {
                        a.ID_ACREDITACION,
                        a.CLIENTE.RUT_CLIENTE,
                        a.CLIENTE.DV_CLIENTE,
                        a.CLIENTE.NOMBRES_CLIENTE,
                        a.CLIENTE.APELLIDOS_CLIENTE,
                        a.CLIENTE.FECHA_NACIMIENTO,
                        a.NOM_USUARIO,
                        a.CLIENTE.AFP.NOM_AFP,
                        a.TIPO_ACREDITACION.DESC_TIPO_ACREDITACION,
                        a.TOTAL_N_CUOTAS
                    })
                    .ToList()
                    .Select(a => new
                    {
                        a.ID_ACREDITACION,
                        RutCliente = $"{a.RUT_CLIENTE}-{a.DV_CLIENTE}",
                        NombreCliente = a.NOMBRES_CLIENTE,
                        ApellidoCliente = a.APELLIDOS_CLIENTE,
                        EdadCliente = DateTime.Today.Year - a.FECHA_NACIMIENTO.Year,
                        UsuarioIngreso = a.NOM_USUARIO,
                        AFPNombre = a.NOM_AFP,
                        TipoAcreditacion = a.DESC_TIPO_ACREDITACION,
                        Total = a.TOTAL_N_CUOTAS.ToString("C2"),
                        Acreditar = "Detalles",
                    })
                    .ToList();

                dgvDatos.DataSource = datos;
                dgvDatos.Columns["Acreditar"].Width = 100;
                dgvDatos.Refresh();
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tipoAcreditacion = dgvDatos.Rows[e.RowIndex].Cells["TipoAcreditacion"].Value.ToString();

                if (dgvDatos.Columns[e.ColumnIndex].Name == "Acreditar")
                {
                    if (tipoAcreditacion == "ACREDITACIÓN")
                    {
                        MessageBox.Show("Este registro no puede ser acreditado porque es de tipo Acreditación.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }

                    int idAcreditacion = (int)dgvDatos.Rows[e.RowIndex].Cells["ID_ACREDITACION"].Value;
                    using (var detailForm = new FormDetalle(idAcreditacion))
                    {
                        detailForm.ShowDialog();
                    }
                }
            }
        }

        private void btnAcreditar_Click_1(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex == -1 || cbTipoAcreditacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente y un tipo de acreditación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = (int)cbCliente.SelectedValue;
            int tipoAcreditacionId = (int)cbTipoAcreditacion.SelectedValue;
            DateTime fechaContable = dtpFechaContable.Value;

            if (fechaContable < DateTime.Today)
            {
                MessageBox.Show("La fecha contable no puede ser anterior a la fecha actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new EVALUACION3Entities())
            {
                var cliente = db.CLIENTEs
                    .Where(c => c.RUT_CLIENTE == clienteId)
                    .Select(c => new { c.REMUNERACION_CLIENTE })
                    .FirstOrDefault();

                if (cliente != null)
                {
                    int comision = 10;
                    int totalNCuotas = (cliente.REMUNERACION_CLIENTE * comision / 100) + cliente.REMUNERACION_CLIENTE;

                    var acreditacion = new ACREDITACION
                    {
                        RUT_CLIENTE = clienteId,
                        ID_TIPO_ACREDITACION = tipoAcreditacionId,
                        FECHA_CONTABLE = fechaContable,
                        FECHA_CREADO = DateTime.Now,
                        NOM_USUARIO = SessionManager.CurrentUsername,
                        TOTAL_N_CUOTAS = totalNCuotas,
                        DV_CLIENTE = GetDVCliente(clienteId)
                    };

                    db.ACREDITACIONs.Add(acreditacion);
                    db.SaveChanges();
                    MessageBox.Show("Cliente acreditado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos();
                }
            }
        }
        private string GetDVCliente(int clienteId)
        {
            using (var db = new EVALUACION3Entities())
            {
                var cliente = db.CLIENTEs
                    .Where(c => c.RUT_CLIENTE == clienteId)
                    .Select(c => c.DV_CLIENTE)
                    .FirstOrDefault();

                return cliente;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvDatos.Columns.Contains("TipoAcreditacion"))
                {
                    var tipoAcreditacionCell = dgvDatos.Rows[e.RowIndex].Cells["TipoAcreditacion"].Value;
                    string tipoAcreditacion = tipoAcreditacionCell != null ? tipoAcreditacionCell.ToString() : string.Empty;

                    Console.WriteLine($"TipoAcreditacion: {tipoAcreditacion}");

                    if (e.ColumnIndex == dgvDatos.Columns["Acreditar"].Index)
                    {
                        if (tipoAcreditacion.Equals("Simulación", StringComparison.OrdinalIgnoreCase))
                        {
                            int idRegistro = (int)dgvDatos.Rows[e.RowIndex].Cells["ID_ACREDITACION"].Value;

                            FormDetalle formDetalle = new FormDetalle(idRegistro);
                            formDetalle.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No puede acceder a los detalles para este cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La columna 'TipoAcreditacion' no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
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

    }
}
