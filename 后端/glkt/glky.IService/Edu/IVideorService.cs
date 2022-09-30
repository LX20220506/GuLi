using glkt.EF;
using glkt.IService.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Edu
{
    public interface IVideorService:IServiceBase<EduVideo>
    {
        /// <summary>
        /// 根据ID查询课时
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<EduVideo> GetVideInfoById(string id);

        /// <summary>
        /// 根据ID删除课时
        /// </summary>
        /// <param name="id">课时id</param>
        /// <returns></returns>
        public Task RemoveById(string id);

        /// <summary>
        /// 根据课程Id，删除小节视频
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task RemoveVideorByCourseId(string courseId);

        /// <summary>
        /// 保存小节信息
        /// </summary>
        /// <param name="eduVideo"></param>
        /// <returns></returns>
        public Task SaveVideoInfo(EduVideo eduVideo);

        /// <summary>
        /// 更新课时
        /// </summary>
        /// <param name="eduVideo">课时信息</param>
        /// <returns></returns>
        Task UpdateVideoInfo(EduVideo eduVideo);

        /// <summary>
        /// 上传小节视频
        /// </summary>
        /// <param name="file">视频文件</param>
        /// <returns></returns>
        public Task<string> UploadVideo(IFormFile file, string title, string fileName);

    }
}
