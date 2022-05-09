using Microsoft.AspNetCore.Mvc;
//using sporKlubuApp.Models;

namespace sporKlubuApp.Controllers
{
    public class UyeController : Controller
    {
        //Veritabanı nesnesini kontroller başlangıcına enjekte ediyoruz
        private DataContext _context;
        public UyeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {//veritabanı örneğinden üyeler listesini çekiyoruz
            List<Uye> uyeler = _context.Uyeler.ToList();
            return View(uyeler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Uye model)
        {
            if (ModelState.IsValid)
            {
                _context.Uyeler.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}