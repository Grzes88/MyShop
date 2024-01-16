using System.ServiceModel;

namespace SoapApi;

public class CategoryServiceContract
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
    }

    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = new List<Category>
            {
                new Category(1, "warzywa"),
                new Category(2, "owoce"),
                new Category(3, "mięso"),
                new Category(4, "ryby")
            };

            var categoryDtos = categories.Select(x => new CategoryDto(x.Id, x.Name));

            return categoryDtos;
        }
    }
}
