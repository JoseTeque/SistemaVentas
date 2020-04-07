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
    public partial class FrmArticulos : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmArticulos _instance;

        public static FrmArticulos GetInstance()
        {
            if(_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmArticulos();
            }
          
            return _instance;

        }



        public void setCategoria(string idCategoria, string nombre)
        {
            this.txtIdCategorias.Text = idCategoria;
            this.txtCategorias.Text = nombre; 

        }




        public FrmArticulos()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "seleccione la imagen del articulo");
            this.ttMensaje.SetToolTip(this.txtIdCategorias, "seleccione la categoria del articulo");
            this.ttMensaje.SetToolTip(this.cbIdPresentacion, "seleccione la presentacion del articulo");

            this.txtIdCategorias.Visible = false;
            this.txtIdCategorias.ReadOnly = true;
            this.LlenarComboPresentacion();
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
            this.txtCodigoVentas.Text = String.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            this.txtIdCategorias.Text = string.Empty;
            this.txtCategorias.Text = string.Empty;
            this.cbIdPresentacion.Text = string.Empty;
          /*  this.pxImagen.Image = string.Empty; */ 
        }

        //Habilitar los controles del formulario

        private void habilitar(bool valor)
        {
            this.txtCodigoVentas.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdArticulo.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdPresentacion.Enabled = valor;
            this.btnagregar.Enabled = valor;
            this.btnlimpiar.Enabled = valor;
            this.txtCategorias.ReadOnly = !valor;

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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;

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
            if (chexbEliminar.Checked)
            {
                this.dataListado.DataSource = NArticulos.Buscar(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.DataSource = NArticulos.Buscar(this.txtBuscar.Text);
                this.OcultarColumnas();
                Listado.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
            }

        }

        private void LlenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "IdPresentacion";
            cbIdPresentacion.DisplayMember = "Nombre";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncargar_Click(object sender, EventArgs e)
        {

        }

        private void txtCategorias_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (chexbEliminar.Checked)
            {
                this.BuscarNombre();
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.BuscarNombre();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                            rpta = NArticulos.Eliminar(Convert.ToInt32(Codigo));

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
            this.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdArticulo"].Value);
            this.txtCodigoVentas.Text = this.dataListado.CurrentRow.Cells["Codigo"].Value.ToString();
            this.txtNombre.Text = this.dataListado.CurrentRow.Cells["Nombre"].Value.ToString();
            this.txtDescripcion.Text = this.dataListado.CurrentRow.Cells["Descripcion"].Value.ToString();

            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdCategorias.Text = this.dataListado.CurrentRow.Cells["IdCategoria"].Value.ToString();
            this.txtCategorias.Text = this.dataListado.CurrentRow.Cells["NombreCategoria"].Value.ToString();

            this.cbIdPresentacion.SelectedValue = this.dataListado.CurrentRow.Cells["IdPresentacion"].Value.ToString();
          

            this.tabControl1.SelectedIndex = 1;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

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

                if (this.txtNombre.Text == string.Empty || this.txtIdCategorias.Text == string.Empty || this.txtCodigoVentas.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un valor");
                    errorIcono.SetError(txtCodigoVentas, "Ingrese un Codigo de articulo");
                    errorIcono.SetError(txtCategorias, "Ingrese una Categoria");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png); // guardar imagen en el buffer

                    byte[] imagen = ms.GetBuffer(); // obtener imagen del buffer y covertirka en array 

                    if (this.IsNuevo)
                    {
                        rpta = NArticulos.Insertar(this.txtCodigoVentas.Text.Trim().ToUpper(),this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(),imagen,Convert.ToInt32(this.txtIdCategorias.Text),Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulos.Editar(Convert.ToInt32(this.txtIdArticulo.Text.Trim()), this.txtCodigoVentas.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(), imagen, Convert.ToInt32(this.txtIdCategorias.Text), Convert.ToInt32(this.cbIdPresentacion.SelectedValue));

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

        private void btnagregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::Capa_Presentacion.Properties.Resources.transparente;
                
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdArticulo.Text.Equals(""))
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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmCategorias_Articulos form = new FrmCategorias_Articulos();
            form.ShowDialog();
        }

        private void cbIdPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pxImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
