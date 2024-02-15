using PruebaPactia.Entities.PruebaEntity;

namespace PruebaPactia.BL.Interfaces
{
    public interface IUserBL
    {
        public Task<EntityResult<EntityUser>> GetUserLoginAsync(string email, string password);
    }
}
