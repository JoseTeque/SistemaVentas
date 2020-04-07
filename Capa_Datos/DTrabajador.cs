using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DTrabajador
    {
        private int _IdTrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;
        private string _TextoNumDocumento;


        public DTrabajador()
        {
        }

        public DTrabajador(int IdTrabajador, string Nombre, string Apellidos, string Sexo, DateTime FechaNacimiento, string Num_documento, string Direccion, string Telefono, string Email, string Acceso, string Usuario, string Password, string TextoBuscar, string TextoNumDocumento, string textoBuscar, string textoNumDocumento)
        {
            _IdTrabajador = IdTrabajador;
            _Nombre = Nombre;
            _Apellidos = Apellidos;
            _Sexo = Sexo;
            _FechaNacimiento = FechaNacimiento;
            _Num_documento = Num_documento;
            _Direccion = Direccion;
            _Telefono = Telefono;
            _Email = Email;
            _Acceso = Acceso;
            _Usuario = Usuario;
            _Password = Password;
            _TextoBuscar = TextoBuscar;
            _TextoNumDocumento = TextoNumDocumento;
            this.TextoBuscar = textoBuscar;
            this.TextoNumDocumento = textoNumDocumento;
        }

        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string TextoNumDocumento { get => _TextoNumDocumento; set => _TextoNumDocumento = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }




        //Metodo Insertar
        public string Insertar(DTrabajador trabajador)
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
                sqlCommand.CommandText = "spinsertar_trabajador";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdTrabajador = new SqlParameter();
                sqlParameterIdTrabajador.ParameterName = "@IdTrabajador";
                sqlParameterIdTrabajador.SqlDbType = SqlDbType.Int;
                sqlParameterIdTrabajador.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdTrabajador);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = trabajador.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParameterApellidos = new SqlParameter();
                sqlParameterApellidos.ParameterName = "@apellidos";
                sqlParameterApellidos.SqlDbType = SqlDbType.VarChar;
                sqlParameterApellidos.Size = 50;
                sqlParameterApellidos.Value = trabajador.Apellidos;
                sqlCommand.Parameters.Add(sqlParameterApellidos);

                SqlParameter sqlParameterSexo = new SqlParameter();
                sqlParameterSexo.ParameterName = "@sexo";
                sqlParameterSexo.SqlDbType = SqlDbType.VarChar;
                sqlParameterSexo.Size = 1;
                sqlParameterSexo.Value = trabajador.Sexo;
                sqlCommand.Parameters.Add(sqlParameterSexo);


                SqlParameter sqlParameterFechaNacimiento = new SqlParameter();
                sqlParameterFechaNacimiento.ParameterName = "@fecha_nacimiento";
                sqlParameterFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                sqlParameterFechaNacimiento.Value = trabajador.FechaNacimiento;
                sqlCommand.Parameters.Add(sqlParameterFechaNacimiento);

                SqlParameter sqlParameterNumDocumento = new SqlParameter();
                sqlParameterNumDocumento.ParameterName = "@num_documento";
                sqlParameterNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterNumDocumento.Size = 50;
                sqlParameterNumDocumento.Value = trabajador.Num_documento;
                sqlCommand.Parameters.Add(sqlParameterNumDocumento);

                SqlParameter sqlParameterDireccion = new SqlParameter();
                sqlParameterDireccion.ParameterName = "@direccion";
                sqlParameterDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParameterDireccion.Size = 50;
                sqlParameterDireccion.Value = trabajador.Direccion;
                sqlCommand.Parameters.Add(sqlParameterDireccion);

                SqlParameter sqlParameterTelefono = new SqlParameter();
                sqlParameterTelefono.ParameterName = "@telefono";
                sqlParameterTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParameterTelefono.Size = 50;
                sqlParameterTelefono.Value = trabajador.Telefono;
                sqlCommand.Parameters.Add(sqlParameterTelefono);

                SqlParameter sqlParameterEmail = new SqlParameter();
                sqlParameterEmail.ParameterName = "@email";
                sqlParameterEmail.SqlDbType = SqlDbType.VarChar;
                sqlParameterEmail.Size = 50;
                sqlParameterEmail.Value = trabajador.Email;
                sqlCommand.Parameters.Add(sqlParameterEmail);

                SqlParameter sqlParameterAcceso = new SqlParameter();
                sqlParameterAcceso.ParameterName = "@acceso";
                sqlParameterAcceso.SqlDbType = SqlDbType.VarChar;
                sqlParameterAcceso.Size = 20;
                sqlParameterAcceso.Value = trabajador.Acceso;
                sqlCommand.Parameters.Add(sqlParameterAcceso);

                SqlParameter sqlParameterUsuario = new SqlParameter();
                sqlParameterUsuario.ParameterName = "@usuario";
                sqlParameterUsuario.SqlDbType = SqlDbType.VarChar;
                sqlParameterUsuario.Size = 50;
                sqlParameterUsuario.Value = trabajador.Usuario;
                sqlCommand.Parameters.Add(sqlParameterUsuario);

                SqlParameter sqlParameterPassword = new SqlParameter();
                sqlParameterPassword.ParameterName = "@password";
                sqlParameterPassword.SqlDbType = SqlDbType.VarChar;
                sqlParameterPassword.Size = 20;
                sqlParameterPassword.Value = trabajador.Password;
                sqlCommand.Parameters.Add(sqlParameterPassword);

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
        public string Editar(DTrabajador trabajador)
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
                sqlCommand.CommandText = "speditar_trabajador";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdTrabajador = new SqlParameter();
                sqlParameterIdTrabajador.ParameterName = "@IdTrabajador";
                sqlParameterIdTrabajador.SqlDbType = SqlDbType.Int;
                sqlParameterIdTrabajador.Value = trabajador.IdTrabajador;
                sqlCommand.Parameters.Add(sqlParameterIdTrabajador);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = trabajador.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParameterApellidos = new SqlParameter();
                sqlParameterApellidos.ParameterName = "@apellidos";
                sqlParameterApellidos.SqlDbType = SqlDbType.VarChar;
                sqlParameterApellidos.Size = 50;
                sqlParameterApellidos.Value = trabajador.Apellidos;
                sqlCommand.Parameters.Add(sqlParameterApellidos);

                SqlParameter sqlParameterSexo = new SqlParameter();
                sqlParameterSexo.ParameterName = "@sexo";
                sqlParameterSexo.SqlDbType = SqlDbType.VarChar;
                sqlParameterSexo.Size = 1;
                sqlParameterSexo.Value = trabajador.Sexo;
                sqlCommand.Parameters.Add(sqlParameterSexo);


                SqlParameter sqlParameterFechaNacimiento = new SqlParameter();
                sqlParameterFechaNacimiento.ParameterName = "@fecha_nacimiento";
                sqlParameterFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                sqlParameterFechaNacimiento.Value = trabajador.FechaNacimiento;
                sqlCommand.Parameters.Add(sqlParameterFechaNacimiento);

                SqlParameter sqlParameterNumDocumento = new SqlParameter();
                sqlParameterNumDocumento.ParameterName = "@num_documento";
                sqlParameterNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParameterNumDocumento.Size = 50;
                sqlParameterNumDocumento.Value = trabajador.Num_documento;
                sqlCommand.Parameters.Add(sqlParameterNumDocumento);

                SqlParameter sqlParameterDireccion = new SqlParameter();
                sqlParameterDireccion.ParameterName = "@direccion";
                sqlParameterDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParameterDireccion.Size = 50;
                sqlParameterDireccion.Value = trabajador.Direccion;
                sqlCommand.Parameters.Add(sqlParameterDireccion);

                SqlParameter sqlParameterTelefono = new SqlParameter();
                sqlParameterTelefono.ParameterName = "@telefono";
                sqlParameterTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParameterTelefono.Size = 50;
                sqlParameterTelefono.Value = trabajador.Telefono;
                sqlCommand.Parameters.Add(sqlParameterTelefono);

                SqlParameter sqlParameterEmail = new SqlParameter();
                sqlParameterEmail.ParameterName = "@email";
                sqlParameterEmail.SqlDbType = SqlDbType.VarChar;
                sqlParameterEmail.Size = 50;
                sqlParameterEmail.Value = trabajador.Email;
                sqlCommand.Parameters.Add(sqlParameterEmail);

                SqlParameter sqlParameterAcceso = new SqlParameter();
                sqlParameterAcceso.ParameterName = "@acceso";
                sqlParameterAcceso.SqlDbType = SqlDbType.VarChar;
                sqlParameterAcceso.Size = 20;
                sqlParameterAcceso.Value = trabajador.Acceso;
                sqlCommand.Parameters.Add(sqlParameterAcceso);

                SqlParameter sqlParameterUsuario = new SqlParameter();
                sqlParameterUsuario.ParameterName = "@usuario";
                sqlParameterUsuario.SqlDbType = SqlDbType.VarChar;
                sqlParameterUsuario.Size = 50;
                sqlParameterUsuario.Value = trabajador.Usuario;
                sqlCommand.Parameters.Add(sqlParameterUsuario);

                SqlParameter sqlParameterPassword = new SqlParameter();
                sqlParameterPassword.ParameterName = "@password";
                sqlParameterPassword.SqlDbType = SqlDbType.VarChar;
                sqlParameterPassword.Size = 20;
                sqlParameterPassword.Value = trabajador.Password;
                sqlCommand.Parameters.Add(sqlParameterPassword);

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

        //Metodo Eliminar
        public string Eliminar(DTrabajador trabajador)
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
                sqlCommand.CommandText = "speliminar_trabajador";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdTrabajador = new SqlParameter();
                sqlParameterIdTrabajador.ParameterName = "@IdTrabajador";
                sqlParameterIdTrabajador.SqlDbType = SqlDbType.Int;
                sqlParameterIdTrabajador.Value = trabajador.IdTrabajador;
                sqlCommand.Parameters.Add(sqlParameterIdTrabajador);

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

            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_trabajador";
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
        public DataTable BuscarApellido(DTrabajador trabajador)
        {

            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_trabajador_apellidos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textoBuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = trabajador.TextoBuscar;
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

        public DataTable BuscarNumDocumento(DTrabajador trabajador)
        {

            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_trabajador_num_documento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textoBuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = trabajador.TextoNumDocumento;
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

        public DataTable Login(DTrabajador trabajador)
        {

            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "splogin";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParUsuario = new SqlParameter();
                sqlParUsuario.ParameterName = "@usuario";
                sqlParUsuario.SqlDbType = SqlDbType.VarChar;
                sqlParUsuario.Value = trabajador.Usuario;
                sqlParUsuario.Size = 20;
                sqlCommand.Parameters.Add(sqlParUsuario);

                SqlParameter sqlParPassword = new SqlParameter();
                sqlParPassword.ParameterName = "@password";
                sqlParPassword.SqlDbType = SqlDbType.VarChar;
                sqlParPassword.Value = trabajador.Password;
                sqlParPassword.Size = 20;
                sqlCommand.Parameters.Add(sqlParPassword);

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
