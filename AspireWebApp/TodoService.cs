using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TodoService
{
    private readonly HttpClient _httpClient;

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<string>>("api/todo");
    }

    public async Task AddTodoAsync(string todo)
    {
        await _httpClient.PostAsJsonAsync("api/todo", todo);
    }

    public async Task DeleteTodoAsync(int index)
    {
        await _httpClient.DeleteAsync($"api/todo/{index}");
    }
}
