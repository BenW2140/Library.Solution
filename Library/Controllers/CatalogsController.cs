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
  }
}