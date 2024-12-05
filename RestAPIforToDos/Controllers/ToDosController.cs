using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using RestAPIforToDos.Models;
using RestAPIforToDos;

namespace RestAPIforToDos.Controllers
{
    public class ToDosController : ApiController
    {
        private readonly ToDoManager _toDoManager;

        public ToDosController()
        {
            var context = new AppDbContext();
            _toDoManager = new ToDoManager(context);
        }

        [HttpGet]
        public async Task<IEnumerable<ToDo>> Get()
        {
            return await _toDoManager.GetToDosAsync();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _toDoManager.AddToDoAsync(toDo);
            return CreatedAtRoute("DefaultApi", new { id = toDo.Id }, toDo);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingToDo = await _toDoManager.GetToDoByIdAsync(id);
            if (existingToDo == null)
            {
                return NotFound();
            }

            await _toDoManager.UpdateToDoAsync(toDo);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            await _toDoManager.DeleteToDoAsync(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
