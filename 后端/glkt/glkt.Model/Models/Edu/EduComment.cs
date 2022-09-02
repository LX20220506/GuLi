using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 评论
    /// </summary>
    public partial class EduComment
    {
        /// <summary>
        /// 讲师ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程id
        /// </summary>
        public string CourseId { get; set; } = null!;
        /// <summary>
        /// 讲师id
        /// </summary>
        public string TeacherId { get; set; } = null!;
        /// <summary>
        /// 会员id
        /// </summary>
        public string MemberId { get; set; } = null!;
        /// <summary>
        /// 会员昵称
        /// </summary>
        public string? Nickname { get; set; }
        /// <summary>
        /// 会员头像
        /// </summary>
        public string? Avatar { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 逻辑删除 1（true）已删除， 0（false）未删除
        /// </summary>
        public byte IsDeleted { get; set; }
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
