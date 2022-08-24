using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Application12.Web.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Size { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        #region navigation to CategoryModel
        [ForeignKey(nameof(Product.CategoryId))]
        public Category Category { get; set; }
        #endregion

        public ICollection<Order> Order { get; set; }

    }
        
}
