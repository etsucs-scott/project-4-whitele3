using System;
using System.Text.Json;
using ToDoList.Core.Models;

namespace ToDoList.Core.Services
{
    /// <summary>
    /// Handles saving and loading tasks.
    /// </summary>
    public class FileService
    {
        private readonly string filePath;

        /// <summary>
        /// Initializes the FileService and creates the file if it doesn't exist.
        /// </summary>
        public FileService(string path)
        {
            filePath = path;

            try
            {
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, "{}");
            }
            catch (IOException ex)
            {
                throw new IOException($"Could not create tasks file at {filePath}.", ex);
            }
        }

        /// <summary>
        /// Saves the given tasks dictionary file.
        /// </summary>
        public void Save(Dictionary<Guid, TodoItem> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);
            }
            catch (IOException ex)
            {
                throw new IOException("Failed to write tasks to file.", ex);
            }
            catch (JsonException ex)
            {
                throw new IOException("Failed to serialize tasks.", ex);
            }
        }

        /// <summary>
        /// Loads tasks from the file.
        /// </summary>
        public Dictionary<Guid, TodoItem> Load()
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Dictionary<Guid, TodoItem>>(json)
                       ?? new Dictionary<Guid, TodoItem>();
            }
            catch (JsonException ex)
            {
                throw new IOException("Failed to parse tasks file.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Failed to read tasks file.", ex);
            }
        }
    }
}