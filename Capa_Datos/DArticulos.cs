using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DArticulos
    {
        private int _IdArticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _IdCategoria;
        private int _IdPresentacion;

        private string _TextoBuscar;

        public DArticulos()
        {
        }

        public DArticulos(int IdArticulo, string Codigo, string Nombre, string Descripcion, byte[] Imagen, int IdCategoria, int IdPresentacion, string TextoBuscar)
        {
            this.IdArticulo = IdArticulo;
            this.Codigo = Codigo;
            _Nombre = Nombre;
            _Descripcion = Descripcion;
            this.Imagen = Imagen;
            this.IdCategoria = IdCategoria;
            _IdPresentacion = IdPresentacion;
            _TextoBuscar = TextoBuscar;
        }

        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }

        //Metodo Insertar
        public string Insertar(DArticulos articulos)
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
                sqlCommand.CommandText = "spinsertar_articulos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdArticulo = new SqlParameter();
                sqlParameterIdArticulo.ParameterName = "@idArticulo";
                sqlParameterIdArticulo.SqlDbType = SqlDbType.Int;
                sqlParameterIdArticulo.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdArticulo);


                SqlParameter sqlParameterCodigo = new SqlParameter();
                sqlParameterCodigo.ParameterName = "@codigo";
                sqlParameterCodigo.SqlDbType = SqlDbType.VarChar;
                sqlParameterCodigo.Size = 50;
                sqlParameterCodigo.Value = articulos.Codigo;
                sqlCommand.Parameters.Add(sqlParameterCodigo);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = articulos.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = articulos.Descripcion;
                sqlCommand.Parameters.Add(sqlParDescripcion);

                SqlParameter sqlParImagen = new SqlParameter();
                sqlParImagen.ParameterName = "@imagen";
                sqlParImagen.SqlDbType = SqlDbType.Image;
                sqlParImagen.Value = articulos.Imagen;
                sqlCommand.Parameters.Add(sqlParImagen);

                SqlParameter sqlParIdCategoria = new SqlParameter();
                sqlParIdCategoria.ParameterName = "@idCategoria";
                sqlParIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParIdCategoria.Value = articulos.IdCategoria;
                sqlCommand.Parameters.Add(sqlParIdCategoria);

                SqlParameter sqlParIdPresentacion = new SqlParameter();
                sqlParIdPresentacion.ParameterName = "@idPresentacion";
                sqlParIdPresentacion.SqlDbType = SqlDbType.Int;
                sqlParIdPresentacion.Value = articulos.IdPresentacion;
                sqlCommand.Parameters.Add(sqlParIdPresentacion);


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
        public string Editar(DArticulos articulos)
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
                sqlCommand.CommandText = "speditar_articulos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdArticulo = new SqlParameter();
                sqlParameterIdArticulo.ParameterName = "@idArticulo";
                sqlParameterIdArticulo.SqlDbType = SqlDbType.Int;
                sqlParameterIdArticulo.Value = articulos.IdArticulo;
                sqlCommand.Parameters.Add(sqlParameterIdArticulo);


                SqlParameter sqlParameterCodigo = new SqlParameter();
                sqlParameterCodigo.ParameterName = "@codigo";
                sqlParameterCodigo.SqlDbType = SqlDbType.VarChar;
                sqlParameterCodigo.Size = 50;
                sqlParameterCodigo.Value = articulos.Codigo;
                sqlCommand.Parameters.Add(sqlParameterCodigo);

                SqlParameter sqlParameterNombre = new SqlParameter();
                sqlParameterNombre.ParameterName = "@nombre";
                sqlParameterNombre.SqlDbType = SqlDbType.VarChar;
                sqlParameterNombre.Size = 50;
                sqlParameterNombre.Value = articulos.Nombre;
                sqlCommand.Parameters.Add(sqlParameterNombre);

                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@descripcion";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 256;
                sqlParDescripcion.Value = articulos.Descripcion;
                sqlCommand.Parameters.Add(sqlParDescripcion);

                SqlParameter sqlParImagen = new SqlParameter();
                sqlParImagen.ParameterName = "@imagen";
                sqlParImagen.SqlDbType = SqlDbType.Image;
                sqlParImagen.Value = articulos.Imagen;
                sqlCommand.Parameters.Add(sqlParImagen);

                SqlParameter sqlParIdCategoria = new SqlParameter();
                sqlParIdCategoria.ParameterName = "@idCategoria";
                sqlParIdCategoria.SqlDbType = SqlDbType.Int;
                sqlParIdCategoria.Value = articulos.IdCategoria;
                sqlCommand.Parameters.Add(sqlParIdCategoria);

                SqlParameter sqlParIdPresentacion = new SqlParameter();
                sqlParIdPresentacion.ParameterName = "@idPresentacion";
                sqlParIdPresentacion.SqlDbType = SqlDbType.Int;
                sqlParIdPresentacion.Value = articulos.IdPresentacion;
                sqlCommand.Parameters.Add(sqlParIdPresentacion);


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
        public string Eliminar(DArticulos articulos)
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
                sqlCommand.CommandText = "speliminar_articulos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdArticulo = new SqlParameter();
                sqlParameterIdArticulo.ParameterName = "@idArticulo";
                sqlParameterIdArticulo.SqlDbType = SqlDbType.Int;
                sqlParameterIdArticulo.Value = articulos.IdArticulo;
                sqlCommand.Parameters.Add(sqlParameterIdArticulo);

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

            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_articulos";
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
        public DataTable BuscarNombre(DArticulos articulos)
        {

            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_articulos";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textobuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = articulos.TextoBuscar;
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

        public DataTable MostrarStockArticulos()
        {

            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spstock_articulos";
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


    }
}
