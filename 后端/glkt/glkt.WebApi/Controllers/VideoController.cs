using AutoMapper;
using glkt.Common.Utils.Result;
using glkt.EF;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace glkt.Edu.Controllers
{
    [Route("api/edu/[controller]")]
    [ApiController]
    [SwaggerTag("课时")]
    public class VideoController : ControllerBase
    {
        private readonly IVideorService _videorService;
        private readonly IMapper _mapper;

        public VideoController(IVideorService videorService, IMapper mapper)
        {
            _videorService = videorService;
            _mapper = mapper;
        }

        [HttpPost("SaveVideoInfo")]
        [SwaggerOperation(Summary = "添加课时信息")]
        public async Task<Result> Save(EduVideoInfoForm videoInfoForm) {
            await _videorService.SaveVideoInfo(_mapper.Map<EduVideo>(videoInfoForm));
            return ApiResult.Ok();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "根据ID查询课时")]
        public async Task<Result> GetVideInfoById(string id) {
            EduVideo video = await _videorService.GetVideInfoById(id);
            return ApiResult.Ok(video);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "更新课时")]
        public async Task<Result> UpdateVideoInfo(EduVideoInfoForm videoInfoForm) {
            await _videorService.UpdateVideoInfo(_mapper.Map<EduVideo>(videoInfoForm));
            return ApiResult.Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "根据ID删除课时")]
        public async Task<Result> RemoveById(string id) {
            await _videorService.RemoveById(id);
            return ApiResult.Ok();
        }

    }
}
