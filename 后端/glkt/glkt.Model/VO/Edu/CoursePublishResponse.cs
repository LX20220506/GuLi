using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class CoursePublishResponse
    {
        /// <summary>
        /// 老师名称
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 课程一级类别
        /// </summary>
        public string SubjectLevelOne { get; set; }

        /// <summary>
        /// 课程二级类别
        /// </summary>
        public string SubjectLevelTwo { get; set; }

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
    }
}
