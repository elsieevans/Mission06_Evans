using Microsoft.AspNetCore.Mvc;
using Mission06_Evans.Models; // Make sure this matches your project name
using System.Linq;

namespace Mission06_Evans.Controllers;

public class HomeController : Controller
{
    // // Creating a private variable to hold our database context
    private MovieContext _context;

    // // Constructor that gets the context from the dependency injector
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }

    // // Basic action to return the home page view
    public IActionResult Index()
    {
        return View();
    }

    // // Action to return the "About Joel" page view
    public IActionResult AboutJoel()
    {
        return View();
    }

    // // --- MOVIE FORM ACTIONS ---

    // // GET method to load the blank form for adding a movie
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    // // POST method to save a new movie to the database
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        // // Checking if the model is valid based on the data requirements (like Year > 1888)
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // Add the new record
            _context.SaveChanges(); // Save changes to the SQLite file

            // // Redirecting to the MovieList so the user can see the new movie in the table
            return RedirectToAction("MovieList");
        }
        
        // // If it's not valid, send them back to the form with their data so they can fix it
        return View(response); 
    }

    // // --- MISSION 07 CRUD SECTION ---

    // // READ: Grabbing all movies from the database to show in the table
    public IActionResult MovieList()
    {
        // // Fetching the movies and ordering them by title before sending to the view
        var movies = _context.Movies
            .OrderBy(x => x.Title)
            .ToList();

        return View(movies);
    }

    // // UPDATE (GET): Find one specific movie and send it to the form view
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // // Find the record that matches the primary key ID passed from the view
        var movieToEdit = _context.Movies.SingleOrDefault(x => x.MovieId == id);

        if (movieToEdit == null)
        {
            return NotFound();
        }

        // // Reusing the AddMovie view but passing in the existing movie data
        return View("AddMovie", movieToEdit);
    }

    // // UPDATE (POST): Taking the edited info and updating the record in the DB
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        if (ModelState.IsValid)
        {
            _context.Update(updatedInfo); // Telling EF to update this specific movie
            _context.SaveChanges(); // Pushing the update to the database file
            
            // // Redirecting back to the list so we can see the updated record
            return RedirectToAction("MovieList");
        }

        return View("AddMovie", updatedInfo);
    }

    // // DELETE: Permanently removing a movie from the collection
    public IActionResult Delete(int id)
    {
        // // Finding the record to delete by its ID
        var movieToDelete = _context.Movies.SingleOrDefault(x => x.MovieId == id);

        if (movieToDelete != null)
        {
            _context.Movies.Remove(movieToDelete); // Removing it from the DbSet
            _context.SaveChanges(); // Deleting it from the SQLite database file
        }

        // // Refresh the movie list view
        return RedirectToAction("MovieList");
    }
}