using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas_Catalogos.BO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.GUI
{
    public partial class frmArticulo : Form
    {
        private MarcaBO mbo;
        private CategoriaBO cbo;
        private ArticuloBO abo;
        public Articulo Articulo { get; set; }
        public bool modif = false;
        private double util = 0;
        private double prec = 0;
        public int idCategoria = 0;
        public int idMarca = 0;
        private double prcosto = 0;
        private double prpubli = 0;
        private double prutil = 0;
        private bool impuesto = false;
       
        List<Articulo> lis = new List<Articulo>();
        
        
        public frmArticulo()
        {
            InitializeComponent();
           
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
        private void btnAgrandar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1069, 431);
            btnAgrandar.Visible = false;
            btnEncoger.Visible = true;
            radButDescripcion.Checked = true;
        }

        private void btnEncoger_Click(object sender, EventArgs e)
        {
            this.Size = new Size(437, 431);
            btnAgrandar.Visible = true;
            btnEncoger.Visible = false;
            txtBuscar.Text = "";
        }

        private void frmArticulo_Load_1(object sender, EventArgs e)
        {
            this.Size = new Size(437, 431);
            cbo = new CategoriaBO();
            mbo = new MarcaBO();
            List<Categoria> dims = cbo.GetCateg();
            cmbDepartamento.Items.AddRange(dims.ToArray<Categoria>());
            List<Marca> marc = mbo.GetMarcas();
            cmbMarca.Items.AddRange(marc.ToArray<Marca>());
            rdbImpSi.Checked = true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            prcosto =Convert.ToDouble(txtCosto.Value) ;
            prpubli = Convert.ToDouble(txtPrecioPub.Value);
            prutil = Convert.ToDouble(txtUtil.Value);
            abo = new ArticuloBO();

            if (modif == true & txtCodArt.Text != "")
            {
                Articulo at = new Articulo()
                {
                    Cod_Art = txtCodArt.Text,
                    Descrip = txtDescp.Text,
                    Fecha_Compra = Convert.ToDateTime(datimeFechaCompra.Text),
                    Precio_Cost = Convert.ToDecimal(prcosto) ,
                    Porc_Util= Convert.ToUInt32(prutil),
                    Precio_Venta =Convert.ToDecimal(prpubli),
                    Cod_Marca = (Marca)cmbMarca.SelectedItem,
                    Cod_Depart = (Categoria)cmbDepartamento.SelectedItem,
                    Cantidad_Invt = Convert.ToInt32(txtExistencia.Text),
                    Impuesto = rdbImpSi.Checked

                };
                MessageBox.Show(abo.ModificarArt(at), "Modificacion Artículo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
               
            {
                txtExistencia.Text = "0";
                try
                {
                    Articulo at = new Articulo()
                    {

                        Cod_Art = txtCodArt.Text,
                        Descrip = txtDescp.Text,
                        Fecha_Compra = Convert.ToDateTime(datimeFechaCompra.Text),
                        Precio_Cost = Convert.ToDecimal(prcosto),
                        Porc_Util = Convert.ToUInt32(prutil),
                        Precio_Venta = Convert.ToDecimal(prpubli),
                        Cod_Marca = (Marca)cmbMarca.SelectedItem,
                        Cod_Depart = (Categoria)cmbDepartamento.SelectedItem,
                        Cantidad_Invt = Convert.ToInt32(txtExistencia.Text),
                        Impuesto = rdbImpSi.Checked
                    };
                    MessageBox.Show(abo.IngrearArt(at), "Registro Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception )
                {

                    throw;
                }
               
            }

            if (radBCodigo.Checked == true)
            {
                this.buscarArt();
            }
            else if (radButDescripcion.Checked == true)
            {
                this.buscarArt();
            }
        }

        private void dataGridCliente_SelectionChanged(object sender, EventArgs e)
        {
            
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            dataGridCliente.DataSource = null;
            this.buscarArt();

            modif = true;
            txtCodArt.Enabled = false;
            
            if (txtBuscar.Text == "")
            {
                LimpiarDatos();
            }

        }

        private void LimpiarDatos()
        {
            dataGridCliente.DataSource = null;
            lblID.Text = "";
            txtCodArt.Text = "";
            txtDescp.Text = "";
            datimeFechaCompra.Text = "";
            txtCosto.Text = "0";
            txtUtil.Text = "0";
            txtPrecioPub.Text = "0";
            txtBuscar.Text = "";
            txtExistencia.Text = "";
            modif = false;
            txtCodArt.Enabled = true;
            txtExistencia.Enabled = true;
            datimeFechaCompra.Enabled = true;
        }
        private void Habilitar()
        {
            txtDescp.Enabled = true;
            txtCosto.Enabled = true;
            txtUtil.Enabled = true;
            txtPrecioPub.Enabled = true;
          
            cmbDepartamento.Enabled = true;
            cmbMarca.Enabled = true;
        }


        private void buscarArt()
        {
            abo = new ArticuloBO();
            dataGridCliente.DataSource = null;
            try
            {
                if (radButDescripcion.Checked == true)
                {              
                    lis = abo.GetDescArt(txtBuscar.Text);
                    idCategoria = lis[0].Cod_Depart.Id;
                    idMarca = lis[0].Cod_Marca.Id;
                    dataGridCliente.DataSource = lis;
                }
                else if (radBCodigo.Checked == true)
                {
                    lis = abo.GetArtCod(txtBuscar.Text);
                    idCategoria = lis[0].Cod_Depart.Id;
                    idMarca = lis[0].Cod_Marca.Id;
                    dataGridCliente.DataSource = lis;
                }
                this.OcultarDatagrid();
            }
            catch (Exception )
            {


            }
        }
  

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarDatos();
            this.Habilitar();
        }

        private void dataGridCliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtDescp.Enabled = false;
            txtCosto.Enabled = false;
            txtUtil.Enabled = false;
            txtPrecioPub.Enabled = false;
            
            cmbDepartamento.Enabled = false;
            cmbMarca.Enabled = false;
            try
            {
                txtCodArt.Text = (string)dataGridCliente.CurrentRow.Cells["Cod_Art"].Value;
                txtDescp.Text = (string)dataGridCliente.CurrentRow.Cells["Descrip"].Value;
                datimeFechaCompra.Text = ((DateTime)dataGridCliente.CurrentRow.Cells["Fecha_Compra"].Value).ToString();
                txtCosto.Value = ((decimal)dataGridCliente.CurrentRow.Cells["Precio_Cost"].Value);
                txtUtil.Value = ((decimal)dataGridCliente.CurrentRow.Cells["Porc_Util"].Value);
                txtPrecioPub.Value = ((decimal)dataGridCliente.CurrentRow.Cells["Precio_Venta"].Value);
                txtExistencia.Text = ((int)dataGridCliente.CurrentRow.Cells["Cantidad_Invt"].Value).ToString();
                impuesto = (bool)dataGridCliente.CurrentRow.Cells["Impuesto"].Value;
                if (impuesto == false)
                {
                    rdbImpNo.Checked = true;
                }
                else
                {
                    rdbImpSi.Checked = true;
                }
                txtCodArt.Enabled = false;
                
                datimeFechaCompra.Enabled = false;
           
                int pos = e.RowIndex;                  
                idCategoria = lis[pos].Cod_Depart.Id;
                idMarca = lis[pos].Cod_Marca.Id;
                
                for (int i = 0; i < cmbMarca.Items.Count; i++)
                {
                    if (((Marca)cmbMarca.Items[i]).Id == idMarca)
                    {
                        cmbMarca.SelectedIndex = i;
                    }
                }
                //**************
                for (int i = 0; i < cmbDepartamento.Items.Count; i++)
                {
                    if (((Categoria)cmbDepartamento.Items[i]).Id == idCategoria)
                    {
                        cmbDepartamento.SelectedIndex = i;
                    }
                }               
            }
            catch (Exception )
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioPub_KeyPress(object sender, KeyPressEventArgs e)
       {

        }

     
        private void OcultarDatagrid()
        {
            // this.dataGridCliente.Columns[0].Visible = false;
            this.dataGridCliente.Columns[2].Visible = false;
            this.dataGridCliente.Columns[3].Visible = false;
            //this.dataGridCliente.Columns[5].Visible = false;
            this.dataGridCliente.Columns[7].Visible = false;
            this.dataGridCliente.Columns[8].Visible = false;
            this.dataGridCliente.Columns[9].Visible = false;
            dataGridCliente.Columns[0].Width = 130;
            dataGridCliente.Columns[1].Width = 150;
            dataGridCliente.Columns[4].Width = 92;
            dataGridCliente.Columns[5].Width = 67;
            dataGridCliente.Columns[6].Width = 92;
            dataGridCliente.Columns[0].HeaderText = "Codigo";
            dataGridCliente.Columns[1].HeaderText = "Descripción";
            dataGridCliente.Columns[4].HeaderText = "Costo";
            dataGridCliente.Columns[5].HeaderText = "Utilidad";
            dataGridCliente.Columns[6].HeaderText = "Venta";
        }

        private void dataGridCliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtDescp.Enabled = true;
            txtCosto.Enabled = true;
            txtUtil.Enabled = true;
            txtPrecioPub.Enabled = true;
            cmbDepartamento.Enabled = true;
            cmbMarca.Enabled = true;
            try
            {
                if (radButDescripcion.Checked == true)
                {
                    txtBuscar.Text = txtDescp.Text;
                }
                else if (radBCodigo.Checked == true)
                {
                    txtBuscar.Text = txtCodArt.Text;
                }

            }
            catch (Exception)
            {


            }
        }

        private void txtCosto_ValueChanged(object sender, EventArgs e)
        {
           
            prcosto = Double.Parse(txtCosto.Text);           
            this.Cambiar_Costo();
        }

        private void txtUtil_ValueChanged(object sender, EventArgs e)
        {
            this.Cambiar_Costo();
        }

        private void Cambiar_Costo()
        {

            if (txtUtil.Text != "")
            {
                prcosto = Double.Parse(txtCosto.Text);
                prutil = Double.Parse(txtUtil.Value.ToString());
                int porc = 100;
                util = (prutil / porc) * prcosto;
                util = util + prcosto;
                txtPrecioPub.Text = (util.ToString());
            }
        }
        private void txtPrecioPub_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    if (txtPrecioPub.Text != "")
                    {
                        prpubli = 0;

                        prpubli = Double.Parse(txtPrecioPub.Text);
                        int porc = 100;
                        prec = porc * (prpubli / prcosto);
                        prec -= 100;
                        txtUtil.Text = (prec.ToString());
                        // txtPrecioPub.Text = prpubli.ToString();
                    }
                }
                catch (Exception )
                {
                }
            }

        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
