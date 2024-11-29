using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models
{
    [Table("employeee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        public string? name { get; set; }

        [Required]
        [Display(Name = "Employee Email")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }

        [Required]
        [Display(Name = "Employee Salary")]
        
        public decimal? salary { get; set; }
    }
}
