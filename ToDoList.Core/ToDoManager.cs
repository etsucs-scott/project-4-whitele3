using System;
using ToDoList.Core.Models;

namespace ToDoList.Core
{
    /// <summary>
    /// Manages the in memory list of to do tasks.
    /// </summary>
    public class TodoManager
    {
        private readonly List<TodoItem> tasks = new();

        /// <summary>Adds a new task with the given description.</summary>
        public TodoItem Add(string description)
        {
            var item = new TodoItem { Description = description };
            tasks.Add(item);
            return item;
        }

        /// <summary>Returns all current tasks.</summary>
        public List<TodoItem> GetAll() => tasks;

        /// <summary>Marks a task complete by its ID. Returns false if not found.</summary>
        public bool Complete(Guid id)
        {
            var item = tasks.FirstOrDefault(t => t.Id == id);
            if (item == null) return false;
            item.IsComplete = true;
            return true;
        }

        /// <summary>Removes a task by its ID. Returns false if not found.</summary>
        public bool Remove(Guid id)
        {
            var item = tasks.FirstOrDefault(t => t.Id == id);
            if (item == null) return false;
            tasks.Remove(item);
            return true;
        }

        /// <summary>Returns tasks as a dictionary keyed by Guid for file storage.</summary>
        public Dictionary<Guid, TodoItem> GetDictionary()
        {
            return tasks.ToDictionary(t => t.Id, t => t);
        }
    }
}