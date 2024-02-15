using PruebaPactia.BL.Interfaces;
using PruebaPactia.DAL.Interface;
using PruebaPactia.Entities.PruebaEntity;
using PruebaPactia.Utility;

namespace PruebaPactia.BL.Task
{
    public class TaskBL : ITaskBL
    {
        private readonly ITaskDAL taskDAL;
        public TaskBL(ITaskDAL _taskDAL)
        {
            this.taskDAL = _taskDAL;
        }

        // Obtiene todas las tareas de las tabla
        public async Task<EntityResult<List<EntityTask>>> GetAllTasksAsync()
        {
            try
            {
                List<EntityTask> result = await taskDAL.GetAllTasksAsync();

                if (result != null)
                    return EntityResult<List<EntityTask>>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<List<EntityTask>>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Obtiene los datos de una tarea con el Id proporcionado
        public async Task<EntityResult<EntityTask>> GetTaskByIdAsync(Guid idTask)
        {
            try
            {
                EntityTask result = await taskDAL.GetTaskByIdAsync(idTask);

                if (result != null)
                    return EntityResult<EntityTask>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<EntityTask>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Registra una tarea
        public string CreateTask(EntityTask entity)
        {
            try
            {
                var result = taskDAL.CreateTask(entity);

                return "Tarea creada con éxito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Actualiza la tarea
        public string UpdateTask(EntityTask entity)
        {
            try
            {
                var result = taskDAL.UpdateTask(entity);

                return "Tarea actualizada con éxito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ELimina la tarea con el id enviado
        public string DeleteTaskById(Guid idTask)
        {
            try
            {
                var result = taskDAL.DeleteTaskByIdAsync(idTask);

                return "Tarea eliminada con éxito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
