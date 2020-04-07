using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class DIngreso
    {
        private int _IdIngreso;
        private int _IdTrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _tipo_comprobante;
        private string _serie;
        private string _correlativo;
        private decimal _igv;
        private string _estado;
  

        public DIngreso()
        {
        }

        public DIngreso(int IdIngreso, int IdTrabajador, int IdProveedor, DateTime Fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado)
        {
            _IdIngreso = IdIngreso;
            _IdTrabajador = IdTrabajador;
            _IdProveedor = IdProveedor;
            _Fecha = Fecha;
            _tipo_comprobante = tipo_comprobante;
            _serie = serie;
            _correlativo = correlativo;
            _igv = igv;
            _estado = estado;

        }

        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _tipo_comprobante; set => _tipo_comprobante = value; }
        public string Serie { get => _serie; set => _serie = value; }
        public string Correlativo { get => _correlativo; set => _correlativo = value; }
        public decimal Igv { get => _igv; set => _igv = value; }
        public string Estado { get => _estado; set => _estado = value; }


        //Metodo Insertar
        public string Insertar(DIngreso ingreso, List<DDetalleIngreso> detalleIngreso)
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
                sqlCommand.CommandText = "spinsertar_ingresos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdIngreso = new SqlParameter();
                sqlParameterIdIngreso.ParameterName = "@IdIngreso";
                sqlParameterIdIngreso.SqlDbType = SqlDbType.Int;
                sqlParameterIdIngreso.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdIngreso);


                SqlParameter sqlParIdTrabajador = new SqlParameter();
                sqlParIdTrabajador.ParameterName = "@IdTrabajador";
                sqlParIdTrabajador.SqlDbType = SqlDbType.Int;
                sqlParIdTrabajador.Value = ingreso.IdTrabajador;
                sqlCommand.Parameters.Add(sqlParIdTrabajador);

                SqlParameter sqlParIdProveedor = new SqlParameter();
                sqlParIdProveedor.ParameterName = "@IdProveedor";
                sqlParIdProveedor.SqlDbType = SqlDbType.Int;
                sqlParIdProveedor.Value = ingreso.IdProveedor;
                sqlCommand.Parameters.Add(sqlParIdProveedor);

                SqlParameter sqlParFecha = new SqlParameter();
                sqlParFecha.ParameterName = "@fecha";
                sqlParFecha.SqlDbType = SqlDbType.Date;
                sqlParFecha.Value = ingreso.Fecha;
                sqlCommand.Parameters.Add(sqlParFecha);

                SqlParameter sqlParTipoComprobante= new SqlParameter();
                sqlParTipoComprobante.ParameterName = "@tipo_comprobante";
                sqlParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                sqlParTipoComprobante.Size = 20;
                sqlParTipoComprobante.Value = ingreso.Tipo_comprobante;
                sqlCommand.Parameters.Add(sqlParTipoComprobante);

                SqlParameter sqlParSerie = new SqlParameter();
                sqlParSerie.ParameterName = "@serie";
                sqlParSerie.SqlDbType = SqlDbType.VarChar;
                sqlParSerie.Size = 4;
                sqlParSerie.Value = ingreso.Serie;
                sqlCommand.Parameters.Add(sqlParSerie);

                SqlParameter sqlParCorrelativo = new SqlParameter();
                sqlParCorrelativo.ParameterName = "@correlativo";
                sqlParCorrelativo.SqlDbType = SqlDbType.VarChar;
                sqlParCorrelativo.Size = 7;
                sqlParCorrelativo.Value = ingreso.Correlativo;
                sqlCommand.Parameters.Add(sqlParCorrelativo);

                SqlParameter sqlParigv = new SqlParameter();
                sqlParigv.ParameterName = "@igv";
                sqlParigv.SqlDbType = SqlDbType.Decimal;
                sqlParigv.Value = ingreso.Igv;
                sqlCommand.Parameters.Add(sqlParigv);

                SqlParameter sqlParEstado = new SqlParameter();
                sqlParEstado.ParameterName = "@estado";
                sqlParEstado.SqlDbType = SqlDbType.VarChar;
                sqlParEstado.Size = 7;
                sqlParEstado.Value = ingreso.Estado;
                sqlCommand.Parameters.Add(sqlParEstado);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso ningun registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.IdIngreso = Convert.ToInt32(sqlCommand.Parameters["@IdIngreso"].Value);
                    foreach(DDetalleIngreso det in detalleIngreso)
                    {
                        det.IdIngreso = this.IdIngreso;
                        rpta = det.Insertar(det, ref sqlConnection, ref sqlTransaction);

                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    sqlTransaction.Commit();
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

        //Metodo Anular
        public string Anular(DIngreso ingreso)
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
                sqlCommand.CommandText = "spanular_ingresos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdIngreso = new SqlParameter();
                sqlParameterIdIngreso.ParameterName = "@IdIngreso";
                sqlParameterIdIngreso.SqlDbType = SqlDbType.Int;
                sqlParameterIdIngreso.Value = ingreso.IdIngreso;
                sqlCommand.Parameters.Add(sqlParameterIdIngreso);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

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

            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_ingresos";
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
                sqlCommand.CommandText = "spbuscar_ingresos_fecha";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParfechaIncial = new SqlParameter();
                sqlParfechaIncial.ParameterName = "@textobuscar";
                sqlParfechaIncial.SqlDbType = SqlDbType.Date;
                sqlParfechaIncial.Value = textoBuscar;
                //sqlParfechaIncial.Size =20;
                sqlCommand.Parameters.Add(sqlParfechaIncial);

                SqlParameter sqlParfechaFinal = new SqlParameter();
                sqlParfechaFinal.ParameterName = "@textobuscar1";
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
        public DataTable BuscarDetalleIngreso(string detalle_ingreso)
        {

            DataTable DtResultado = new DataTable("DetalleIngreso");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_detalle_ingresos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParDetalleIngreso = new SqlParameter();
                sqlParDetalleIngreso.ParameterName = "@textobuscar";
                sqlParDetalleIngreso.SqlDbType = SqlDbType.VarChar;
                sqlParDetalleIngreso.Value = detalle_ingreso;
                sqlParDetalleIngreso.Size = 50;
                sqlCommand.Parameters.Add(sqlParDetalleIngreso);


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
