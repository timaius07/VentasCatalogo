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
    public partial class frmFactura : Form
    {
        //acceso al BO de articulos
        private ArticuloBO abo;
        //acceso al BO de provedor
        private ProvedorBO pbo;
        //acceso al BO de factura provedor
        private FacturaProvBO fpbo;
        //acceso al BO de factura provedor
        private FacturaArticBO fabo;
        //acceso al BO de factura precio
        private FacturaPrecioBO fprbo;
        //acceso a la entidad articulo
        public Articulo Articulo { get; set; }
        //acceso a la entidad provedor
        public Provedor Provedor { get; set; }
        //acceso a la entidad FacturaProv
        public FacturaProv FacturaProv { get; set; }
        //acceso a la entidad FacturaProv
        public FacturaArtc FacturaArtc { get; set; }
        //acceso a la entidad FacturaPrec
        public FacturaPrecio FacturaPrecio { get; set; }
        //almacena los articulos buscados desde el txtCodarticulo
        List<Articulo> lis = new List<Articulo>();
        List<Provedor> lisProid = new List<Provedor>();
        //lista almacena los datos de FacturaProv ;
        List<FacturaProv> lisfactProv = new List<FacturaProv>();

        //verifica si el articulo posse impuesto
        private bool impuesto = false;
        //permite buscar el articulo solo si es verdadera
        private bool salir = false;
        //
        private bool subtotal = false;
        //verifica si se va a modificar la fila del datagrid
        private bool modificar=false;
        //verifica si se va a modificar o guardar la factura
        private bool guardafactura = false;
        //verifica si la factura sufrio algun cambio para guardarla nuevamente
        private bool modificafactura = false;
        //verifica que se haya cargado la factura buscada para validar al momento de guardar
        //de nuevo la factura
        private bool buscarfactura = false;
        //verifica que la factura se guardo recientemente
        private bool salvarfactura = false;
        int porc = 100;
        //contiene la posicion de la fila del datagrid
        int posicion = 0;
        //contiene la utilidad del articulo
        private double util = 0;
        //contiene el valor del impuesto
        private double iv = 13;
        //almacena el id de las facturas de provedor-articulos
        //para establecer la relacion
        int relartfac = 0;
        //variables usadas en el calculo de los precios, descuentos y impuestos
        private double prec = 0;
        private double prcosto = 0;
        private double prpubli = 0;
        private double prutil = 0;
        private double prdescuento = 0;
        private double descuento = 0;
        private double descuento2= 0;
        private double montdescuento = 0;
        private double montimpuesto = 0;
        private double SubIV=0;
        double totalcdesc = 0;
        double totalimp = 0;
        //*************************************************************************
        //calculan los montos finales de las facturas
        decimal subtotalfactura = 0;
        decimal descuentofactura = 0;
        decimal impuestofactura = 0;
        decimal totalfinalfactura = 0;
        //*********************************************************
        //variables que obtienen los resultados de la busqueda
        string numfact1 = "";
        string nombreprov1 = "";
        string idprov1 = "";
        string formapag1 = "";
        string fecha1 = "";
        string descrp1 = "";
        bool aplicinv1 = false;
        bool finfact1 = false;
        //para verificar en que momento se realiza una busqueda
        bool buscar = false;

        public int CurrencyDecimalDigits { get; set; }
        NumberFormatInfo nfi = new CultureInfo("es-CR", false).NumberFormat;

        public frmFactura()
        {
            InitializeComponent();
        }

        private void ResultBusqueda()
        {
           lblNumfact.Text = numfact1;
           lblNomProvedor.Text= nombreprov1;
           lblIdProvedor.Text = idprov1;
           lblFormPago.Text = formapag1;
           datetimeFechaFact.Text = fecha1;
           txtDescp.Text = descrp1;
           chkAplicaInv.Checked = aplicinv1;
           chkfinfact.Checked = finfact1;
        }
        private void LimpiarArt()
        {
            txtDescp.Text = "";
            txtCodArt.Text = "";
            txtCosto.Value = 0;
            txtUtil.Value = 0;
            txtPrecioPub.Value = 0;
          
            salir = false;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            this.IniciarDatagridArt();
            this.IniciarDatagrid();
            btnModificar.Enabled = false;
            btnQuitar.Enabled = false;
            GroupArt.Visible = false;
            pbo = new ProvedorBO();
            fpbo = new FacturaProvBO();
            fabo = new FacturaArticBO();
            fprbo = new FacturaPrecioBO();
            abo = new ArticuloBO();
            List<Provedor> dims = pbo.GetProvedorID();
            cmbRazSoc.Items.AddRange(dims.ToArray<Provedor>());
            cmbRazSoc2.Items.AddRange(dims.ToArray<Provedor>());
            lisProid = pbo.GetProvedorID();
            for (int i = 0; i < lisProid.Count; i++)
            {
                cmbID.Items.Add(lisProid[i].Id);
                cmbID2.Items.Add(lisProid[i].Id);
            }
            panelBuscar.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.LimpiarArt();
            GroupArt.Visible = false;
        }

        private void btnArtExit_Click(object sender, EventArgs e)
        {
            this.LimpiarArt();
            GroupArt.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            salir = false;
            modificafactura = true;
            salvarfactura = false;
            GroupArt.Visible = true;
            txtCodArt.Focus();
            txtCodArt.Enabled = true;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((posicion >= 0) & (dataGridArt[0, posicion].Value.ToString() != ""))
                {
                    this.ModificarArticulo();
                    modificafactura = true;
                    salvarfactura = false;
                }             
            }
            catch (Exception)
            {
                GroupArt.Visible = false;
                MessageBox.Show("No se pueden Modificar Filas", "Error al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ModificarArticulo()
        {
            try
            {

                modificar = true;
                GroupArt.Visible = true;
                txtCodArt.Focus();
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 0;
                txtCodArt.Text = (string)dataGridFact.CurrentRow.Cells["Codigo Art"].Value;
                txtDescp.Text = (string)dataGridFact.CurrentRow.Cells["Descripción"].Value.ToString();
                txtCantidad.Text = (string)dataGridFact.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtCosto.Text = (string)dataGridFact.CurrentRow.Cells["Precio"].Value.ToString();
                txtSubTotal.Text = (string)dataGridFact.CurrentRow.Cells["SubTotal"].Value.ToString();
                txtDescuento.Text = (string)dataGridFact.CurrentRow.Cells["% Desc"].Value.ToString();
                txtSubTotal1.Text = (string)dataGridFact.CurrentRow.Cells["SubTotal Desc"].Value.ToString();
                txtTotalIV.Text = (string)dataGridFact.CurrentRow.Cells["SubTotal  I.V"].Value.ToString();
                txtTotalFinal.Text = (string)dataGridFact.CurrentRow.Cells["Total Final"].Value.ToString();
                impuesto = (bool)dataGridFact.CurrentRow.Cells["I.V"].Value;
                txtPrecioPub.Text = (string)dataGridArt.CurrentRow.Cells["Precio Público"].Value.ToString();
                txtCostoPrecio.Text = (string)dataGridArt.CurrentRow.Cells["Costo"].Value.ToString();
                txtUtil.Text = (string)dataGridArt.CurrentRow.Cells["Utilidad"].Value.ToString();
                checkBox1.Checked = (bool)dataGridArt.CurrentRow.Cells["Aplica Descuento"].Value;
                if (impuesto == false)
                {
                    rdbImpNo.Checked = true;
                }
                else
                {
                    rdbImpSi.Checked = true;
                }
            }
            catch (Exception)
            {
            }
        }
        private void txtCodArt_TextChanged(object sender, EventArgs e)
        {
      
        
           
        }

        private void btnArtOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar == false & txtCantidad.Value > 0)
                {
                    //objeto que contiene los datos del articulo a insertar en el datagridFactura
                    object[] row1 = new object[] { txtCodArt.Text,txtDescp.Text, txtCantidad.Value.ToString(), txtCosto.Value.ToString(),
               txtSubTotal.Value.ToString(),txtDescuento.Value.ToString(),montdescuento.ToString(),txtSubTotal1.Value.ToString(),
               montimpuesto.ToString(), txtTotalIV.Value.ToString(),txtTotalFinal.Value.ToString(), impuesto,
           "**" };
                    dataGridFact.Rows.Add(row1);
                    //*********************************************************************
                    //objeto que contiene los datos del ariculo a insertar en el datadridArticulo
                    object[] row2 = new object[] { txtCodArt.Text,txtDescp.Text,txtCostoPrecio.Value.ToString(),
              txtUtil.Value.ToString(),txtPrecioPub.Value.ToString(),checkBox1.Checked,
           "**" };
                    dataGridArt.Rows.Add(row2);
                    //*********************************************************************
                    dataGridArt.Refresh();
                    salir = true;
                    this.GroupArt.Visible = false;
                    LimpiarIngreso();
                }
                else if (modificar == true & txtCantidad.Value > 0)
                {
                    //insertar los valores modificados del dataGridFact
                    dataGridFact[0, posicion].Value = txtCodArt.Text;
                    dataGridFact[1, posicion].Value = txtDescp.Text;
                    dataGridFact[2, posicion].Value = txtCantidad.Value;
                    dataGridFact[3, posicion].Value = txtCosto.Value;
                    dataGridFact[4, posicion].Value = txtSubTotal.Value;
                    dataGridFact[5, posicion].Value = txtDescuento.Value;
                    dataGridFact[6, posicion].Value = montdescuento;
                    dataGridFact[7, posicion].Value = txtSubTotal1.Value;
                    dataGridFact[8, posicion].Value = montimpuesto;
                    dataGridFact[9, posicion].Value = txtTotalIV.Value;
                    dataGridFact[10, posicion].Value = txtTotalFinal.Value;
                    dataGridFact[11, posicion].Value = impuesto;
                    //insertar los valores modificados del dataGridArticulos
                    dataGridArt[0, posicion].Value = txtCodArt.Text;
                    dataGridArt[1, posicion].Value = txtDescp.Text;
                    dataGridArt[2, posicion].Value = txtCostoPrecio.Text;
                    dataGridArt[3, posicion].Value = txtUtil.Text;
                    dataGridArt[4, posicion].Value = txtPrecioPub.Text;
                    dataGridArt[5, posicion].Value = checkBox1.Checked;
                    modificar = false;
                    salir = true;
                    this.GroupArt.Visible = false;
                    this.LimpiarIngreso();

                }
                else
                {
                    MessageBox.Show("La cantidad debe ser Mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.SumarTotales();
                btnQuitar.Enabled = true;
                btnModificar.Enabled = true;
                txtCodArt.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        private void SumarTotales()
        {
            subtotalfactura = 0;
            descuentofactura = 0;
            impuestofactura = 0;
            totalfinalfactura = 0;
            foreach (DataGridViewRow row in dataGridFact.Rows)
            {
                //string codigo = Convert.ToString(row.Cells["Codigo"].Value);

                subtotalfactura +=  Convert.ToDecimal(row.Cells["SubTotal"].Value);
                descuentofactura += Convert.ToDecimal(row.Cells["Monto Desc"].Value);
                impuestofactura += Convert.ToDecimal(row.Cells["Monto IV"].Value);
                totalfinalfactura += Convert.ToDecimal(row.Cells["Total Final"].Value);
            }

            txtmontoSubtotal.Text = (subtotalfactura.ToString("C", nfi));
            txtmontoDescu.Text = (descuentofactura.ToString("C", nfi));
            txtmontoIV.Text = (impuestofactura.ToString("C", nfi));
            txtmontoFinal.Text = (totalfinalfactura.ToString("C", nfi));
            
        }

        private void LimpiarIngreso()
        {
            txtCodArt.Text = "";
            txtDescp.Text = "";
            rdbImpNo.Checked = false;
            rdbImpSi.Checked = false;
            txtCantidad.Value = 0;
            txtCosto.Value = 0;
            txtSubTotal.Value = 0;
            txtDescuento.Value = 0;
            txtSubTotal1.Value = 0;
            txtTotalIV.Value = 0;
            txtTotalFinal.Value = 0;
            checkBox1.Checked = false;
            txtCostoPrecio.Value = 0;
            txtUtil.Value = 0;
            txtPrecioPub.Value = 0;
            prec = 0;
            prcosto = 0;
            prpubli = 0;
            prutil = 0;
            prdescuento = 0;
            descuento = 0;
            montdescuento = 0;
            montimpuesto = 0;
            SubIV = 0;
            totalcdesc = 0;
            totalimp = 0;

    }

        private void IniciarDatagrid()
        {
            dataGridFact.ColumnCount = 11;  
            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            dataGridFact.Columns[0].Name = "Codigo Art";
            dataGridFact.Columns[1].Name = "Descripción";
            dataGridFact.Columns[2].Name = "Cantidad";
            dataGridFact.Columns[3].Name = "Precio";         
            dataGridFact.Columns[4].Name = "SubTotal";
            dataGridFact.Columns[5].Name = "% Desc";
            dataGridFact.Columns[6].Name = "Monto Desc";
            dataGridFact.Columns[7].Name = "SubTotal Desc";
            dataGridFact.Columns[8].Name = "Monto IV";
            dataGridFact.Columns[9].Name = "SubTotal  I.V";
            dataGridFact.Columns[10].Name = "Total Final";
            //agregar columna de impuesto con check
            dataGridFact.Columns.Add(col1);
            dataGridFact.Columns[11].Name = "I.V";
            dataGridFact.Columns[0].Width = 100;
            dataGridFact.Columns[1].Width = 130;
            dataGridFact.Columns[2].Width = 66;
            dataGridFact.Columns[3].Width = 75;
            dataGridFact.Columns[4].Width = 80;
            dataGridFact.Columns[5].Width = 75;
            dataGridFact.Columns[6].Width = 75;
            dataGridFact.Columns[7].Width = 75;
            dataGridFact.Columns[8].Width = 75;
            dataGridFact.Columns[9].Width = 75;
            dataGridFact.Columns[10].Width = 75;
            dataGridFact.Columns[11].Visible = false;
           // dataGridFact.Columns[11].Width = 20;
        }
        private void IniciarDatagridArt()
        {
            dataGridArt.ColumnCount = 5;
            DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
            dataGridArt.Columns[0].Name = "Codigo Art";
            dataGridArt.Columns[1].Name = "Descripción";
            dataGridArt.Columns[1].Width = 200;
            dataGridArt.Columns[2].Name = "Costo";
            dataGridArt.Columns[3].Name = "Utilidad";
            dataGridArt.Columns[3].Width = 70;
            dataGridArt.Columns[4].Name = "Precio Público";
            //agregar columna de descuento con check
            dataGridArt.Columns.Add(col2);
            dataGridArt.Columns[5].Name = "Aplica Descuento";
        }

        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            txtSubTotal.Value = (txtCantidad.Value * txtCosto.Value);

            if (rdbImpSi.Checked == true)
            {
                totalcdesc = Double.Parse(txtSubTotal1.Value.ToString());
                totalimp = ((iv / porc) * totalcdesc);
                montimpuesto = totalimp;
                totalimp = (totalimp + totalcdesc);
                SubIV = totalimp;
            }
            else
            {
                SubIV = Convert.ToDouble(txtSubTotal.Value);
                txtCostoPrecio.Text = (SubIV / Convert.ToDouble(txtCantidad.Value)).ToString();
            }
            
            //txtSubTotal1.Value = txtSubTotal.Value;

        }

        private void txtCodArt_KeyPress(object sender, KeyPressEventArgs e)
        {
           // bool repetido = false;
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridFact.Rows)
                    {
                        //string codigo = Convert.ToString(row.Cells["Codigo"].Value);

                        if (txtCodArt.Text == (row.Cells["Codigo Art"].Value).ToString())
                        {

                            if (MessageBox.Show("El artículo digitado ya fue agregado, Desea Modificar la Linea para Agregarlo", "Artículo Repetido",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                dataGridFact.CurrentCell = dataGridFact.Rows[row.Index].Cells[0];
                                posicion = row.Index;
                                this.ModificarArticulo();
                                goto Finall;

                            }
                        }
                    }


                    if (salir == false)
                    {
                        abo = new ArticuloBO();
                        lis = abo.GetArtCodComp(txtCodArt.Text);
                        txtDescp.Text = lis[0].Descrip;
                        txtCosto.Value = lis[0].Precio_Cost;
                        prcosto = Double.Parse(txtCosto.Text);
                        txtCostoPrecio.Value = txtCosto.Value;
                        txtUtil.Value = lis[0].Porc_Util;
                        prutil = Double.Parse(txtUtil.Text);
                        txtPrecioPub.Value = lis[0].Precio_Venta;
                        prpubli = Double.Parse(txtPrecioPub.Text);
                        impuesto = lis[0].Impuesto;

                        if (impuesto == false)
                        {
                            rdbImpNo.Checked = true;
                        }
                        else
                        {
                            rdbImpSi.Checked = true;
                        }
                        salir = true;
                        txtCodArt.Enabled = false;
                    }
                }
                catch (Exception )
                {
                }

            Finall:;
            }
        }

        private void txtCosto_ValueChanged(object sender, EventArgs e)
        {
            txtCostoPrecio.Text = txtCosto.Text;
            txtSubTotal.Value = txtCantidad.Value * txtCosto.Value;    
        }

        private void ValidaCosto()
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    txtCostoPrecio.Value = txtTotalFinal.Value / txtCantidad.Value;
                }
                else
                {
                    if (rdbImpSi.Checked == true)
                    {
                        totalcdesc = Double.Parse(txtSubTotal.Value.ToString());
                        totalimp = ((iv / porc) * totalcdesc);
                        montimpuesto = totalimp;
                        totalimp = (totalimp + totalcdesc);
                        txtCostoPrecio.Value = Convert.ToDecimal(totalimp) / txtCantidad.Value;
                    }
                    else
                    {
                        SubIV = Convert.ToDouble(txtSubTotal.Value);
                        txtCostoPrecio.Text = (SubIV / Convert.ToDouble(txtCantidad.Value)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                
            }
       
        }

        private void txtUtil_ValueChanged(object sender, EventArgs e)
        {
            this.Util_Articulo();
        }

        private void Util_Articulo()
        {
            if (txtUtil.Value <= 0)
            {
                txtUtil.BackColor = Color.Red;
            }
            else
            {
                txtUtil.BackColor = Color.White;
            }

            if (txtUtil.Text != "")
            {
                prcosto = Double.Parse(txtCostoPrecio.Value.ToString());
                prutil = Double.Parse(txtUtil.Value.ToString());
                util = (prutil / porc) * prcosto;
                util = util + prcosto;
                txtPrecioPub.Text = (util.ToString());
            }
        }

        private void txtPrecioPub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    if (txtPrecioPub.Text != "")
                    {
                        prpubli = 0;
                        prpubli = Double.Parse(txtPrecioPub.Text);
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
        private void txtSubTotal_ValueChanged(object sender, EventArgs e)
        {
            this.SubCosto();
            this.ValidaCosto();
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

            
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    try
            //    {
            //        subtotal = true;
            //        txtCosto.Value = (txtSubTotal.Value / txtCantidad.Value);
            //        prcosto = Double.Parse(txtCosto.Value.ToString());
            //        prdescuento = Double.Parse(txtDescuento.Value.ToString());                  
            //        descuento = (prdescuento / porc) * prcosto;
            //        montdescuento = descuento* Double.Parse(txtCantidad.Value.ToString());
            //        descuento = (prcosto - descuento) * Double.Parse(txtCantidad.Value.ToString());
            //        txtSubTotal1.Text = (descuento.ToString());

            //    }
            //    catch (Exception )
            //    {
            //    }
            //}
        }


        private void SubCosto()
        {
           
                try
                {
                    subtotal = true;
                    txtCosto.Value = (txtSubTotal.Value / txtCantidad.Value);
                    prcosto = Double.Parse(txtCosto.Value.ToString());
                    prdescuento = Double.Parse(txtDescuento.Value.ToString());
                    descuento = (prdescuento / porc) * prcosto;
                    montdescuento = descuento * Double.Parse(txtCantidad.Value.ToString());
                    descuento = (prcosto - descuento) * Double.Parse(txtCantidad.Value.ToString());
                    txtSubTotal1.Text = (descuento.ToString());

                }
                catch (Exception ex)
                {
                }
          
            
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                //calcula el costo del articulo solo con IV  
                if (rdbImpSi.Checked == true)
                    {
                        totalcdesc = Double.Parse(txtSubTotal.Value.ToString());
                        totalimp = ((iv / porc) * totalcdesc);
                        montimpuesto = totalimp;
                        totalimp = (totalimp + totalcdesc);
                        txtCostoPrecio.Value = Convert.ToDecimal(totalimp) / txtCantidad.Value ;
                    }
                    else
                    {
                        txtCostoPrecio.Value = Convert.ToDecimal(txtSubTotal.Value) / txtCantidad.Value;
                    }           
                   
                    prcosto = Double.Parse(txtCosto.Value.ToString());
                    prdescuento = Double.Parse(txtDescuento.Value.ToString());               
                    descuento = (prdescuento / porc) * prcosto;
                    montdescuento = descuento * Double.Parse(txtCantidad.Value.ToString());
                    descuento = (prcosto - descuento)* Double.Parse (txtCantidad.Value.ToString()) ;
                    txtSubTotal1.Text = (descuento.ToString());
                   
                }
                catch (Exception )
                {
                }
            }
            this.ValidaCosto();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               if (rdbImpSi.Checked == true)
                {
                    if (checkBox1.Checked == true)
                    {
                        txtCostoPrecio.Value = txtTotalIV.Value / txtCantidad.Value;
                    }
                    else
                    {
                        if (modificar== true)
                        {
                            totalcdesc = Double.Parse(txtSubTotal.Value.ToString());
                            totalimp = ((iv / porc) * totalcdesc);
                            montimpuesto = totalimp;
                            totalimp = (totalimp + totalcdesc);
                            SubIV = totalimp;
                            txtCostoPrecio.Value = Convert.ToDecimal(SubIV) / txtCantidad.Value;
                        }else
                        {
                            totalcdesc = Double.Parse(txtSubTotal.Value.ToString());
                            totalimp = ((iv / porc) * totalcdesc);
                            montimpuesto = totalimp;
                            totalimp = (totalimp + totalcdesc);
                            SubIV = totalimp;
                            txtCostoPrecio.Value = Convert.ToDecimal(SubIV) / txtCantidad.Value;
                        }
                        
                    }
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        txtCostoPrecio.Value = txtTotalFinal.Value / txtCantidad.Value;
                    }
                    else
                    {
                        txtCostoPrecio.Value = Convert.ToDecimal(SubIV) / txtCantidad.Value;
                    }
                }
            
            }
            catch (Exception)
            {
            }
          
        }

        private void txtCostoPrecio_ValueChanged(object sender, EventArgs e)
        {
            
            //if (subtotal == true)
            //{
                if (txtPrecioPub.Text != "")
                {
                    prpubli = 0;
                    prcosto = Double.Parse(txtCostoPrecio.Value.ToString());
                    prpubli = Double.Parse(txtPrecioPub.Value.ToString());
                    int porc = 100;
                    prec = porc * (prpubli / prcosto);
                    prec -= 100;
                    txtUtil.Text = (prec.ToString());
                    // txtPrecioPub.Text = prpubli.ToString();
                    subtotal = false;
                }
            //}
        }

        private void txtSubTotal1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbImpSi.Checked == true)
                {

                    totalcdesc = Double.Parse(txtSubTotal1.Value.ToString());

                    totalimp = ((iv / porc) * totalcdesc);
                    //totalimp = (totalimp * Double.Parse(txtCantidad.Value.ToString()));
                    montimpuesto = totalimp;
                    totalimp = (totalimp + totalcdesc);
                    txtTotalIV.Text = (totalimp.ToString());
                    txtTotalFinal.Value = txtTotalIV.Value;
                    txtCostoPrecio.Text = (Convert.ToDecimal(SubIV) / txtCantidad.Value).ToString();

                }
                else
                {
                    txtTotalFinal.Value = txtSubTotal1.Value;
                    //SubIV = Convert.ToDouble(txtSubTotal1.Value); 
                    txtCostoPrecio.Text = (Convert.ToDecimal(SubIV) / txtCantidad.Value).ToString();
                }

            }
            catch (Exception)
            {

               
            }
            this.ValidaCosto();
        }


        private void dataGridFact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                posicion = dataGridFact.CurrentRow.Index;
                //establecemos la posicion de la fila en el datagridart para que esten en la 
                //misma posicion
                dataGridArt.CurrentCell = dataGridArt.Rows[posicion].Cells[0];
            }
            catch (Exception)
            {

                MessageBox.Show("No ha Iniciado la nueva factura", "Error Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void frmFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.ValidaCosto();
            }
            
        }
        /// <summary>
        /// boton de eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if  ( (posicion >= 0) & (dataGridArt[0, posicion].Value.ToString() != ""))
                {
                    dataGridFact.Rows.RemoveAt(posicion);
                    dataGridArt.Rows.RemoveAt(posicion);
                    SumarTotales();
                    txtCodArt.Enabled = true;
                    modificafactura = true;
                    salvarfactura = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se pueden Eliminar Filas", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           
        }

        private void dataGridFact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = cmbID.SelectedIndex;
            int idProvedor = 0;
            idProvedor = lisProid[pos].Id;
            int estadofinac = lisProid[pos].DiasCredito;

            if (estadofinac > 0)
            {
                cmbCredCont.SelectedIndex = 1;
            }
            else
            {
                cmbCredCont.SelectedIndex = 0;
            }

            for (int i = 0; i < cmbID.Items.Count; i++)
            {
                if (Convert.ToInt32(cmbID.Items[i]) == idProvedor)
                {
                    cmbRazSoc.SelectedIndex = i;
                }
            }
           
        }
        private void cmbRazSoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = cmbRazSoc.SelectedIndex;
            int idProvedor = 0;
            idProvedor = lisProid[pos].Id;
            int estadofinac = lisProid[pos].DiasCredito;

            if (estadofinac > 0)
            {
                cmbCredCont.SelectedIndex = 1;
            }
            else
            {
                cmbCredCont.SelectedIndex = 0;
            }

            for (int i = 0; i < cmbRazSoc.Items.Count; i++)
            {
                if (Convert.ToInt32(cmbID.Items[i]) == idProvedor)
                {
                    cmbID.SelectedIndex = i;
                }
            }
        }
        
       
        
        private void button3_Click(object sender, EventArgs e)
        {
           if ( this.ValidarFacturaExist() == false)
            {
                btnSalvar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAplicInv.Enabled = true;
                btnFinFact.Enabled = true;
                btnAgregar.Enabled = true;
                datetimeFechaFact.Text = datimeFechaCompra.Text;
                lblNumfact.Text = txtnumFact.Text;
                lblNomProvedor.Text = cmbRazSoc.Text;
                lblIdProvedor.Text = cmbID.Text;
                lblFormPago.Text = cmbCredCont.Text;
                panelFactura.Visible = false;
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelFactura.Visible = false;
        }

        private void btnNuevaFact_Click(object sender, EventArgs e)
        {
            if (lblIdProvedor.Text != "")
            {
                if (MessageBox.Show("Realmente desea ingresar otra factura???", "Nueva Factura",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    panelFactura.Visible = true;
                    this.LimpiarFact();
                }
            }else
            {
                panelFactura.Visible = true;
            }
        }
        /// <summary>
        /// valida si la factura existe en la base de datos
        /// </summary>
        private bool ValidarFacturaExist()
        {
            List<FacturaProv> NumFactRep = new List<FacturaProv>();
            NumFactRep = fpbo.GetNumFactProv();
            bool factrepite = false;
            for (int i = 0; i < NumFactRep.Count; i++)
            {
                if ((NumFactRep[i].NumFactProv).Equals(txtnumFact.Text) &
                            (NumFactRep[i].IdProvedor).Equals(Int32.Parse(cmbID.Text)))
                {
                    MessageBox.Show(" Factura ya existe", "Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    factrepite = true;
                }
             
            }
            return factrepite;
            
        }

        private void LimpiarFact()
        {
            txtnumFact.Text = "";
            lblFormPago.Text = "";
            lblIdProvedor.Text = "";
            lblNomProvedor.Text = "";
            lblNumfact.Text = "";
            chkAplicaInv.Checked = false;
            chkfinfact.Checked = false;
            txtmontoDescu.Text = "00.00";
            txtmontoIV.Text = "00.00";
            txtmontoFinal.Text = "00.00";
            txtmontoSubtotal.Text = "00.00";
            panelFactura.Visible = true;
            btnSalvar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAplicInv.Enabled = false;
            btnFinFact.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnModificar.Enabled = false;
            cmbID.SelectedIndex = -1;
            cmbRazSoc.SelectedIndex = -1;
            cmbCredCont.SelectedIndex = -1;
            txtObservaciones.Text = "";
            dataGridArt.Rows.Clear();
            dataGridFact.Rows.Clear();
            guardafactura = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelBuscar.Visible = true;
            buscar = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //suma todos los montos y los guarda actualizados
            this.SumarTotales();
            modificafactura = false;
            if (guardafactura == true)
            {
                //elimina lo de las tablas espejo para ingresar datos actualizados
                this.EliminarEspejoArticulos();
                this.EliminarEspejoPrecios();
                //ingresa de nuevo los datos actualizados en las tablas espejo
                relartfac = Convert.ToInt32(lblrelFact.Text);  
                this.GuardarArt_Fact(relartfac);
                this.GuardarPreciosArt_Fact(relartfac);
                lblrelFact.Text = relartfac.ToString();
                //va al metodo y modifica el monto de la facturaprov
                this.GuardarFact_Prov();
                salvarfactura = true;
            }
            else
            {
                //guarda en la tabla facturaprov y obtiene el ID
                relartfac = this.GuardarFact_Prov();
                //guarda en los espejos
                this.GuardarArt_Fact(relartfac);
                this.GuardarPreciosArt_Fact(relartfac);
                lblrelFact.Text = relartfac.ToString();
                salvarfactura = true;
            }
           
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelBuscar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           

            List<FacturaProv> listFactprovBusc = new List<FacturaProv>();
            
            if (rdbTodo.Checked == true)
            {
                try
                {
                    //se cae revisar
                    listFactprovBusc = fpbo.GetNumFactProvBusc(txtnumFact2.Text, Convert.ToInt32(cmbID2.Text), Convert.ToDateTime(datimeFechaCompra2.Text));
                    if (listFactprovBusc.Count > 0)
                    {
                        dataGridBusq.DataSource = listFactprovBusc;
                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe llenar todos los campos", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (rdbProv.Checked == true)
            {
                if (cmbID2.Text != "")
                {
                    listFactprovBusc = fpbo.GetNumFactProvBuscProv(Convert.ToInt32(cmbID2.Text));
                    if (listFactprovBusc.Count > 0)
                    {
                        dataGridBusq.DataSource = listFactprovBusc;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un provedor", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (rdbFecha.Checked == true)
            {
                listFactprovBusc = fpbo.GetNumFactProvBuscFec(Convert.ToDateTime(datimeFechaCompra2.Text));
                if (listFactprovBusc.Count > 0)
                {
                    dataGridBusq.DataSource = listFactprovBusc;
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (rdbFact.Checked == true)
            {
                if (txtnumFact2.Text != "")
                {
                    listFactprovBusc = fpbo.GetNumFactProvBuscNumF(txtnumFact2.Text);
                    if (listFactprovBusc.Count > 0)
                    {
                        dataGridBusq.DataSource = listFactprovBusc;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Debe ingresar un numero de Factura", "Buscar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (listFactprovBusc.Count > 0)
            {
                dataGridBusq.Columns["NombProv"].DisplayIndex = 2;
                dataGridBusq.Columns[2].Visible = false;
                dataGridBusq.Columns[3].Visible = false;
                dataGridBusq.Columns[4].Visible = false;
                dataGridBusq.Columns[0].Visible = false;
                dataGridBusq.Columns[5].Visible = false;
                dataGridBusq.Columns[9].Width = 218;

            }
        }

        private void cmbID2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = cmbID2.SelectedIndex;
            int idProvedor = 0;
            idProvedor = lisProid[pos].Id;
            int estadofinac = lisProid[pos].DiasCredito;

            for (int i = 0; i < cmbID2.Items.Count; i++)
            {
                if (Convert.ToInt32(cmbID2.Items[i]) == idProvedor)
                {
                    cmbRazSoc2.SelectedIndex = i;
                }
            }
        }

        private void cmbRazSoc2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = cmbRazSoc2.SelectedIndex;
            int idProvedor = 0;
            idProvedor = lisProid[pos].Id;
            int estadofinac = lisProid[pos].DiasCredito;

            for (int i = 0; i < cmbRazSoc2.Items.Count; i++)
            {
                if (Convert.ToInt32(cmbID2.Items[i]) == idProvedor)
                {
                    cmbID2.SelectedIndex = i;
                }
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// metodo para cargar la factura unicamente con los datos del 
        /// provedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridBusq_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void HabilitarBotones()
        {
            this.btnAgregar.Enabled = true;
            this.btnModificar.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnSalvar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnAplicInv.Enabled = true;
            this.btnFinFact.Enabled = true;

        }
        private int GuardarFact_Prov()
        {

            if (guardafactura == true)
            {
                FacturaProv at = new FacturaProv()
                {
                    NumFactProv = lblNumfact.Text,
                    Fecha = Convert.ToDateTime(datetimeFechaFact.Text),
                    IDProvFact = Convert.ToInt32 (lblrelFact.Text),                   
                    Observaciones = txtObservaciones.Text,
                    Formapago = lblFormPago.Text,
                    AplicaInv = chkAplicaInv.Checked,
                    Finalfact = chkfinfact.Checked,
                    Montofact = totalfinalfactura
                };
               fpbo.ModificarProv(at);
               return 0;
            }
            else

            {
               
                    FacturaProv at = new FacturaProv()
                    {
                        NumFactProv = lblNumfact.Text,
                        IdProvedor = Convert.ToInt32(lblIdProvedor.Text),
                        Fecha = Convert.ToDateTime(datetimeFechaFact.Text),
                        Formapago = cmbCredCont.Text,
                        Observaciones = txtObservaciones.Text,
                        AplicaInv = chkAplicaInv.Checked,
                        Finalfact = chkfinfact.Checked,
                        Montofact = totalfinalfactura
                    };
                  return  fpbo.ValidarIngFactPrv(at);
               //modif = true;          
            }
        }
        private void GuardarArt_Fact(int idRelArProv)
        {    
                foreach (DataGridViewRow row in dataGridFact.Rows)
                {
                    try
                    {
                   
                        FacturaArtc at = new FacturaArtc()
                        {
                            Num_Fact = lblNumfact.Text,
                            Cod_Arti = Convert.ToString(row.Cells["Codigo Art"].Value),
                            DescripArt = Convert.ToString(row.Cells["Descripción"].Value),
                            Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                            PrecioU = Convert.ToDecimal(row.Cells["Precio"].Value),
                            Subtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value),
                            PorcDesc = Convert.ToDecimal(row.Cells["% Desc"].Value),
                            MontoDesc = Convert.ToDecimal(row.Cells["Monto Desc"].Value),
                            SubtoDesc = Convert.ToDecimal(row.Cells["SubTotal Desc"].Value),
                            MontocIV = Convert.ToDecimal(row.Cells["Monto IV"].Value),
                            SubtoIV = Convert.ToDecimal(row.Cells["SubTotal  I.V"].Value),
                            TotalFin = Convert.ToDecimal(row.Cells["Total Final"].Value),
                            IV = Convert.ToBoolean(row.Cells["I.V"].Value),
                            RelFactProve = idRelArProv,
                        };
                        fabo.IngresarEspejo(at);
                        
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                //modif = true;
            
        }
        private void GuardarPreciosArt_Fact(int relfactprec)
        {
   
                foreach (DataGridViewRow row in dataGridArt.Rows)
                {
                    try
                    {

                        FacturaPrecio at = new FacturaPrecio()
                        {
                            Num_Fact = lblNumfact.Text,
                            Cod_Arti = Convert.ToString(row.Cells["Codigo Art"].Value),
                            Descripcion = Convert.ToString(row.Cells["Descripción"].Value),
                            Costo = Convert.ToDecimal(row.Cells["Costo"].Value),
                            Utilidad = Convert.ToDecimal(row.Cells["Utilidad"].Value),
                            PrecioPub = Convert.ToDecimal(row.Cells["Precio Público"].Value),
                            AplicDesc = Convert.ToBoolean(row.Cells["Aplica Descuento"].Value),
                            RelFactPrecio = relfactprec,

                        };
                        fprbo.IngresoEspejoFacPrecio(at);

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                guardafactura = true;
            
        }

        private void EliminarEspejoArticulos()
        {
            fabo.EliminarEspejoFactArt();
            
        }
        private void EliminarEspejoPrecios ()
        {
            fprbo.EliminarEspFactArt();
        }

        private void lblNomProvedor_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void lblNumfact_TextChanged(object sender, EventArgs e)
        {
            dataGridFact.Rows.Clear();
            dataGridArt.Rows.Clear();
            if (buscar == true)
            {
                List<FacturaArtc> listFAB = new List<FacturaArtc>();
                listFAB = fabo.GetNumFactProv(lblNumfact.Text);
                for (int i = 0; i < listFAB.Count; i++)
                {
                    //objeto que contiene los datos del articulo a insertar en el datagridFactura
                  object[] row1 = new object[] { listFAB[i].Cod_Arti,listFAB[i].DescripArt,
                  listFAB[i].Cantidad, listFAB[i].PrecioU,listFAB[i].Subtotal,
                  listFAB[i].PorcDesc,listFAB[i].MontoDesc, listFAB[i].SubtoDesc,
                  listFAB[i].MontocIV,listFAB[i].SubtoIV,listFAB[i].TotalFin,listFAB[i].IV };
                  dataGridFact.Rows.Add(row1);
                }
                List<FacturaPrecio> listFP = new List<FacturaPrecio>();
                listFP = fprbo.GetNumFactPrec(lblNumfact.Text);
                for (int i = 0; i < listFP.Count; i++)
                {
                    //objeto que contiene los datos del articulo a insertar en el datagridFactura
                    object[] row2 = new object[] { listFP[i].Cod_Arti,listFP[i].Descripcion,
                    listFP[i].Costo, listFP[i].Utilidad,listFP[i].PrecioPub,
                   listFP[i].AplicDesc};
                    dataGridArt.Rows.Add(row2);
                }
                this.SumarTotales();
            }
        }

        private void dataGridBusq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lblNumfact.Text = (string)dataGridBusq.CurrentRow.Cells["NumFactProv"].Value;
            lblNomProvedor.Text = (string)dataGridBusq.CurrentRow.Cells["NombProv"].Value;
            lblIdProvedor.Text = (string)dataGridBusq.CurrentRow.Cells["IdProvedor"].Value.ToString();
            lblFormPago.Text = (string)dataGridBusq.CurrentRow.Cells["Formapago"].Value;
            datetimeFechaFact.Text = (string)dataGridBusq.CurrentRow.Cells["Fecha"].Value.ToString();
            txtObservaciones.Text = (string)dataGridBusq.CurrentRow.Cells["Observaciones"].Value;
            chkAplicaInv.Checked = (bool)dataGridBusq.CurrentRow.Cells["AplicaInv"].Value;
            chkfinfact.Checked = (bool)dataGridBusq.CurrentRow.Cells["Finalfact"].Value;
            buscar = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            panelBuscar.Visible = false;
            modificar = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        
            //guarda solo si se ha buscado una factura para modificarla
            if (modificafactura ==false  & guardafactura ==true & buscarfactura ==true & salvarfactura==true  )
            {
                //eliminar las facturas originales para luego obtenerlas del espejo
                //eliminar en las tablas articprove y precprove por #factura               
                fabo.EliminarFactArt(Convert.ToInt32(lblrelFact.Text));
                fprbo.EliminarFactPrec(Convert.ToInt32(lblrelFact.Text));
                //inserta el contenido de las tablas espejo en articprove y precprov
                this.InsertarArtPrecioFact_Permanente();
                this.Close();
           //guarda solo si se modifica la factura actual
            }else if (modificafactura ==false & guardafactura ==true & salvarfactura==true)
            {
                //validar para que vuelva a ingresar si nada mas se aplica y finaliza inventario
                //o si solo la consuta
                this.InsertarArtPrecioFact_Permanente();
                fabo.EliminarEspejoFactArt();
                fprbo.EliminarEspFactArt();
                this.Close();
          //mensaje de verificar si se guardo     
            }else if (modificafactura == true)
            {
                MessageBox.Show("Debe Guardar la Factura antes de Salir", "Guardar Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                this.Close();
            }


        }
        private void InsertarArtPrecioFact_Permanente()
        {
            try
            {
                List<FacturaArtc> listFAB = new List<FacturaArtc>();
                listFAB = fabo.GetNumFactEspejoProv(lblNumfact.Text);
                for (int i = 0; i < listFAB.Count; i++)
                {
                    FacturaArtc at = new FacturaArtc()
                    {
                        Num_Fact = listFAB[i].Num_Fact,
                        Cod_Arti = listFAB[i].Cod_Arti,
                        DescripArt = listFAB[i].DescripArt,
                        Cantidad = listFAB[i].Cantidad,
                        PrecioU = listFAB[i].PrecioU,
                        Subtotal = listFAB[i].Subtotal,
                        PorcDesc = listFAB[i].PorcDesc,
                        MontoDesc = listFAB[i].MontoDesc,
                        SubtoDesc = listFAB[i].SubtoDesc,
                        MontocIV = listFAB[i].MontocIV,
                        SubtoIV = listFAB[i].SubtoIV,
                        TotalFin = listFAB[i].TotalFin,
                        IV = listFAB[i].IV,
                        RelFactProve = listFAB[i].RelFactProve
                    };
                    fabo.ValidarIngFacArt(at);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //se ingresa a la tabla precprove de manera permanente
            try
            {
                List<FacturaPrecio> listFP = new List<FacturaPrecio>();
                listFP = fprbo.GetEspejoNumFactPrec(lblNumfact.Text);
                for (int i = 0; i < listFP.Count; i++)
                {
                    FacturaPrecio at = new FacturaPrecio()
                    {
                        Num_Fact = listFP[i].Num_Fact,
                        Cod_Arti = listFP[i].Cod_Arti,
                        Descripcion = listFP[i].Descripcion,
                        Costo = listFP[i].Costo,
                        Utilidad = listFP[i].Utilidad,
                        PrecioPub = listFP[i].PrecioPub,
                        AplicDesc = listFP[i].AplicDesc,
                        RelFactPrecio = listFP[i].RelFactPrecio

                    };
                    fprbo.IngresoFacPrecio(at);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnAplicInv_Click(object sender, EventArgs e)
        {
            chkAplicaInv.Checked = true;
           // this.ModificarFacturaProv();
            string codarticulo = "0381";
            int cantidad = 0;
            decimal costom = 0;
            decimal utilidadm = 0;
            decimal preciopm = 0;
            bool aplicades = false;
            List<Articulo> listAModf = new List<Articulo>();
            
            foreach (DataGridViewRow row in dataGridArt.Rows)
            {
                try
                {
                    
                    codarticulo = Convert.ToString(row.Cells["Codigo Art"].Value);
                    listAModf = abo.GetModifArtCompra(codarticulo);
                    cantidad =Convert.ToInt32(dataGridFact.Rows[row.Index].Cells["Cantidad"].Value) ;
                    cantidad += listAModf[0].Cantidad_Invt;
                    costom = Convert.ToDecimal(row.Cells["Costo"].Value);
                    utilidadm = Convert.ToDecimal(row.Cells["Utilidad"].Value);
                    preciopm = Convert.ToDecimal(row.Cells["Precio Público"].Value);
                    aplicades = Convert.ToBoolean(row.Cells["Aplica Descuento"].Value);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            

        }
        private void btnFinFact_Click(object sender, EventArgs e)
        {
            if (chkAplicaInv.Checked == true)
            {
                chkfinfact.Checked = true;
                this.ModificarFacturaProv();
            }
            else
            {
                MessageBox.Show("Debe aplicar inventario para finalizar factura", "Finalizar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ModificarFacturaProv()
        {
            FacturaProv at = new FacturaProv()
            {
                NumFactProv = lblNumfact.Text,
                Fecha = Convert.ToDateTime(datetimeFechaFact.Text),
                IDProvFact = Convert.ToInt32(lblrelFact.Text),
                Observaciones = txtObservaciones.Text,
                Formapago = lblFormPago.Text,
                AplicaInv = chkAplicaInv.Checked,
                Finalfact = chkfinfact.Checked,
                Montofact = totalfinalfactura
            };
            fpbo.ModificarProv(at);         
        }

        private void dataGridBusq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNumfact.Text = (string)dataGridBusq.CurrentRow.Cells["NumFactProv"].Value;
            lblNomProvedor.Text = (string)dataGridBusq.CurrentRow.Cells["NombProv"].Value;
            lblIdProvedor.Text = (string)dataGridBusq.CurrentRow.Cells["IdProvedor"].Value.ToString();
            lblFormPago.Text = (string)dataGridBusq.CurrentRow.Cells["Formapago"].Value;
            datetimeFechaFact.Text = (string)dataGridBusq.CurrentRow.Cells["Fecha"].Value.ToString();
            txtObservaciones.Text = (string)dataGridBusq.CurrentRow.Cells["Observaciones"].Value;
            chkAplicaInv.Checked = (bool)dataGridBusq.CurrentRow.Cells["AplicaInv"].Value;
            chkfinfact.Checked = (bool)dataGridBusq.CurrentRow.Cells["Finalfact"].Value;
            lblrelFact.Text = (string)dataGridBusq.CurrentRow.Cells["IDProvFact"].Value.ToString();
            panelBuscar.Visible = false;
            if (chkAplicaInv.Checked == true || chkAplicaInv.Checked == true)
            {
                MessageBox.Show("No se puede Editar una factura Aplicada, Debe Reversarla..", "Editar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.HabilitarBotones();
            }

            guardafactura = true;
            buscarfactura = true;
        }
    }
}      

