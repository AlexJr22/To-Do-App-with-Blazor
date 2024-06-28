using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void DeleteTask(this WebApplication app)
        {
            app.MapDelete(
                "DeleteTask/{id}",
                async (int id, AppDbContext context) =>
                {
                    var task = await context.TasksTable.FindAsync(id);

                    if (task is not null)
                        context.TasksTable.Remove(task);

                    await context.SaveChangesAsync();
                    return Results.Ok();
                }
            );
        }
    }
}
