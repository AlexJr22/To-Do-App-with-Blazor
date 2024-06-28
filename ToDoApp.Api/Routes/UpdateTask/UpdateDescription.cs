using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;
using ToDoApp_api.Requests.UpdateRequests;

namespace ToDoApp_api.Routes.UpdateTask
{
    public static partial class Routes
    {
        public static void UpdateDescription(this WebApplication app)
        {
            app.MapPut(
                "UpdateDescription/{id:int}",
                async (int id, AppDbContext context, UpdateDescriptionTaskRequest request) =>
                {
                    var task = await context
                        .TasksTable
                        .FirstOrDefaultAsync(task => task.IdTask == id);

                    task?.UpdateDescription(request);

                    await context.SaveChangesAsync();
                    return Results.Ok("Task Description updated!");
                }
            );
        }
    }
}
