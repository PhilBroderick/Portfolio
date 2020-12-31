using System;

namespace Portfolio.Core.ServiceModels
{
    public class BlogItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}