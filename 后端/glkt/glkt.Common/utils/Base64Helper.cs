using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils
{
    public static class Base64Helper
    {
        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="text">要加密的字符串</param>
        /// <returns></returns>
        public static string Base64_Encode(string text) {
            return (Convert.ToBase64String(Encoding.Default.GetBytes(text)));
        }

        /// <summary>
        /// base64解密
        /// </summary>
        /// <param name="text">要解密的字符串</param>
        /// <returns></returns>
        public static string Base64_Decode(string text) 
        {
            return (Encoding.Default.GetString(Convert.FromBase64String(text)));
        }
    }
}
