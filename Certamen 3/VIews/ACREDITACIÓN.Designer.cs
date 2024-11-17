namespace Certamen_3.VIews
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbTipoAcreditacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaContable = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.labal5 = new System.Windows.Forms.Label();
            this.txtTotalCuotas = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aFPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCREDITACIÓNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userNameLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFechaCreado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAcreditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTipoAcreditacion
            // 
            this.cbTipoAcreditacion.FormattingEnabled = true;
            this.cbTipoAcreditacion.Location = new System.Drawing.Point(25, 49);
            this.cbTipoAcreditacion.Name = "cbTipoAcreditacion";
            this.cbTipoAcreditacion.Size = new System.Drawing.Size(121, 21);
            this.cbTipoAcreditacion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Acreditación";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(25, 110);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(161, 21);
            this.cbCliente.TabIndex = 2;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // dtpFechaContable
            // 
            this.dtpFechaContable.Location = new System.Drawing.Point(199, 49);
            this.dtpFechaContable.Name = "dtpFechaContable";
            this.dtpFechaContable.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaContable.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Contable";
            // 
            // labal5
            // 
            this.labal5.AutoSize = true;
            this.labal5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labal5.Location = new System.Drawing.Point(296, 90);
            this.labal5.Name = "labal5";
            this.labal5.Size = new System.Drawing.Size(122, 17);
            this.labal5.TabIndex = 8;
            this.labal5.Text = "Total con Comisión: ";
            // 
            // txtTotalCuotas
            // 
            this.txtTotalCuotas.Location = new System.Drawing.Point(299, 110);
            this.txtTotalCuotas.Name = "txtTotalCuotas";
            this.txtTotalCuotas.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCuotas.TabIndex = 9;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 211);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(1135, 227);
            this.dgvDatos.TabIndex = 10;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.aFPToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.aCREDITACIÓNToolStripMenuItem,
            this.userNameLabel,
            this.cierreSessionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // aFPToolStripMenuItem
            // 
            this.aFPToolStripMenuItem.Name = "aFPToolStripMenuItem";
            this.aFPToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aFPToolStripMenuItem.Text = "AFP";
            this.aFPToolStripMenuItem.Click += new System.EventHandler(this.aFPToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // aCREDITACIÓNToolStripMenuItem
            // 
            this.aCREDITACIÓNToolStripMenuItem.Name = "aCREDITACIÓNToolStripMenuItem";
            this.aCREDITACIÓNToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.aCREDITACIÓNToolStripMenuItem.Text = "ACREDITACIÓN ";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(125, 20);
            this.userNameLabel.Text = "toolStripMenuItem1";
            // 
            // cierreSessionToolStripMenuItem
            // 
            this.cierreSessionToolStripMenuItem.Name = "cierreSessionToolStripMenuItem";
            this.cierreSessionToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.cierreSessionToolStripMenuItem.Text = "Cierre Session";
            this.cierreSessionToolStripMenuItem.Click += new System.EventHandler(this.cierreSessionToolStripMenuItem_Click);
            // 
            // txtFechaCreado
            // 
            this.txtFechaCreado.Location = new System.Drawing.Point(445, 48);
            this.txtFechaCreado.Name = "txtFechaCreado";
            this.txtFechaCreado.Size = new System.Drawing.Size(142, 20);
            this.txtFechaCreado.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha Creada";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(25, 165);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCompleto.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nombre";
            // 
            // btnAcreditar
            // 
            this.btnAcreditar.Location = new System.Drawing.Point(299, 165);
            this.btnAcreditar.Name = "btnAcreditar";
            this.btnAcreditar.Size = new System.Drawing.Size(75, 23);
            this.btnAcreditar.TabIndex = 16;
            this.btnAcreditar.Text = "Acreditar";
            this.btnAcreditar.UseVisualStyleBackColor = true;
            this.btnAcreditar.Click += new System.EventHandler(this.btnAcreditar_Click_1);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 453);
            this.Controls.Add(this.btnAcreditar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaCreado);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtTotalCuotas);
            this.Controls.Add(this.labal5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaContable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipoAcreditacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACREDITACIÓN";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoAcreditacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaContable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labal5;
        private System.Windows.Forms.TextBox txtTotalCuotas;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aFPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCREDITACIÓNToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFechaCreado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAcreditar;
        private System.Windows.Forms.ToolStripMenuItem userNameLabel;
        private System.Windows.Forms.ToolStripMenuItem cierreSessionToolStripMenuItem;
    }
}