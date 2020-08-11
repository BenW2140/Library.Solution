using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public BooksController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this._userManager.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userBooks = _db.Books.Where(entry => entry.User.Id == currentUser.Id);
      return View(userBooks);
    }
    public ActionResult Create()
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Book book, int authorId)
    {
      var userId = this._userManager.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      book.User = currentUser;
      _db.Books.Add(book);
      if (authorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = authorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
        .Include(book => book.Authors)
        .ThenInclude(join => join.Author)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    public ActionResult Edit(int id)
    {
      var thisBook = FirstOrDefault(book => book.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View(thisBook);
    }
    [HttpPost]
    public ActionResult Edit(Book book, int authorId)
    {
      if (authorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = authorId, BookId = book.BookId });
      }
      _db.Entry(book).state = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View(thisBook);
    }
    [HttpPost]
    public ActionResult AddAuthor(Book book, int authorId)
    {
      if (authorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = authorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}