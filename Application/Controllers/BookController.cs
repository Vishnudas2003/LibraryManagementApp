using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class BookController : Controller
{
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Add()
    {
        return View(new Book());
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Add(Book book)
    {
        return View(book);
    }
}