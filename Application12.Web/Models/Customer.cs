using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application12.Web.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]

        public string CustomerName { get; set; }

        [Required]
        public string CustomerOrderProduct { get; set; }
        public int OrderNumber { get; set; }

        #region navigation to OrderModel


        [ForeignKey(nameof(Customer.OrderNumber))]
        public Order Order { get; set; }
        #endregion

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
