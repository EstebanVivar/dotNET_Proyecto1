using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Display Order")]
        [Range(1,10000,ErrorMessage="Debe estar entre 1 y 10,000")]
        public int displayOrder { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;




    }
}
