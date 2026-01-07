using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
