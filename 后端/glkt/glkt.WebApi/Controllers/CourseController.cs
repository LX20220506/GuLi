using glkt.Common.Utils.Result;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace glkt.Edu.Controllers
{
    [Route("api/edu/[controller]")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpPost("List/{index}/{size}")]
        public async Task<Result> GetCourseList([FromRoute]int index,[FromRoute]int size, EduCourseSearchRequest? searchObj) {
            var list = await _courseService.PageList(index,size, searchObj);
            return ApiResult.Ok(list);
        }

        [HttpPost("SaveCourseInfo")]
        [SwaggerOperation(Summary = "新增课程")]
        public async Task<Result> SaveCourseInfo(EduCourseInfoForm courseInfo) { 
            string courseId = await _courseService.saveCourseInfo(courseInfo);
            if (string.IsNullOrEmpty(courseId))
            {
                return ApiResult.Error("课程信息添加失败"); 
            }
            var data = new Dictionary<string, object>();
            data.Add("courseId", courseId);
            return ApiResult.Ok("课程信息添加成功", data);
        }


        [HttpGet("GetInfoById/{id}")]
        [SwaggerOperation(Summary ="根据课程Id，获取课程信息")]
        public async Task<Result> GetCourseInfoById(string id) {
             var courseInfoForm = await _courseService.getCourseInfoFormById(id);
            if (courseInfoForm == null)
                return ApiResult.Error("未找到该课程");
            return ApiResult.Ok(courseInfoForm);
        }

        [HttpPut("Update")]
        [SwaggerOperation(Summary = "修改课程信息")]
        public async Task<Result> UpdateCourseInfo(EduCourseInfoForm courseInfoForm) {
            await _courseService.UpdateCourseInfo(courseInfoForm);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("courseId", courseInfoForm.Id);
            return ApiResult.Ok(code: 20000, data:data);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "根据ID删除课程")]
        public async Task<Result> RemoveById(string id) {
            await _courseService.RemoveById(id);
            return ApiResult.Ok();
        }


        [HttpGet("CoursePublishInfo/{courseId}")]
        public async Task<Result> GetCoursePublishById(string courseId) {
            CoursePublishResponse coursePublishResponse = await _courseService.GetCoursePublishVoById(courseId);
            return ApiResult.Ok(coursePublishResponse);
        }

        [HttpPut("PublishCourse/{courseId}")]
        public async Task<Result> PublishCourse(string courseId)
        {
            await _courseService.PublishCourse(courseId);
            return ApiResult.Ok();
        }
    }
}
