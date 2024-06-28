using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;
using ToDoApp_api.Requests.UpdateRequests;

namespace ToDoApp_api.Routes.UpdateTask
{
    public static partial class Routes
    {
        public static void UpdateNameOdResponsible(this WebApplication app)
        {
            app.MapPut(
                "UpdateResponsibleName/{id:int}",
                async (int id, AppDbContext context, UpdateNameOfResponsibleRequest request) =>
                {
                    var task = await context
                        .TasksTable
                        .FirstOrDefaultAsync(task => task.IdTask == id);

                    task?.UpdateNameOfResponsible(request);

                    await context.SaveChangesAsync();
                    return Results.Ok();
                }
            );
        }
    }
}
