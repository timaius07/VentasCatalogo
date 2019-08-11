using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas_Catalogos.GUI
{
    public partial class frmMenu : Form
    {


        public frmMenu()
        {
            InitializeComponent();
        }

        private void nuevoClieenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmCli = new frmCliente();
            frmCli.Show(this);
            this.Hide();
        }

        private void nuevoArToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frmArt = new frmArticulo();
            frmArt.Show(this);
            this.Hide();
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaArt frmMArt = new frmMarcaArt();
            frmMArt.Show(this);
            this.Hide();
        }

        private void nuevaCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frmCatart = new frmCategoria();
            frmCatart.Show(this);
            this.Hide();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura frmFactCompra = new frmFactura();
            frmFactCompra.Show(this);
            this.Hide();
        }
    }
}
