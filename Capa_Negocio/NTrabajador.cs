using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using System.Data;

namespace Capa_Negocio
{
   public  class NTrabajador
    {
        //Metodo insertar que llama al metodo insertar de la clase DTrabajador
        //de la capa datos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fechaNacimiento, string numdocumento, string direccion, string telefono, string email,string acceso, string usuario, string password)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.Nombre = nombre;
            trabajador.Apellidos = apellidos;
            trabajador.Sexo = sexo;
            trabajador.FechaNacimiento = fechaNacimiento;
            trabajador.Num_documento = numdocumento;
            trabajador.Direccion = direccion;
            trabajador.Telefono = telefono;
            trabajador.Email = email;
            trabajador.Acceso = acceso;
            trabajador.Usuario = usuario;
            trabajador.Password = password;

            return trabajador.Insertar(trabajador);
        }

        //Metodo insertar que llama al metodo insertar de la clase DTrabajador
        //de la capa datos

        public static string Editar(int IdTrabajador, string nombre, string apellidos, string sexo, DateTime fechaNacimiento, string numdocumento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.IdTrabajador = IdTrabajador;
            trabajador.Nombre = nombre;
            trabajador.Apellidos = apellidos;
            trabajador.Sexo = sexo;
            trabajador.FechaNacimiento = fechaNacimiento;
            trabajador.Num_documento = numdocumento;
            trabajador.Direccion = direccion;
            trabajador.Telefono = telefono;
            trabajador.Email = email;
            trabajador.Acceso = acceso;
            trabajador.Usuario = usuario;
            trabajador.Password = password;

            return trabajador.Editar(trabajador);

        }

        //Metodo eliminar que llama al metodo insertar de la clase DTrabajador
        //de la capa datos

        public static string Eliminar(int IdTrabajador)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.IdTrabajador = IdTrabajador;

            return trabajador.Eliminar(trabajador);
        }

        //Metodo mostrar que llama al metodo insertar de la clase DTrabajador
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }


        //Metodo BUSCAR que llama al metodo insertar de la clase DTrabajador
        //de la capa datos

        public static DataTable BuscarApellido(string textoBuscar)
        {
            DTrabajador trabajador = new DTrabajador();

            trabajador.TextoBuscar = textoBuscar;

            return trabajador.BuscarApellido(trabajador);

        }


        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            DTrabajador trabajador = new DTrabajador();

            trabajador.TextoNumDocumento = textoBuscar;

            return trabajador.BuscarNumDocumento(trabajador);

        }
    }
}
