using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Api.Controllers;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces;
using TaskManagementApi.Controllers;
using Xunit;

namespace TaskManagement.Tests
{
    public class TasksControllerTests
    {
        private readonly Mock<ITaskService> _taskServiceMock;
        private readonly TasksController _tasksController;

        public TasksControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _tasksController = new TasksController(_taskServiceMock.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkResultWithTasks()
        {            
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", CreatedAt = DateTime.Now, Status = TaskStatusPonta.Pending },
                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", CreatedAt = DateTime.Now, Status = TaskStatusPonta.InProgress }
            };
            _taskServiceMock.Setup(service => service.GetTasksAsync(null)).ReturnsAsync(tasks);

            var result = await _tasksController.GetTasks(null);
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<TaskItem>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task AddTask_ShouldReturnCreatedAtAction()
        {            
            var newTask = new TaskItem { Title = "New Task", Description = "New Description", CreatedAt = DateTime.Now, Status = TaskStatusPonta.Pending, UserId = "joaoldk" };
                     
            var result = await _tasksController.CreateTask(newTask);
            
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<TaskItem>(createdAtActionResult.Value);
            Assert.Equal(newTask.Title, returnValue.Title);
        }
    }
}
