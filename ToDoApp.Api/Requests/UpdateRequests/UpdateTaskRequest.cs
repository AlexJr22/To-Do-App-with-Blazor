namespace ToDoApp_api.Requests.UpdateRequests
{
    public record UpdateTaskRequest(
        string NewTaskTitle,
        string NewNameResponsible,
        string NewDescriptionTask,
        bool NewStatus
        )
    { }
}
