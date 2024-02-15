using PruebaPactia.Entities.PruebaEntity;

namespace PruebaPactia.DAL.Interface
{
    public interface ITaskDAL
    {
        public Task<List<EntityTask>> GetAllTasksAsync();
        public Task<EntityTask> GetTaskByIdAsync(Guid idTask);
        public Task<string> CreateTask(EntityTask entity);
        public Task<string> UpdateTask(EntityTask entity);
        public Task<string> DeleteTaskByIdAsync(Guid idTask);
    }
}
