using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Identity.Services
{
    public interface IAuthCodeServices
    {
        /// <summary>
        /// 根据手机号验证 验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="authCode">验证码</param>
        /// <returns></returns>
        bool Validate(string phone, string authCode);

    }
}
