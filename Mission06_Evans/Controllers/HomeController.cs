using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Evans.Models;

namespace Mission06_Evans.Controllers;


public class HomeController : Controller
{
    private MovieContext _context;

    // Constructor to initialize the database context
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }

    // Default action to return the Index view
    public IActionResult Index()
    {
        return View();
    }

    // GET action to navigate to the AddMovie form page
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    // POST action to receive form data, add it to the database, and save changes
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response); // Add record to the DbSet
        _context.SaveChanges(); // Synchronize changes with the SQLite database
        
        return View("Confirmation", response);
    }
    public IActionResult AboutJoel()
    {
        return View();
    }
}