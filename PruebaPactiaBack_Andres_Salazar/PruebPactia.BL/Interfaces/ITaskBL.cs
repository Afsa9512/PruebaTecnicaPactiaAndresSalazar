using PruebaPactia.Entities.PruebaEntity;

namespace PruebaPactia.BL.Interfaces
{
    public interface ITaskBL
    {
        public Task<EntityResult<List<EntityTask>>> GetAllTasksAsync();
        public Task<EntityResult<EntityTask>> GetTaskByIdAsync(Guid idTask);
        public string DeleteTaskById(Guid idTask);
        public string CreateTask(EntityTask entity);
        public string UpdateTask(EntityTask entity);
    }
}
