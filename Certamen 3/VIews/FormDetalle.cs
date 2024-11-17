using Certamen_3.Classes;
using Certamen_3.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Certamen_3.Views
{
    public partial class FormDetalle : Form
    {
        private int idRegistro;

        public FormDetalle(int idRegistro)
        {
            this.idRegistro = idRegistro;
            InitializeComponent();
            LoadDetails();
        }

        private void LoadDetails()
        {
            using (var db = new EVALUACION3Entities())
            {
                var detalle = db.ACREDITACIONs
                                .Where(a => a.ID_ACREDITACION == idRegistro)
                                .Select(a => new
                                {
                                    a.ID_ACREDITACION,
                                    RutCliente = a.CLIENTE.RUT_CLIENTE + "-" + a.CLIENTE.DV_CLIENTE,
                                    NombreCliente = a.CLIENTE.NOMBRES_CLIENTE,
                                    ApellidoCliente = a.CLIENTE.APELLIDOS_CLIENTE,
                                    EdadCliente = DateTime.Today.Year - a.CLIENTE.FECHA_NACIMIENTO.Year,
                                    UsuarioIngreso = a.USUARIO.NOM_USUARIO,
                                    AFP = a.CLIENTE.AFP.NOM_AFP,
                                    TipoAcreditacion = a.TIPO_ACREDITACION.DESC_TIPO_ACREDITACION,
                                    a.TOTAL_N_CUOTAS,
                                    a.FECHA_CREADO,
                                    a.FECHA_CONTABLE
                                })
                                .FirstOrDefault();

                if (detalle != null)
                {
                    lblIDRegistro.Text = detalle.ID_ACREDITACION.ToString();
                    lblRutCliente.Text = detalle.RutCliente;
                    lblNombreCliente.Text = detalle.NombreCliente;
                    lblApellidoCliente.Text = detalle.ApellidoCliente;
                    lblEdadCliente.Text = detalle.EdadCliente.ToString();
                    lblUsuarioIngreso.Text = detalle.UsuarioIngreso;
                    lblAFP.Text = detalle.AFP;
                    lblTipoAcreditacion.Text = detalle.TipoAcreditacion;
                    lblTotal.Text = detalle.TOTAL_N_CUOTAS.ToString("C2"); 
                    lblFechaCreado.Text = detalle.FECHA_CREADO.ToString("d");
                    lblFechaContable.Text = detalle.FECHA_CONTABLE.ToString("d");

                    LoadPaymentDetails(detalle.TOTAL_N_CUOTAS);
                }
            }
        }

        private void LoadPaymentDetails(decimal total)
        {
            var paymentDetails = new DataTable();
            paymentDetails.Columns.Add("Mes");
            paymentDetails.Columns.Add("Valor");

            var percentages = new Dictionary<int, decimal>
            {
                { 6, 0.05m },
                { 12, 0.08m },
                { 18, 0.10m },
                { 24, 0.15m }
            };

            foreach (var term in percentages)
            {
                var valor = total + (total * term.Value);
                paymentDetails.Rows.Add(term.Key, valor.ToString("C2"));
            }

            dataGridViewPayments.DataSource = paymentDetails;
        }
    }
}