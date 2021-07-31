using System;
using System.ComponentModel.DataAnnotations;

namespace RazorFields.EntityFramework.Persistence
{
    public record PersistenceRazorModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Content { get; set; }
    }
}