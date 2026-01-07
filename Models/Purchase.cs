using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required] public string Number { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] public decimal TotalAmount { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
    }
}
