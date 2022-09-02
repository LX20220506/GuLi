using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程
    /// </summary>
    public partial class EduCourse
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程讲师ID
        /// </summary>
        public string TeacherId { get; set; } = null!;
        /// <summary>
        /// 课程专业ID
        /// </summary>
        public string SubjectId { get; set; } = null!;
        /// <summary>
        /// 课程专业父级ID
        /// </summary>
        public string SubjectParentId { get; set; } = null!;
        /// <summary>
        /// 课程标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 课程销售价格，设置为0则可免费观看
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 总课时
        /// </summary>
        public uint LessonNum { get; set; }
        /// <summary>
        /// 课程封面图片路径
        /// </summary>
        public string Cover { get; set; } = null!;
        /// <summary>
        /// 销售数量
        /// </summary>
        public ulong BuyCount { get; set; }
        /// <summary>
        /// 浏览数量
        /// </summary>
        public ulong ViewCount { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public ulong Version { get; set; }
        /// <summary>
        /// 课程状态 Draft未发布  Normal已发布
        /// </summary>
        public string Status { get; set; } = null!;
        /// <summary>
        /// 逻辑删除 1（true）已删除， 0（false）未删除
        /// </summary>
        public sbyte? IsDeleted { get; set; }
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
