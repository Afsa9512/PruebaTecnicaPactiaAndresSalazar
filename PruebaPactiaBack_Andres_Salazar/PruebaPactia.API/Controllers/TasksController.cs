using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaPactia.BL.Interfaces;
using PruebaPactia.Entities.PruebaEntity;

namespace PruebaPactia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private ITaskBL _actionBL_Task;
        private IConfiguration _configuration;

        public TasksController(ITaskBL actionBL_Task, IConfiguration configuration)
        {
            _actionBL_Task = actionBL_Task;
            _configuration = configuration;
        }

        // GET: api/Tasks
        /// <summary>
        /// Consulta de todas las tareas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EntityTask>> GetAllTasks()
        {
            var tasks = await _actionBL_Task.GetAllTasksAsync();

            return tasks.Data;
        }

        // GET: api/Tasks/GetTaskById?idTask=000-000-0000
        /// <summary>
        /// Consulta una tarea por el Id
        /// </summary>
        /// /// <param name="idTask"></param>
        /// <returns></returns>
        [HttpGet("GetTaskById")]
        public async Task<EntityTask> GetTaskById(Guid idTask)
        {
            var task = await _actionBL_Task.GetTaskByIdAsync(idTask);

            return task.Data;
        }

        // POST: api/Tasks
        /// <summary>
        /// Crear una tarea 
        /// </summary>
        /// /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CreateTask(EntityTask dto)
        {
            var result = _actionBL_Task.CreateTask(dto);

            return new JsonResult(result);
        }

        // PUT: api/Tasks
        /// <summary>
        /// Actulaiza una tarea 
        /// </summary>
        /// /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<JsonResult> UpdateTask(EntityTask dto)
        {
            var result = _actionBL_Task.UpdateTask(dto);

            return new JsonResult(result);
        }

        // POST: api/Tasks?idTask=000-000-0000
        /// <summary>
        /// Elimina una tarea con el id proporcionado
        /// </summary>
        /// /// <param name="idTask"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<JsonResult> DeleteTaskById(Guid idTask)
        {
            var result = _actionBL_Task.DeleteTaskById(idTask);

            return new JsonResult(result);
        }

    }
}