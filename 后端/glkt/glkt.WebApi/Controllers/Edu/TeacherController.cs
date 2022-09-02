using glkt.EF;
using glkt.IService.Edu;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "1"
        )]
        public async Task<dynamic> FindAllTeacher()
        {
            IEnumerable<EduTeacher> enumerable = await _teacherService.GetAllAsync();
            return Ok(enumerable);
        }

        [HttpDelete("{id}")]
        public async Task<dynamic> RemoveTeacher(string id) {
            await _teacherService.DeleteById(id);
            return Ok();
        }
    }
}
