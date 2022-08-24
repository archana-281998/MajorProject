using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application12.Web.Models
{
    public class OrderDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public string OrderedProductMyCustomer { get; set; }

        [Required]

        public double Amount { get; set; }
        public int CustomerId { get; set; }
        #region navigation to Customer Model


        [ForeignKey(nameof(OrderDetail.CustomerId))]
        public Customer Customer { get; set; }
        #endregion

    }
}
