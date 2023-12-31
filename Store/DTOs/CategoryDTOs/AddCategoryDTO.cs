﻿using System.ComponentModel.DataAnnotations;

namespace Store.DTOs.CategoryDTOs
{
    public class AddCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
