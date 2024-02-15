using System.Data;
using System.Data.SqlClient;

namespace PruebaPactia.DAL.Connection
{
    public class AdminConnection
    {
        ConnectionDB db = new ConnectionDB();
        public string cadenaConnect = string.Empty;

        public DataTable ObtenerDataTable(string procedimiento, ref string mensajeDeError, SqlParameter[]? parametros = null)
        {
            DataTable datos = new DataTable();
            cadenaConnect = db.ConexionDao();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedimiento, cadenaConnect);

            try
            {
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(parametros);
                }
                sqlDataAdapter.SelectCommand.Connection.Open();
                sqlDataAdapter.Fill(datos);
            }
            catch (Exception excepcion)
            {
                mensajeDeError = excepcion.Message;
            }
            finally
            {
                sqlDataAdapter.SelectCommand.Connection.Close();
                sqlDataAdapter.SelectCommand.Dispose();
            }
            return datos;
        }

        public DataTable ExecuteQuery(string query, ref string mensajeDeError)
        {
            DataTable datos = new DataTable();
            cadenaConnect = db.ConexionDao();

            try
            {
                using (var connection = new SqlConnection(cadenaConnect))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.Fill(datos);
                }
            }
            catch (Exception excepcion)
            {
                mensajeDeError = excepcion.Message;
            }

            return datos;
        }

    }
}
