using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application12.Web.Models
{
    public class CashOnDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public double Amount { get; set; }

        public int OrderNumber { get; set; }
        #region navigation to OrderModel


        [ForeignKey(nameof(CashOnDelivery.OrderNumber))]
        public Order Order { get; set; }
        #endregion
    }
}
