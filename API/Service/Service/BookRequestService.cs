using System.Text.Json;
using API.Model.Book;
using API.Service.Interface.Repository;
using API.Service.Interface.Service;

namespace API.Service.Service;

public class BookRequestService(IHttpClientFactory httpClientFactory, IBookRepository bookRepository)
    : IBookRequestService
{
    public async Task<List<BookRequest>> GetBooksAsync()
    {
        return await bookRepository.GetAllBooksAsync();
    }

    public async Task<BookRequest> GetBookDetailsByIsbnAsync(string? isbn)
    {
        isbn ??= "9781451648546"; // Default to Steve Jobs book if no ISBN provided

        var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}";
        var bookRequest = new BookRequest { Isbn = isbn };

        try
        {
            var response = await httpClientFactory.CreateClient().GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var results = JsonDocument.Parse(content);

            if (results.RootElement.GetProperty("totalItems").GetInt32() > 0)
            {
                var jsonElement = results.RootElement.GetProperty("items")[0].GetProperty("volumeInfo");
                bookRequest.Title = GetPropertyValue(jsonElement, "title");
                bookRequest.SubTitle = GetPropertyValue(jsonElement, "subtitle");
                bookRequest.Author = GetAuthors(jsonElement);
                bookRequest.PrintType = GetPropertyValue(jsonElement, "printType");
                bookRequest.PageCount = jsonElement.TryGetProperty("pageCount", out var pageCountValue)
                    ? pageCountValue.GetInt32()
                    : 0;
                bookRequest.Publisher = GetPropertyValue(jsonElement, "publisher");
                bookRequest.PublicationDate = GetPropertyValue(jsonElement, "publishedDate");
                bookRequest.Genre = GetGenres(jsonElement);
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching book details: {e.Message}");
        }

        return bookRequest;
    }

    private string?[] GetGenres(JsonElement element)
    {
        if (element.TryGetProperty("categories", out var categoriesValue))
        {
            return categoriesValue.EnumerateArray()
                .Select(category => category.GetString()?.Trim())
                .Where(category => !string.IsNullOrEmpty(category))
                .ToArray();
        }
        return new[] { "N/A" };
    }

    private string GetPropertyValue(JsonElement element, string propertyName)
    {
        return element.TryGetProperty(propertyName, out var value) ? value.GetString() ?? "N/A" : "N/A";
    }

    private string?[] GetAuthors(JsonElement element)
    {
        if (element.TryGetProperty("authors", out var authorsValue))
        {
            return authorsValue.EnumerateArray()
                .Select(author => author.GetString()?.Trim())
                .Where(author => !string.IsNullOrEmpty(author))
                .ToArray();
        }

        return new[] { "N/A" };
    }
}