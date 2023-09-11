// In your BooksController.cs
using Microsoft.AspNetCore.Mvc;
using DynamicWebBookLibrary.Models;
using DynamicWebBookLibrary.Services; // or the correct namespace where BookService is defined
using System.Threading.Tasks;

public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<ActionResult> Index()
    {
        var books = await _bookService.GetAllBooksAsync();
        return View(books);
    }
}
