using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(TaskStatusPonta? status)
        {
            return await _taskRepository.GetTasksAsync(status);
        }

        public async Task<TaskItem> GetTaskAsync(int id)
        {
            return await _taskRepository.GetTaskAsync(id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            return await _taskRepository.CreateTaskAsync(taskItem);
        }

        public async Task<bool> UpdateTaskAsync(TaskItem taskItem)
        {
            return await _taskRepository.UpdateTaskAsync(taskItem);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
