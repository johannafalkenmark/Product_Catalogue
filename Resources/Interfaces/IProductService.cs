using Main_App.Models;

namespace Resources.Interfaces;

public interface IProductService<T, TResult> where T : class where TResult : class
{
    public ResponseResult<TResult> AddProductToList(T product);

    public ResponseResult<Fruit> GetProductFromName(string Name);
    public ResponseResult<IEnumerable<TResult>> GetAllProducts(); 

    public ResponseResult<TResult> GetProduct(string id); 

    public ResponseResult<TResult> DeleteProduct(string id); 
    public ResponseResult<IEnumerable<TResult>> AddProductsFromFile();
    public ResponseResult<TResult> SaveProductsToFile();
}
