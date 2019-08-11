namespace Ventas_Catalogos.GUI
{
    partial class frmArticulo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulo));
            this.txtDescp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodArt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgrandar = new System.Windows.Forms.Button();
            this.btnEncoger = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridCliente = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.radBCodigo = new System.Windows.Forms.RadioButton();
            this.radButDescripcion = new System.Windows.Forms.RadioButton();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.datimeFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rdbImpSi = new System.Windows.Forms.RadioButton();
            this.rdbImpNo = new System.Windows.Forms.RadioButton();
            this.txtExistencia = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.NumericUpDown();
            this.txtUtil = new System.Windows.Forms.NumericUpDown();
            this.txtPrecioPub = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioPub)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescp
            // 
            this.txtDescp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescp.Location = new System.Drawing.Point(150, 44);
            this.txtDescp.Name = "txtDescp";
            this.txtDescp.Size = new System.Drawing.Size(228, 22);
            this.txtDescp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Precio Público";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Utilidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Precio Costo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Descripción Art:";
            // 
            // txtCodArt
            // 
            this.txtCodArt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArt.Location = new System.Drawing.Point(150, 14);
            this.txtCodArt.Name = "txtCodArt";
            this.txtCodArt.Size = new System.Drawing.Size(228, 22);
            this.txtCodArt.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Cod Artículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Marca:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Departamento";
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(150, 180);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(171, 21);
            this.cmbMarca.TabIndex = 6;
            this.cmbMarca.SelectedIndexChanged += new System.EventHandler(this.cmbMarca_SelectedIndexChanged);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(150, 206);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(171, 21);
            this.cmbDepartamento.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::Ventas_Catalogos.Properties.Resources.limpiar;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(150, 320);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(41, 45);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "  ";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackgroundImage = global::Ventas_Catalogos.Properties.Resources.guardar2;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(197, 320);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(41, 45);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgrandar
            // 
            this.btnAgrandar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgrandar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgrandar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgrandar.Location = new System.Drawing.Point(401, 0);
            this.btnAgrandar.Name = "btnAgrandar";
            this.btnAgrandar.Size = new System.Drawing.Size(22, 393);
            this.btnAgrandar.TabIndex = 31;
            this.btnAgrandar.Text = ">";
            this.btnAgrandar.UseVisualStyleBackColor = false;
            this.btnAgrandar.Click += new System.EventHandler(this.btnAgrandar_Click);
            // 
            // btnEncoger
            // 
            this.btnEncoger.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEncoger.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncoger.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncoger.Location = new System.Drawing.Point(1033, 0);
            this.btnEncoger.Name = "btnEncoger";
            this.btnEncoger.Size = new System.Drawing.Size(22, 393);
            this.btnEncoger.TabIndex = 32;
            this.btnEncoger.Text = "<";
            this.btnEncoger.UseVisualStyleBackColor = false;
            this.btnEncoger.Click += new System.EventHandler(this.btnEncoger_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridCliente);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(429, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 285);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Artículo";
            // 
            // dataGridCliente
            // 
            this.dataGridCliente.AllowUserToAddRows = false;
            this.dataGridCliente.AllowUserToDeleteRows = false;
            this.dataGridCliente.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCliente.GridColor = System.Drawing.Color.Black;
            this.dataGridCliente.Location = new System.Drawing.Point(15, 113);
            this.dataGridCliente.Name = "dataGridCliente";
            this.dataGridCliente.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCliente.Size = new System.Drawing.Size(577, 166);
            this.dataGridCliente.TabIndex = 1;
            this.dataGridCliente.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridCliente_CellMouseClick);
            this.dataGridCliente.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridCliente_CellMouseDoubleClick);
            this.dataGridCliente.SelectionChanged += new System.EventHandler(this.dataGridCliente_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.radBCodigo);
            this.groupBox2.Controls.Add(this.radButDescripcion);
            this.groupBox2.Location = new System.Drawing.Point(210, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(50, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(165, 22);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // radBCodigo
            // 
            this.radBCodigo.AutoSize = true;
            this.radBCodigo.Location = new System.Drawing.Point(141, 56);
            this.radBCodigo.Name = "radBCodigo";
            this.radBCodigo.Size = new System.Drawing.Size(67, 18);
            this.radBCodigo.TabIndex = 1;
            this.radBCodigo.TabStop = true;
            this.radBCodigo.Text = "Código";
            this.radBCodigo.UseVisualStyleBackColor = true;
            // 
            // radButDescripcion
            // 
            this.radButDescripcion.AutoSize = true;
            this.radButDescripcion.Location = new System.Drawing.Point(21, 53);
            this.radButDescripcion.Name = "radButDescripcion";
            this.radButDescripcion.Size = new System.Drawing.Size(102, 18);
            this.radButDescripcion.TabIndex = 0;
            this.radButDescripcion.TabStop = true;
            this.radButDescripcion.Text = "Descripción";
            this.radButDescripcion.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(307, 104);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 14);
            this.label8.TabIndex = 35;
            this.label8.Text = "Fecha de Compra:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 37;
            this.label9.Text = "Existencia:";
            // 
            // datimeFechaCompra
            // 
            this.datimeFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datimeFechaCompra.Location = new System.Drawing.Point(150, 76);
            this.datimeFechaCompra.Name = "datimeFechaCompra";
            this.datimeFechaCompra.Size = new System.Drawing.Size(104, 20);
            this.datimeFechaCompra.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(198, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 22);
            this.label10.TabIndex = 39;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 40;
            this.label11.Text = "Impuesto:";
            // 
            // rdbImpSi
            // 
            this.rdbImpSi.AutoSize = true;
            this.rdbImpSi.BackColor = System.Drawing.Color.Transparent;
            this.rdbImpSi.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbImpSi.ForeColor = System.Drawing.Color.White;
            this.rdbImpSi.Location = new System.Drawing.Point(150, 265);
            this.rdbImpSi.Name = "rdbImpSi";
            this.rdbImpSi.Size = new System.Drawing.Size(39, 18);
            this.rdbImpSi.TabIndex = 41;
            this.rdbImpSi.TabStop = true;
            this.rdbImpSi.Text = "Sí";
            this.rdbImpSi.UseVisualStyleBackColor = false;
            // 
            // rdbImpNo
            // 
            this.rdbImpNo.AutoSize = true;
            this.rdbImpNo.BackColor = System.Drawing.Color.Transparent;
            this.rdbImpNo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbImpNo.ForeColor = System.Drawing.Color.White;
            this.rdbImpNo.Location = new System.Drawing.Point(212, 265);
            this.rdbImpNo.Name = "rdbImpNo";
            this.rdbImpNo.Size = new System.Drawing.Size(39, 18);
            this.rdbImpNo.TabIndex = 42;
            this.rdbImpNo.TabStop = true;
            this.rdbImpNo.Text = "No";
            this.rdbImpNo.UseVisualStyleBackColor = false;
            // 
            // txtExistencia
            // 
            this.txtExistencia.AutoSize = true;
            this.txtExistencia.BackColor = System.Drawing.Color.Transparent;
            this.txtExistencia.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExistencia.ForeColor = System.Drawing.Color.Black;
            this.txtExistencia.Location = new System.Drawing.Point(151, 239);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(0, 14);
            this.txtExistencia.TabIndex = 43;
            // 
            // txtCosto
            // 
            this.txtCosto.DecimalPlaces = 2;
            this.txtCosto.Location = new System.Drawing.Point(150, 102);
            this.txtCosto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(92, 20);
            this.txtCosto.TabIndex = 44;
            this.txtCosto.ValueChanged += new System.EventHandler(this.txtCosto_ValueChanged);
            // 
            // txtUtil
            // 
            this.txtUtil.DecimalPlaces = 2;
            this.txtUtil.Location = new System.Drawing.Point(150, 128);
            this.txtUtil.Name = "txtUtil";
            this.txtUtil.Size = new System.Drawing.Size(47, 20);
            this.txtUtil.TabIndex = 45;
            this.txtUtil.ValueChanged += new System.EventHandler(this.txtUtil_ValueChanged);
            // 
            // txtPrecioPub
            // 
            this.txtPrecioPub.DecimalPlaces = 2;
            this.txtPrecioPub.Location = new System.Drawing.Point(150, 155);
            this.txtPrecioPub.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtPrecioPub.Name = "txtPrecioPub";
            this.txtPrecioPub.Size = new System.Drawing.Size(92, 20);
            this.txtPrecioPub.TabIndex = 46;
            this.txtPrecioPub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioPub_KeyPress_1);
            // 
            // frmArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ventas_Catalogos.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(422, 392);
            this.Controls.Add(this.txtPrecioPub);
            this.Controls.Add(this.txtUtil);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtExistencia);
            this.Controls.Add(this.rdbImpNo);
            this.Controls.Add(this.rdbImpSi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.datimeFechaCompra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEncoger);
            this.Controls.Add(this.btnAgrandar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodArt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro Artículo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticulo_FormClosing);
            this.Load += new System.EventHandler(this.frmArticulo_Load_1);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioPub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodArt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgrandar;
        private System.Windows.Forms.Button btnEncoger;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.RadioButton radBCodigo;
        private System.Windows.Forms.RadioButton radButDescripcion;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datimeFechaCompra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdbImpSi;
        private System.Windows.Forms.RadioButton rdbImpNo;
        private System.Windows.Forms.Label txtExistencia;
        private System.Windows.Forms.NumericUpDown txtCosto;
        private System.Windows.Forms.NumericUpDown txtUtil;
        private System.Windows.Forms.NumericUpDown txtPrecioPub;
    }
}