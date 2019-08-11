namespace Ventas_Catalogos.GUI
{
    partial class frmhBuscarFact
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbFecha = new System.Windows.Forms.RadioButton();
            this.rdbProv = new System.Windows.Forms.RadioButton();
            this.rdbFact = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbRazSoc2 = new System.Windows.Forms.ComboBox();
            this.cmbID2 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtnumFact2 = new System.Windows.Forms.TextBox();
            this.llb1 = new System.Windows.Forms.Label();
            this.datimeFechaCompra2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridBusq = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusq)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.dataGridBusq);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(22, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 306);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados de Búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbFecha);
            this.groupBox2.Controls.Add(this.rdbProv);
            this.groupBox2.Controls.Add(this.rdbFact);
            this.groupBox2.Controls.Add(this.rdbTodo);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(487, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Por:";
            // 
            // rdbFecha
            // 
            this.rdbFecha.AutoSize = true;
            this.rdbFecha.Location = new System.Drawing.Point(6, 87);
            this.rdbFecha.Name = "rdbFecha";
            this.rdbFecha.Size = new System.Drawing.Size(60, 18);
            this.rdbFecha.TabIndex = 3;
            this.rdbFecha.TabStop = true;
            this.rdbFecha.Text = "Fecha";
            this.rdbFecha.UseVisualStyleBackColor = true;
            // 
            // rdbProv
            // 
            this.rdbProv.AutoSize = true;
            this.rdbProv.Location = new System.Drawing.Point(6, 65);
            this.rdbProv.Name = "rdbProv";
            this.rdbProv.Size = new System.Drawing.Size(81, 18);
            this.rdbProv.TabIndex = 2;
            this.rdbProv.TabStop = true;
            this.rdbProv.Text = "Provedor";
            this.rdbProv.UseVisualStyleBackColor = true;
            // 
            // rdbFact
            // 
            this.rdbFact.AutoSize = true;
            this.rdbFact.Location = new System.Drawing.Point(6, 45);
            this.rdbFact.Name = "rdbFact";
            this.rdbFact.Size = new System.Drawing.Size(74, 18);
            this.rdbFact.TabIndex = 1;
            this.rdbFact.TabStop = true;
            this.rdbFact.Text = "Factura";
            this.rdbFact.UseVisualStyleBackColor = true;
            // 
            // rdbTodo
            // 
            this.rdbTodo.AutoSize = true;
            this.rdbTodo.Location = new System.Drawing.Point(6, 21);
            this.rdbTodo.Name = "rdbTodo";
            this.rdbTodo.Size = new System.Drawing.Size(53, 18);
            this.rdbTodo.TabIndex = 0;
            this.rdbTodo.TabStop = true;
            this.rdbTodo.Text = "Todo";
            this.rdbTodo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.cmbRazSoc2);
            this.panel2.Controls.Add(this.cmbID2);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtnumFact2);
            this.panel2.Controls.Add(this.llb1);
            this.panel2.Controls.Add(this.datimeFechaCompra2);
            this.panel2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 135);
            this.panel2.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(190, 98);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 23);
            this.btnBuscar.TabIndex = 44;
            this.btnBuscar.Text = "Búscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbRazSoc2
            // 
            this.cmbRazSoc2.FormattingEnabled = true;
            this.cmbRazSoc2.Location = new System.Drawing.Point(191, 61);
            this.cmbRazSoc2.Name = "cmbRazSoc2";
            this.cmbRazSoc2.Size = new System.Drawing.Size(253, 22);
            this.cmbRazSoc2.TabIndex = 43;
            this.cmbRazSoc2.SelectionChangeCommitted += new System.EventHandler(this.cmbRazSoc_SelectionChangeCommitted);
            // 
            // cmbID2
            // 
            this.cmbID2.FormattingEnabled = true;
            this.cmbID2.Location = new System.Drawing.Point(114, 61);
            this.cmbID2.Name = "cmbID2";
            this.cmbID2.Size = new System.Drawing.Size(71, 22);
            this.cmbID2.TabIndex = 42;
            this.cmbID2.SelectionChangeCommitted += new System.EventHandler(this.cmbID_SelectionChangeCommitted);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 14);
            this.label23.TabIndex = 41;
            this.label23.Text = "Razón Social:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(4, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 14);
            this.label22.TabIndex = 40;
            this.label22.Text = "Fecha Factura:";
            // 
            // txtnumFact2
            // 
            this.txtnumFact2.Location = new System.Drawing.Point(115, 2);
            this.txtnumFact2.Name = "txtnumFact2";
            this.txtnumFact2.Size = new System.Drawing.Size(136, 22);
            this.txtnumFact2.TabIndex = 3;
            // 
            // llb1
            // 
            this.llb1.AutoSize = true;
            this.llb1.BackColor = System.Drawing.Color.Transparent;
            this.llb1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llb1.ForeColor = System.Drawing.Color.White;
            this.llb1.Location = new System.Drawing.Point(4, 8);
            this.llb1.Name = "llb1";
            this.llb1.Size = new System.Drawing.Size(112, 14);
            this.llb1.TabIndex = 2;
            this.llb1.Text = "Número Factura:";
            // 
            // datimeFechaCompra2
            // 
            this.datimeFechaCompra2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datimeFechaCompra2.Location = new System.Drawing.Point(116, 34);
            this.datimeFechaCompra2.Name = "datimeFechaCompra2";
            this.datimeFechaCompra2.Size = new System.Drawing.Size(108, 22);
            this.datimeFechaCompra2.TabIndex = 39;
            // 
            // dataGridBusq
            // 
            this.dataGridBusq.AllowUserToAddRows = false;
            this.dataGridBusq.AllowUserToDeleteRows = false;
            this.dataGridBusq.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridBusq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBusq.GridColor = System.Drawing.Color.Black;
            this.dataGridBusq.Location = new System.Drawing.Point(6, 162);
            this.dataGridBusq.Name = "dataGridBusq";
            this.dataGridBusq.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBusq.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridBusq.Size = new System.Drawing.Size(661, 135);
            this.dataGridBusq.TabIndex = 1;
            this.dataGridBusq.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBusq_CellContentDoubleClick);
            // 
            // frmhBuscarFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ventas_Catalogos.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(701, 329);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmhBuscarFact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Factura Provedor";
            this.Load += new System.EventHandler(this.frmhBuscarFact_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridBusq;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbRazSoc2;
        private System.Windows.Forms.ComboBox cmbID2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtnumFact2;
        private System.Windows.Forms.Label llb1;
        private System.Windows.Forms.DateTimePicker datimeFechaCompra2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbFecha;
        private System.Windows.Forms.RadioButton rdbProv;
        private System.Windows.Forms.RadioButton rdbFact;
        private System.Windows.Forms.RadioButton rdbTodo;
    }
}