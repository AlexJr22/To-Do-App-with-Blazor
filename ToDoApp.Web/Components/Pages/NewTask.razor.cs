using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using ToDoApp.Web.Model;

namespace ToDoApp.Web.Components.Pages
{
    public partial class NewTask
    {
        private string? TaskTitle { get; set; }
        private string? NameResponsible { get; set; }
        private string? Description { get; set; }


        private async Task CreateNewTask()
        {
            if (TaskTitle is not null && NameResponsible is not null)
            {
                var DataJson = new
                {
                    taskTitle = TaskTitle,
                    nameResponsible = NameResponsible,
                    descriptionTask = Description
                };

                await TodoService.CreateNewTask(DataJson);
            }
        }
    }
}
