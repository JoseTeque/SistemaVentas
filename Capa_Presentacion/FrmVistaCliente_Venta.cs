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
    public partial class FrmVistaCliente_Venta : Form
    {
        public FrmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        private void FrmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }


        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar Razon social
        private void BuscarApellido()
        {
          
                this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
               

        }

        //Metodo buscar nro Documento
        private void BuscarNroDocumento()
        {

                this.dataListado.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta frmVenta = FrmVenta.GetInstance();
            string part1, part2;
            part1 = Convert.ToString(this.dataListado.CurrentRow.Cells["IdCliente"].Value);
            part2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value) + " "+ Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);

            frmVenta.setCliente(part1,part2);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cboxBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellido();
            }
            else if (this.cboxBuscar.Text.Equals("Nro Documento"))
            {
                this.BuscarNroDocumento();
            }
        }
    }
}
