using PruebaPactia.BL.Interfaces;
using PruebaPactia.BL.Task;
using PruebaPactia.DAL.Interface;
using PruebaPactia.DAL.Task;

namespace PruebaPactia.API.Extensions
{
    public static class PruebaExtensions
    {
        public static void configureExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITaskBL, TaskBL>();
            builder.Services.AddTransient<ITaskDAL, TaskDAL>();
            builder.Services.AddTransient<IUserBL, UserBL>();
            builder.Services.AddTransient<IUserDAL, UserDAL>();
        }
    }
}
