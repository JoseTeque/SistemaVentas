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
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese el apellido");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el numero de telefono");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la direccion");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese su email");
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
            this.txtIdCliente.Text = String.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
        
        }

        //Habilitar los controles del formulario

        private void habilitar(bool valor)
        {
            this.txtIdCliente.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.cboxTipoDocumento.Enabled = valor;
            this.dtFechaNac.Enabled = valor;
            this.cboxSexo.Enabled = valor;


        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
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
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar Razon social
        private void BuscarApellido()
        {
            if (chexbEliminar.Checked)
            {
                this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }

        }

        //Metodo buscar nro Documento
        private void BuscarNroDocumento()
        {
            if (chexbEliminar.Checked)
            {
                this.dataListado.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.limpiar();
            this.habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty || this.txtNumDocumento.Text == string.Empty || this.txtDireccion.Text == string.Empty || this.txtApellidos.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                    errorIcono.SetError(txtApellidos, "Ingrese los apellidos");
                    errorIcono.SetError(txtNumDocumento, "Ingrese el numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese la direccion");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cboxSexo.Text.Trim().ToUpper(), this.cboxTipoDocumento.Text.Trim().ToUpper(),this.dtFechaNac.Value, this.txtNumDocumento.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim());
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cboxSexo.Text.Trim().ToUpper(), this.cboxTipoDocumento.Text.Trim().ToUpper(), this.dtFechaNac.Value, this.txtNumDocumento.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim());

                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.limpiar();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.habilitar(false);
            this.limpiar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdCliente"].Value);
            this.txtNombre.Text = this.dataListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.txtApellidos.Text = this.dataListado.CurrentRow.Cells["apellidos"].Value.ToString();
            this.cboxSexo.Text = this.dataListado.CurrentRow.Cells["sexo"].Value.ToString();
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.txtNumDocumento.Text = this.dataListado.CurrentRow.Cells["num_documento"].Value.ToString();
            this.txtTelefono.Text = this.dataListado.CurrentRow.Cells["telefono"].Value.ToString();
            this.txtEmail.Text = this.dataListado.CurrentRow.Cells["email"].Value.ToString();
            this.txtDireccion.Text = this.dataListado.CurrentRow.Cells["direccion"].Value.ToString();

            this.cboxTipoDocumento.Text = this.dataListado.CurrentRow.Cells["tipo_documento"].Value.ToString();



            this.tabControl1.SelectedIndex = 1;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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

        private void btnBuscar_Click_1(object sender, EventArgs e)
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
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
                            rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
