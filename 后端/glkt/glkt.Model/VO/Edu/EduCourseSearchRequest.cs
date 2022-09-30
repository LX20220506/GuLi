using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class EduCourseSearchRequest
    {
        /// <summary>
        /// 二级分类
        /// </summary>
        public string? SubjectId { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public string? SubjectParentId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 讲师
        /// </summary>
        public string? TeacherId { get; set; }
    }
}
