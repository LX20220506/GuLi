using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.Vo.Edu
{
    public class TeacherQueryVo
    {
        public int index { get; set; }

        public int size { get; set; }
        public string? name { get; set; }

        public int? level { get; set; }

        public DateTime? begin { get; set; }

        public DateTime? end { get; set; }
    }
}
