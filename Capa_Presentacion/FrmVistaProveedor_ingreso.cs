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
    public partial class FrmVistaProveedor_ingreso : Form
    {
        public FrmVistaProveedor_ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProveedor_ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //Metodo ocultar columnas

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar Razon social
        private void BuscarNombreRazonSocial()
        {
        
          
                this.dataListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                this.dataListado.Columns[0].Visible = true;
        

        }

        //Metodo buscar nro Documento
        private void BuscarNroDocumento()
        {

                this.dataListado.DataSource = NProveedor.BuscarNumDocmuento(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                this.dataListado.Columns[0].Visible = true;
 

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.cboxBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarNombreRazonSocial();
            }
            else if (this.cboxBuscar.Text.Equals("Nro Documento"))
            {
                this.BuscarNroDocumento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso frmIngreso = FrmIngreso.GetInstance();
            string part1, part2;
            part1 = this.dataListado.CurrentRow.Cells["IdProveedor"].Value.ToString();
            part2 = this.dataListado.CurrentRow.Cells["razon_social"].Value.ToString();

            frmIngreso.setProveedor(part1, part2);
            this.Hide();

        }
    }
}
