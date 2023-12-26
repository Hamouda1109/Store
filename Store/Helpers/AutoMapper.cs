using AutoMapper;
using Store.DTOs.CategoryDTOs;
using Store.Models.Store;

namespace Store.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Category , CategoryDTO>().ReverseMap();
            CreateMap<Category , AddCategoryDTO>().ReverseMap();
            CreateMap<Category , UpdateCategoryDTO>().ReverseMap();
        }
    }
}
