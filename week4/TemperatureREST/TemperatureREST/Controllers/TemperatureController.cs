using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureREST.Models;

namespace TemperatureREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        // really we would use a DB, but for dmeo purposes, a static list.
        public static List<Temperature> Data = new List<Temperature>
        {
            new Temperature
            {
                Id = 1,
                Time = DateTime.Now,
                Value = 36,
                Unit = TemperatureUnit.Celsius
            }
        };

        // GET: api/Temperature
        [HttpGet]
        // the return type can be just your type
        // or, ActionResult<YourType>, both will work, but the latter also allows you to
        // return error messages
        public ActionResult<IEnumerable<Temperature>> Get()
        {
            //internal server error
            //sending server exceptions blindly to the client is not good for security
            // StatusCode(500, ex)
            return Ok(Data);
        }

        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        // override content negotiation and only provide this media type from this action method
        //can do this --> [Produces("application/json")] -- but not very restfull
        public ActionResult<Temperature> Get(int id)
        {
            Temperature result = Data.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // POST: api/Temperature
        // for inserting a new resource
        [HttpPost]
        public ActionResult<Temperature> Post([FromBody] Temperature value)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            Data.Add(value);
            //can also do CreatedAtRoute
            return CreatedAtAction("Get",new { Id = value.Id},value);
        }

        // in our action methods, we have acces to Request properties and Response object
        // on ConterollerBase class.
        // so you can access any info about the recieved request and do conditions
        //ResponseCacheAttribute.Headers.Add("CustomHeader", new StringValues("mycustomvalue"));

        // PUT: api/Temperature/5
        // replace an existing resource
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temperature value)
        {
            if(id != value.Id)
            {
                return BadRequest();
            }
            var existing = Data.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            Data.Remove(existing);
            value.Id = id;
            Data.Add(value);
            return NoContent(); // success = Ok()
        }

        // DELETE: api/Temperature/5
        // DELETE is for deleting resources
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existing = Data.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            Data.Remove(existing);
            //return Ok(); // success = Ok()
            return NoContent();
        }
    }
}
