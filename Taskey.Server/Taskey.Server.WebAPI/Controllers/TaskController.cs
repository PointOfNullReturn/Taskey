using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taskey.Server.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Create
        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] object task)
        {
            // Logic to create a task in the database or service
            return CreatedAtAction(nameof(GetTaskByIdAsync), new { id = 1 }, task); // Example ID
        }
        #endregion

        #region Read
        // Get a specific task by ID: api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(int id)
        {
            // Logic to get a task by ID from the database or service
            return Ok(new { Message = $"Task with ID: {id}" });
        }

        // Get: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            // Logic to get tasks from the database or service
            return Ok(new { Message = "List of tasks" });
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] object task)
        {
            // Logic to update a task in the database or service
            return Ok(new { Message = $"Task with ID: {id} updated" });
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            // Logic to delete a task from the database or service
            return NoContent(); // 204 No Content
        }
        #endregion


    }
}
