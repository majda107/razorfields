using System;
using System.ComponentModel.DataAnnotations;

namespace RazorFields.EntityFramework.Persistence
{
    public class PersistenceRazorModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Content { get; set; }
    }
}