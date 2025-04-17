using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskey.Server.Domain.Models;

namespace Taskey.Server.Application
{
    public interface ITaskItemService
    {
        Task<TaskItem> CreateTaskAsync(TaskItem taskItem);

        Task<TaskItem?> GetTaskByIdAsync(int id);

        Task<IEnumerable<TaskItem?>> GetAllTasksAsync();

        Task<TaskItem> UpdateTaskAsync(int id, TaskItem taskItem);

        Task<bool> DeleteTaskAsync(int id);
    }
}
