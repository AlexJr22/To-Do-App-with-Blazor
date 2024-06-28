using ToDoApp_api.DataBase.Context;
using ToDoApp_api.Model;
using ToDoApp_api.Requests;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void CreateTask(this WebApplication app)
        {
            app.MapPost(
                "CreateTask",
                async (AppDbContext context, TasksRequests request) =>
                {
                    var newTask = new Tasks(
                        request.TaskTitle,
                        request.DescriptionTask,
                        request.NameResponsible
                    );

                    await context.AddAsync(newTask);
                    await context.SaveChangesAsync();
                }
            );
        }
    }
}
