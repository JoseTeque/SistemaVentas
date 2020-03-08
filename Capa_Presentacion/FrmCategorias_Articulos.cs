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
    public partial class FrmCategorias_Articulos : Form
    {
        public FrmCategorias_Articulos()
        {
            InitializeComponent();
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
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmCategorias_Articulos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulos form = FrmArticulos.GetInstance();
            string par1, par2;

            par1 = this.dataListado.CurrentRow.Cells["IdCategoria"].Value.ToString();
            par2 = this.dataListado.CurrentRow.Cells["Nombre"].Value.ToString();
            form.setCategoria(par1,par2);
            this.Hide();
        }
    }
}
