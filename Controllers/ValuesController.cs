using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceToCollection.Model;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceToCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CollectionTest>> Get()
        {
            List<CollectionTest> collection = new List<CollectionTest>
            {
                new CollectionTest
                {
                    Id = 1,
                    Name = "Value1"
                },
                new CollectionTest
                {
                    Id = 2,
                    Name = "Value2"
                },
                new CollectionTest
                {
                    Id = 3,
                    Name = "Value3"
                }
            };
            return collection;
        }

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
