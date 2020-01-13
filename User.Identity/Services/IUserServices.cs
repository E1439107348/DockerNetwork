using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Identity.Services
{
    public interface IUserServices
    {
        ///<summary>
        ///检车手机号是否注册  没有的话就去注册 
        /// </summary>
        /// <param name="phone"></param>
        int CheckOrCreate(string phone);
    }
}
