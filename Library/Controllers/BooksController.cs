using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    public BooksController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create()
    {
      return RedirectToAction("Index");
    }
  }
}