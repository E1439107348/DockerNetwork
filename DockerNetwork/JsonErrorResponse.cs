using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerNetwork
{
    /// <summary>
    /// 返回所有的异常信息=》固定格式
    /// </summary>
    public class JsonErrorResponse
    {
        public string Message { get; set; }

        public object DeveloperMessage { get; set; }
    }
}
