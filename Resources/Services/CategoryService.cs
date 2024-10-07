using Main_App.Models;

namespace Main_App.Services;

public static class CategoryService
{

    public static ResponseResult<IEnumerable<Category>> GetAllCategories()
    {
        List<Category> categories = new List<Category>();

        categories.Add(new Category("LOCAL FRUIT", "1")); 
        
        categories.Add(new Category("EXOTIC FRUIT", "2")); 
       

        return new ResponseResult<IEnumerable<Category>> { Success = true, Result = categories};

    }

}