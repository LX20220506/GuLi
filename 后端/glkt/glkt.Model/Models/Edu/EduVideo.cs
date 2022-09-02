using System;
using System.Collections.Generic;

namespace glkt.EF
{
    /// <summary>
    /// 课程视频
    /// </summary>
    public partial class EduVideo
    {
        /// <summary>
        /// 视频ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 课程ID
        /// </summary>
        public string CourseId { get; set; } = null!;
        /// <summary>
        /// 章节ID
        /// </summary>
        public string ChapterId { get; set; } = null!;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 云端视频资源
        /// </summary>
        public string? VideoSourceId { get; set; }
        /// <summary>
        /// 原始文件名称
        /// </summary>
        public string? VideoOriginalName { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public uint Sort { get; set; }
        /// <summary>
        /// 播放次数
        /// </summary>
        public ulong PlayCount { get; set; }
        /// <summary>
        /// 是否可以试听：0收费 1免费
        /// </summary>
        public byte IsFree { get; set; }
        /// <summary>
        /// 视频时长（秒）
        /// </summary>
        public float Duration { get; set; }
        /// <summary>
        /// Empty未上传 Transcoding转码中  Normal正常
        /// </summary>
        public string Status { get; set; } = null!;
        /// <summary>
        /// 视频源文件大小（字节）
        /// </summary>
        public ulong Size { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public ulong Version { get; set; }
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
