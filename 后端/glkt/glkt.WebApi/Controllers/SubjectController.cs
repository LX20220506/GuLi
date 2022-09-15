using glkt.Common.Utils.Result;
using glkt.IService.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace glkt.Edu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("BatchImport")]
        [SwaggerOperation(Summary ="导入课程")]
        public async Task<Result> BatchImport(IFormFile file) {
            await _subjectService.BatchImport(file);
            return ApiResult.Ok("导入成功");
        }

        [HttpGet("List")]
        [SwaggerOperation(Summary = "嵌套数据列表")]
        public async Task<Result> NestedList() { 
            var list = await _subjectService.NestedList();
            return ApiResult.Ok(list);
        }
    }
}
