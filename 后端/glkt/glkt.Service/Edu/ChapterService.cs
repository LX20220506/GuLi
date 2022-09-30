using ggkt.Service.Base;
using glkt.EF;
using glkt.IRepository.Base;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Service.Edu
{
    public class ChapterService : ServiceBase<EduChapter>, IChapterService
    {
        private readonly IChapterRepository _repository;
        private readonly IVideorService _videorService;

        public ChapterService(IChapterRepository repository, IVideorService videorService) : base(repository)
        {
            this._repository = repository;
            this._videorService = videorService;
        }

        /// <summary>
        /// 查找章节信息
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<EduChapterResponse>> NestedList(string courseId)
        {
            // 定义要返回的数据
            List<EduChapterResponse> chapterResponseList =new List<EduChapterResponse>();

            // 查找该课程的所有章节
            var chapterList = await _repository.GetAllAsync(c => c.CourseId == courseId).ToListAsync();

            foreach (var chapter in chapterList)
            {
                EduChapterResponse chapterResponse = new EduChapterResponse();

                chapterResponse.Title = chapter.Title;
                chapterResponse.Id=chapter.Id;

                // 查找该章节的所有小节
                var videoList = await _videorService.GetAllAsync(s => s.ChapterId == chapter.Id);
                foreach (var video in videoList)
                {
                    EduVideoResponse videoResponse = new EduVideoResponse();
                    videoResponse.Title=video.Title;
                    videoResponse.Id=video.Id;

                    // 将小节添加到所有章节
                    chapterResponse.children.Add(videoResponse);
                }

                chapterResponseList.Add(chapterResponse);
            }
            return chapterResponseList;
        }

        public async Task RemoveChapterByCourseId(string courseId)
        {
            var chapterList = await _repository.GetAllAsync(c => c.CourseId == courseId).ToListAsync();
            foreach (var chapter in chapterList)
            {
                _repository.Delete(chapter);
            }
        }

        public async Task<bool> RemoveChapterById(string id)
        {
            List<EduVideo> vidrorList = (await _videorService.GetAllAsync(v => v.ChapterId == id)).ToList();
            //根据id查询是否存在视频，如果有则提示用户尚有子节点
            if (vidrorList.Count>0)
            {
                throw new Exception("该分章节下存在视频课程，请先删除视频课程");
            }

            var chapter = await base.GetEntityAsync(c => c.Id == id);
            return await base.Delete(chapter);
        }
    }
}
