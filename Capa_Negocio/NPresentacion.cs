using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NPresentacion
    {
        //Metodo insertar que llama al metodo insertar de la clase DPresentacion
        //de la capa datos
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion  dPresentacion = new DPresentacion();
            dPresentacion.Nombre = nombre;
            dPresentacion.Descripcion = descripcion;

            return dPresentacion.Insertar(dPresentacion);
        }

        //Metodo insertar que llama al metodo insertar de la clase DPresentacion
        //de la capa datos

        public static string Editar(int IdPresentacion, string nombre, string descripcion)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.IdPresentacion = IdPresentacion;
            dPresentacion.Nombre = nombre;
            dPresentacion.Descripcion = descripcion;

            return dPresentacion.Editar(dPresentacion);

        }

        //Metodo eliminar que llama al metodo insertar de la clase DPresentacion
        //de la capa datos

        public static string Eliminar(int IdPresentacion)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.IdPresentacion = IdPresentacion;

            return dPresentacion.Eliminar(dPresentacion);
        }

        //Metodo mostrar que llama al metodo insertar de la clase DPresentacion
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DPresentacion
        //de la capa datos

        public static DataTable Buscar(string textoBuscar)
        {
            DPresentacion dPresentacion = new DPresentacion();

            dPresentacion.TextoBuscar = textoBuscar;

            return dPresentacion.BuscarNombre(dPresentacion);

        }
    }
}
