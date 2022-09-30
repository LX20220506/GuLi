using Aliyun.OSS;
using glkt.Common.Utils.ReadConfig;
using glkt.IService.OSS;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.OSS
{
    public class FileService : IFileService
    {

        private readonly OssFileConfig _OssFileConfig;
        private readonly ILogger<FileService> _logger;

        public FileService(OssFileConfig ossFileConfig,ILogger<FileService> logger)
        {
            this._OssFileConfig = ossFileConfig;
            this._logger = logger;
        }

        /// <summary>
        /// 上传文件到阿里云OSS
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Upload(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                throw new Exception("没有上传文件");
            }
            // 文件上传的路径
            string filePath = Path.Combine("TeacherHeadPortrait/" , Guid.NewGuid().ToString().Replace("-","") + "_" + file.FileName);

            // 拼接文件的url，后续返回给前端
            string filrUrl = "http://" + _OssFileConfig.bucketname + "." + _OssFileConfig.endpoint + "/" + filePath;

            // 创建OSSClient实例。
            var client = new OssClient(_OssFileConfig.endpoint, _OssFileConfig.keyid, _OssFileConfig.keysecret);
            try
            {
                // 将文件转换为流
                using Stream stream = file.OpenReadStream();
                // 上传文件。
                var result = client.PutObject(_OssFileConfig.bucketname, filePath, stream);
                //_logger.LogInformation("文件上传成功, ETag: {0} ", result.ETag);
            }
            catch (Exception e)
            {
                _logger.LogError("文件上传失败, {0}", e.Message);
                throw new Exception("文件上传失败,"+ e.Message);
            }
            return filrUrl;
        }

        /// <summary>
        /// 上传文件到阿里云OSS
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Upload(IFormFile file,string host)
        {
            if (file == null || file.Length <= 0)
            {
                throw new Exception("没有上传文件");
            }
            // 文件上传的路径
            string filePath = Path.Combine(host+"/", Guid.NewGuid().ToString().Replace("-", "") + "_" + file.FileName);

            // 拼接文件的url，后续返回给前端
            string filrUrl = "http://" + _OssFileConfig.bucketname + "." + _OssFileConfig.endpoint + "/" + filePath;

            // 创建OSSClient实例。
            var client = new OssClient(_OssFileConfig.endpoint, _OssFileConfig.keyid, _OssFileConfig.keysecret);
            try
            {
                // 将文件转换为流
                using Stream stream = file.OpenReadStream();
                // 上传文件。
                var result = client.PutObject(_OssFileConfig.bucketname, filePath, stream);
                //_logger.LogInformation("文件上传成功, ETag: {0} ", result.ETag);
            }
            catch (Exception e)
            {
                _logger.LogError("文件上传失败, {0}", e.Message);
                throw new Exception("文件上传失败," + e.Message);
            }
            return filrUrl;
        }
    }
}
