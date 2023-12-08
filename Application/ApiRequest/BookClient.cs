using Core.Models.Catalog;
using Newtonsoft.Json;

namespace Application.ApiRequest;

public class BookClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public BookClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["ApiBaseUrl"] ?? string.Empty;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}/book");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Book>>(content);
    }
}