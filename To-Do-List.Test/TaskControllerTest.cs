using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using To_Do_List_Api.Controllers;
using To_Do_List_Api.DAL;
using To_Do_List_Api.Models;
using Xunit;

namespace To_Do_List.Test
{
    public class TaskControllerTest
    {
        private TasksController tasksController;
        public DbContextOptions<ApplicationDBContext> dbContextOptions { get; }
        public string connectionString = "Data Source=C:\\Sqlite\\testdb.db";
        public TaskControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseSqlite(connectionString)
                .Options;
            tasksController = new TasksController(new ApplicationDBContext(dbContextOptions));
        }
        
        [Fact]
        public void GetTask_ShouldTestTask()
        {
            var result = tasksController.GetTask();

            Assert.Equal(1, result.Result.Value.First().id);
            Assert.False(result.Result.Value.First().Complete);
        }

        [Fact]
        public void GetHistoricTask_ShouldTestHistoricTask()
        {
            var result = tasksController.GetHistoricTask();

            Assert.Equal(2, result.Result.Value.First().id);
            Assert.True(result.Result.Value.First().Complete);
        }

        [Fact]
        public void PostTask_ShouldTestPostTask()
        {
            var result = tasksController.PostTask(new Task { Complete=true, Title="Lemon"});

            Assert.True(result.Result.Value);
        }

        [Fact]
        public void PostTaskList_ShouldTestPostTaskList()
        {
            var result = tasksController.PostTaskList(new List<Task> { new Task { Complete = true, Title = "Apple" } });

            Assert.True(result.Result.Value);
        }
    }
}
