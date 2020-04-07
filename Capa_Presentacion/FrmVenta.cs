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
    public partial class FrmVenta : Form
    {
        public int IdTrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;
        private static FrmVenta _instance;

        public static FrmVenta GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmVenta();
            }
            return _instance;

        }

        public void setCliente(string IdCliente, string nombre)
        {
            this.txtIdCliente.Text = IdCliente;
            this.txtCliente.Text = nombre;
        }

        public void setArticulo(string IdDetalleIngreso, string nombre, decimal precio_compra, decimal precio_venta, int stock, DateTime fecha_vencimiento)
        {
            this.txtIdArticulo.Text = IdDetalleIngreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text = precio_compra.ToString();
            this.txtPrecioVenta.Text = precio_venta.ToString();
            this.txtstock_actual.Text = stock.ToString();
            this.dtFechaVencimiento.Value = fecha_vencimiento;
        }

        public FrmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtstock_actual, "Ingrese la cantidad actual de producto");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el articulo de compra");
            this.ttMensaje.SetToolTip(this.txtPrecioCompra, "Ingrese precio de compra");
            this.ttMensaje.SetToolTip(this.txtPrecioVenta, "Ingrese precio de venta");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la canitdad de articulos");
            this.txtIdArticulo.Visible = false;
            this.txtIdCliente.Visible = false;
            this.txtIdIVenta.Visible = false;
            this.txtCliente.ReadOnly = true;
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
            this.txtIdIVenta.Text = String.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
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
            this.txtstock_actual.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtDescuento.Text = "0.0";
        }

        //Habilitar los controles del formulario

        private void habilitar(bool valor)
        {
            this.txtIdIVenta.Visible = false;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIGV.ReadOnly = !valor;
            this.txtstock_actual.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.dtfecha.Enabled = valor;
            this.cboxTipo_Comprobante.Enabled = valor;
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
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar nombre
        private void BuscarFecha()
        {
            this.dataListado.DataSource = NVenta.BuscarFecha(this.dtFechaInicio.Value, this.dtFechaFin.Value);
            //this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            //this.dataListado.Columns[0].Visible = true;                  
        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("IdDetalle_ingreso", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("Articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));     
            dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar el DataGriedView con el DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalleVenta(Convert.ToInt32(this.txtIdIVenta.Text));
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.habilitar(false);
            this.Botones();
            this.CrearTabla();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Venta frm = new FrmVistaCliente_Venta();
            frm.ShowDialog();
            
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Venta frm = new FrmVistaArticulo_Venta();
            frm.ShowDialog();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;

                dialogResult = MessageBox.Show("Realmente Desea Eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";
                    foreach (DataGridViewRow data in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(data.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(data.Cells[1].Value);
                            rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino correctamente el ingreso");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdVentas"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtfecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cboxTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lbTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtCliente.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty || this.txtIGV.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtCliente, "Selecciones un cliente");
                    errorIcono.SetError(txtSerie, "Ingrese el numero de serie del comprobante");
                    errorIcono.SetError(txtCorrelativo, "Ingrese el numero del comprobante");
                    errorIcono.SetError(txtIGV, "Ingrese el IGV");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text),this.IdTrabajador,this.dtfecha.Value, this.cboxTipo_Comprobante.Text, this.txtSerie.Text.Trim(), this.txtCorrelativo.Text.Trim(), Convert.ToDecimal(this.txtIGV.Text), dtDetalle);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.habilitar(false);
            this.limpiar();
            this.limpiarDetalle();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (this.txtArticulo.Text == string.Empty  || this.txtPrecioVenta.Text == string.Empty || this.txtDescuento.Text == string.Empty || this.txtCantidad.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtArticulo, "Selecciones un articulo");
                    errorIcono.SetError(txtDescuento, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["IdDetalle_Ingreso"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en detalle.");
                        }
                    }
                    if (registrar && Convert.ToInt32(this.txtCantidad.Text) <= Convert.ToInt32(this.txtstock_actual.Text))
                    {
                        decimal subtotal = (Convert.ToInt32(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)) - Convert.ToDecimal(this.txtDescuento.Text);
                        TotalPagado = TotalPagado + subtotal;
                        this.lbTotalPagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdDetalle_Ingreso"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["Articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay stock suficiente");
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

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            FrmReporteFactura frm = new FrmReporteFactura();
            frm.IdVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdVentas"].Value);
            frm.ShowDialog();
        }
    }
}
