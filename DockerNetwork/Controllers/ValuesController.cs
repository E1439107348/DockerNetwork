using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DockerNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region MyRegion
        private TestContext _testContext;

        public ValuesController(TestContext estContext)
        {
            _testContext = estContext;
        }

        [HttpGet]
        public string Get()
        {
            string reMsg = "无数据";

            //1先保存一个数据
            int num = 1;
            var getall = _testContext.User.Where(c => true).OrderByDescending(c => c.Id).FirstOrDefault();
            if (getall != null)
            {
                num = getall.Id + 1;
            }
            _testContext.User.Add(new Models.User
            {
                Id = num,
                Name = "测试" + num,
                Company = "2" + num
            });
            _testContext.SaveChanges();

            //2获取一个数据，然后返回
            if (getall != null)
            {
                var get = _testContext.User.SingleOrDefault(c => c.Id == (num - 1));
                reMsg = get.Id + get.Name;
            }

            return (reMsg);
        }
        #endregion

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
