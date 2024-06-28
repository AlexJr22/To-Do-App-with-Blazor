using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;
using ToDoApp_api.Requests.UpdateRequests;

namespace ToDoApp_api.Routes.UpdateTask
{
    public static partial class Routes
    {
        public static void UpdateTaskTitle(this WebApplication app)
        {
            app.MapPut(
                "UpdateTaskTitle/{id:int}",
                async (AppDbContext context, UpdateTaskTitleRequest request, int id) =>
                {
                    var task = await context
                        .TasksTable
                        .FirstOrDefaultAsync(task => task.IdTask == id);

                    task?.UpdateTaskTitle(request);

                    await context.SaveChangesAsync();
                    return Results.Ok();
                }
            );
        }
    }
}
