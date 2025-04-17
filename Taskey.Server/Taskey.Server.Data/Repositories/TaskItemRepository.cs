using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskey.Server.Domain.Models;
using Taskey.Server.Domain.Repositories;

namespace Taskey.Server.Data.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var taskItem = await GetByIdAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
