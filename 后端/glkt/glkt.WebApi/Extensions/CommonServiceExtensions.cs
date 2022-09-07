using glkt.Common.Utils.AutoMapper;
using glkt.EF;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Serilog.Events;
using Serilog;
using System.Text;

namespace glkt.WebApi.Extensions
{
    /// <summary>
    /// IServiceCollection的公共扩展方法
    /// </summary>
    public static class CommonServiceExtensions
    {

        /// <summary>
        /// 添加CommonService服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommonService(this IServiceCollection services) {

            // 添加AutoMapper服务
            CommonServiceExtensions.AddCustomAutoMapper(services);
            // 添加Serilog服务
            CommonServiceExtensions.AddSerilog(services);
            //添加跨域
            CommonServiceExtensions.AddCors(services);

            return services;
        }


        /// <summary>
        /// 创建GuLiDbContext
        /// </summary>
        /// <param name="services">ServiceCollection（IOC容器）</param>
        /// <param name="sqlConnectionString">数据连接字符串</param>
        /// <returns></returns>
        public static IServiceCollection AddGuLiDbContext(this IServiceCollection services,string sqlConnectionString) {

            // 指定MySql版本
            MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new Version(5, 7, 38));

            services.AddDbContext<GuLiDbContext>(options => {
                options.UseMySql(sqlConnectionString, mySqlServerVersion);
            });

            return services;
        }

        /// <summary>
        /// 添加AutoMapper服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomAutoMapper(IServiceCollection services) {
            services.AddAutoMapper(typeof(CustomAutoMapperProfile));
            return services;
        }


        /// <summary>
        /// 添加Serilog服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSerilog(IServiceCollection services)
        {
            // 添加logging服务
            services.AddLogging(logBulider => {

                var outputTemplate = "{NewLine}【{Level:u3}】{Timestamp:yyyy-MM-dd HH:mm:ss.fff}" +
                                     "{NewLine}#Msg# {Message:lj}" +
                                     "{NewLine}#Pro# {Properties:j}" +
                                     "{NewLine}#Exc# {Exception}{NewLine}{NewLine}";//输出模板

                // 创建Logger,绑定Serilog
                var log = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(
                        Path.Combine("Log", "_log" + DateTime.Now.ToString("yyMM") + ".log"),   // 文件存放路径和名称
                        restrictedToMinimumLevel: LogEventLevel.Information,                    // 最低输出日志级别
                        outputTemplate: outputTemplate,                                         // 输出模板
                        rollingInterval: RollingInterval.Month,                                 // 日志按日保存，这样会在文件名称后自动加上日期后缀   
                        //fileSizeLimitBytes: 1024^2*20,                                         // 文件大小，单文件建议2M，这里30M
                        encoding: Encoding.UTF8                                                 // 文件字符编码
                        )
                .CreateLogger();

                logBulider.AddSerilog(log); // 添加 Serilog 服务

            });
            return services;
        }


        public static IServiceCollection AddCors(IServiceCollection services) {
            string[] urls = new[] { "http://localhost:9528", "http://127.0.0.1:5173" };

            services.AddCors(options =>
                    options.AddPolicy("cors", builder =>
                    builder.WithOrigins(urls) // 设置允许访问的地址
                            .AllowAnyMethod() // 允许任何方法
                            .AllowAnyHeader() // 允许任何标头
                            .AllowCredentials()));

            return services;
        }

    }
}
