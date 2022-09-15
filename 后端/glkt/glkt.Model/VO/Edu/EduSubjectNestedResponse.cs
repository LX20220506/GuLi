using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.Edu
{
    public class EduSubjectNestedResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<EduSubjectNestedResponse> Children { get; set; } = new List<EduSubjectNestedResponse>();
    }
}
