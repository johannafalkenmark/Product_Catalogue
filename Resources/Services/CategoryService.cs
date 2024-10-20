using Main_App.Models;

namespace Resources.Services;

public class CategoryService
{

    public ResponseResult<IEnumerable<Category>> ShowAllCategories()
    {
        List<Category> categories = new List<Category>();

        categories.Add(new Category("LOCAL FRUIT", "1"));

        categories.Add(new Category("EXOTIC FRUIT", "2"));


        return new ResponseResult<IEnumerable<Category>> { Success = true, Result = categories };

    }

}