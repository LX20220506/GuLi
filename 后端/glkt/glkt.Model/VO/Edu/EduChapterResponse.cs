using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    /// <summary>
    /// 章节信息
    /// </summary>
    public class EduChapterResponse
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public List<EduVideoResponse> children { get; set; } = new List<EduVideoResponse>();
    }
}
