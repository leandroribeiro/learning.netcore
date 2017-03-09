using System;
using System.Collections.Generic;
using System.Text;

namespace Prime.Domain
{
    public class Todo
    {
        public Todo(int userId, int id, string title, bool completed)
        {
            this.UserId = userId;
            this.Id = id;
            this.Title = title;
            this.Completed = completed;
        }

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
