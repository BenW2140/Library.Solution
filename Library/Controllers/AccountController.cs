using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using Library.ViewModels;
using System.Threading.Tasks;

namespace Library.Controllers
{
  public class AccountController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userMangager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, LibraryContext db)
    {
      _userMangager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }
    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    public ActionResult Login()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
  }
}