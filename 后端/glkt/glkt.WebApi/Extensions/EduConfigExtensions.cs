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
            EduConfigExtensions.AddEduSebjectService(services);
            EduConfigExtensions.AddEduCourseService(services);
            EduConfigExtensions.AddEduChapterService(services);
            EduConfigExtensions.AddEduVideor(services);
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

        /// <summary>
        /// 添加课程类别的相关服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEduSebjectService(IServiceCollection services) {

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }

        /// <summary>
        /// 添加课程相关的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEduCourseService(IServiceCollection services) {
            services.AddScoped<ICourseRepository, CourseRepositoy>();
            services.AddScoped<ICourseDescriptionRepositoy, CourseDescriptionRepositoy>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseDescriptionService, CourseDescriptionService>();
            return services;
        }

        /// <summary>
        /// 添加章节相关的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEduChapterService(IServiceCollection services) {
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IChapterService, ChapterService>();
            return services;
        }

        /// <summary>
        /// 添加小节相关的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEduVideor(IServiceCollection services)
        {
            services.AddScoped<IVideorRepository,VideorRepository>();
            services.AddScoped<IVideorService, VideorService>();
            return services;
        }
    }
}
