
using Main_App.Models;

namespace Main_App.Interfaces;

//Filen ska kunna spara ned en lista till filen samt kunna hämta lista från fil. Har lagt in två metoder i interfacet. Skapar själva funktionaliteten i FileService.
public interface IFileService
{
    public ResponseResult<string> SaveToFile(string content); //Spara produkter till fil

    public ResponseResult<string>GetFromFile(); //Läser in produkter från tidigare sparad text fil
}
