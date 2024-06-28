using ToDoApp.Web.Model;

namespace ToDoApp.Web.Components.Pages
{
    public partial class Home
    {
        public List<TodoItem>? todos;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);
            try
            {
                todos = await TodoService.GetTodosAsync();
                // Console.WriteLine("Dados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");

                todos = [];
            }
        }
    }
}
