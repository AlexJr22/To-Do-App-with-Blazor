using Microsoft.AspNetCore.Components;
using ToDoApp.Web.Model;
using ToDoApp.Web.Services;

namespace ToDoApp.Web.Components.TaskCardComponents.TaskCompleteds
{
    public partial class TaskCardCompleted
    {
        [Parameter]
        public TodoItem? Todo { get; set; }

        private string CurrentClassInput = "div-input-notChecked";
        private string CurrentClassDivContainer = "taskCard-container";
        private string CurrentDisplay = "display-flex";

        private void ChangeClassInput()
        {
            CurrentClassInput = CurrentClassInput ==
                "div-input-notChecked" ? "div-input-Checked" : "div-input-notChecked";
        }

        private void VerifyStatus()
        {
            if (Todo is not null)
                if (Todo.Status)
                    CurrentClassInput = "div-input-Checked";
        }

        private async Task UpdateStatus()
        {
            if (Todo is not null)
                await TodoService.UpdateStatus(Todo.IdTask);
        }

        private void UpdateTask()
        {
            CurrentDisplay = "display-none";
        }

        private async void OnClickInput()
        {
            UpdateTask();
            ChangeClassInput();
            await UpdateStatus();
        }
        private async Task DeleteTask()
        {
            CurrentDisplay = "display-none";
            if (Todo is not null)
                await TodoService.DeleteTask(Todo.IdTask);
        }

        protected override void OnInitialized()
        {
            VerifyStatus();
        }
    }
}
