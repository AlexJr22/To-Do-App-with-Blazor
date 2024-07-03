using Microsoft.AspNetCore.Components;
using ToDoApp.Web.Model;

namespace ToDoApp.Web.Components.Pages.UpdateTaskComponents
{
    public partial class UpdateTask
    {
        public List<TodoItem>? tasks;

        private void ClickToUpdadate(int id)
        {
            Nav.NavigateTo($"/UpdateTask/taskid={id}");
        }

        protected override async Task OnInitializedAsync()
        {
            tasks = await TodoService.GetTodosAsync();
        }
    }
}
