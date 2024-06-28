using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void GetTaskForId(this WebApplication app)
        {
            app.MapGet(
                "GetTaskForId/{id:int}",
                async (int id, AppDbContext context) =>
                {
                    var task = await context
                        .TasksTable
                        .Where(task => task.IdTask == id)
                        .Select(
                            task =>
                                new
                                {
                                    task.TaskTitle,
                                    task.NameOfResponsible,
                                    task.DescriptionTask
                                }
                        )
                        .FirstOrDefaultAsync();

                    return task;
                }
            );
        }
    }
}
