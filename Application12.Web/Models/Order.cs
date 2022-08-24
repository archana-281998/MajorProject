using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Application12.Web.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }
        [Required]
        public string OrderProductName { get; set; }
        [Required]
        public DateTime OrderDateTime { get; set; }


        public double Amount { get; set; }

        public int ProductId { get; set; }
        #region navigation to OrderModel


        [ForeignKey(nameof(Order.ProductId))]
        public Product Product { get; set; }
        #endregion

        #region Navigation Properties to Order Model


        public ICollection<Customer> Customers { get; set; }
        #endregion
        #region Navigation Properties to OnlinePayment Model


        public ICollection<OnlinePayment> OnlinePayments { get; set; }
        #endregion
        #region Navigation Properties to OnlinePayment Model


        public ICollection<CashOnDelivery> CashOnDeliveries { get; set; }
        #endregion

       
    }
}

