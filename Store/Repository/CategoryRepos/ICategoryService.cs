using Store.DTOs.CategoryDTOs;
using Store.DTOs.ErrorDTOs;
using Store.Models.Store;

namespace Store.Repository.CategoryRepos
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> getAllActive();
        Task<List<CategoryDTO>> getAll();
        Task<Category> getById(int id);
        Task<ErrorsDTO> addCategory(AddCategoryDTO categoryDTO);
        Task<ErrorsDTO> removeCategory(int id);
        Task<ErrorsDTO> removeCategoryFinally(int id);
        Task<ErrorsDTO> updateCategory(UpdateCategoryDTO categoryDTO);
    }
}
