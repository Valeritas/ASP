using System.ComponentModel.DataAnnotations;

namespace Potions.API.Models
{
    namespace PotionAPI
    {
      
        public class Potion
        {
            [Key]
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }

        }
    }
}
