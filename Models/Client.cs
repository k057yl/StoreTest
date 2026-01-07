using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public DateTime RegistrationDate { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
