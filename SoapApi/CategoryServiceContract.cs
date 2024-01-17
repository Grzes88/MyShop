using System.ServiceModel;

namespace SoapApi;

public class CategoryServiceContract
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        Task<IEnumerable<Category>> GetAllCategoryAsync();
    }

    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var categories = new List<Category>
            {
                new Category(Guid.NewGuid(), "warzywa"),
                new Category(Guid.NewGuid(), "owoce"),
                new Category(Guid.NewGuid(), "mięso"),
                new Category(Guid.NewGuid(), "ryby")
            };

            return categories;
        }
    }
}
