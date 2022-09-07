using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Model.DTO.Edu
{
    public class UserLoginRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }
}
