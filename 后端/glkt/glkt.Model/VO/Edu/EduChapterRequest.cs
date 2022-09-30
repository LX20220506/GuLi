using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class EduChapterRequest
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public string CourseId { get; set; } 
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Title { get; set; } 
        /// <summary>
        /// 显示排序
        /// </summary>
        public uint Sort { get; set; }
    }
}
