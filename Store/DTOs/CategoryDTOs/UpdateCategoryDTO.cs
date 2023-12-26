using Store.Data;
using System.ComponentModel.DataAnnotations;

namespace Store.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO : BaseAbstractData
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
    }
}
