using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.ReadConfig
{
    /// <summary>
    /// 阿里云OSS的配置类
    /// </summary>
    public class OssFileConfig
    {
        /// <summary>
        /// Endpoint:填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
        /// </summary>
        public string endpoint { get; set; } = null!;


        /// <summary>
        /// 阿里云账号AccessKey拥有所有API的访问权限，风险很高。
        /// 强烈建议您创建并使用RAM用户进行API访问或日常运维，
        /// 请登录RAM控制台创建RAM用户。
        /// </summary>      
        public string keyid { get; set; } = null!;
        /// <summary>
        /// KeySecret
        /// </summary>
        public string keysecret { get; set; } = null!;

        /// <summary>
        /// BucketName:填写Bucket名称。
        /// </summary>
        public string bucketname { get; set; }
    }
}
