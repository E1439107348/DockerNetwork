using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Identity.Services
{
    public class AuthCodeServices : IAuthCodeServices
    {
        public bool Validate(string phone, string authCode)
        {
            return true;//测试环境 总是 通过
        }
    }
}
