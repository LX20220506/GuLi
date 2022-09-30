using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    /// <summary>
    /// 课时信息
    /// </summary>
    public class EduVideoResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool Free { get; set; }
    }
}
