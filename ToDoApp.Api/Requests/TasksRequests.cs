namespace ToDoApp_api.Requests
{
    public record TasksRequests(
        string TaskTitle,
        string NameResponsible,
        string DescriptionTask
    ) { }
}
