using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class EduCourseInfoForm
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 课程讲师ID
        /// </summary>
        public string TeacherId { get; set; }

        /// <summary>
        /// 课程专业ID
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// 课程类别
        /// </summary>
        public string SubjectParentId { get; set; }

        /// <summary>
        /// 课程标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 课程销售价格，设置为0则可免费观看
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总课时
        /// </summary>
        public int LessonNum { get; set; }

        /// <summary>
        /// 课程封面图片路径
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// 课程简介
        /// </summary>
        public string Description { get; set; }

    }
}
