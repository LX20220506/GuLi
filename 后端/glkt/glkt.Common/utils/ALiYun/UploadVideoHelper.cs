using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
using Aliyun.OSS;
using glkt.Common.Utils.ReadConfig;
using glkt.Model.VO.aliyun;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.ALiYun
{
    /// <summary>
    /// 上传视频
    /// </summary>
    public class UploadVideoHelper
    {

        private readonly UploadVideoConfig _videoConfig;

        public UploadVideoHelper(UploadVideoConfig videoConfig)
        {
            _videoConfig = videoConfig;
        }

        /// <summary>
        /// 初始化点播客户端
        /// </summary>
        /// <param name="accessKeyId">访问密钥标识</param>
        /// <param name="accessKeySecret">访问密钥</param>
        /// <returns></returns>
        public DefaultAcsClient InitVodClient()
        {
            // 点播服务接入区域
            string regionId = "cn-shanghai";
            //填写AccessKey信息
            IClientProfile profile = DefaultProfile.GetProfile(regionId, _videoConfig.AccessKeyId, _videoConfig.AccessKeySecret);
            return new DefaultAcsClient(profile);
        }

        /// <summary>
        /// 获取上传地址和凭证
        /// </summary>
        /// <param name="vodClient"></param>
        /// <returns></returns>
        public CreateUploadVideoResponse CreateUploadVideo(DefaultAcsClient vodClient,string title,string fileName)
        {
            CreateUploadVideoRequest request = new CreateUploadVideoRequest();
            request.AcceptFormat = Aliyun.Acs.Core.Http.FormatType.JSON;
            request.FileName = fileName;
            request.Title = title;
            //request.Description = "<文件描述>";
            //request.Tags = "<标签，多个标签用逗号分开>";
            //CoverURL示例：http://example.aliyundoc.com/test_cover_****.jpg
            //request.CoverURL = "<视频封面>";
            //媒体分类。登录点播控制台
            request.CateId = 1000442144;
            //转码模板组ID。登录点播控制台
            request.TemplateGroupId = "VOD_NO_TRANSCODE";
            //工作流ID。可登录点播控制台
            //request.WorkflowId = "<工作流ID>";
            //存储地址。登录点播控制台
            //request.StorageLocation = "<存储地址>";
            //AppId为固定取值。
            //request.AppId = "app-1000000";
            //设置请求超时时间
            request.SetReadTimeoutInMilliSeconds(1000);
            request.SetConnectTimeoutInMilliSeconds(1000);
            return vodClient.GetAcsResponse(request);
        }

        /// <summary>
        /// 初始化OSS客户端
        /// </summary>
        /// <param name="uploadAuth">上传凭证</param>
        /// <param name="uploadAddress">上传地址</param>
        /// <returns></returns>
        public OssClient InitOssClient(JObject uploadAuth, JObject uploadAddress)
        {
            string endpoint = uploadAddress.GetValue("Endpoint").ToString();
            string accessKeyId = uploadAuth.GetValue("AccessKeyId").ToString();
            string accessKeySecret = uploadAuth.GetValue("AccessKeySecret").ToString();
            string securityToken = uploadAuth.GetValue("SecurityToken").ToString();
            return new OssClient(endpoint, accessKeyId, accessKeySecret, securityToken);
        }


        /// <summary>
        /// 刷新上传凭证;
        /// 如果上传凭证过期，可刷新上传凭证再上传
        /// </summary>
        /// <param name="vodClient">初始化后的客户端</param>
        /// <param name="videoId">之前获取的Vodeoid</param>
        /// <returns></returns>
        public RefreshUploadVideoResponse RefreshUploadVideo(DefaultAcsClient vodClient,string videoId)
        {
            RefreshUploadVideoRequest request = new RefreshUploadVideoRequest();
            request.AcceptFormat = Aliyun.Acs.Core.Http.FormatType.JSON;
            request.VideoId = videoId;
            //设置请求超时时间
            request.SetReadTimeoutInMilliSeconds(1000);
            request.SetConnectTimeoutInMilliSeconds(1000);
            return vodClient.GetAcsResponse(request);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ossClient">oss客户端</param>
        /// <param name="uploadAddress">上传地址</param>
        /// <param name="file">上传文件</param>
        public void UploadLocalFile(OssClient ossClient, JObject uploadAddress, IFormFile file)
        {
            try
            {
                string bucketName = uploadAddress.GetValue("Bucket").ToString();
                string objectName = uploadAddress.GetValue("FileName").ToString();
                using Stream stream = file.OpenReadStream();
                ossClient.PutObject(bucketName, objectName, stream);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
