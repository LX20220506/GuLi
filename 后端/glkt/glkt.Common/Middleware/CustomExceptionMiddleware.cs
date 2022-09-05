using glkt.Common.Utils.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace glkt.Common.Middleware
{
    /// <summary>
    /// 自定义异常处理中间件
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await HandleExceptionAsync(context,e);
            }

        }

        /// <summary>
        /// 设置异常统一放回结果
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="e">异常</param>
        /// <returns></returns>
        public async Task HandleExceptionAsync(HttpContext context, Exception e) {
            Result result = new Result();
            // 获取异常状态码
            result.Code= e switch
                {
                    ApplicationException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };
            result.Message = e.Message;
            result.Data = null;
            result.Success = false;
            // 设置返回结果
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
