using PruebaPactia.DAL.Connection;
using PruebaPactia.DAL.Interface;
using PruebaPactia.Entities.PruebaEntity;
using System.Data;
using System.Data.SqlClient;

namespace PruebaPactia.DAL.Task
{
    public class TaskDAL : ITaskDAL
    {
        // Obtiene todos los registros de la tabla de tareas
        public async Task<List<EntityTask>> GetAllTasksAsync()
        {
            try
            {
                List<EntityTask> listTasks = new List<EntityTask>();
                AdminConnection adminConection = new AdminConnection(); // Crea la conexión con la base de datos
                string mensajeDeError = string.Empty;

                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_GetAllTasks", ref mensajeDeError);

                // Recorre todos los registros para incluirlos en el modelo de la lista
                foreach (DataRow item in data.Rows)
                {
                    EntityTask task = new EntityTask
                    {
                        IdTask = new Guid(item["IdTask"].ToString()),
                        NameTask = item["NameTask"].ToString(),
                        StateTask = item["StateTask"].ToString(),
                    };
                    listTasks.Add(task);
                }

                return listTasks;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Obtiene los datos de la tarea encontrada con el Id
        public async Task<EntityTask> GetTaskByIdAsync(Guid idTask)
        {
            try
            {
                EntityTask task = new EntityTask();
                AdminConnection adminConection = new AdminConnection();// Crea la conexión con la base de datos
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdTask",Value = idTask }
                };

                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_GetByIdTask", ref mensajeDeError, parameters);

                // Recorre el registro para inclierlo en el modelo de la entidad
                foreach (DataRow item in data.Rows)
                {
                    task = new EntityTask()
                    {
                        IdTask = new Guid(item["IdTask"].ToString()),
                        NameTask = item["NameTask"].ToString(),
                        StateTask = item["StateTask"].ToString(),
                    };
                }

                return task;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Crea una tarea con los datos proporcionados para el usuario
        public async Task<string> CreateTask(EntityTask entity)
        {
            try
            {
                AdminConnection adminConection = new AdminConnection();// Crea la conexión con la base de datos
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                // Llena la lista de parametros para registrar una tarea
                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "IdTask", Value = Guid.NewGuid() },
                    new SqlParameter {ParameterName = "NameTask", Value = entity.NameTask},
                    new SqlParameter {ParameterName = "StateTask", Value = entity.StateTask},
                };
                
                // Ejecuta el procedimiento almacenado que se encarga de registrar
                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_CreateTask", ref mensajeDeError, parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Actuliza una tarea con los datos proporcionados para el usuario
        public async Task<string> UpdateTask(EntityTask entity)
        {
            try
            {
                AdminConnection adminConection = new AdminConnection();// Crea la conexión con la base de datos
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                // Llena la lista de parametros para registrar una tarea
                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdTask", Value = entity.IdTask},
                    new SqlParameter {ParameterName = "NameTask", Value = entity.NameTask},
                    new SqlParameter {ParameterName = "StateTask", Value = entity.StateTask},
                };

                // Ejecuta el procedimiento almacenado que se encarga de actualizar
                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_UpdateTask", ref mensajeDeError, parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // // Elimina una tarea con el id
        public async Task<string> DeleteTaskByIdAsync(Guid idTask)
        {
            try
            {
                EntityTask task = new EntityTask();
                AdminConnection adminConection = new AdminConnection();// Crea la conexión con la base de datos
                string mensajeDeError = string.Empty;

                // Llena la lista de parametros para registrar una tarea
                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdTask",Value = idTask }
                };

                // Ejecuta el procedimiento almacenado que se encarga de eliminar
                DataTable data = adminConection.ObtenerDataTable("DBPruebaPactia.dbo.SP_DeleteTaskById", ref mensajeDeError, parameters);

                return "Ok";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
