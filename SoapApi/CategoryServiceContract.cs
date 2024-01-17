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
                new Category(new Guid(), "warzywa"),
                new Category(new Guid(), "owoce"),
                new Category(new Guid(), "mięso"),
                new Category(new Guid(), "ryby")
            };

            return categories.Select(x => new Category(x.Id, x.Name));
        }
    }
}
