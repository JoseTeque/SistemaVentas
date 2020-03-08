using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_datos
{
   public class DCliente
    {
        private int _IdCliente;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private string _Tipo_documento;
        private DateTime _FechaNacimiento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;
        private string _TextoNumDocumento;

      
        public DCliente()
        {
        }

        public DCliente(int IdCliente, string Nombre, string Apellidos, string Sexo, string Tipo_documento, DateTime FechaNacimiento, string Num_documento, string Direccion, string Telefono, string Email, string TextoBuscar, string TextoNumDocumento)
        {
            _IdCliente = IdCliente;
            _Nombre = Nombre;
            _Apellidos = Apellidos;
            _Sexo = Sexo;
            _Tipo_documento = Tipo_documento;
            _FechaNacimiento = FechaNacimiento;
            _Num_documento = Num_documento;
            _Direccion = Direccion;
            _Telefono = Telefono;
            _Email = Email;
            _TextoBuscar = TextoBuscar;
            _TextoNumDocumento = TextoNumDocumento;
        }

        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Tipo_documento { get => _Tipo_documento; set => _Tipo_documento = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string TextoNumDocumento { get => _TextoNumDocumento; set => _TextoNumDocumento = value; }




        //Metodo Insertar
        public string Insertar(DCliente cliente)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spinsertar_cliente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCliente = new SqlParameter();
                sqlParameterIdCliente.ParameterName = "@IdCliente";
                sqlParameterIdCliente.SqlDbType = SqlDbType.Int;
                sqlParameterIdCliente.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdCliente);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = cliente.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParameterApellidos = new SqlParameter();
                sqlParameterApellidos.ParameterName = "@apellidos";
                sqlParameterApellidos.SqlDbType = SqlDbType.VarChar;
                sqlParameterApellidos.Size = 50;
                sqlParameterApellidos.Value = cliente.Apellidos;
                sqlCommand.Parameters.Add(sqlParameterApellidos);

                SqlParameter sqlParameterSexo = new SqlParameter();
                sqlParameterSexo.ParameterName = "@sexo";
                sqlParameterSexo.SqlDbType = SqlDbType.VarChar;
                sqlParameterSexo.Size = 1;
                sqlParameterSexo.Value = cliente.Sexo;
                sqlCommand.Parameters.Add(sqlParameterSexo);


                SqlParameter sqlParameterTipoDocumento = new SqlParameter();
                sqlParameterTipoDocumento.ParameterName = "@tipo_documento";
                sqlParameterTipoDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterTipoDocumento.Size = 50;
                sqlParameterTipoDocumento.Value = cliente.Tipo_documento;
                sqlCommand.Parameters.Add(sqlParameterTipoDocumento);

                SqlParameter sqlParameterFechaNacimiento = new SqlParameter();
                sqlParameterFechaNacimiento.ParameterName = "@fecha_nacimiento";
                sqlParameterFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                sqlParameterFechaNacimiento.Value = cliente.FechaNacimiento;
                sqlCommand.Parameters.Add(sqlParameterFechaNacimiento);

                SqlParameter sqlParameterNumDocumento = new SqlParameter();
                sqlParameterNumDocumento.ParameterName = "@num_documento";
                sqlParameterNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterNumDocumento.Size = 50;
                sqlParameterNumDocumento.Value = cliente.Num_documento;
                sqlCommand.Parameters.Add(sqlParameterNumDocumento);

                SqlParameter sqlParameterDireccion = new SqlParameter();
                sqlParameterDireccion.ParameterName = "@direccion";
                sqlParameterDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParameterDireccion.Size = 50;
                sqlParameterDireccion.Value = cliente.Direccion;
                sqlCommand.Parameters.Add(sqlParameterDireccion);

                SqlParameter sqlParameterTelefono = new SqlParameter();
                sqlParameterTelefono.ParameterName = "@telefono";
                sqlParameterTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParameterTelefono.Size = 50;
                sqlParameterTelefono.Value = cliente.Telefono;
                sqlCommand.Parameters.Add(sqlParameterTelefono);

                SqlParameter sqlParameterEmail = new SqlParameter();
                sqlParameterEmail.ParameterName = "@email";
                sqlParameterEmail.SqlDbType = SqlDbType.VarChar;
                sqlParameterEmail.Size = 50;
                sqlParameterEmail.Value = cliente.Email;
                sqlCommand.Parameters.Add(sqlParameterEmail);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso ningun registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;

        }

        //Metodo Editar
        public string Editar(DCliente cliente)
        {

            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "speditar_cliente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCliente = new SqlParameter();
                sqlParameterIdCliente.ParameterName = "@IdCliente";
                sqlParameterIdCliente.SqlDbType = SqlDbType.Int;
                sqlParameterIdCliente.Value = cliente.IdCliente;
                sqlCommand.Parameters.Add(sqlParameterIdCliente);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = cliente.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParameterApellidos = new SqlParameter();
                sqlParameterApellidos.ParameterName = "@apellidos";
                sqlParameterApellidos.SqlDbType = SqlDbType.VarChar;
                sqlParameterApellidos.Size = 50;
                sqlParameterApellidos.Value = cliente.Apellidos;
                sqlCommand.Parameters.Add(sqlParameterApellidos);

                SqlParameter sqlParameterSexo = new SqlParameter();
                sqlParameterSexo.ParameterName = "@sexo";
                sqlParameterSexo.SqlDbType = SqlDbType.VarChar;
                sqlParameterSexo.Size = 1;
                sqlParameterSexo.Value = cliente.Sexo;
                sqlCommand.Parameters.Add(sqlParameterSexo);


                SqlParameter sqlParameterTipoDocumento = new SqlParameter();
                sqlParameterTipoDocumento.ParameterName = "@tipo_documento";
                sqlParameterTipoDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterTipoDocumento.Size = 50;
                sqlParameterTipoDocumento.Value = cliente.Tipo_documento;
                sqlCommand.Parameters.Add(sqlParameterTipoDocumento);

                SqlParameter sqlParameterFechaNacimiento = new SqlParameter();
                sqlParameterFechaNacimiento.ParameterName = "@fecha_nacimiento";
                sqlParameterFechaNacimiento.SqlDbType = SqlDbType.Date;
                sqlParameterFechaNacimiento.Value = cliente.FechaNacimiento;
                sqlCommand.Parameters.Add(sqlParameterFechaNacimiento);

                SqlParameter sqlParameterNumDocumento = new SqlParameter();
                sqlParameterNumDocumento.ParameterName = "@num_documento";
                sqlParameterNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterNumDocumento.Size = 50;
                sqlParameterNumDocumento.Value = cliente.Num_documento;
                sqlCommand.Parameters.Add(sqlParameterNumDocumento);

                SqlParameter sqlParameterDireccion = new SqlParameter();
                sqlParameterDireccion.ParameterName = "@direccion";
                sqlParameterDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParameterDireccion.Size = 50;
                sqlParameterDireccion.Value = cliente.Direccion;
                sqlCommand.Parameters.Add(sqlParameterDireccion);

                SqlParameter sqlParameterTelefono = new SqlParameter();
                sqlParameterTelefono.ParameterName = "@telefono";
                sqlParameterTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParameterTelefono.Size = 50;
                sqlParameterTelefono.Value = cliente.Telefono;
                sqlCommand.Parameters.Add(sqlParameterTelefono);

                SqlParameter sqlParameterEmail = new SqlParameter();
                sqlParameterEmail.ParameterName = "@email";
                sqlParameterEmail.SqlDbType = SqlDbType.VarChar;
                sqlParameterEmail.Size = 50;
                sqlParameterEmail.Value = cliente.Email;
                sqlCommand.Parameters.Add(sqlParameterEmail);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo ningun registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(DCliente cliente)
        {
            string rpta = "";
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                sqlConnection.Open();
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "speliminar_cliente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCliente = new SqlParameter();
                sqlParameterIdCliente.ParameterName = "@IdCliente";
                sqlParameterIdCliente.SqlDbType = SqlDbType.Int;
                sqlParameterIdCliente.Value = cliente.IdCliente;
                sqlCommand.Parameters.Add(sqlParameterIdCliente);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {

            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_cliente";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //Metodo buscar nombre
        public DataTable BuscarApellido(DCliente cliente)
        {

            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_cliente_apellidos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textoBuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = cliente.TextoBuscar;
                sqlParametertextoBuscar.Size = 50;
                sqlCommand.Parameters.Add(sqlParametertextoBuscar);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public DataTable BuscarNumDocumento(DCliente cliente)
        {

            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_cliente_num_documento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textoBuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = cliente.TextoNumDocumento;
                sqlParametertextoBuscar.Size = 50;
                sqlCommand.Parameters.Add(sqlParametertextoBuscar);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                sqlData.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }
    }
}
