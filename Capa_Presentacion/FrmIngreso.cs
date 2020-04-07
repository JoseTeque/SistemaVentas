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
    public partial class FrmIngreso : Form
    {
        public int IdTrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;
        private static FrmIngreso _instance;

        public static FrmIngreso GetInstance()
        {
            if(_instance == null || _instance.IsDisposed)
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
            this.ttMensaje.SetToolTip(this.txtProveedor,"Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el articulo de compra");
            this.txtIdArticulo.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtIdIngreso.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }

        // Mostrar mensaje de confirmacion

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Limpiar las cajas de textos

        private void limpiar()
        {
            this.txtIdIngreso.Text = String.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIGV.Text = string.Empty;
            this.lbTotalPagado.Text = "0.0";
            this.CrearTabla();
            /*  this.pxImagen.Image = string.Empty; */
        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }

        //Habilitar los controles del formulario

        private void habilitar(bool valor)
        {
            this.txtIdIngreso.Visible = false;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIGV.ReadOnly = !valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.dtfecha.Enabled = valor;
            this.cboxTipo_Comprobante.Enabled = valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

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
            this.dataListado.DataSource = NIngreso.MostrarIngreso();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar nombre
        private void BuscarFecha()
        {
                this.dataListado.DataSource = NIngreso.BuscarFecha(this.dtFechaInicio.Value, this.dtFechaFin.Value);
                //this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                //this.dataListado.Columns[0].Visible = true;                  
        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("IdArticulo",System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("Articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar el DataGriedView con el DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalleIngreso(this.txtIdIngreso.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
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
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.habilitar(false);
            this.Botones();
            this.CrearTabla();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;

                dialogResult = MessageBox.Show("Realmente Desea Anular los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";
                    foreach (DataGridViewRow data in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(data.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(data.Cells[1].Value);
                            rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anulo correctamente el ingreso");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }

                        }
                    }
                    this.Mostrar();
                    this.dataListado.Columns[0].Visible = true;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chexbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chexbEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell dataGridView = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                dataGridView.Value = !Convert.ToBoolean(dataGridView.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.limpiar();
            this.habilitar(true);
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.habilitar(false);
            this.limpiar();
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty || this.txtIGV.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtIdProveedor, "Selecciones un proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese el numero de serie del comprobante");
                    errorIcono.SetError(txtCorrelativo, "Ingrese el numero del comprobante");
                    errorIcono.SetError(txtIGV, "Ingrese el IGV");
                }
                else
                { 

                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(this.IdTrabajador, Convert.ToInt32(this.txtIdProveedor.Text.Trim().ToUpper()), this.dtfecha.Value, this.cboxTipo_Comprobante.Text, this.txtSerie.Text.Trim(), this.txtCorrelativo.Text.Trim(),Convert.ToDecimal(this.txtIGV.Text),"EMITIDO",dtDetalle);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            MensajeOk("Se inserto de forma correcta el registro");
                        }
                      
                    }
                    else
                    {
                        MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtArticulo.Text == string.Empty || this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty || this.txtStock.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtArticulo, "Selecciones un articulo");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                    errorIcono.SetError(txtStock, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if(Convert.ToInt32(row["IdArticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en detalle.");
                        }
                    }
                    if (registrar)
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        TotalPagado = TotalPagado + subtotal;
                        this.lbTotalPagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdArticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["Articulo"] = this.txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fecha_produccion"] = this.dtFechaProduccion.Value;
                        row["fecha_vencimiento"] = this.dtFechaVencimiento.Value;
                        row["subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int IndiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[IndiceFila];
                //Disminuir el totalPagado
                this.TotalPagado = this.TotalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lbTotalPagado.Text = TotalPagado.ToString("#0.00#");
                this.dtDetalle.Rows.Remove(row);

            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdIngreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtfecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cboxTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lbTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["totalCompras"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
