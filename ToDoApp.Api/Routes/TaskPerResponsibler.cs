using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void TaskPerResponsibler(this WebApplication app)
        {
            app.MapGet(
                "TaskForResponsible/{nameResponsible}",
                async (string nameResponsible, AppDbContext context) =>
                {
                    var tasks = await context
                        .TasksTable
                        .Where(
                            task =>
                                task.NameOfResponsible != null
                                && task.NameOfResponsible.StartsWith(nameResponsible)
                        )
                        .ToListAsync();

                    return tasks;
                }
            );
        }
    }
}
