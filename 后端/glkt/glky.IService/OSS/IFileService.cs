using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.OSS
{
    public interface IFileService
    {
         /**
         * 文件上传至阿里云
         * @param file
         * @return
         */
        string Upload(IFormFile file);
    }
}
