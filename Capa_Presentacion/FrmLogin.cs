using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.lblHoraSistema.Text = DateTime.Now.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblHoraSistema.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = Capa_Negocio.NTrabajador.Login(this.txtUsuario.Text.Trim(), this.txtPassword.Text.Trim());
            //Evaluar si existe el usuario
            if(Datos.Rows.Count == 0)
            {
                MessageBox.Show("No tiene acceso al sistema", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.IdTrabajador = Datos.Rows[0][0].ToString();
                frm.apellidos = Datos.Rows[0][1].ToString();
                frm.nombre = Datos.Rows[0][2].ToString();
                frm.acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();
            }
        }
    }
}
