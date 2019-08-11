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
    public partial class frmhBuscarFact : Form
    {

        public Provedor Provedor { get; set; }
        public FacturaProv FacturaProv { get; set; }
        //acceso al BO de provedor
        private ProvedorBO pbo;
        //acceso al BO de facturaprov
        private FacturaProvBO fpbo;
        //**************************
        List<Provedor> lisProid = new List<Provedor>();
        //***************************
        List<FacturaProv> listFactprov = new List<FacturaProv>();
        //***************************
        List<FacturaProv> listFactprovBusc = new List<FacturaProv>();
      

        public frmhBuscarFact()
        {
            InitializeComponent();
        }

        private void frmhBuscarFact_Load(object sender, EventArgs e)
        {
            pbo = new ProvedorBO();
            fpbo = new FacturaProvBO();
            List<Provedor> dims = pbo.GetProvedorID();
            cmbRazSoc2.Items.AddRange(dims.ToArray<Provedor>());
            lisProid = pbo.GetProvedorID();
            for (int i = 0; i < lisProid.Count; i++)
            {
                cmbID2.Items.Add(lisProid[i].Id);
            }
            rdbTodo.Checked = true;
          //  frmFactura frmFact = new frmFactura();
        }

        private void cmbID_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void cmbRazSoc_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdbTodo .Checked == true)
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
            else if (rdbFecha.Checked==true)
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
            else if (rdbFact.Checked == true )
            {
                if (txtnumFact2.Text  != "")
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
                dataGridBusq.Columns[1].Visible = false;
                dataGridBusq.Columns[3].Visible = false;
                dataGridBusq.Columns[4].Visible = false;
            }
           
        }

        private void dataGridBusq_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           
            //numfact= (string)dataGridBusq.CurrentRow.Cells["NumFactProv"].Value,
            //nombreprov = (string)dataGridBusq.CurrentRow.Cells["NombProv"].Value,
            //idprov = (string)dataGridBusq.CurrentRow.Cells["IdProvedor"].Value.ToString(),
            //formapag= (string)dataGridBusq.CurrentRow.Cells["Formapago"].Value,
            //fecha = (string)dataGridBusq.CurrentRow.Cells["Fecha"].Value.ToString(),
            //observ = (string)dataGridBusq.CurrentRow.Cells["Observaciones"].Value,
            //aplicinv = (bool)dataGridBusq.CurrentRow.Cells["AplicaInv"].Value,
            //finfact = (bool)dataGridBusq.CurrentRow.Cells["Finalfact"].Value
           
        }
    }
}
