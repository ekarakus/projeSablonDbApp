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
            //model geçerli ise; eksik bilgi veya geçersiz bilgi yok ise
            if (ModelState.IsValid)
            {
                //db örneğindeki üye listesine ekle
                _context.Uyeler.Add(model);
                //veritabanı örneğini veritabanına kaydet, veritabanını güncelle
                _context.SaveChanges();
                //uye listesine dön
                return RedirectToAction(nameof(Index));
            }
            //eğer model geçersiz ise  hataların olduğu hali ile kullanıcıya tekrar göster
            return View();
        }
    }
}