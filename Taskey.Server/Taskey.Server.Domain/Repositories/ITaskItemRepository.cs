using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskey.Server.Domain.Models;

namespace Taskey.Server.Domain.Repositories
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem?>> GetAllAsync();
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
        Task DeleteAsync(int id);
    }
}
