using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.DTOs.CategoryDTOs;
using Store.DTOs.ErrorDTOs;
using Store.Models.Store;

namespace Store.Repository.CategoryRepos
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext _db;
        private readonly IMapper _mapper;
        public CategoryService(StoreDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ErrorsDTO> addCategory(AddCategoryDTO categoryDTO)
        {
            try
            {
                await _db.AddAsync(_mapper.Map<Category>(categoryDTO));
                await _db.SaveChangesAsync();
                return new ErrorsDTO() { IsValid = true, Errors = new List<ErrorDTO>() };
            }
            catch (Exception e)
            {
                return new ErrorsDTO()
                {
                    IsValid = false,
                    Errors = new List<ErrorDTO>() { new ErrorDTO { ErrorEn = e.Message, ErrorAr = "هناك مشكلة في اضافة فئة جديدة" } }
                };
            }
        }

        public async Task<List<CategoryDTO>> getAllActive()
        {
           
            return _mapper.Map<List<CategoryDTO>>(await _db.categories.Where(c => c.IsActive == true).ToListAsync());
        }

        public async Task<List<CategoryDTO>> getAll()
        {
            return _mapper.Map<List<CategoryDTO>>(await _db.categories.ToListAsync());
        }

        public async Task<Category> getById(int id)
        {
            return await _db.categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ErrorsDTO> removeCategory(int id)
        {
            try
            {
                var category = await getById(id);
                category.IsActive = false;
                category.DeletedAt = DateTime.Now;
                _db.categories.Update(category);
                await _db.SaveChangesAsync();
                return new ErrorsDTO() { IsValid = true, Errors = new List<ErrorDTO>() };
            }
            catch (Exception e)
            {
                return new ErrorsDTO()
                {
                    IsValid = false,
                    Errors = new List<ErrorDTO>() { new ErrorDTO { ErrorEn = e.Message, ErrorAr = "هناك مشكلة في حذف هذة الفئة" } }
                };
            }
        }

        public async Task<ErrorsDTO> removeCategoryFinally(int id)
        {
            try
            {
                _db.categories.Remove(await getById(id));
                await _db.SaveChangesAsync();
                return new ErrorsDTO() { IsValid = true, Errors = new List<ErrorDTO>() };

            }
            catch (Exception e)
            {
                return new ErrorsDTO()
                {
                    IsValid = false,
                    Errors = new List<ErrorDTO>() { new ErrorDTO { ErrorEn = e.Message, ErrorAr = "هناك مشكلة في حذف هذة الفئة" } }
                };
            }
        }

        public async Task<ErrorsDTO> updateCategory(UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var category = await getById(categoryDTO.Id);
                category.Name = categoryDTO.name;
                category.Description = categoryDTO.description;
                category.ModifiedAt = DateTime.Now;
                _db.categories.Update(category);
                await _db.SaveChangesAsync();
                return new ErrorsDTO() { IsValid = true, Errors = new List<ErrorDTO>() };

            }
            catch (Exception e)
            {
                return new ErrorsDTO()
                {
                    IsValid = false,
                    Errors = new List<ErrorDTO>() { new ErrorDTO { ErrorEn = e.Message, ErrorAr = "هناك مشكلة في تعديل هذة الفئة" } }
                };
            }
        }
    }
}
