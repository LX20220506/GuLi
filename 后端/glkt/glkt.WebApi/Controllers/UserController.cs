using glkt.Common.Utils.Result;
using glkt.Model.Vo.Edu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace glkt.Edu.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public dynamic Login(UserLoginRequest userLogin)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("token", "admin");
            return ApiResult.Ok(data);
        }

        [HttpGet]
        public dynamic Info(string token)
        {

            //"code": 20000,
            //"data": {
            //              "roles": [
            //                "admin"
            //  ],
            //  "introduction": "I am a super administrator",
            //  "avatar": "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
            //  "name": "Super Admin"
            //}

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("roles", new string[] { "admin" });// 角色
            data.Add("introduction", "我是一个超级管理员");// 介绍
            data.Add("avatar", "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif");// 头像
            data.Add("name", "admin");// 名称
            return ApiResult.Ok(data);
        }

    }
}
