namespace Ventas_Catalogos.GUI
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.menuStrpVentas = new System.Windows.Forms.MenuStrip();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClieenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoArToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPedidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrpVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrpVentas
            // 
            this.menuStrpVentas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrpVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarToolStripMenuItem,
            this.facturaciónToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.menuStrpVentas.Location = new System.Drawing.Point(0, 0);
            this.menuStrpVentas.Name = "menuStrpVentas";
            this.menuStrpVentas.Size = new System.Drawing.Size(498, 24);
            this.menuStrpVentas.TabIndex = 0;
            this.menuStrpVentas.Text = "menuStrip1";
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClieenteToolStripMenuItem,
            this.nuevoArToolStripMenuItem,
            this.nuevaMarcaToolStripMenuItem,
            this.nuevaCategoríaToolStripMenuItem});
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ingresarToolStripMenuItem.Text = "Ingresar";
            // 
            // nuevoClieenteToolStripMenuItem
            // 
            this.nuevoClieenteToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevoClieenteToolStripMenuItem.Image = global::Ventas_Catalogos.Properties.Resources.NetByte_Design_Studio___1137;
            this.nuevoClieenteToolStripMenuItem.Name = "nuevoClieenteToolStripMenuItem";
            this.nuevoClieenteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.nuevoClieenteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClieenteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClieenteToolStripMenuItem_Click);
            // 
            // nuevoArToolStripMenuItem
            // 
            this.nuevoArToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevoArToolStripMenuItem.Image = global::Ventas_Catalogos.Properties.Resources.NetByte_Design_Studio___0078;
            this.nuevoArToolStripMenuItem.Name = "nuevoArToolStripMenuItem";
            this.nuevoArToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.nuevoArToolStripMenuItem.Text = "Nuevo Artículo";
            this.nuevoArToolStripMenuItem.Click += new System.EventHandler(this.nuevoArToolStripMenuItem_Click);
            // 
            // nuevaMarcaToolStripMenuItem
            // 
            this.nuevaMarcaToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevaMarcaToolStripMenuItem.Image = global::Ventas_Catalogos.Properties.Resources._220px_Copyright_svg;
            this.nuevaMarcaToolStripMenuItem.Name = "nuevaMarcaToolStripMenuItem";
            this.nuevaMarcaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.nuevaMarcaToolStripMenuItem.Text = "Nueva Marca";
            this.nuevaMarcaToolStripMenuItem.Click += new System.EventHandler(this.nuevaMarcaToolStripMenuItem_Click);
            // 
            // nuevaCategoríaToolStripMenuItem
            // 
            this.nuevaCategoríaToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevaCategoríaToolStripMenuItem.Image = global::Ventas_Catalogos.Properties.Resources.icon_wamms;
            this.nuevaCategoríaToolStripMenuItem.Name = "nuevaCategoríaToolStripMenuItem";
            this.nuevaCategoríaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.nuevaCategoríaToolStripMenuItem.Text = "Nueva Categoría";
            this.nuevaCategoríaToolStripMenuItem.Click += new System.EventHandler(this.nuevaCategoríaToolStripMenuItem_Click);
            // 
            // facturaciónToolStripMenuItem
            // 
            this.facturaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaFacturaToolStripMenuItem,
            this.consultarFacturaToolStripMenuItem});
            this.facturaciónToolStripMenuItem.Name = "facturaciónToolStripMenuItem";
            this.facturaciónToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.facturaciónToolStripMenuItem.Text = "Facturación";
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            this.nuevaFacturaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nuevaFacturaToolStripMenuItem.Text = "Nueva Factura";
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click);
            // 
            // consultarFacturaToolStripMenuItem
            // 
            this.consultarFacturaToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.consultarFacturaToolStripMenuItem.Name = "consultarFacturaToolStripMenuItem";
            this.consultarFacturaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.consultarFacturaToolStripMenuItem.Text = "Consultar  Factura";
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoPedidoToolStripMenuItem1,
            this.consultarPedidoToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // nuevoPedidoToolStripMenuItem1
            // 
            this.nuevoPedidoToolStripMenuItem1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.nuevoPedidoToolStripMenuItem1.Name = "nuevoPedidoToolStripMenuItem1";
            this.nuevoPedidoToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.nuevoPedidoToolStripMenuItem1.Text = "Nuevo Pedido";
            // 
            // consultarPedidoToolStripMenuItem
            // 
            this.consultarPedidoToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.consultarPedidoToolStripMenuItem.Name = "consultarPedidoToolStripMenuItem";
            this.consultarPedidoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.consultarPedidoToolStripMenuItem.Text = "Consultar Pedido";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ventas_Catalogos.Properties.Resources.log6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(498, 331);
            this.Controls.Add(this.menuStrpVentas);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrpVentas;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.menuStrpVentas.ResumeLayout(false);
            this.menuStrpVentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrpVentas;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClieenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoArToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoPedidoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaMarcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCategoríaToolStripMenuItem;
    }
}