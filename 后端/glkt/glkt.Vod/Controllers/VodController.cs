using glkt.Common.Utils.Result;
using glkt.IService.Edu;
using glkt.Service.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace glkt.Vod.Controllers
{
    [Route("api/vod")]
    [ApiController]
    [SwaggerTag("阿里云视频点播")]
    public class VodController : ControllerBase
    {
        private readonly IVideorService _videorService;

        public VodController(IVideorService videorService)
        {
            _videorService = videorService;
        }

        [HttpPost("upload")]
        [SwaggerOperation(Summary ="上传视频")]
        public async Task<Result> UploadVideo(IFormFile file) {
            string videoId = await _videorService.UploadVideo(file,file.Name,file.FileName);
            return ApiResult.Ok(data: videoId, message: "上传成功");
        }
    }
}
