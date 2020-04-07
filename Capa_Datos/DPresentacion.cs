using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DPresentacion
    {
        private int _IdPresentacion;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public DPresentacion()
        {
        }

        public DPresentacion(int IdPresentacion, string Nombre, string Descripcion, string TextoBuscar)
        {
            _IdPresentacion = IdPresentacion;
            _Nombre = Nombre;
            _Descripcion = Descripcion;
            _TextoBuscar = TextoBuscar;
        }

        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Metodo Insertar
        public string Insertar(DPresentacion presentacion)
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
                sqlCommand.CommandText = "spinsertar_presentacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdPresentacion = new SqlParameter();
                sqlParameterIdPresentacion.ParameterName = "@IdPresentacion";
                sqlParameterIdPresentacion.SqlDbType = SqlDbType.Int;
                sqlParameterIdPresentacion.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdPresentacion);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = presentacion.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = presentacion.Descripcion;
                sqlCommand.Parameters.Add(sqlParDescripcion);

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
        public string Editar(DPresentacion presentacion)
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
                sqlCommand.CommandText = "speditar_presentacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdPresentacion = new SqlParameter();
                sqlParameterIdPresentacion.ParameterName = "@IdPresentacion";
                sqlParameterIdPresentacion.SqlDbType = SqlDbType.Int;
                sqlParameterIdPresentacion.Value = presentacion.IdPresentacion;
                sqlCommand.Parameters.Add(sqlParameterIdPresentacion);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = presentacion.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = presentacion.Descripcion;
                sqlCommand.Parameters.Add(sqlParDescripcion);

                //ejecutamos el comando

                rpta = sqlCommand.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

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
        public string Eliminar(DPresentacion presentacion)
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
                sqlCommand.CommandText = "spborrar_presentacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdPresentacion = new SqlParameter();
                sqlParameterIdPresentacion.ParameterName = "@IdPresentacion";
                sqlParameterIdPresentacion.SqlDbType = SqlDbType.Int;
                sqlParameterIdPresentacion.Value = presentacion.IdPresentacion;
                sqlCommand.Parameters.Add(sqlParameterIdPresentacion);

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

            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion presentacion)
        {

            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_presentacion_nombre";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textobuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = presentacion.TextoBuscar;
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
