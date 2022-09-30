using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class EduVideoInfoForm
    {
        /// <summary>
        /// 视频ID
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 课程ID
        /// </summary>
        public string? CourseId { get; set; }

        /// <summary>
        /// 章节ID
        /// </summary>
        public string? ChapterId { get; set; }

        /// <summary>
        /// 视频资源
        /// </summary>
        public string? VideoSourceId { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 是否可以试听：0默认 1免费
        /// </summary>
        public bool Free { get; set; }
    }
}
