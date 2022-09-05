using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.DTO.Edu
{
    public class EduTeacherDto
    {

        /// <summary>
        /// 讲师ID
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 讲师姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 讲师简介
        /// </summary>
        public string Intro { get; set; }

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
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }
    }
}
