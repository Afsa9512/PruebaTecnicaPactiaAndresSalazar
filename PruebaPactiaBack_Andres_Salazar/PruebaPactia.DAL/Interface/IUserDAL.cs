using PruebaPactia.Entities.PruebaEntity;

namespace PruebaPactia.DAL.Interface
{
    public interface IUserDAL
    {
        public Task<EntityUser> GetUserLoginAsync(string userName, string password);
    }
}
