namespace Capa_Presentacion
{
    partial class FrmVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label11 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lbTotalPagado = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtstock_actual = new System.Windows.Forms.TextBox();
            this.dtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.txtCorrelativo = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxTipo_Comprobante = new System.Windows.Forms.ComboBox();
            this.dtfecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdIVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Listado = new System.Windows.Forms.Label();
            this.chexbEliminar = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnComprobante = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(601, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "IGV:";
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.lbTotalPagado);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dataListadoDetalle);
            this.groupBox1.Controls.Add(this.txtIdArticulo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtIGV);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCorrelativo);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboxTipo_Comprobante);
            this.groupBox1.Controls.Add(this.dtfecha);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtIdIVenta);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(279, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 34;
            this.label16.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(347, 57);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(285, 26);
            this.txtCliente.TabIndex = 35;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCliente.Location = new System.Drawing.Point(347, 25);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(46, 26);
            this.txtIdCliente.TabIndex = 36;
            // 
            // lbTotalPagado
            // 
            this.lbTotalPagado.AutoSize = true;
            this.lbTotalPagado.Location = new System.Drawing.Point(121, 416);
            this.lbTotalPagado.Name = "lbTotalPagado";
            this.lbTotalPagado.Size = new System.Drawing.Size(32, 18);
            this.lbTotalPagado.TabIndex = 33;
            this.lbTotalPagado.Text = "0.0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 416);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 18);
            this.label15.TabIndex = 32;
            this.label15.Text = "Total Pagado: $.";
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(7, 268);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.Size = new System.Drawing.Size(900, 131);
            this.dataListadoDetalle.TabIndex = 31;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIdArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdArticulo.Location = new System.Drawing.Point(6, 125);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(46, 26);
            this.txtIdArticulo.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtDescuento);
            this.groupBox2.Controls.Add(this.txtstock_actual);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.dtFechaVencimiento);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtPrecioVenta);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPrecioCompra);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtArticulo);
            this.groupBox2.Controls.Add(this.btnBuscarArticulo);
            this.groupBox2.Location = new System.Drawing.Point(6, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(901, 111);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(587, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 18);
            this.label13.TabIndex = 33;
            this.label13.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(687, 75);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(153, 26);
            this.txtDescuento.TabIndex = 34;
            // 
            // txtstock_actual
            // 
            this.txtstock_actual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtstock_actual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstock_actual.Location = new System.Drawing.Point(195, 71);
            this.txtstock_actual.Name = "txtstock_actual";
            this.txtstock_actual.Size = new System.Drawing.Size(84, 26);
            this.txtstock_actual.TabIndex = 32;
            // 
            // dtFechaVencimiento
            // 
            this.dtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVencimiento.Location = new System.Drawing.Point(711, 30);
            this.dtFechaVencimiento.Name = "dtFechaVencimiento";
            this.dtFechaVencimiento.Size = new System.Drawing.Size(129, 26);
            this.dtFechaVencimiento.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(565, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 18);
            this.label14.TabIndex = 28;
            this.label14.Text = "Fecha Vencimiento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(328, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 18);
            this.label12.TabIndex = 24;
            this.label12.Text = "Precio Venta:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVenta.Location = new System.Drawing.Point(437, 69);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(107, 26);
            this.txtPrecioVenta.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCompra.Location = new System.Drawing.Point(437, 30);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(107, 26);
            this.txtPrecioCompra.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(93, 71);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(84, 26);
            this.txtCantidad.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Articulo:";
            // 
            // txtArticulo
            // 
            this.txtArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticulo.Location = new System.Drawing.Point(86, 27);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(163, 26);
            this.txtArticulo.TabIndex = 17;
            // 
            // txtIGV
            // 
            this.txtIGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGV.Location = new System.Drawing.Point(650, 100);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.Size = new System.Drawing.Size(150, 26);
            this.txtIGV.TabIndex = 29;
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorrelativo.Location = new System.Drawing.Point(425, 100);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(150, 26);
            this.txtCorrelativo.TabIndex = 27;
            // 
            // txtSerie
            // 
            this.txtSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Location = new System.Drawing.Point(354, 101);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(65, 26);
            this.txtSerie.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Numero:";
            // 
            // cboxTipo_Comprobante
            // 
            this.cboxTipo_Comprobante.FormattingEnabled = true;
            this.cboxTipo_Comprobante.Items.AddRange(new object[] {
            "Ticket",
            "Boleta",
            "Factura"});
            this.cboxTipo_Comprobante.Location = new System.Drawing.Point(152, 100);
            this.cboxTipo_Comprobante.Name = "cboxTipo_Comprobante";
            this.cboxTipo_Comprobante.Size = new System.Drawing.Size(121, 26);
            this.cboxTipo_Comprobante.TabIndex = 24;
            this.cboxTipo_Comprobante.Text = "Boleta";
            // 
            // dtfecha
            // 
            this.dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfecha.Location = new System.Drawing.Point(758, 57);
            this.dtfecha.Name = "dtfecha";
            this.dtfecha.Size = new System.Drawing.Size(129, 26);
            this.dtfecha.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(697, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo Comprobante:";
            // 
            // txtIdIVenta
            // 
            this.txtIdIVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIdIVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIVenta.Location = new System.Drawing.Point(145, 57);
            this.txtIdIVenta.Name = "txtIdIVenta";
            this.txtIdIVenta.Size = new System.Drawing.Size(110, 26);
            this.txtIdIVenta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(26, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 497);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnComprobante);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dtFechaFin);
            this.tabPage1.Controls.Add(this.dtFechaInicio);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.Listado);
            this.tabPage1.Controls.Add(this.chexbEliminar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "FechaFin:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(195, 53);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(125, 26);
            this.dtFechaFin.TabIndex = 10;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(25, 53);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(125, 26);
            this.dtFechaInicio.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "FechaInicio:";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataListado.Location = new System.Drawing.Point(6, 135);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(848, 325);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // Listado
            // 
            this.Listado.AutoSize = true;
            this.Listado.Location = new System.Drawing.Point(777, 102);
            this.Listado.Name = "Listado";
            this.Listado.Size = new System.Drawing.Size(50, 18);
            this.Listado.TabIndex = 6;
            this.Listado.Text = "label3";
            // 
            // chexbEliminar
            // 
            this.chexbEliminar.AutoSize = true;
            this.chexbEliminar.Location = new System.Drawing.Point(25, 102);
            this.chexbEliminar.Name = "chexbEliminar";
            this.chexbEliminar.Size = new System.Drawing.Size(87, 22);
            this.chexbEliminar.TabIndex = 5;
            this.chexbEliminar.Text = "Eliminar";
            this.chexbEliminar.UseVisualStyleBackColor = true;
            this.chexbEliminar.CheckedChanged += new System.EventHandler(this.chexbEliminar_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(25, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ventas";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // btnComprobante
            // 
            this.btnComprobante.ForeColor = System.Drawing.Color.Black;
            this.btnComprobante.Image = global::Capa_Presentacion.Properties.Resources.imprimir;
            this.btnComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprobante.Location = new System.Drawing.Point(651, 50);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(131, 29);
            this.btnComprobante.TabIndex = 12;
            this.btnComprobante.Text = "Comprobante";
            this.btnComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComprobante.UseVisualStyleBackColor = true;
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobante_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::Capa_Presentacion.Properties.Resources.imprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(798, 50);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 29);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = global::Capa_Presentacion.Properties.Resources.eliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(533, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 29);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::Capa_Presentacion.Properties.Resources.Buscar_p;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(413, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackgroundImage = global::Capa_Presentacion.Properties.Resources.Buscar;
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCliente.Location = new System.Drawing.Point(639, 55);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(40, 26);
            this.btnBuscarCliente.TabIndex = 37;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::Capa_Presentacion.Properties.Resources.Remove;
            this.btnQuitar.Location = new System.Drawing.Point(846, 69);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(49, 26);
            this.btnQuitar.TabIndex = 31;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Capa_Presentacion.Properties.Resources.agregar_p;
            this.btnAgregar.Location = new System.Drawing.Point(846, 32);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(49, 26);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.BackgroundImage = global::Capa_Presentacion.Properties.Resources.Buscar;
            this.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarArticulo.Location = new System.Drawing.Point(265, 25);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(40, 26);
            this.btnBuscarArticulo.TabIndex = 19;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Capa_Presentacion.Properties.Resources.error2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(801, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Capa_Presentacion.Properties.Resources.disco;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(671, 414);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Capa_Presentacion.Properties.Resources.nuevo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(544, 414);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(88, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Capa_Presentacion.Properties.Resources.pencil_scale;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(250, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmVenta";
            this.Text = ".:.Mantenimiento de ventas.:.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label lbTotalPagado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtstock_actual;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dtFechaVencimiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.TextBox txtCorrelativo;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxTipo_Comprobante;
        private System.Windows.Forms.DateTimePicker dtfecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtIdIVenta;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label Listado;
        private System.Windows.Forms.CheckBox chexbEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorIcono;
    }
}