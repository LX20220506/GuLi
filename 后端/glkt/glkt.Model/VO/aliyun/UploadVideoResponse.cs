using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.VO.aliyun
{
    /// <summary>
    /// 获取视频上传地址和凭证  https://help.aliyun.com/document_detail/55407.html?spm=a2c4g.11186623.6.763.ec8f70373Xn4lb
    /// </summary>
    public class UploadVideoResponse
    {
        /// <summary>
        /// 请求ID  示例值：25818875-5F78-4A*****F6-D7393642CA58
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 视频ID  示例值：93ab850b4f6f*****54b6e91d24d81d4
        /// </summary>
        public string VideoId { get; set; }

        /// <summary>
        /// 上传地址 示例值：eyJTZWN1cml0*****a2VuIjoiQ0FJU3p3TjF
        /// </summary>
        public string UploadAddress { get; set; }

        /// <summary>
        /// 上传凭证 示例值：eyJFbmRw*****b2ludCI6Im
        /// </summary>
        public string UploadAuth { get; set; }
    }
}
