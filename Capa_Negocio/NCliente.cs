using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using System.Data;

namespace Capa_Negocio
{
    public class NCliente
    { 
    //Metodo insertar que llama al metodo insertar de la clase DCliente
    //de la capa datos
    public static string Insertar(string nombre, string apellidos, string sexo, string tipodocumento, DateTime fechaNacimiento, string numdocumento, string direccion, string telefono, string email)
    {
        DCliente cliente = new DCliente();
        cliente.Nombre = nombre;
        cliente.Apellidos = apellidos;
        cliente.Sexo = sexo;
        cliente.Tipo_documento = tipodocumento;
        cliente.FechaNacimiento = fechaNacimiento;
        cliente.Num_documento = numdocumento;
        cliente.Direccion = direccion;
        cliente.Telefono = telefono;
        cliente.Email = email;

        return cliente.Insertar(cliente);
    }

    //Metodo insertar que llama al metodo insertar de la clase DCliente
    //de la capa datos

    public static string Editar(int IdCliente,string nombre, string apellidos, string sexo, string tipodocumento, DateTime fechaNacimiento, string numdocumento, string direccion, string telefono, string email)
        {
            DCliente cliente = new DCliente();
            cliente.IdCliente = IdCliente;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.Tipo_documento = tipodocumento;
            cliente.FechaNacimiento = fechaNacimiento;
            cliente.Num_documento = numdocumento;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            return cliente.Editar(cliente);

        }

    //Metodo eliminar que llama al metodo insertar de la clase DCliente
    //de la capa datos

    public static string Eliminar(int IdCliente)
    {
        DCliente cliente = new DCliente();
            cliente.IdCliente = IdCliente;

        return cliente.Eliminar(cliente);
    }

        //Metodo mostrar que llama al metodo insertar de la clase DCliente
        //de la capa datos

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
    }


    //Metodo BUSCAR que llama al metodo insertar de la clase DCliente
    //de la capa datos

    public static DataTable BuscarApellido(string textoBuscar)
    {
        DCliente cliente = new DCliente();

        cliente.TextoBuscar = textoBuscar;

        return cliente.BuscarApellido(cliente);

    }


        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            DCliente cliente = new DCliente();

            cliente.TextoNumDocumento = textoBuscar;

            return cliente.BuscarNumDocumento(cliente);

        }
    }
}
