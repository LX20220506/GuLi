using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.Result
{
    public static class ApiResult
    {

        public static Result Ok() {
            return new Result {
                Code = 2000,
                Message="成功",
                Success=true,
                Data=null
            };
        }

        public static Result Ok(dynamic data) {
            return new Result {
                Code = 2000,
                Message = "成功",
                Success = true,
                Data=data
            };
        }

        public static Result Ok(string message)
        {
            return new Result
            {
                Code = 2000,
                Message = message,
                Success = true,
                Data = null
            };
        }

        public static Result Ok(string message,dynamic data)
        {
            return new Result
            {
                Code = 2000,
                Message = message,
                Success = true,
                Data = data
            };
        }

        public static Result Ok(int code,string message, dynamic data)
        {
            return new Result
            {
                Code = code,
                Message = message,
                Success = true,
                Data = data
            };
        }



        public static Result Error()
        {
            return new Result
            {
                Code = 2001,
                Message = "失败",
                Success = false,
                Data = null
            };
        }

        public static Result Error(string message)
        {
            return new Result
            {
                Code = 2001,
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static Result Error(int code,string message)
        {
            return new Result
            {
                Code = code,
                Message = message,
                Success = false,
                Data = null
            };
        }
    }
}
