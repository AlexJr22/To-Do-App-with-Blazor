using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoApp.Web.Model;

namespace ToDoApp.Web.Services
{
    public class TodoService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/GetAllTasks");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Erro na resposta da API: {response.StatusCode}");
                    return new List<TodoItem>();
                }

                var todos = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
                if (todos == null || todos.Count == 0)
                {
                    Console.WriteLine("Nenhuma tarefa encontrada.");
                }

                return todos ?? new List<TodoItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter dados: {ex.Message}");
                return new List<TodoItem>();
            }
        }

        public async Task<List<TodoItem>> GetTasksCompleteds()
        {
            var responce = await _httpClient.GetAsync("/TasksCompleted");

            var todos = await responce.Content.ReadFromJsonAsync<List<TodoItem>>();

            return todos ?? new List<TodoItem>();
        }

        public async Task UpdateStatus(int id)
        {
            _ = await _httpClient.PutAsync($"/UpdateStatus/{id}", null);
        }

        public async Task CreateNewTask(object Datas)
        {
            var DatasJason = JsonSerializer.Serialize(Datas);
            var content = new StringContent(DatasJason,
                                                        Encoding.UTF8,
                                                        "application/json");

            await _httpClient.PostAsync("/CreateTask", content);
        }

        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"/DeleteTask/{id}");
        }

        public async Task UpdateNameResponsible(int id, string nameOfResponsible)
        {
            var data = new { nameOfResponsible = nameOfResponsible };   

            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"/UpdateResponsibleName/{id}", content);
        }

        public async Task UpdateTitle(int id, string newTaskTitle)
        {

            var data = new {  newTaskTitle = newTaskTitle };
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"/UpdateTaskTitle/{id}", content);
        }

        public async Task<TodoItem> GetTaskForId(int id)
        {
            var response = await _httpClient.GetAsync($"/GetTaskForId/{id}");
            response.EnsureSuccessStatusCode();

            var task = await response.Content.ReadFromJsonAsync<TodoItem>();

            if( task is not  null )
                return task;
            return new TodoItem();
        }
    }
}
