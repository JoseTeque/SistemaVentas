using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using System.Data;

namespace Capa_Negocio
{
  public class NCategoria
    {
        //Metodo insertar que llama al metodo insertar de la clase DCategoria
        //de la capa datos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.Nombre = nombre;
            dCategoria.Descripcion = descripcion;

            return dCategoria.Insertar(dCategoria);
        }

        //Metodo insertar que llama al metodo insertar de la clase DCategoria
        //de la capa datos

        public static string Editar(int IdCategoria, string nombre, string descripcion)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.IdCategoria = IdCategoria;
            dCategoria.Nombre = nombre;
            dCategoria.Descripcion = descripcion;

            return dCategoria.Editar(dCategoria);

        }

        //Metodo eliminar que llama al metodo insertar de la clase DCategoria
        //de la capa datos

        public static string Eliminar(int IdCategoria)
        {
            DCategoria dCategoria = new DCategoria();
            dCategoria.IdCategoria = IdCategoria;

            return dCategoria.Eliminar(dCategoria);
        }

        //Metodo mostrar que llama al metodo insertar de la clase DCategoria
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DCategoria
        //de la capa datos

        public static DataTable Buscar(string textoBuscar)
        {
            DCategoria dCategoria = new DCategoria();

            dCategoria.TextoBuscar = textoBuscar;

            return dCategoria.BuscarNombre(dCategoria);

        }

    }
}
