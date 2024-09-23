//Implementera en funktion som sparar alla produkter i listan till en textfil. Filen ska innehålla varje produkts information och vara sparat i .json-format.
//Implementera en funktion som läser in produkter från en tidigare sparad textfil och lägger till dem i listan.

// Update: Lagt till interface för fileservice.


using Main_App.Interfaces;
using Main_App.Models;

namespace Main_App.Services;


internal class FileService : IFileService
{

    private readonly string _filePath; //HÄR skapar variabel för sökväg till filen

    public FileService(string filePath) //Innebär när vi gör instansering av fileservice kommer vi ange sökväg till _filePath som vi sen kan använda
    {
        _filePath = filePath;
    }




    //METOD Läsa från filen
    public ResponseResult<string> GetFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))  //Säger Om INTE filen existerer skicka tillbaka file not found
            { throw new FileNotFoundException("File not found."); }

            using var sr = new StreamReader(_filePath); //USING existerar endast i måsvinagrna sen raderas så ej tar upp minne
            var content = sr.ReadToEnd();
            
            return new ResponseResult<string> {Result = content,  Success = true };

        }
        catch (Exception ex)
        { 
        return new ResponseResult<string> { Success = false, Message = ex.Message };
        }
    }




    //METOD Spara/skriva till filen: //SW är själva syntaxen?


    public ResponseResult<string> SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath, false);
            sw.WriteLine(content);
            return new ResponseResult<string> { Success = true };

        }
        catch (Exception ex)
        {
            return new ResponseResult<string>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }
}
