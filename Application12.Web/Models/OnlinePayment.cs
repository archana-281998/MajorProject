using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application12.Web.Models
{
    public class OnlinePayment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required]
        public string PaymentViaPhonePe { get; set; }

        [Required]

        public string Location { get; set; }

        [Required]
        public double Amount { get; set; }


        public int OrderNumber { get; set; }
        #region navigation to OrderModel


        [ForeignKey(nameof(OnlinePayment.OrderNumber))]
        public Order Order { get; set; }
        #endregion


    }
}

