using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class DDetalle_venta
    {
        private int _IdDetalleVenta;
        private int _IdVenta;
        private int _IdDetalleIngreso;
        private int _cantidad;
        private decimal _precio_venta;
        private decimal _descuento;



        public DDetalle_venta()
        {
        }

        public DDetalle_venta(int IdDetalleVenta, int IdVenta, int IdDetalleIngreso, int cantidad, decimal precio_venta, decimal descuento)
        {
            _IdDetalleVenta = IdDetalleVenta;
            _IdVenta = IdVenta;
            _IdDetalleIngreso = IdDetalleIngreso;
            _cantidad = cantidad;
            _precio_venta = precio_venta;
            _descuento = descuento;
        }

        public int IdDetalleVenta { get => _IdDetalleVenta; set => _IdDetalleVenta = value; }
        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public int IdDetalleIngreso { get => _IdDetalleIngreso; set => _IdDetalleIngreso = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }
        public decimal Descuento { get => _descuento; set => _descuento = value; }


        //Metodo Insertar
        public string Insertar(DDetalle_venta dDetalle, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            string rpta = "";          
            try
            {     
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = "spinsertar_detalle_venta";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdDetalleVenta = new SqlParameter();
                sqlParameterIdDetalleVenta.ParameterName = "@IdDetalleVenta";
                sqlParameterIdDetalleVenta.SqlDbType = SqlDbType.Int;
                sqlParameterIdDetalleVenta.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdDetalleVenta);


                SqlParameter sqlParIdVenta = new SqlParameter();
                sqlParIdVenta.ParameterName = "@IdVenta";
                sqlParIdVenta.SqlDbType = SqlDbType.Int;
                sqlParIdVenta.Value = dDetalle.IdVenta;
                sqlCommand.Parameters.Add(sqlParIdVenta);

                SqlParameter sqlParIdDetalleIngreso = new SqlParameter();
                sqlParIdDetalleIngreso.ParameterName = "@IdDetalleIngreso";
                sqlParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                sqlParIdDetalleIngreso.Value = dDetalle.IdDetalleIngreso;
                sqlCommand.Parameters.Add(sqlParIdDetalleIngreso);

                SqlParameter sqlParCantidad = new SqlParameter();
                sqlParCantidad.ParameterName = "@cantidad";
                sqlParCantidad.SqlDbType = SqlDbType.Int;
                sqlParCantidad.Value = dDetalle.Cantidad;
                sqlCommand.Parameters.Add(sqlParCantidad);

                SqlParameter sqlParPrecioVenta = new SqlParameter();
                sqlParPrecioVenta.ParameterName = "@precio_venta";
                sqlParPrecioVenta.SqlDbType = SqlDbType.Decimal;
                sqlParPrecioVenta.Value = dDetalle.Precio_venta;
                sqlCommand.Parameters.Add(sqlParPrecioVenta);

                SqlParameter sqlParDescuento = new SqlParameter();
                sqlParDescuento.ParameterName = "@descuento";
                sqlParDescuento.SqlDbType = SqlDbType.Decimal;
                sqlParDescuento.Value = dDetalle.Descuento;
                sqlCommand.Parameters.Add(sqlParDescuento);


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
