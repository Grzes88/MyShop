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
                new Category(1, "warzywa"),
                new Category(2, "owoce"),
                new Category(3, "mięso"),
                new Category(4, "ryby")
            };

            return categories.Select(x => new Category(x.Id, x.Name));
        }
    }
}
