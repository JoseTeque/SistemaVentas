using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
   public class DDetalleIngreso
    {
        private int _IdDetalleIngreso;
        private int _IdIngreso;
        private int _IdArticulo;
        private decimal _precio_compra;
        private decimal _precio_venta;
        private int _stock_inicial;
        private int _stock_actual;
        private DateTime _fecha_produccion;
        private DateTime _fecha_vencimiento;

        public DDetalleIngreso()
        {
        }

        public DDetalleIngreso(int IdDetalleIngreso, int IdIngreso, int IdArticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            _IdDetalleIngreso = IdDetalleIngreso;
            _IdIngreso = IdIngreso;
            _IdArticulo = IdArticulo;
            _precio_compra = precio_compra;
            _precio_venta = precio_venta;
            _stock_inicial = stock_inicial;
            _stock_actual = stock_actual;
            _fecha_produccion = fecha_produccion;
            _fecha_vencimiento = fecha_vencimiento;
        }

        public int IdDetalleIngreso { get => _IdDetalleIngreso; set => _IdDetalleIngreso = value; }
        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public decimal Precio_compra { get => _precio_compra; set => _precio_compra = value; }
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }
        public int Stock_inicial { get => _stock_inicial; set => _stock_inicial = value; }
        public int Stock_actual { get => _stock_actual; set => _stock_actual = value; }
        public DateTime Fecha_produccion { get => _fecha_produccion; set => _fecha_produccion = value; }
        public DateTime Fecha_vencimiento { get => _fecha_vencimiento; set => _fecha_vencimiento = value; }

        //METODO INSERTAR

        public string Insertar(DDetalleIngreso detalleIngreso, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            string rpta = "";
            try
            {
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = "spinsertar_detalle_ingresos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdDetalleIngreso = new SqlParameter();
                sqlParameterIdDetalleIngreso.ParameterName = "@IdDetalleIngreso";
                sqlParameterIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                sqlParameterIdDetalleIngreso.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdDetalleIngreso);

                SqlParameter sqlParameterIdArticulo = new SqlParameter();
                sqlParameterIdArticulo.ParameterName = "@IdArticulo";
                sqlParameterIdArticulo.SqlDbType = SqlDbType.Int;
                sqlParameterIdArticulo.Value = detalleIngreso.IdArticulo;
                sqlCommand.Parameters.Add(sqlParameterIdArticulo);

                SqlParameter sqlParameterIdIngreso = new SqlParameter();
                sqlParameterIdIngreso.ParameterName = "@IdIngreso";
                sqlParameterIdIngreso.SqlDbType = SqlDbType.Int;
                sqlParameterIdIngreso.Value = detalleIngreso.IdIngreso;
                sqlCommand.Parameters.Add(sqlParameterIdIngreso);


                SqlParameter sqlParPreCompra = new SqlParameter();
                sqlParPreCompra.ParameterName = "@precio_compra";
                sqlParPreCompra.SqlDbType = SqlDbType.Money;
                sqlParPreCompra.Value = detalleIngreso.Precio_compra;
                sqlCommand.Parameters.Add(sqlParPreCompra);

                SqlParameter sqlParPreVenta = new SqlParameter();
                sqlParPreVenta.ParameterName = "@precio_venta";
                sqlParPreVenta.SqlDbType = SqlDbType.Money;
                sqlParPreVenta.Value = detalleIngreso.Precio_venta;
                sqlCommand.Parameters.Add(sqlParPreVenta);

                SqlParameter sqlParStockInicial = new SqlParameter();
                sqlParStockInicial.ParameterName = "@stock_inicial";
                sqlParStockInicial.SqlDbType = SqlDbType.Int;
                sqlParStockInicial.Value = detalleIngreso.Stock_inicial;
                sqlCommand.Parameters.Add(sqlParStockInicial);

                SqlParameter sqlParStockActual = new SqlParameter();
                sqlParStockActual.ParameterName = "@stock_actual";
                sqlParStockActual.SqlDbType = SqlDbType.Int;
                sqlParStockActual.Value = detalleIngreso.Stock_actual;
                sqlCommand.Parameters.Add(sqlParStockActual);

                SqlParameter sqlParFechaProduccion = new SqlParameter();
                sqlParFechaProduccion.ParameterName = "@fecha_produccion";
                sqlParFechaProduccion.SqlDbType = SqlDbType.Date;
                sqlParFechaProduccion.Value = detalleIngreso.Fecha_produccion;
                sqlCommand.Parameters.Add(sqlParFechaProduccion);

                SqlParameter sqlParFechaVencimiento = new SqlParameter();
                sqlParFechaVencimiento.ParameterName = "@fecha_vencimiento";
                sqlParFechaVencimiento.SqlDbType = SqlDbType.Date;
                sqlParFechaVencimiento.Value = detalleIngreso.Fecha_vencimiento;
                sqlCommand.Parameters.Add(sqlParFechaVencimiento);


                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso ningun registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }

    }
}
