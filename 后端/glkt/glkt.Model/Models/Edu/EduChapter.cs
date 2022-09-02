using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程
    /// </summary>
    public partial class EduChapter
    {
        /// <summary>
        /// 章节ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程ID
        /// </summary>
        public string CourseId { get; set; } = null!;
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 显示排序
        /// </summary>
        public uint Sort { get; set; }
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
