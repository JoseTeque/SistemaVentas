using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using System.Data;

namespace Capa_Negocio
{
    public class NArticulos
    {
        //Metodo insertar que llama al metodo insertar de la clase DArticulos
        //de la capa datos
        public static string Insertar(string codigo,string nombre, string descripcion, byte[] imagen,int idCategoria, int idPresentacion)
        {
            DArticulos articulos = new DArticulos();
            articulos.Codigo = codigo;
            articulos.Nombre = nombre;
            articulos.Descripcion = descripcion;
            articulos.Imagen = imagen;
            articulos.IdCategoria = idCategoria;
            articulos.IdPresentacion = idPresentacion;

            return articulos.Insertar(articulos);
        }

        //Metodo insertar que llama al metodo insertar de la clase DArticulos
        //de la capa datos

        public static string Editar(int IdArticulo,string codigo, string nombre, string descripcion,byte[] imagen, int idCategoria, int idPresentacion)
        {
            DArticulos articulos = new DArticulos();
            articulos.IdArticulo = IdArticulo;
            articulos.Codigo = codigo;
            articulos.Nombre = nombre;
            articulos.Descripcion = descripcion;
            articulos.Imagen = imagen;
            articulos.IdCategoria = idCategoria;
            articulos.IdPresentacion = idPresentacion;

            return articulos.Editar(articulos);

        }

        //Metodo eliminar que llama al metodo insertar de la clase DArticulos
        //de la capa datos

        public static string Eliminar(int IdArticulo)
        {
            DArticulos articulos = new DArticulos();
            articulos.IdArticulo = IdArticulo;

            return articulos.Eliminar(articulos);
        }

        //Metodo mostrar que llama al metodo insertar de la clase DArticulos
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DArticulos().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DArticulos
        //de la capa datos

        public static DataTable Buscar(string textoBuscar)
        {
            DArticulos articulos = new DArticulos();

            articulos.TextoBuscar = textoBuscar;

            return articulos.BuscarNombre(articulos);

        }
    }
}
