using Main_App.Models;
using Resources.Interfaces;

namespace Resources.Services;


public class FileService : IFileService
{

    private readonly string _filePath; //HÄR skapar variabel för sökväg till filen

    public FileService(string filePath) //Innebär när vi gör instansering av fileservice kommer vi ange sökväg till _filePath som vi sen kan använda
    {
        _filePath = filePath;
    }


    public ResponseResult<string> GetFromFile()
    {
        try
        {
            if (File.Exists(_filePath))  
            {

                using var sr = new StreamReader(_filePath); 
                var content = sr.ReadToEnd();

                return new ResponseResult<string> { Result = content, Success = true };
            }
        }
        catch (Exception ex)
        {
            return new ResponseResult<string> { Success = false, Message = ex.Message };
        }
        return null!;
    }


    public ResponseResult<string> SaveToFile(string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath);
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
