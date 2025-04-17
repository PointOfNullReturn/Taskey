using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskey.Server.Application;
using Taskey.Server.Domain.Models;
using Taskey.Server.WebAPI.DTOs;

namespace Taskey.Server.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ILogger<TaskItemController> _logger;
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ILogger<TaskItemController> logger, ITaskItemService taskItemService)
        {
            _logger = logger;
            _taskItemService = taskItemService;
        }

        #region Create
        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItemDto taskItemDto)
        {
            var taskItem = new TaskItem
            {
                Id = taskItemDto.Id,
                Title = taskItemDto.Title,
                IsCompleted = taskItemDto.IsCompleted
            };

            var createdTask = await _taskItemService.CreateTaskAsync(taskItem);

            if (createdTask.Id == 0)
            {
                return BadRequest("Task creation failed. ID was not assigned.");
            }

            // Return a 201 Created response with the location of the new resource
            return CreatedAtAction(nameof(GetTaskByIdAsync), new { id = createdTask.Id }, createdTask);
        }
        #endregion

        #region Read
        // Get a specific task by ID: api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(int id)
        {
            // Logic to get a specific task by ID from the database or service
            var task = await _taskItemService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(task);
        }

        // Get: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            // Logic to get all tasks from the database or service
            var tasks = await _taskItemService.GetAllTasksAsync();
            return Ok(tasks);
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
