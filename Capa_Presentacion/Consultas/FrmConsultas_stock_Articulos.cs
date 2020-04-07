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

namespace Capa_Presentacion.Consultas
{
    public partial class FrmConsultas_stock_Articulos : Form
    {
        public FrmConsultas_stock_Articulos()
        {
            InitializeComponent();
        }

        private void FrmConsultas_stock_Articulos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulos.MostrarStockArticulos();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
    }
}
