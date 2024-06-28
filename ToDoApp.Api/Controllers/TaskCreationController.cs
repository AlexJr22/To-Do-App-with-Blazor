namespace ToDoApp_api.Controllers
{
    public class TaskCreationController
    {
        public static string DateCreationTaks()
        {
            DateTime DateNow = DateTime.Now;

            string FormattedDate = DateNow.ToString("dd/MM/yyyy");

            return FormattedDate;
        }
    }
}
