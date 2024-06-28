using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void TasksToDo(this WebApplication app)
        {
            app.MapGet(
                "TasksToDo",
                async (AppDbContext context) =>
                {
                    var TaskToDo = await context
                        .TasksTable
                        .Where(task => task.Status == false)
                        .ToListAsync();

                    return TaskToDo;
                }
            );
        }
    }
}
