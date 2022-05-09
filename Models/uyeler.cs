using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Uye{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Display(Name ="Ad")]
    [Required(ErrorMessage ="Ad boş bırakılamaz")]
    public string   Ad { get; set; }

    [Display(Name ="Soyad")]
    [Required(ErrorMessage ="Soyad boş bırakılamaz")]
    public string   Soyad { get; set; }

    [Display(Name ="Email")]
    [Required(ErrorMessage ="Email boş bırakılamaz")]
    [EmailAddress]
    public string   Email { get; set; }
}