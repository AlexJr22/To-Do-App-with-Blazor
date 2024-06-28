using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes.UpdateTask
{
    public static partial class Routes
    {
        public static void UpdateStatus(this WebApplication app)
        {
            app.MapPut(
                "UpdateStatus/{id:int}",
                async (int id, AppDbContext context) =>
                {
                    var task = await context
                        .TasksTable
                        .FirstOrDefaultAsync(task => task.IdTask == id);

                    task?.UpdateStatus();

                    await context.SaveChangesAsync();
                    return Results.Ok();
                }
            );
        }
    }
}
