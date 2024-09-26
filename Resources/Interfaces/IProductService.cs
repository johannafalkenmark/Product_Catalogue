
//Specificerar här vilka metider som ska finnas i vår productservice. gör själva funktionalieteten i productservice sen


//Specificerar här vilka metider som ska finnas i vår productservice. gör själva funktionalieteten i productservice sen
using Main_App.Models;

namespace Resources.Interfaces;
//FRÅGA förklara TResult
public interface IProductService<T, TResult> where T : class where TResult : class
{
    public ResponseResult<TResult> AddProductToList(T product); //Ska kunna lägga till produkter till listan

    public ResponseResult<IEnumerable<TResult>> GetAllProducts(); //Visa alla produkter i listan med ID namn och pris (foreach-loop) - skapa funktionalitet i prodctservice

    public ResponseResult<TResult> RemoveProductFromListBasedOnID(string id); //Ta bort produkt från listan baserat på ID

    public ResponseResult<TResult> UpdateProductNameOrPriceBasedOnID(string id, T updateContact); //Uppdatera produkts namn och pris baserat på ID
}
