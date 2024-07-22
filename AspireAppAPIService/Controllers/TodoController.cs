using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspireAppAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static readonly List<string> todos = new List<string>();

        // GET: api/todo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(todos);
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult Post([FromBody] string todo)
        {
            if (string.IsNullOrWhiteSpace(todo))
            {
                return BadRequest("Todo item cannot be empty");
            }

            todos.Add(todo);
            return Ok();
        }

        // DELETE: api/todo/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= todos.Count)
            {
                return NotFound("Todo item not found");
            }

            todos.RemoveAt(index);
            return Ok();
        }
    }
}
