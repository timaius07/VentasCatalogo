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
using Ventas_Catalogos.GUI;

namespace GUI
{
    public partial class Login : Form
    {


        private UsuarioBO usubo;

        public Login()
        {
            InitializeComponent();
            usubo = new UsuarioBO();
        }
        /// <summary>
        /// btn que nos sirve para autentificar los dos jugadores 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario()
            {
                Nombre = txtNombre.Text.Trim(),
                Contras= txtCont.Text.Trim()
            };
            u = usubo.Loguear(u);
            if (u.Id > 0)
            {
               
                this.Hide();
                frmMenu f = new frmMenu();
                f.Show(this);         
            }
            else
            {
                MessageBox.Show("Verifique su Informacion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
    }
}