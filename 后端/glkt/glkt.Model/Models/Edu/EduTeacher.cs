using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 讲师
    /// </summary>
    public partial class EduTeacher
    {
        /// <summary>
        /// 讲师ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 讲师姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 讲师简介
        /// </summary>
        public string Intro { get; set; } = null!;
        /// <summary>
        /// 讲师资历,一句话说明讲师
        /// </summary>
        public string? Career { get; set; }
        /// <summary>
        /// 头衔 1高级讲师 2首席讲师
        /// </summary>
        public uint Level { get; set; }
        /// <summary>
        /// 讲师头像
        /// </summary>
        public string? Avatar { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public uint Sort { get; set; }
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
        public DateTime GmtModified { get; set; }= DateTime.UtcNow;
    }
}
