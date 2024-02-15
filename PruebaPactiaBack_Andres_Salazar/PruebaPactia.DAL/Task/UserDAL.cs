using PruebaPactia.DAL.Connection;
using PruebaPactia.DAL.Interface;
using PruebaPactia.Entities.PruebaEntity;
using System.Data.SqlClient;
using System.Data;

namespace PruebaPactia.DAL.Task
{
    public class UserDAL : IUserDAL
    {
        // Consulta la información del usuario que esta inciando sessión
        public async Task<EntityUser> GetUserLoginAsync(string email, string password)
        {
            try
            {
                EntityUser user = new EntityUser();
                AdminConnection adminConection = new AdminConnection();
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "email",Value = email },
                    new SqlParameter { ParameterName = "password",Value = password }
                };

                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_GetUserLogin", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    user = new EntityUser()
                    {
                        IdUser = item["IdUser"].ToString(),
                        Email = item["Email"].ToString(),
                        DocumentNumber = item["DocumentNumber"].ToString(),
                        Password = item["Password"].ToString(),
                        FullName = item["FullName"].ToString()
                    };
                }

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
