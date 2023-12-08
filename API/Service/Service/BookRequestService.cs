using System.Text.Json;
using API.Model.Book;
using API.Service.Interface;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Service.Service;

public class BookRequestService : IBookRequestService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IHttpClientFactory _httpClientFactory;

    public BookRequestService(ApplicationDbContext applicationDbContext, IHttpClientFactory httpClientFactory)
    {
        _applicationDbContext = applicationDbContext;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<BookRequest>> GetBooksAsync()
    {
        return await GetListOfBooks().ToListAsync();
    }

    private IQueryable<BookRequest> GetListOfBooks()
    {
        var books = _applicationDbContext.Book
            .Where(b => b.StatusId != 0 && b.IsDeleted == false)
            .Select(b => new BookRequest
            {
                Title = b.Title,
                Isbn = b.Isbn,
                PublicationDate = b.PublicationDateT.ToShortDateString(),
                Quantity = b.Quantity,
                Author = new[] { $"{b.Author.FirstName} {b.Author.LastName}" },
                Publisher = b.Publisher.Name,
                Genre = b.Genre.Name
            });

        return books;
    }

    public async Task<BookRequest> GetBookDetailsByIsbnAsync(string? isbn)
    {
        isbn ??= "9781451648546"; // Default to Steve Jobs book if no ISBN provided

        var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}";
        var bookRequest = new BookRequest { Isbn = isbn };

        try
        {
            var response = await _httpClientFactory.CreateClient().GetAsync(url);
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
                bookRequest.Genre = GetPropertyValue(jsonElement, "genre");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching book details: {e.Message}");
        }

        return bookRequest;
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