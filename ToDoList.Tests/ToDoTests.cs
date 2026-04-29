using ToDoList.Core;
using ToDoList.Core.Models;
using ToDoList.Core.Services;

namespace ToDoList.Tests
{
    /// <summary>
    /// Unit tests for TodoManager and FileService.
    /// </summary>
    public class TodoTests
    {
        /// <summary>
        /// Verifies that adding a task increases the task count to 1.
        /// </summary>
        [Fact]
        public void Add_AddsTask()
        {
            var manager = new TodoManager();
            manager.Add("Test");
            Assert.Single(manager.GetAll());
        }

        /// <summary>
        /// Verifies that the added task has the correct description.
        /// </summary>
        [Fact]
        public void Add_SetsDescription()
        {
            var manager = new TodoManager();
            var item = manager.Add("Hello");
            Assert.Equal("Hello", item.Description);
        }

        /// <summary>
        /// Verifies that completing a task marks it as complete and returns true.
        /// </summary>
        [Fact]
        public void Complete_MarksTaskComplete()
        {
            var manager = new TodoManager();
            var item = manager.Add("Test");
            var result = manager.Complete(item.Id);
            Assert.True(result);
            Assert.True(item.IsComplete);
        }

        /// <summary>
        /// Verifies that completing a non existent task returns false.
        /// </summary>
        [Fact]
        public void Complete_ReturnsFalse_WhenNotFound()
        {
            var manager = new TodoManager();
            var result = manager.Complete(Guid.NewGuid());
            Assert.False(result);
        }

        /// <summary>
        /// Verifies that removing a task by ID removes it from the list.
        /// </summary>
        [Fact]
        public void Remove_RemovesTask()
        {
            var manager = new TodoManager();
            var item = manager.Add("Test");
            var removed = manager.Remove(item.Id);
            Assert.True(removed);
            Assert.Empty(manager.GetAll());
        }

        /// <summary>
        /// Verifies that removing a non existent task returns false.
        /// </summary>
        [Fact]
        public void Remove_ReturnsFalse_WhenNotFound()
        {
            var manager = new TodoManager();
            var removed = manager.Remove(Guid.NewGuid());
            Assert.False(removed);
        }

        /// <summary>
        /// Verifies that tasks saved to a file can be loaded back correctly.
        /// </summary>
        [Fact]
        public void FileService_SavesAndLoads()
        {
            var path = "test_tasks.json";
            var fileService = new FileService(path);
            var manager = new TodoManager();
            var item = manager.Add("Test");
            fileService.Save(manager.GetDictionary());
            var loaded = fileService.Load();
            Assert.Single(loaded);
            Assert.Equal(item.Description, loaded[item.Id].Description);
            File.Delete(path);
        }

        /// <summary>
        /// Verifies that loading from a missing file returns an empty dictionary.
        /// </summary>
        [Fact]
        public void FileService_LoadsEmpty_WhenFileMissing()
        {
            var fileService = new FileService("does_not_exist.json");
            var result = fileService.Load();
            Assert.Empty(result);
        }

        /// <summary>
        /// Verifies that loading a file with invalid JSON throws an IOException.
        /// </summary>
        [Fact]
        public void FileService_Throws_OnInvalidJson()
        {
            var path = "bad.json";
            File.WriteAllText(path, "{not valid json");
            var fileService = new FileService(path);
            Assert.Throws<IOException>(() => fileService.Load());
            File.Delete(path);
        }

        /// <summary>
        /// Verifies that a new TodoItem has default values for IsComplete and Id.
        /// </summary>
        [Fact]
        public void TodoItem_HasDefaultValues()
        {
            var item = new TodoItem();
            Assert.False(item.IsComplete);
            Assert.NotEqual(Guid.Empty, item.Id);
        }

        /// <summary>
        /// Verifies that adding multiple tasks results in all of them appearing in the list.
        /// </summary>
        [Fact]
        public void Add_MultipleTasksAllAppear()
        {
            var manager = new TodoManager();
            manager.Add("Task one");
            manager.Add("Task two");
            manager.Add("Task three");
            var all = manager.GetAll();
            Assert.Equal(3, all.Count);
            Assert.Contains(all, t => t.Description == "Task one");
            Assert.Contains(all, t => t.Description == "Task two");
            Assert.Contains(all, t => t.Description == "Task three");
        }
    }
}