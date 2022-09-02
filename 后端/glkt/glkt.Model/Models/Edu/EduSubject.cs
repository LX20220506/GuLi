using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程科目
    /// </summary>
    public partial class EduSubject
    {
        /// <summary>
        /// 课程类别ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; } = null!;
        /// <summary>
        /// 排序字段
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
