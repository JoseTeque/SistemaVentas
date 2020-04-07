using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class NIngreso

    {        //Metodo insertar que llama al metodo insertar de la clase DIngreso
            //de la capa datos
            public static string Insertar( int IdTrabajador, int IdProveedor, DateTime Fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado,DataTable detalle)
            {
                DIngreso ingreso = new DIngreso();
                ingreso.IdTrabajador = IdTrabajador;
                ingreso.IdProveedor = IdProveedor;
                ingreso.Fecha = Fecha;
                ingreso.Tipo_comprobante = tipo_comprobante;
                ingreso.Serie = serie;
                ingreso.Correlativo = correlativo;
                ingreso.Igv = igv;
                ingreso.Estado = estado;
                List<DDetalleIngreso> detalleIngresos = new List<DDetalleIngreso>();
                foreach (DataRow data in detalle.Rows)
                {
                    DDetalleIngreso dDetalle = new DDetalleIngreso();
                    dDetalle.IdArticulo = Convert.ToInt32(data["IdArticulo"].ToString());
                    dDetalle.Precio_compra = Convert.ToDecimal(data["precio_compra"].ToString());
                    dDetalle.Precio_venta = Convert.ToDecimal(data["precio_venta"].ToString());
                    dDetalle.Stock_inicial = Convert.ToInt32(data["stock_inicial"].ToString());
                    dDetalle.Stock_actual = Convert.ToInt32(data["stock_inicial"].ToString());
                    dDetalle.Fecha_produccion = Convert.ToDateTime(data["fecha_produccion"].ToString());
                    dDetalle.Fecha_vencimiento = Convert.ToDateTime(data["fecha_vencimiento"].ToString());
                     detalleIngresos.Add(dDetalle);

                }

                return ingreso.Insertar(ingreso,detalleIngresos);
            }

         //Metodo eliminar que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static string Anular(int IdIngreso)
            {
                DIngreso ingreso = new DIngreso();
                ingreso.IdIngreso = IdIngreso;

                return ingreso.Anular(ingreso);
            }

        //Metodo mostrar que llama al metodo mostrar de la clase DIngreso
        //de la capa datos

        public static DataTable MostrarIngreso()
            {
                return new DIngreso().Mostrar();
            }


        //Metodo BUSCAR que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static DataTable BuscarFecha(DateTime textoBuscar,DateTime textoBuscarFecha)
            {

            return new DIngreso().BuscarFecha(textoBuscar,textoBuscarFecha);

            }

        //Metodo BUSCAR que llama al metodo insertar de la clase DIngreso
        //de la capa datos

        public static DataTable MostrarDetalleIngreso(string textoBuscar)
        {

            return new DIngreso().BuscarDetalleIngreso(textoBuscar);

        }
    }
}
