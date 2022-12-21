using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HalcyonApparelsDomain.Entities
{
    public class CustomerDetails
    {
        [Key]
        [DisplayName("Customer Id")]
        [Required(ErrorMessage = "Customer Id is required")]
        [Column(TypeName = "INT")]
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string? Email { get; set; }
    }
}
