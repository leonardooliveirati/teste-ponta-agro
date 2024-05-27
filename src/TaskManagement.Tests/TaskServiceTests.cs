using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Services;
using Xunit;

namespace TaskManagement.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepositoryMock.Object);
        }

        [Fact]
        public async Task GetTasksAsync_ShouldReturnAllTasks()
        {            
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", CreatedAt = DateTime.Now, Status = TaskStatusPonta.Pending },
                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", CreatedAt = DateTime.Now, Status = TaskStatusPonta.Completed }
            };
            _taskRepositoryMock.Setup(repo => repo.GetTasksAsync(null)).ReturnsAsync(tasks);
         
            var result = await _taskService.GetTasksAsync(null);
            
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddTaskAsync_ShouldCallRepositoryMethod()
        {            
            var task = new TaskItem { Title = "New Task", Description = "New Description", CreatedAt = DateTime.Now, Status = TaskStatusPonta.Pending };
                     
            await _taskService.CreateTaskAsync(task);
            
            _taskRepositoryMock.Verify(repo => repo.CreateTaskAsync(task), Times.Once);
        }
    }
}
