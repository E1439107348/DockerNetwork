using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
namespace DockerNetwork.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {




        private TestContext _testContext;
        private ILogger<UserController> _ilogger;

        public UserController(TestContext estContext, ILogger<UserController> ilogger)
        {
            _ilogger = ilogger;
            _testContext = estContext;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = _testContext.User
                   .AsNoTracking()//不会对数据进行状态跟踪    节省ef的开销
                   .Include(u => u.Properties)
                   .SingleOrDefault(u => u.Id == UserIdentity.UserId);
            if (user == null)
            {
                throw new UserOperationException($"错误的用户上下文id{UserIdentity.UserId}");
            }

            return Json(user);
        }


        [Route("")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody]JsonPatchDocument<Models.User>patch)
        {

            var user =await _testContext.User.SingleOrDefaultAsync(c => c.Id == UserIdentity.UserId);
            patch.ApplyTo(user);

            _testContext.Update(user);
            _testContext.SaveChanges();
            return Json(user);
        }


    }
}