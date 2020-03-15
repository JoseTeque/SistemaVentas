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
    public partial class FrmIngreso : Form
    {
        public int IdTrabajador;
        private static FrmIngreso _instance;

        public static FrmIngreso GetInstance()
        {
            if(_instance == null)
            {
                _instance = new FrmIngreso();
            }
            return _instance;
            
        }
        public void setProveedor(string IdProveedor, string nombre)
        {
            this.txtIdProveedor.Text = IdProveedor;
            this.txtProveedor.Text = nombre;

        }

        public void setArticulo(string IdArticulo, string nombre)
        {
            this.txtIdArticulo.Text = IdArticulo;
            this.txtArticulo.Text = nombre;

        }

        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_ingreso frm = new FrmVistaArticulo_ingreso();
            frm.ShowDialog();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {

        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnBuscarProveedor_Click_1(object sender, EventArgs e)
        {
            FrmVistaProveedor_ingreso frm = new FrmVistaProveedor_ingreso();
            frm.ShowDialog();
        }
    }
}
