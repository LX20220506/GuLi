using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Repository.Edu;
using glkt.Service.Edu;

namespace glkt.Edu.Extensions
{
    /// <summary>
    ///  用于注册edu的服务
    /// </summary>
    public static class EduConfigExtensions
    {
        /// <summary>
        /// 注册edu的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEduService(this IServiceCollection services) {
            EduConfigExtensions.AddEduTeacherService(services);
            return services;  
        }


        /// <summary>
        /// 添加老师的服务
        /// </summary>
        /// <param name="services">IServiceCollection类型；用于添加服务</param>
        /// <returns></returns>
        public static IServiceCollection AddEduTeacherService(IServiceCollection services) {
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        } 

    }
}
