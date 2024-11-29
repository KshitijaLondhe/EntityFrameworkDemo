using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string? name { get; set; }

        [Required]
        [Display(Name = "Book Author")]
        public string? author { get; set; }


        [Required]
        [Display(Name = "Book Price")]

        public decimal? price { get; set; }
    }
}
