using glkt.Common.Utils.ALiYun;
using glkt.Common.Utils.ReadConfig;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Repository.Edu;
using glkt.Service.Edu;

namespace glkt.Vod.Extensions
{
    public static class VodServiceExtensions
    {

        /// <summary>
        /// 添加关于视频点播需要的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddVodService(this IServiceCollection services, IConfiguration configuration)
        {
            AddVideoService(services);
            AddUploadVideoService(services,configuration);
            return services;
        }

        /// <summary>
        /// 添加Vieeo相关的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddVideoService(IServiceCollection services) {
            services.AddScoped<IVideorRepository, VideorRepository>();
            services.AddScoped<IVideorService, VideorService>();
            return services;
        }

        /// <summary>
        /// 添加上传视频相关的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddUploadVideoService(IServiceCollection services, IConfiguration configuration) {
            // 加载配置
            var uploadVideo = configuration.GetSection("UploadVideo");
            UploadVideoConfig uploadVideoConfig = uploadVideo.Get<UploadVideoConfig>();

            // 添加UploadVideoHelper
            services.AddSingleton(new UploadVideoHelper(uploadVideoConfig));

            return services;
        }

    }
}
