using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程简介
    /// </summary>
    public partial class EduCourseDescription
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程简介
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime GmtModified { get; set; }
    }
}
