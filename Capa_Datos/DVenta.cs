using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class DVenta
    {
        private int _IdVentas;
        private int _IdCliente;
        private int _IdTrabajador;
        private DateTime _fecha;
        private string _tipo_comprobante;
        private string _serie;
        private string _correlativo;
        private decimal _igv;

        public DVenta()
        {
        }

        public DVenta(int IdVentas, int IdCliente, int idTrabajador, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv)
        {
            _IdVentas = IdVentas;
            _IdCliente = IdCliente;
            _IdTrabajador = idTrabajador;
            _fecha = fecha;
            _tipo_comprobante = tipo_comprobante;
            _serie = serie;
            _correlativo = correlativo;
            _igv = igv;
        }

        public int IdVentas { get => _IdVentas; set => _IdVentas = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Tipo_comprobante { get => _tipo_comprobante; set => _tipo_comprobante = value; }
        public string Serie { get => _serie; set => _serie = value; }
        public string Correlativo { get => _correlativo; set => _correlativo = value; }
        public decimal Igv { get => _igv; set => _igv = value; }


        public string Insertar(DVenta venta, List<DDetalle_venta> dDetalle_Ventas)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer la transaccion
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = "spinsertar_venta";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdVenta = new SqlParameter();
                sqlParameterIdVenta.ParameterName = "@IdVentas";
                sqlParameterIdVenta.SqlDbType = SqlDbType.Int;
                sqlParameterIdVenta.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdVenta);


                SqlParameter sqlParIdCliente = new SqlParameter();
                sqlParIdCliente.ParameterName = "@IdCliente";
                sqlParIdCliente.SqlDbType = SqlDbType.Int;
                sqlParIdCliente.Value = venta.IdCliente;
                sqlCommand.Parameters.Add(sqlParIdCliente);

                SqlParameter sqlParIdTrabajador = new SqlParameter();
                sqlParIdTrabajador.ParameterName = "@IdTrabajador";
                sqlParIdTrabajador.SqlDbType = SqlDbType.Int;
                sqlParIdTrabajador.Value = venta.IdTrabajador;
                sqlCommand.Parameters.Add(sqlParIdTrabajador);

                SqlParameter sqlParFecha = new SqlParameter();
                sqlParFecha.ParameterName = "@fecha";
                sqlParFecha.SqlDbType = SqlDbType.Date;
                sqlParFecha.Value = venta.Fecha;
                sqlCommand.Parameters.Add(sqlParFecha);

                SqlParameter sqlParTipoComprobante = new SqlParameter();
                sqlParTipoComprobante.ParameterName = "@tipo_comprobante";
                sqlParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                sqlParTipoComprobante.Size = 20;
                sqlParTipoComprobante.Value = venta.Tipo_comprobante;
                sqlCommand.Parameters.Add(sqlParTipoComprobante);

                SqlParameter sqlParSerie = new SqlParameter();
                sqlParSerie.ParameterName = "@serie";
                sqlParSerie.SqlDbType = SqlDbType.VarChar;
                sqlParSerie.Size = 4;
                sqlParSerie.Value = venta.Serie;
                sqlCommand.Parameters.Add(sqlParSerie);

                SqlParameter sqlParCorrelativo = new SqlParameter();
                sqlParCorrelativo.ParameterName = "@correlativo";
                sqlParCorrelativo.SqlDbType = SqlDbType.VarChar;
                sqlParCorrelativo.Size = 7;
                sqlParCorrelativo.Value = venta.Correlativo;
                sqlCommand.Parameters.Add(sqlParCorrelativo);

                SqlParameter sqlParigv = new SqlParameter();
                sqlParigv.ParameterName = "@igv";
                sqlParigv.SqlDbType = SqlDbType.Decimal;
                sqlParigv.Value = venta.Igv;
                sqlCommand.Parameters.Add(sqlParigv);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso ningun registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.IdVentas = Convert.ToInt32(sqlCommand.Parameters["@IdVentas"].Value);
                    foreach (DDetalle_venta det in dDetalle_Ventas)
                    {
                        det.IdVenta = this.IdVentas;
                        rpta = det.Insertar(det, ref sqlConnection, ref sqlTransaction);

                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizar el stock
                            rpta = DisminuirStock(det.IdDetalleIngreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }                        
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Commit();
                    }
                }
                else
                {
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;

        }

        //Metodo disminurstock
        public string DisminuirStock(int IdDetalleIngreso, int cantidad)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spdisminuir_stock";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdDetalleIngreso = new SqlParameter();
                sqlParameterIdDetalleIngreso.ParameterName = "@IdDetalle_ingreso";
                sqlParameterIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                sqlParameterIdDetalleIngreso.Value = IdDetalleIngreso;
                sqlCommand.Parameters.Add(sqlParameterIdDetalleIngreso);

                SqlParameter sqlParameterCantidad = new SqlParameter();
                sqlParameterCantidad.ParameterName = "@cantidad";
                sqlParameterCantidad.SqlDbType = SqlDbType.Int;
                sqlParameterCantidad.Value = cantidad;
                sqlCommand.Parameters.Add(sqlParameterCantidad);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el stock";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;
        }

        public string Eliminar(DVenta venta)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "speliminar_venta";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdVentas = new SqlParameter();
                sqlParameterIdVentas.ParameterName = "@IdVentas";
                sqlParameterIdVentas.SqlDbType = SqlDbType.Int;
                sqlParameterIdVentas.Value = venta.IdVentas;
                sqlCommand.Parameters.Add(sqlParameterIdVentas);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "OK";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {

            DataTable DtResultado = new DataTable("Ventas");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_venta";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //Metodo buscar fecha
        public DataTable BuscarFecha(DateTime textoBuscar, DateTime textoBuscar2)
        {

            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_ventas_fecha";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParfechaIncial = new SqlParameter();
                sqlParfechaIncial.ParameterName = "@textofecha1";
                sqlParfechaIncial.SqlDbType = SqlDbType.Date;
                sqlParfechaIncial.Value = textoBuscar;
                //sqlParfechaIncial.Size =20;
                sqlCommand.Parameters.Add(sqlParfechaIncial);

                SqlParameter sqlParfechaFinal = new SqlParameter();
                sqlParfechaFinal.ParameterName = "@textofecha2";
                sqlParfechaFinal.SqlDbType = SqlDbType.Date;
                sqlParfechaFinal.Value = textoBuscar2;
                // sqlParfechaFinal.Size =20;
                sqlCommand.Parameters.Add(sqlParfechaFinal);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        //Metodo Mostrar detalle_ingreso
        public DataTable BuscarDetalleVenta(int detalle_venta)
        {

            DataTable DtResultado = new DataTable("Datelle_venta");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_detalles_venta";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParDetalleVenta = new SqlParameter();
                sqlParDetalleVenta.ParameterName = "@textobuscar";
                sqlParDetalleVenta.SqlDbType = SqlDbType.Int;
                sqlParDetalleVenta.Value = detalle_venta;
                sqlCommand.Parameters.Add(sqlParDetalleVenta);


                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        //Mostrar articulos por su nombre
        public DataTable MostrarArticulos_Venta_Nombre(string textobuscar)
        {

            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscararticulo_venta_nombre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParDetalleVenta = new SqlParameter();
                sqlParDetalleVenta.ParameterName = "@textobuscar";
                sqlParDetalleVenta.SqlDbType = SqlDbType.VarChar;
                sqlParDetalleVenta.Size = 50;
                sqlParDetalleVenta.Value = textobuscar;
                sqlCommand.Parameters.Add(sqlParDetalleVenta);


                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public DataTable MostrarArticulos_Venta_Codigo(string textobuscar)
        {

            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscararticulo_venta_codigo";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParDetalleVenta = new SqlParameter();
                sqlParDetalleVenta.ParameterName = "@textobuscar";
                sqlParDetalleVenta.SqlDbType = SqlDbType.VarChar;
                sqlParDetalleVenta.Size = 50;
                sqlParDetalleVenta.Value = textobuscar;
                sqlCommand.Parameters.Add(sqlParDetalleVenta);


                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }


    }
}
