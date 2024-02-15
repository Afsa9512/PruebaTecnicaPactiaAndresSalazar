using PruebaPactia.BL.Interfaces;
using PruebaPactia.DAL.Interface;
using PruebaPactia.Entities.PruebaEntity;
using PruebaPactia.Utility;

namespace PruebaPactia.BL.Task
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL userDAL;
        public UserBL(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public async Task<EntityResult<EntityUser>> GetUserLoginAsync(string email, string password)
        {
            try
            {
                EntityUser result = await userDAL.GetUserLoginAsync(email, password);

                if (result != null)
                    return EntityResult<EntityUser>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<EntityUser>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
