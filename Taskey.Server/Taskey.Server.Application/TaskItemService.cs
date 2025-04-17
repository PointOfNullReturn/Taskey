using Taskey.Server.Domain.Models;
using Taskey.Server.Domain.Repositories;

namespace Taskey.Server.Application
{
    public class TaskItemService : ITaskItemService
    {
        //private readonly ILogger<TaskItemService> _logger;
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            await _taskItemRepository.AddAsync(taskItem);
            return taskItem;
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _taskItemRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaskItem?>> GetAllTasksAsync()
        {
            return await _taskItemRepository.GetAllAsync();
        }

        public async Task<TaskItem> UpdateTaskAsync(int id, TaskItem taskItem)
        {
            var existingTask = await _taskItemRepository.GetByIdAsync(id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
            existingTask.Title = taskItem.Title;
            existingTask.IsCompleted = taskItem.IsCompleted;
            await _taskItemRepository.UpdateAsync(existingTask);
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var existingTask = await _taskItemRepository.GetByIdAsync(id);
            if (existingTask == null)
            {
                return false;
            }
            await _taskItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
