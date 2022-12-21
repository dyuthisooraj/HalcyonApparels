using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalcyonApparelsDomain.Entities
{
    public class OrderDetails
    {
        [Key]
        [DisplayName("Order Id")]
        [Required(ErrorMessage = "Order Id is required")]
        [Column(TypeName = "INT")]
        public int OrderId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string Product { get; set; } = null!;

        [DisplayName("Product Type")]
        [Required(ErrorMessage = "Product Type is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string ProductType { get; set; } = null!;

        [ForeignKey("CustomerId")]

        [DisplayName("Customer Id")]
        [Required(ErrorMessage = "Customer Id is required")]
        [Column(TypeName = "INT")]
        public CustomerDetails? CustomerId { get; set; }

    }
}
