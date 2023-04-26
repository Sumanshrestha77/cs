using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")] //ROUTING:giving route , making url format
    [ApiController]
    public class WebApiController : ControllerBase
    {
        // GET: api/<WebApiController>
        [HttpGet]
        public object get()
        {
           return new { Name = "suman", Value = 1 };

        }
        public List<object> set()
        {
            List<object> list = new List<object>();
            list.Add(new { Name = "suman", Value = 1 });
            list.Add(new { Name = "heisenberg", Value = 1 });

            list.Add(new { Name = "san", Value = 2 });

            return list;
        }



        // GET api/<WebApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WebApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WebApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WebApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
