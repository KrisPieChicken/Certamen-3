namespace Certamen_3.VIews
{
    partial class Form3
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
            this.txtNombreAFP = new System.Windows.Forms.TextBox();
            this.txtComisionAFP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAFP = new System.Windows.Forms.DataGridView();
            this.btnAgregarAfp = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aFPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCREDITACIÓNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userNameLabel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFP)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreAFP
            // 
            this.txtNombreAFP.Location = new System.Drawing.Point(56, 47);
            this.txtNombreAFP.Name = "txtNombreAFP";
            this.txtNombreAFP.Size = new System.Drawing.Size(100, 20);
            this.txtNombreAFP.TabIndex = 0;
            // 
            // txtComisionAFP
            // 
            this.txtComisionAFP.Location = new System.Drawing.Point(56, 115);
            this.txtComisionAFP.Name = "txtComisionAFP";
            this.txtComisionAFP.Size = new System.Drawing.Size(100, 20);
            this.txtComisionAFP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "AFP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comision";
            // 
            // dgvAFP
            // 
            this.dgvAFP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAFP.Location = new System.Drawing.Point(13, 181);
            this.dgvAFP.Name = "dgvAFP";
            this.dgvAFP.Size = new System.Drawing.Size(395, 257);
            this.dgvAFP.TabIndex = 4;
            // 
            // btnAgregarAfp
            // 
            this.btnAgregarAfp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarAfp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAfp.Location = new System.Drawing.Point(214, 112);
            this.btnAgregarAfp.Name = "btnAgregarAfp";
            this.btnAgregarAfp.Size = new System.Drawing.Size(75, 33);
            this.btnAgregarAfp.TabIndex = 5;
            this.btnAgregarAfp.Text = "Guardar";
            this.btnAgregarAfp.UseVisualStyleBackColor = true;
            this.btnAgregarAfp.Click += new System.EventHandler(this.btnAgregarAfp_Click_1);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(333, 112);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(75, 33);
            this.btnLimpiarCampos.TabIndex = 6;
            this.btnLimpiarCampos.Text = "Limpiar";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.aFPToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.aCREDITACIÓNToolStripMenuItem,
            this.userNameLabel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(430, 24);
            this.menuStrip1.TabIndex = 10;
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
            this.aCREDITACIÓNToolStripMenuItem.Click += new System.EventHandler(this.aCREDITACIÓNToolStripMenuItem_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(125, 20);
            this.userNameLabel.Text = "toolStripMenuItem1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnAgregarAfp);
            this.Controls.Add(this.dgvAFP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComisionAFP);
            this.Controls.Add(this.txtNombreAFP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFP)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreAFP;
        private System.Windows.Forms.TextBox txtComisionAFP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAFP;
        private System.Windows.Forms.Button btnAgregarAfp;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aFPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCREDITACIÓNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userNameLabel;
    }
}