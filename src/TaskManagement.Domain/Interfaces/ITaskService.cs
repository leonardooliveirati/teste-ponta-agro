using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync(TaskStatus? status);
        Task<TaskItem> GetTaskAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem taskItem);
        Task<bool> UpdateTaskAsync(TaskItem taskItem);
        Task<bool> DeleteTaskAsync(int id);
    }
}
