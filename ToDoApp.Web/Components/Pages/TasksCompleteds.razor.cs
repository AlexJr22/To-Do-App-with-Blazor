using Microsoft.AspNetCore.Components;
using ToDoApp.Web.Model;

namespace ToDoApp.Web.Components.Pages
{
    public partial class TasksCompleteds
    {
        public List<TodoItem>? todos;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            todos = await TodoService.GetTasksCompleteds();
        }
    }
}
