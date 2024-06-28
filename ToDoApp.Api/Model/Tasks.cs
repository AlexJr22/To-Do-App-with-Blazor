using ToDoApp_api.Controllers;
using ToDoApp_api.Requests.UpdateRequests;

namespace ToDoApp_api.Model
{
    public class Tasks
    {
        public string? TaskTitle { get; private set; }
        public int? IdTask { get; init; }
        public string? DescriptionTask { get; private set; }
        public string? NameOfResponsible { get; private set; }
        public bool? Status { get; private set; }
        public string? DateCreation { get; init; }

        public Tasks(
            string taskTitle,
            string descriptionTask,
            string nameOfResponsible)
        {
            this.TaskTitle = taskTitle;
            this.NameOfResponsible = nameOfResponsible;
            this.DescriptionTask = descriptionTask;
            this.DateCreation = TaskCreationController.DateCreationTaks();
            this.Status = false;
        }

        public void UpdateTaskTitle(UpdateTaskTitleRequest request) =>
            this.TaskTitle = request.NewTaskTitle;

        public void UpdateNameOfResponsible(UpdateNameOfResponsibleRequest request) =>
            this.NameOfResponsible = request.NameOfResponsible;

        public void UpdateDescription(UpdateDescriptionTaskRequest request) =>
            this.DescriptionTask = request.newDescription;

        public void UpdateStatus() =>
            this.Status = !this.Status;

        public void UpdateTaskData(UpdateTaskRequest request)
        {
            this.TaskTitle = request.NewTaskTitle;
            this.NameOfResponsible = request.NewNameResponsible;
            this.DescriptionTask = request.NewDescriptionTask;
            this.Status = request.NewStatus;
        }
    }
}
