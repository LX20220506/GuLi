using Aliyun.Acs.Core;
using Aliyun.Acs.vod.Model.V20170321;
using Aliyun.OSS;
using ggkt.Service.Base;
using glkt.Common.Utils;
using glkt.Common.Utils.ALiYun;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.Edu
{
    public class VideorService : ServiceBase<EduVideo>, IVideorService
    {
        private readonly IVideorRepository _repository;
        private readonly UploadVideoHelper _uploadVideoHelper;

        public VideorService(IVideorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public VideorService(IVideorRepository repository, UploadVideoHelper uploadVideoHelper) : base(repository)
        {
            _repository = repository;
            _uploadVideoHelper = uploadVideoHelper;
        }

        public async Task<EduVideo> GetVideInfoById(string id)
        {
            return await base.GetEntityAsync(v => v.Id == id);
        }

        public async Task RemoveById(string id)
        {
            //删除视频资源 TODO

            EduVideo video = await base.GetEntityAsync(v => v.Id == id);
            await base.Delete(video);
        }

        public async Task RemoveVideorByCourseId(string courseId)
        {
            var videorList = await _repository.GetAllAsync(v => v.CourseId == courseId).ToListAsync();

            foreach (var videor in videorList)
            {
                _repository.Delete(videor);
            }
        }

        public async Task SaveVideoInfo(EduVideo eduVideo)
        {
            eduVideo.Id = Guid.NewGuid().ToString().Replace("-", "");
            bool result = await base.Add(eduVideo);
            if (!result)
            {
                throw new Exception("课时信息保存失败");
            }
        }

        public async Task UpdateVideoInfo(EduVideo eduVideo)
        {
            EduVideo video = await base.GetEntityAsync(v => v.Id == eduVideo.Id);

            video.Title = eduVideo.Title;
            video.VideoSourceId=eduVideo.VideoSourceId;
            video.Sort=eduVideo.Sort;
            video.IsFree = eduVideo.IsFree;

            await _repository.SaveAsync();
        }

        public async Task<string> UploadVideo(IFormFile file, string title, string fileName)
        {
            string videoId = "";
            try
            {
                // 初始化VOD客户端并获取上传地址和凭证
                DefaultAcsClient vodClient = _uploadVideoHelper.InitVodClient();
                CreateUploadVideoResponse createUploadVideoResponse = _uploadVideoHelper.CreateUploadVideo(vodClient,title,fileName);
               
                // 执行成功会返回VideoId、UploadAddress和UploadAuth
                videoId = createUploadVideoResponse.VideoId;
                JObject uploadAuth = JObject.Parse(Base64Helper.Base64_Decode(createUploadVideoResponse.UploadAuth));
                JObject uploadAddress = JObject.Parse(Base64Helper.Base64_Decode(createUploadVideoResponse.UploadAddress));
               
                // 使用UploadAuth和UploadAddress初始化OSS客户端
                OssClient ossClient = _uploadVideoHelper.InitOssClient(uploadAuth, uploadAddress);
                await Task.Run(() =>
                {
                    // 上传文件，注意是同步上传会阻塞等待，耗时与文件大小和网络上行带宽有关
                    _uploadVideoHelper.UploadLocalFile(ossClient, uploadAddress, file);
                });

            }
            catch (Exception e)
            {
                throw e;
            }

            return videoId;
        }
    }
}
