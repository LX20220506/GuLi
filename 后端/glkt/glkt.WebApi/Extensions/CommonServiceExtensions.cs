using glkt.EF;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace glkt.WebApi.Extensions
{
    /// <summary>
    /// IServiceCollection的公共扩展方法
    /// </summary>
    public static class CommonServiceExtensions
    {
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
    }
}
