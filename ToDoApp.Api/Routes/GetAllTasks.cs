using Microsoft.EntityFrameworkCore;
using ToDoApp_api.DataBase.Context;

namespace ToDoApp_api.Routes
{
    public static partial class Routes
    {
        public static void GetAllTasks(this WebApplication app)
        {
            app.MapGet(
                "GetAllTasks",
                async (AppDbContext context) =>
                {
                    var tasks = await context.TasksTable.ToListAsync();

                    return tasks;
                }
            );
        }
    }
}
