using AutoMapper;
using glkt.Common.Utils.Result;
using glkt.EF;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using glkt.Service.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace glkt.Edu.Controllers
{
    [Route("api/edu/[controller]")]
    [SwaggerTag("章节")]
    [ApiController]
    public class ChapterController : ControllerBase
    {

        private readonly IChapterService _chapterService;
        private readonly IMapper _mapper;

        public ChapterController(IChapterService chapterService,IMapper mapper)
        {
            _chapterService = chapterService;
            this._mapper = mapper;
        }

        [HttpGet("GetChapterList/{courseId}")]
        [SwaggerOperation(Summary = "嵌套章节数据列表")]
        public async Task<Result> NestedListByCourseId(string courseId) {
            var chapterResponsesList = await _chapterService.NestedList(courseId);
            return ApiResult.Ok(chapterResponsesList);
        }

        [HttpPost]
        [SwaggerOperation("新增章节")]
        public async Task<Result> AddChapterInfo(EduChapterRequest chapterRequest) {
            var chapter = _mapper.Map<EduChapter>(chapterRequest);
            chapter.Id = Guid.NewGuid().ToString().Replace("-", "");
            var check = await _chapterService.Add(chapter);
            if (check)
                return ApiResult.Ok();
            return ApiResult.Error("添加章节信息失败");
        }

        [HttpGet("{id}")]
        [SwaggerOperation("根据ID查询章节")]
        public async Task<Result> GetChapterInfoById(string id) {
            var chapter = await _chapterService.GetEntityAsync(c => c.Id == id);
            return ApiResult.Ok(chapter);
        }

        [HttpPut]
        [SwaggerOperation("修改章节")]
        public async Task<Result> UpdateChapterInfoById(EduChapter chapter) {
            var eduChapter =await _chapterService.GetEntityAsync(c => c.Id == chapter.Id);
            eduChapter.CourseId = chapter.CourseId;
            eduChapter.Sort=chapter.Sort;
            eduChapter.Title=chapter.Title;

            await _chapterService.Update(eduChapter);

            return ApiResult.Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "根据ID删除章节")]
        public async Task<Result> DeleteChapterById(string id) {
            await _chapterService.RemoveChapterById(id);
            return ApiResult.Ok();
        }
    }
}
