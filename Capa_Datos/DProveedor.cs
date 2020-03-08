using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_datos
{
    public class DProveedor
    {
        private int _IdProveedor;
        private string _razonSocial;
        private string _sectorComercial;
        private string _tipoDocumento;
        private string _numDocumento;
        private string _direccion;
        private string _telefono;
        private string _email;
        private string _url;

        private string _TextoBuscar;
        private string _numDocumentoBuscar;

        public DProveedor()
        {
        }

        public DProveedor(int IdProveedor, string razonSocial, string sectorComercial, string tipoDocumento, string numDocumento, string direccion, string telefono, string email, string url, string TextoBuscar, string numDocumentoBuscar)
        {
            this.IdProveedor = IdProveedor;
            RazonSocial = razonSocial;
            SectorComercial = sectorComercial;
            TipoDocumento = tipoDocumento;
            NumDocumento = numDocumento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Url = url;
            this.TextoBuscar = TextoBuscar;
            NumDocumentoBuscar = numDocumentoBuscar;
        }

        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public string RazonSocial { get => _razonSocial; set => _razonSocial = value; }
        public string SectorComercial { get => _sectorComercial; set => _sectorComercial = value; }
        public string TipoDocumento { get => _tipoDocumento; set => _tipoDocumento = value; }
        public string NumDocumento { get => _numDocumento; set => _numDocumento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Url { get => _url; set => _url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string NumDocumentoBuscar { get => _numDocumentoBuscar; set => _numDocumentoBuscar = value; }


        //Metodo Insertar
        public string Insertar(DProveedor proveedor)
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
                sqlCommand.CommandText = "spinsertar_proveedor";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdProveedor = new SqlParameter();
                sqlParameterIdProveedor.ParameterName = "@IdProveedor";
                sqlParameterIdProveedor.SqlDbType = SqlDbType.Int;
                sqlParameterIdProveedor.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameterIdProveedor);


                SqlParameter sqlParameterRaSocial = new SqlParameter();
                sqlParameterRaSocial.ParameterName = "@razonsocial";
                sqlParameterRaSocial.SqlDbType = SqlDbType.VarChar;
                sqlParameterRaSocial.Size = 150;
                sqlParameterRaSocial.Value = proveedor.RazonSocial;
                sqlCommand.Parameters.Add(sqlParameterRaSocial);

                SqlParameter sqlParameterSectorCom = new SqlParameter();
                sqlParameterSectorCom.ParameterName = "@sectorcomercial";
                sqlParameterSectorCom.SqlDbType = SqlDbType.VarChar;
                sqlParameterSectorCom.Size = 50;
                sqlParameterSectorCom.Value = proveedor.SectorComercial;
                sqlCommand.Parameters.Add(sqlParameterSectorCom);

                SqlParameter sqlParTipoDocumento = new SqlParameter();
                sqlParTipoDocumento.ParameterName = "@tipodocumento";
                sqlParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParTipoDocumento.Size = 50;
                sqlParTipoDocumento.Value = proveedor.TipoDocumento;
                sqlCommand.Parameters.Add(sqlParTipoDocumento);

                SqlParameter sqlParNumDocumento = new SqlParameter();
                sqlParNumDocumento.ParameterName = "@numdocumento";
                sqlParNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParNumDocumento.Size = 50;
                sqlParNumDocumento.Value = proveedor.NumDocumento;
                sqlCommand.Parameters.Add(sqlParNumDocumento);

                SqlParameter sqlParDireccion = new SqlParameter();
                sqlParDireccion.ParameterName = "@direccion";
                sqlParDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParDireccion.Size = 256;
                sqlParDireccion.Value = proveedor.Direccion;
                sqlCommand.Parameters.Add(sqlParDireccion);

                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@telefono";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 50;
                sqlParTelefono.Value = proveedor.Telefono;
                sqlCommand.Parameters.Add(sqlParTelefono);

                SqlParameter sqlParemail = new SqlParameter();
                sqlParemail.ParameterName = "@email";
                sqlParemail.SqlDbType = SqlDbType.VarChar;
                sqlParemail.Size = 50;
                sqlParemail.Value = proveedor.Email;
                sqlCommand.Parameters.Add(sqlParemail);

                SqlParameter sqlParUrl = new SqlParameter();
                sqlParUrl.ParameterName = "@url";
                sqlParUrl.SqlDbType = SqlDbType.VarChar;
                sqlParUrl.Size = 50;
                sqlParUrl.Value = proveedor.Url;
                sqlCommand.Parameters.Add(sqlParUrl);


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
        public string Editar(DProveedor proveedor)
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
                sqlCommand.CommandText = "speditar_proveedor";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdProveedor = new SqlParameter();
                sqlParameterIdProveedor.ParameterName = "@IdProveedor";
                sqlParameterIdProveedor.SqlDbType = SqlDbType.Int;
                sqlParameterIdProveedor.Value = proveedor.IdProveedor;
                sqlCommand.Parameters.Add(sqlParameterIdProveedor);


                SqlParameter sqlParameterRaSocial = new SqlParameter();
                sqlParameterRaSocial.ParameterName = "@razonsocial";
                sqlParameterRaSocial.SqlDbType = SqlDbType.VarChar;
                sqlParameterRaSocial.Size = 150;
                sqlParameterRaSocial.Value = proveedor.RazonSocial;
                sqlCommand.Parameters.Add(sqlParameterRaSocial);

                SqlParameter sqlParameterSectorCom = new SqlParameter();
                sqlParameterSectorCom.ParameterName = "@sectorcomercial";
                sqlParameterSectorCom.SqlDbType = SqlDbType.VarChar;
                sqlParameterSectorCom.Size = 50;
                sqlParameterSectorCom.Value = proveedor.SectorComercial;
                sqlCommand.Parameters.Add(sqlParameterSectorCom);

                SqlParameter sqlParTipoDocumento = new SqlParameter();
                sqlParTipoDocumento.ParameterName = "@tipodocumento";
                sqlParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParTipoDocumento.Size = 50;
                sqlParTipoDocumento.Value = proveedor.TipoDocumento;
                sqlCommand.Parameters.Add(sqlParTipoDocumento);

                SqlParameter sqlParNumDocumento = new SqlParameter();
                sqlParNumDocumento.ParameterName = "@numdocumento";
                sqlParNumDocumento.SqlDbType = SqlDbType.VarChar;
                sqlParNumDocumento.Size = 50;
                sqlParNumDocumento.Value = proveedor.NumDocumento;
                sqlCommand.Parameters.Add(sqlParNumDocumento);

                SqlParameter sqlParDireccion = new SqlParameter();
                sqlParDireccion.ParameterName = "@direccion";
                sqlParDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParDireccion.Size = 256;
                sqlParDireccion.Value = proveedor.Direccion;
                sqlCommand.Parameters.Add(sqlParDireccion);

                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@telefono";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 50;
                sqlParTelefono.Value = proveedor.Telefono;
                sqlCommand.Parameters.Add(sqlParTelefono);

                SqlParameter sqlParemail = new SqlParameter();
                sqlParemail.ParameterName = "@email";
                sqlParemail.SqlDbType = SqlDbType.VarChar;
                sqlParemail.Size = 50;
                sqlParemail.Value = proveedor.Email;
                sqlCommand.Parameters.Add(sqlParemail);

                SqlParameter sqlParUrl = new SqlParameter();
                sqlParUrl.ParameterName = "@url";
                sqlParUrl.SqlDbType = SqlDbType.VarChar;
                sqlParUrl.Size = 50;
                sqlParUrl.Value = proveedor.Url;
                sqlCommand.Parameters.Add(sqlParUrl);


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
        public string Eliminar(DProveedor proveedor)
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
                sqlCommand.CommandText = "speliminar_proveedor";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterIdProveedor = new SqlParameter();
                sqlParameterIdProveedor.ParameterName = "@IdProveedor";
                sqlParameterIdProveedor.SqlDbType = SqlDbType.Int;
                sqlParameterIdProveedor.Value = proveedor.IdProveedor;
                sqlCommand.Parameters.Add(sqlParameterIdProveedor);

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

            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spmostrar_proveedor";
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
        public DataTable BuscarRazonSocial(DProveedor proveedor)
        {

            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_proveedor_razonSocial";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParametertextoBuscar = new SqlParameter();
                sqlParametertextoBuscar.ParameterName = "@textobuscar";
                sqlParametertextoBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParametertextoBuscar.Value = proveedor.TextoBuscar;
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

        //Metodo buscar numDocumento
        public DataTable BuscarNumDocumento(DProveedor proveedor)
        {

            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexion.Cn;
                //Establecer el comando
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "spbuscar_proveedor_numDocumento";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterNumBuscar = new SqlParameter();
                sqlParameterNumBuscar.ParameterName = "@numeroDocumento";
                sqlParameterNumBuscar.SqlDbType = SqlDbType.VarChar;
                sqlParameterNumBuscar.Value = proveedor.NumDocumentoBuscar;
                sqlParameterNumBuscar.Size = 50;
                sqlCommand.Parameters.Add(sqlParameterNumBuscar);

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
