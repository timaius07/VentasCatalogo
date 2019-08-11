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
    public partial class frmProvedor : Form
    {

        private ProvedorBO pbo;
        private bool modif;
        List<Provedor> lis = new List<Provedor>();
       

    public frmProvedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pbo = new ProvedorBO();

            if (modif == true & lblID.Text != "")
            {
                Provedor pt = new Provedor()
                {

                    RazonSocial = txtRazonSoc.Text,
                    RazonComercial = txtRazonCom.Text,
                    Cedula = txtCedJuri.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    TelefonoEmpresa = maskTelcasa.Text,
                    TelefonoCel = maskTelCell.Text,
                    DiasCredito = Convert.ToInt32(cmbDias.Text),
                    Id = Int32.Parse(lblID.Text)
                };
                MessageBox.Show(pbo.ModificarProv(pt), "Modificacion Provedor Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                dataGridProvedor.DataSource = pbo.GetProvedor(txtBuscar.Text);
            }
            else
            {
                Provedor pt = new Provedor()
                {
                    RazonSocial = txtRazonSoc.Text,
                    RazonComercial = txtRazonCom.Text,
                    Cedula = txtCedJuri.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    TelefonoEmpresa = maskTelcasa.Text,
                    TelefonoCel = maskTelCell.Text,
                    DiasCredito =Convert.ToInt32(cmbDias.Text) 
                };
                MessageBox.Show(pbo.Validar(pt), "Registro Provedor Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarDatos();
            }
        }

        private void btnAgrandar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(977, 411); 
            btnAgrandar.Visible = false;
            btnEncoger.Visible = true;
        }

        private void btnEncoger_Click(object sender, EventArgs e)
        {
            this.Size = new Size(446, 411);
            btnEncoger.Visible = false;
            btnAgrandar.Visible = true;
        }

        private void frmProvedor_Load(object sender, EventArgs e)
        {

            this.Size = new Size(446, 411);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            pbo = new ProvedorBO();

            if (MessageBox.Show("Realmente desea Eliminar el Provedor?", " Eliminar Provedor",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lblID.Text != " ")
                {
                    if (pbo.EliminarProvedor(Int32.Parse(lblID.Text)) == true)
                    {
                        LimpiarDatos();
                        MessageBox.Show("Se ha eliminado el provedor", "Eliminar Provedor Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El Provedor seleccionado tiene FACTURAS PENDIENTES", "Eliminar Provedor Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            pbo = new ProvedorBO();
            dataGridProvedor.DataSource = pbo.GetProvedor(txtBuscar.Text);
            lis = pbo.GetProvedor(txtBuscar.Text);
            //Zermat

            this.dataGridProvedor.Columns[0].Visible = false;
            this.dataGridProvedor.Columns[4].Visible = false;
            this.dataGridProvedor.Columns[5].Visible = false;
            this.dataGridProvedor.Columns[7].Visible = false;
            this.dataGridProvedor.Columns[2].Visible = false;
            modif = true;

            if (txtBuscar.Text == "")
            {
                LimpiarDatos();
            }
        }


        private void LimpiarDatos()
        {
            dataGridProvedor.DataSource = null;
            lblID.Text = "";
            txtRazonSoc.Text = "";
            txtRazonCom.Text = "";
            txtCedJuri.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            maskTelcasa.Text = "";
            maskTelCell.Text = "";          
            btnEliminar.Visible = false;
            txtBuscar.Text = "";
            modif = false;
        }

        private void dataGridProvedor_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarDatos();
        }

        private void frmProvedor_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Owner.Show();
        }

        private void dataGridProvedor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string diacomb = "";

            try
            {
                lblID.Text = ((int)dataGridProvedor.CurrentRow.Cells["Id"].Value).ToString();
                txtRazonSoc.Text = (string)dataGridProvedor.CurrentRow.Cells["RazonSocial"].Value;
                txtRazonCom.Text = (string)dataGridProvedor.CurrentRow.Cells["RazonComercial"].Value;
                txtCedJuri.Text = (string)dataGridProvedor.CurrentRow.Cells["Cedula"].Value;
                txtDireccion.Text = (string)dataGridProvedor.CurrentRow.Cells["Direccion"].Value;
                txtEmail.Text = (string)dataGridProvedor.CurrentRow.Cells["Email"].Value;
                maskTelcasa.Text = (string)dataGridProvedor.CurrentRow.Cells["TelefonoEmpresa"].Value;
                maskTelCell.Text = (string)dataGridProvedor.CurrentRow.Cells["TelefonoCel"].Value;
                diacomb = ((int)dataGridProvedor.CurrentRow.Cells["DiasCredito"].Value).ToString();
                btnEliminar.Visible = true;
                int pos = e.RowIndex;
                int diascredito;
                diascredito = lis[pos].DiasCredito;
                for (int i = 0; i < cmbDias.Items.Count; i++)
                {
                    if ((cmbDias.Items[i]).Equals(diascredito.ToString()) )
                    {
                        cmbDias.SelectedIndex = i;
                    }
                }
            }
            catch (Exception )
            {

            }
        }
    }
}
