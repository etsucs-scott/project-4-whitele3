using System;

namespace ToDoList.Core.Models
{
    /// <summary>
    /// Represents a single to do task.
    /// </summary>
    public class TodoItem
    {
        /// <summary>Unique identifier for this task.</summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>The text description of the task.</summary>
        public string Description { get; set; } = "";

        /// <summary>Whether the task has been completed.</summary>
        public bool IsComplete { get; set; } = false;
    }
}