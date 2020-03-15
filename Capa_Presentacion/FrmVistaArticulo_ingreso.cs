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
    public partial class FrmVistaArticulo_ingreso : Form
    {
        public FrmVistaArticulo_ingreso()
        {
            InitializeComponent();
        }

        //Metodo ocultar columnas

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[8].Visible = false;


        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulos.Mostrar();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar nombre
        private void BuscarNombre()
        {
          
                this.dataListado.DataSource = NArticulos.Buscar(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);        

        }

        private void FrmVistaArticulo_ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso frmIngreso = FrmIngreso.GetInstance();
            string part1, part2;
            part1 = this.dataListado.CurrentRow.Cells["IdArticulo"].Value.ToString();
            part2 = this.dataListado.CurrentRow.Cells["nombre"].Value.ToString();

            frmIngreso.setArticulo(part1,part2);
            this.Hide();

        }
    }
}
