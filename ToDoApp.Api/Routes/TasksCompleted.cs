using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void TasksCompleted(this WebApplication app)
        {
            app.MapGet(
                "TasksCompleted",
                async (AppDbContext context) =>
                {
                    var TaskToDo = await context
                        .TasksTable
                        .Where(task => task.Status == true)
                        .ToListAsync();

                    return TaskToDo;
                }
            );
        }
    }
}
