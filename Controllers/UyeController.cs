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

        public IActionResult Sil(int id)
        {
            //silinecek kaydı bul
            Uye silinecek = _context.Uyeler.Find(id);
            //eğer silinecek kayıt veritabanına var ise
            if (silinecek != null)
            {
                //veritabanından sil
                _context.Remove(silinecek);
                //veritabanını güncelle
                _context.SaveChanges();
            }
            //listeye yönlendir
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Duzenle(int? id)
        {
            if (id.HasValue)
            {
                Uye aranan = _context.Uyeler.Find(id);
                if (aranan != null)
                {
                    return View(aranan);
                }
                //eğer aranan id ile kayıt yok ise 404 ver
                return NotFound();
            }
            //eğer id gelmedi ise 404 ver
            return NotFound();

        }
        [HttpPost]
        public IActionResult Duzenle(Uye m)
        {
            
            if (ModelState.IsValid)
            {
                _context.Uyeler.Update(m);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}