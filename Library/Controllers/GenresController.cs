using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class GenresController : Controller
  {
    private readonly LibraryContext _db;
    public GenresController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Genres.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Genre Genre)
    {
      _db.Genres.Add(Genre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(Genre => Genre.GenreId == id);
      return View(thisGenre);
    }
    public ActionResult Edit(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(Genre => Genre.GenreId == id);
      return View(thisGenre);
    }
    [HttpPost]
    public ActionResult Edit(Genre Genre)
    {
      _db.Entry(Genre).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(Genre => Genre.GenreId == id);
      return View(thisGenre);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(Genre => Genre.GenreId == id);
      _db.Genres.Remove(thisGenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}