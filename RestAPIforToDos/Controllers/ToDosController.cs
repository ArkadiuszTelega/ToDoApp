using Microsoft.AspNetCore.Mvc;
using RestAPIforToDos.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPIforToDos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoManager _toDoManager;

        // Constructor-based Dependency Injection (DI)
        public ToDosController(ToDoManager toDoManager)
        {
            _toDoManager = toDoManager;
        }

        // Returns all ToDos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> Get()
        {
            var toDos = await _toDoManager.GetToDosAsync();
            return Ok(toDos); 
        }

        // Returns all done ToDos
        [HttpGet("done")]
        public async Task<ActionResult<IEnumerable<ToDo>>> Done()
        {
            var doneToDos = await _toDoManager.GetDoneToDosAsync();
            return Ok(doneToDos); 
        }

        // Returns all not done ToDos
        [HttpGet("notdone")]
        public async Task<ActionResult<IEnumerable<ToDo>>> NotDone()
        {
            var notDoneToDos = await _toDoManager.GetNotDoneToDosAsync();
            return Ok(notDoneToDos); 
        }

        // Returns ToDos to be done in the next {range} days    || Usage : /api/todos/range?range={range}
        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDosInRange([FromQuery] int range)
        {
            if (range < 0)
            {
                return BadRequest("Range must be greater than or equal to 0.");
            }

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(range);

            if (range > 0)
            {
                endDate = endDate.AddDays(1); // Include the end date
            }

            var toDos = await _toDoManager.GetToDosRangeAsync(startDate, endDate);
            return Ok(toDos);
        }

        // Returns a specific ToDo by ID    || Usage: /api/todos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> Get(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }

        // Adds a new ToDo to the database  || Usage : POSt /api/todos with ToDo object
        [HttpPost]
        public async Task<ActionResult<ToDo>> Post([FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns BadRequest if ModelState is invalid
            }

            await _toDoManager.AddToDoAsync(toDo);
            return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo);
        }

        // Marks a ToDo as done by ID   || Usage: /api/todos/{id}/markdone
        [HttpPatch("{id}/markdone")]
        public async Task<IActionResult> MarkDone(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound(); // Return NotFound if ToDo doesn't exist
            }

            await _toDoManager.MarkDoneToDoAsync(id);
            return NoContent(); // Return NoContent to indicate success
        }

        // Marks a ToDo as not done by ID    || Usage: /api/todos/{id}/marknotdone
        [HttpPatch("{id}/marknotdone")]
        public async Task<IActionResult> MarkNotDone(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound(); // Return NotFound if ToDo doesn't exist
            }

            await _toDoManager.MarkNotDoneToDoAsync(id);
            return NoContent(); // Return NoContent to indicate success
        }

        // Sets the completion percentage of a ToDo by ID || Usage : /api/todos/{id}/complete?complete={percent}
        [HttpGet("{id}/complete")]
        public async Task<ActionResult<ToDo>> Complete(int id, [FromQuery] int complete)
        {
            if (complete < 0 || complete > 100)
            {
                return BadRequest("Complete percentage must be between 0 and 100."); // Validates percentage range
            }

            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound(); // Return NotFound if ToDo doesn't exist
            }

            toDo.Complete = complete;
            toDo.Done = (complete == 100); // Mark as Done if complete is 100%
            await _toDoManager.UpdateToDoAsync(toDo);

            return Ok(toDo); // Return the updated ToDo
        }

        // Updates an existing ToDo by ID    || Usage:PUT /api/todos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns BadRequest if ModelState is invalid
            }

            var existingToDo = await _toDoManager.GetToDoByIdAsync(id);
            if (existingToDo == null)
            {
                return NotFound(); // Return NotFound if ToDo doesn't exist
            }

            // Update fields
            existingToDo.Title = toDo.Title;
            existingToDo.Description = toDo.Description;
            existingToDo.DateOfExpiry = toDo.DateOfExpiry;
            existingToDo.Complete = toDo.Complete;
            existingToDo.Done = toDo.Done;

            await _toDoManager.UpdateToDoAsync(existingToDo);
            return NoContent(); // Return NoContent to indicate success
        }

        // Deletes a ToDo by ID     || Usage: DELETE /api/todos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDo = await _toDoManager.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return NotFound(); // Return NotFound if ToDo doesn't exist
            }

            await _toDoManager.DeleteToDoAsync(id);
            return NoContent(); // Return NoContent to indicate success
        }
    }
}
