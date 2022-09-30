using glkt.EF;
using glkt.IService.Base;
using glkt.Model.VO.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Edu
{
    public interface IChapterService:IServiceBase<EduChapter>
    {
        /// <summary>
        /// 拿到查找章节信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<List<EduChapterResponse>> NestedList(String courseId);

        /// <summary>
        /// 根据ID删除章节
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> RemoveChapterById(string id);

        /// <summary>
        /// 根据课程Id，删除章节信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task RemoveChapterByCourseId(string courseId);
    }
}
