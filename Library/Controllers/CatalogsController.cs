using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class CatalogsController : Controller
  {
    private readonly LibraryContext _db;
    public CatalogsController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Catalogs.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Catalog catalog)
    {
      _db.Catalogs.Add(catalog);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisCatalog = _db.Catalogs.FirstOrDefault(catalog => catalog.CatalogId == id);
      return View(thisCatalog);
    }
  }
}