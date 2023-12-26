using Store.Data;
using System.ComponentModel.DataAnnotations;

namespace Store.DTOs.CategoryDTOs
{
    public class CategoryDTO : BaseAbstractData
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
