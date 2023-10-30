using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger  = logger;
        _context = context;
    }

    // Displays All Dishes
    [HttpGet("dishes")]
    public ViewResult AllDishes()
    {
        List<Dish> DishesFromDb = _context.Dishes.Include(d => d.Creator).OrderBy(d => d.Name).ToList();
        return View(DishesFromDb);
    }

    // Displays the 'Add a Dish' Form
    [HttpGet("dishes/new")]
    public ViewResult NewDish()
    {
        @ViewBag.AllChefs = _context.Chefs.OrderBy(ch => ch.LastName).ToList();
        return View();
    }

    // Adds New Dish to the DB
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            return View("NewDish");
        }
        
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("AllDishes", "Dish");
    }


    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}