using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Web.Model
{
    public class TodoItem
    {
        [Required]
        public string TaskTitle { get; set; } = null!;
        public int IdTask { get; set; }
        public string DescriptionTask { get; set; } = null!;
        [Required]
        public string NameOfResponsible { get; set; } = null!;
        public bool Status { get; set; }
        public string DateCreation { get; set; } = null!;
    }
}
