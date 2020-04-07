using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
   public class NProveedor
    {
        //Metodo insertar que llama al metodo insertar de la clase DProveedor
        //de la capa datos
        public static string Insertar(string razonSocial, string sectorComercial, string tipoDocumento, string numDocumento, string direccion, string telefono,string email, string url)
        {
            DProveedor proveedor = new DProveedor();
            proveedor.RazonSocial = razonSocial;
            proveedor.SectorComercial = sectorComercial;
            proveedor.TipoDocumento = tipoDocumento;
            proveedor.NumDocumento = numDocumento;
            proveedor.Direccion = direccion;
            proveedor.Telefono = telefono;
            proveedor.Email = email;
            proveedor.Url = url;
            return proveedor.Insertar(proveedor);
        }

        //Metodo insertar que llama al metodo insertar de la clase DProveedor
        //de la capa datos

        public static string Editar(int IdProveedor,string razonSocial, string sectorComercial, string tipoDocumento, string numDocumento, string direccion, string telefono, string email, string url)
        {
            DProveedor proveedor = new DProveedor();
            proveedor.IdProveedor = IdProveedor;
            proveedor.RazonSocial = razonSocial;
            proveedor.SectorComercial = sectorComercial;
            proveedor.TipoDocumento = tipoDocumento;
            proveedor.NumDocumento = numDocumento;
            proveedor.Direccion = direccion;
            proveedor.Telefono = telefono;
            proveedor.Email = email;
            proveedor.Url = url;
            return proveedor.Editar(proveedor);

        }

        //Metodo eliminar que llama al metodo insertar de la clase DProveedor
        //de la capa datos

        public static string Eliminar(int IdProveedor)
        {
            DProveedor proveedor = new DProveedor();
            proveedor.IdProveedor = IdProveedor;

            return proveedor.Eliminar(proveedor);
        }

        //Metodo mostrar que llama al metodo insertar de la clase DProveedor
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DProveedor
        //de la capa datos

        public static DataTable BuscarRazonSocial(string textoBuscar)
        {
            DProveedor proveedor = new DProveedor();

            proveedor.TextoBuscar = textoBuscar;

            return proveedor.BuscarRazonSocial(proveedor);

        }

        public static DataTable BuscarNumDocmuento(string numDocumento)
        {
            DProveedor proveedor = new DProveedor();

            proveedor.NumDocumentoBuscar = numDocumento;

            return proveedor.BuscarNumDocumento(proveedor);

        }
    }
}
