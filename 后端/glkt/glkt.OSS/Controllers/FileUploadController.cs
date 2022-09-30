using glkt.Common.Utils.Result;
using glkt.IService.OSS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;

namespace glkt.OSS.Controllers
{
    [Route("api/eduoss/[controller]")]
    [ApiController]
    [SwaggerTag("头像上传")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileService _FileService;

        public FileUploadController(IFileService fileService)
        {
            _FileService = fileService;
        }

        [HttpPost("upload")]
        [SwaggerOperation(Summary ="上传文件")]
        public dynamic Upload(IFormFile file, [FromQuery]string host) {
            string fileUrl = _FileService.Upload(file,host);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("url",fileUrl);
            data.Add("code", "20000");

            return ApiResult.Ok(data:data);
        }

        //[HttpPost("upload")]
        //[SwaggerOperation(Summary = "上传文件")]
        //public dynamic Upload(IFormFile file)
        //{
        //    string fileUrl = _FileService.Upload(file);
        //    Dictionary<string, object> data = new Dictionary<string, object>();
        //    data.Add("url", fileUrl);
        //    data.Add("code", "20000");

        //    return ApiResult.Ok(data: data);
        //}
    }
}
