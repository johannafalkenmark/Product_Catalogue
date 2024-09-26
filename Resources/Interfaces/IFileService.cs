using Main_App.Models;

namespace Resources.Interfaces;
public interface IFileService
{
    public ResponseResult<string> SaveToFile(string content); //Spara produkter till fil

    public ResponseResult<string> GetFromFile(); //Läser in produkter från tidigare sparad text fil
}
