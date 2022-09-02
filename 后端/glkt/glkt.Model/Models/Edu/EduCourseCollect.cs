using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程收藏
    /// </summary>
    public partial class EduCourseCollect
    {
        /// <summary>
        /// 收藏ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程讲师ID
        /// </summary>
        public string CourseId { get; set; } = null!;
        /// <summary>
        /// 课程专业ID
        /// </summary>
        public string MemberId { get; set; } = null!;
        /// <summary>
        /// 逻辑删除 1（true）已删除， 0（false）未删除
        /// </summary>
        public sbyte IsDeleted { get; set; }
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
