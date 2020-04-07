using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class FrmVistaArticulo_Venta : Form
    {
        public FrmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        private void FrmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cboxCodigo.Text.Equals("Codigo"))
            {
                this.MostrarArticulos_venta_codigo();
            }
            else if (this.cboxCodigo.Text.Equals("Nombre"))
            {
                this.MostrarArticulos_venta_nombre();
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

 
        private void MostrarArticulos_venta_codigo()
        {

            this.dataListado.DataSource = NVenta.MostrarArticulos_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);


        }

        private void MostrarArticulos_venta_nombre()
        {

            this.dataListado.DataSource = NVenta.MostrarArticulos_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);


        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta frmVenta = FrmVenta.GetInstance();
            string part1, part2;
            decimal par3, par4;
            int par5;
            DateTime par6;

            part1 = this.dataListado.CurrentRow.Cells["IdDetalleIngreso"].Value.ToString();
            part2 = this.dataListado.CurrentRow.Cells["nombre"].Value.ToString();
             par3=  Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stock_actual"].Value);
            par6 = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);

            frmVenta.setArticulo(part1, part2,par3,par4,par5,par6);
            this.Hide();
        }
    }
}
