using glkt.Model.VO.Edu;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.IService.Edu
{
    public interface ISubjectService
    {
        public Task BatchImport(IFormFile file);
        public Task<List<EduSubjectNestedResponse>> NestedList();
    }
}
