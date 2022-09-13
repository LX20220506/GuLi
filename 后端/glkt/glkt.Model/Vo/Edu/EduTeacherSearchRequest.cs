using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.Vo.Edu
{
    public class EduTeacherSearchRequest
    {
        public string? name { get; set; }

        public int? level { get; set; }

        public string? begin { get; set; }

        public string? end { get; set; }
    }
}
