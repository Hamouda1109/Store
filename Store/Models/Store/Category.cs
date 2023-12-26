using Store.Data;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Store
{
    public class Category : BaseAbstractData
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
