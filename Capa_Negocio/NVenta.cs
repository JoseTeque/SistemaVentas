using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NVenta
    {
        public static string Insertar( int IdCliente, int idTrabajador, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, DataTable detalle)
        {
            DVenta venta = new DVenta();
            venta.IdCliente = IdCliente;
            venta.IdTrabajador = idTrabajador;
            venta.Fecha = fecha;
            venta.Tipo_comprobante = tipo_comprobante;
            venta.Serie = serie;
            venta.Correlativo = correlativo;
            venta.Igv = igv;
            List<DDetalle_venta> dventas = new List<DDetalle_venta>();
            foreach (DataRow data in detalle.Rows)
            {
                DDetalle_venta dDetalle = new DDetalle_venta();
                dDetalle.IdDetalleIngreso = Convert.ToInt32(data["IdDetalle_Ingreso"].ToString());
                dDetalle.Cantidad = Convert.ToInt32(data["cantidad"].ToString());
                dDetalle.Precio_venta = Convert.ToDecimal(data["precio_venta"].ToString());        
                dDetalle.Descuento = Convert.ToInt32(data["descuento"].ToString());
                dventas.Add(dDetalle);

            }

            return venta.Insertar(venta, dventas);
        }

        //Metodo eliminar que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static string Eliminar(int IdVenta)
        {
            DVenta venta = new DVenta();
            venta.IdVentas = IdVenta;

            return venta.Eliminar(venta);
        }

        //Metodo mostrar que llama al metodo mostrar de la clase DIngreso
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static DataTable BuscarFecha(DateTime textoBuscar, DateTime textoBuscarFecha)
        {

            return new DVenta().BuscarFecha(textoBuscar, textoBuscarFecha);

        }

        //Metodo BUSCAR que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static DataTable MostrarDetalleVenta(int textoBuscar)
        {

            return new DVenta().BuscarDetalleVenta(textoBuscar);

        }
        public static DataTable MostrarArticulos_Venta_Nombre(string textoBuscar)
        {

            return new DVenta().MostrarArticulos_Venta_Nombre(textoBuscar);

        }

        public static DataTable MostrarArticulos_Venta_Codigo(string textoBuscar)
        {

            return new DVenta().MostrarArticulos_Venta_Codigo(textoBuscar);

        }
    }
}
