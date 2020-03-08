using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_datos
{
    public class DCategoria
    {
        private int _IdCategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public DCategoria()
        {
        }

        public DCategoria(int IdCategoria, string Nombre, string Descripcion, string TextoBuscar)
        {
            _IdCategoria = IdCategoria;
            _Nombre = Nombre;
            _Descripcion = Descripcion;
            _TextoBuscar = TextoBuscar;
        }

        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Metodo Insertar
        public string Insertar(DCategoria categoria)
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
                sqlCommand.CommandText = "spinsertar_categoria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCategoria = new SqlParameter();
                sqlParameterIdCategoria.ParameterName = "@IdCategoria";
                sqlParameterIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParameterIdCategoria.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdCategoria);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = categoria.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = categoria.Descripcion;
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
        public string Editar(DCategoria categoria)
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
                sqlCommand.CommandText = "speditar_categoria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCategoria = new SqlParameter();
                sqlParameterIdCategoria.ParameterName = "@IdCategoria";
                sqlParameterIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParameterIdCategoria.Value = categoria.IdCategoria;
                sqlCommand.Parameters.Add(sqlParameterIdCategoria);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = categoria.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = categoria.Descripcion;
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
        public string Eliminar(DCategoria categoria)
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
                sqlCommand.CommandText = "spborrar_categoria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdCategoria = new SqlParameter();
                sqlParameterIdCategoria.ParameterName = "@IdCategoria";
                sqlParameterIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParameterIdCategoria.Value = categoria.IdCategoria;
                sqlCommand.Parameters.Add(sqlParameterIdCategoria);
               
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

            DataTable DtResultado = new DataTable("Categoria");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_categoria";
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
        public DataTable BuscarNombre(DCategoria categoria)
        {

            DataTable DtResultado = new DataTable("Categoria");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_nombre_categoria";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textobuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = categoria.TextoBuscar;
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
