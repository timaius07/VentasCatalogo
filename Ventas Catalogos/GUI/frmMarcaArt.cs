using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas_Catalogos.BO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.GUI
{
    public partial class frmMarcaArt : Form
    {
        private MarcaBO mbo;
        

        public frmMarcaArt()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            mbo = new MarcaBO();

            Marca mc = new Marca()
            {
                NombreMarca = txtMarca.Text,
                
            };
            MessageBox.Show(mbo.IngresarMarca(mc), "Registro Marca Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridMarca.DataSource = mbo.GetMarcas();
            this.dataGridMarca.Columns[0].Visible = false;
        }

        private void frmMarcaArt_Load(object sender, EventArgs e)
        {
            mbo = new MarcaBO();
            dataGridMarca.DataSource = mbo.GetMarcas();
            this.dataGridMarca.Columns[0].Visible = false;
            dataGridMarca.Columns[1].Width = 150;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            mbo = new MarcaBO();

            if (MessageBox.Show("Realmente desea Eliminar la Marca?", " Eliminar Marca",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lblID.Text != " ")
                {
                    if (mbo.EliminarMarca(Int32.Parse(lblID.Text)) == true)
                    {
                        MessageBox.Show("Se ha eliminado la Marca", "Eliminar Marca Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dataGridMarca.DataSource = mbo.GetMarcas();
                        this.dataGridMarca.Columns[0].Visible = false;
                    }
                   else
                    {
                    MessageBox.Show(" No ha seleccionado ningúna Marca", "Eliminar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            }
           
        }

        private void dataGridMarca_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = ((int)dataGridMarca.CurrentRow.Cells["Id"].Value).ToString();
                txtMarca.Text = (string)dataGridMarca.CurrentRow.Cells["NombreMarca"].Value;
                btnEliminar.Visible = true;
            }
            catch (Exception)
            {

            }
        }

        private void frmMarcaArt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
