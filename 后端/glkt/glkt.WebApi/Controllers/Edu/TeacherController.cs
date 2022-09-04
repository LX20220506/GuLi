using glkt.Common.utils;
using glkt.Common.utils.Result;
using glkt.EF;
using glkt.IService.Edu;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToPage;

namespace glkt.WebApi.Controllers.Edu
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("讲师")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "查找所有讲师")]
        public async Task<dynamic> FindAllTeacher(int index,int size)
        {
            IEnumerable<EduTeacher> enumerable = await _teacherService.GetAllAsync();
            IEnumerable<EduTeacher> data=enumerable.ToPage(index, size);

            PageList pagelist = new PageList(data, index,size,enumerable.Count());

            return ApiResult.Ok(pagelist);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary ="根据ID删除讲师")]
        public async Task<dynamic> RemoveTeacher(string id) {
            await _teacherService.DeleteById(id);
            return ApiResult.Ok();
        }
    }
}
