using Microsoft.EntityFrameworkCore;
using sporKlubuApp.Models;
 
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;
 
    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // appsettings.js içinde belirtilen sql servere bağlan
        options.UseSqlServer(Configuration.GetConnectionString("filmCnnStr"));
    }
// veritabanına Film nesnesini Filmler tablosu olarak ekliyoruz
    public DbSet<Uye> Uyeler { get; set; }
}
