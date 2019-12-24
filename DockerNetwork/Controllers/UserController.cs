using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace DockerNetwork.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    //[ApiController]
    public class UserController : BaseController
    {

   


        private TestContext _testContext;

        public UserController(TestContext estContext)
        {
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
                return NotFound();
            }
            return Json(user);
        }


        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Patch()
        {
            return Content("");
        }


    }
}