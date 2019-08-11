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
    public partial class frmCliente : Form
    {
        private ClienteBO cbo;
        private bool modif;

        public frmCliente()
        {
            InitializeComponent();
        }

     

        private void btnAgrandar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(956, 420);
            btnAgrandar.Visible = false;
            btnEncoger.Visible =true;
        }

        private void btnEncoger_Click(object sender, EventArgs e)
        {
            this.Size = new Size(454, 420);
            btnEncoger.Visible = false;
            btnAgrandar.Visible = true;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Size = new Size(454, 420);
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cbo = new ClienteBO();

            if (modif  == true & lblID.Text != "")
            {
                Cliente pt = new Cliente()
                {

                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                    Cedula = txtNumced.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    TelefonoCasa = maskTelcasa.Text,
                    TelefonoCel = maskTelCell.Text,
                    Id = Int32 .Parse(lblID.Text)
                };
                MessageBox.Show(cbo.ModificarCli(pt), "Modificacion Cliente Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (radBNomb.Checked == true)
                {
                    dataGridCliente.DataSource = cbo.GetCliente(txtBuscar.Text);
                }
                else if (radBCed.Checked == true)
                {
                    dataGridCliente.DataSource = cbo.GetClienteCed(txtBuscar.Text);
                }
            }
            else
            {
                Cliente pt = new Cliente()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                    Cedula = txtNumced.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    TelefonoCasa = maskTelcasa.Text,
                    TelefonoCel = maskTelCell.Text,
                    EstadoCliente = chkCuentas2.Checked
                };
                MessageBox.Show(cbo.Validar(pt), "Registro Cliente Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }          
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cbo = new ClienteBO();

            if (radBNomb.Checked == true)
            {
                dataGridCliente.DataSource = cbo.GetCliente(txtBuscar.Text);
            }else if (radBCed.Checked == true)
            {
                dataGridCliente.DataSource = cbo.GetClienteCed(txtBuscar.Text);
            }
            
            this.dataGridCliente.Columns[0].Visible = false;
            this.dataGridCliente.Columns[2].Visible = false;
            this.dataGridCliente.Columns[4].Visible = false;
            this.dataGridCliente.Columns[5].Visible = false;
            this.dataGridCliente.Columns[8].Visible = false;
            modif = true;

            if (txtBuscar.Text == "")
            {
                LimpiarDatos();
            }

        }

        private void dataGridCliente_SelectionChanged(object sender, EventArgs e)
        {
            string resultado = "";
            
            try
            {
                lblID.Text = ((int)dataGridCliente.CurrentRow.Cells["Id"].Value).ToString();
                txtNombre.Text = (string)dataGridCliente.CurrentRow.Cells["Nombre"].Value;
                resultado= (string)dataGridCliente.CurrentRow.Cells["Nombre"].Value;
                txtApellidos.Text = (string)dataGridCliente.CurrentRow.Cells["Apellido"].Value;
                txtNumced.Text = (string)dataGridCliente.CurrentRow.Cells["Cedula"].Value;
                txtDireccion.Text = (string)dataGridCliente.CurrentRow.Cells["Direccion"].Value;
                txtEmail.Text = (string)dataGridCliente.CurrentRow.Cells["Email"].Value;
                maskTelcasa.Text = (string)dataGridCliente.CurrentRow.Cells["TelefonoCasa"].Value;
                maskTelCell.Text = (string)dataGridCliente.CurrentRow.Cells["TelefonoCel"].Value;
                chkCuentas2.Checked = (bool)dataGridCliente.CurrentRow.Cells["EstadoCliente"].Value;
                btnEliminar.Visible = true;
            }
            catch (Exception )
            {
             
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cbo = new ClienteBO();

            if (MessageBox.Show("Realmente desea Eliminar el cliente?", " Eliminar Cliente",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               if (lblID.Text != " " & chkCuentas2.Checked==false)
                {
                   if (cbo.EliminarCliente(Int32.Parse(lblID.Text)) == true)
                    {
                        LimpiarDatos();
                        MessageBox.Show("Se ha eliminado el cliente", "Eliminar Cliente Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (chkCuentas2.Checked == true)
                {
                    MessageBox.Show("El Cliente seleccionado tiene CUENTAS PENDIENTES", "Eliminar Cliente Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else{
                    MessageBox.Show(" No ha seleccionado ningún Cliente", "Eliminar Cliente Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                
            }
        }

        private void LimpiarDatos()
        {
            dataGridCliente.DataSource = null;
            lblID.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtNumced.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            maskTelcasa.Text = "";
            maskTelCell.Text = "";
            chkCuentas2.Checked = false;
            btnEliminar.Visible = false;
            txtBuscar.Text = "";
            modif = false;
        }

        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
