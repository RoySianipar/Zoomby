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
            .Where(x => x.IsDeleted == false && x.StartDate.Date >= DateTime.Now.Date && x.EndDate.Date <= DateTime.Now.Date)
            .ToList();

        //var listZoom = _context.ZoomSchedulers.ToList();
        return Ok(new { data = listZoom  });
    }

    public IActionResult GetByDateRange(DateTime StartDate, DateTime EndDate)
    {
        var listZoom = _context.ZoomSchedulers
            .Include(x => x.PIC)
            .Include(y => y.Account)
            .Where(x => x.IsDeleted == false && (x.StartDate.Date >= StartDate.Date 
            && x.EndDate.Date <= EndDate.Date))
            .ToList();
        return Ok(new { data = listZoom });
    }


    public IActionResult GetById(int id)
    {
        var listZoom = _context.ZoomSchedulers
            .Where(x => x.Id == id).FirstOrDefault();
        return Ok(listZoom);
    }
    public IActionResult Deleted(int id)
    {
        var listZoom = _context.ZoomSchedulers
            .Where(x => x.Id == id).FirstOrDefault();
        try
        {
            if(listZoom != null)
            {
                listZoom.IsDeleted = true;
                _context.Entry(listZoom).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(listZoom);
            }
            else
            {
                return BadRequest();
            }
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
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
            var result = _context.ZoomSchedulers.Where(x => x.Id == data.Id).FirstOrDefault();
            result.PICId = data.PICId;
            result.ZoomAccountId = data.ZoomAccountId;
            result.StartDate = data.StartDate;
            result.EndDate = data.EndDate;
            result.Agenda = data.Agenda;
            result.LinkAddress = data.LinkAddress;
            _context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(data);
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