using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult GetAll()
    {
        var listZoom = _context.ZoomSchedulers
            .Include(x => x.PIC)
            .Include(y => y.Account)
            .ToList();
        return Ok(new { data = listZoom  });
    }
    public IActionResult GetPIC()
    {
        return Ok(_context.PICs.ToList());
    }
    public IActionResult Save(ZoomScheduler data)
    {
        if (data.Id == 0)
        {
            _context.ZoomSchedulers.Add(data);
            _context.SaveChanges();
            return Ok(data);
        }
        else
        {
            throw new Exception();
        }
    }
    public IActionResult GetZoom()
    {
        return Ok(_context.ZoomAccounts.ToList());
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}