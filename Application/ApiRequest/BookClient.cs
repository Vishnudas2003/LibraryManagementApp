using Core.Models.Catalog;
using Newtonsoft.Json;

namespace Application.ApiRequest;

public class BookClient(HttpClient httpClient, IConfiguration configuration)
{
    private readonly string _apiBaseUrl = configuration["ApiBaseUrl"] ?? string.Empty;

    public async Task<List<Book>> GetBooksAsync()
    {
        var response = await httpClient.GetAsync($"{_apiBaseUrl}/book");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Book>>(content);
    }
}