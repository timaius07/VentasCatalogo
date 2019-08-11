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
    public partial class frmCategoria : Form
    {
        private CategoriaBO cbo;

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cbo = new CategoriaBO();
            dataGridCateg.DataSource = cbo.GetCateg();
            this.dataGridCateg.Columns[0].Visible = false;
            dataGridCateg.Columns[1].Width = 150;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCateg.Text == "") {
                      MessageBox.Show(" No ingreso la Categoría, favor revise la información", "Registro Categoría fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cbo = new CategoriaBO();
                    Categoria mc = new Categoria()
                    {
                        NombreCategoria = txtCateg.Text,
                    };
                    cbo.IngresarCategoria(mc);
                    dataGridCateg.DataSource = cbo.GetCateg();
                    this.dataGridCateg.Columns[0].Visible = false;
                }
               
            }
            catch (Exception)
            {

                MessageBox.Show(" Faltan datos, favor revise la informacion", "Registro Categoría fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cbo = new CategoriaBO();

            if (MessageBox.Show("Realmente desea Eliminar la Marca?", " Eliminar Marca",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lblID.Text != " ")
                {
                    if (cbo.EliminaCategoria(Int32.Parse(lblID.Text)) == true)
                    {
                        MessageBox.Show("Se ha eliminado la Marca", "Eliminar Marca Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dataGridCateg.DataSource = cbo.GetCateg();
                        this.dataGridCateg.Columns[0].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show(" No ha seleccionado ningúna Marca", "Eliminar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
          

        }

        private void dataGridCateg_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = ((int)dataGridCateg.CurrentRow.Cells["Id"].Value).ToString();
                txtCateg.Text = (string)dataGridCateg.CurrentRow.Cells["NombreCategoria"].Value;
                btnEliminar.Visible = true;
            }
            catch (Exception)
            {

            }
        }

        private void frmCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
