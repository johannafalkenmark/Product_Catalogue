using Main_App.Models;

namespace Resources.Interfaces;
public interface IFileService
{
    public ResponseResult<string> SaveToFile(string content); 

    public ResponseResult<string> GetFromFile(); 
}

