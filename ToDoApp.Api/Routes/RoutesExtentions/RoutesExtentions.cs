using ToDoApp_api.Routes.UpdateTask;

namespace ToDoApp_api.Routes.RoutesExtentions
{
    public static class RoutesExtentions
    {
        public static void UseRoutesExtentions(this WebApplication app)
        {
            app.CreateTask();
            app.GetAllTasks();
            app.UpdateTaskTitle();
            app.UpdateNameOdResponsible();
            app.UpdateDescription();
            app.UpdateStatus();
            app.TasksToDo();
            app.TasksCompleted();
            app.GetTaskForId();
            app.TaskPerResponsibler();
            app.DeleteTask();
        }
    }
}
