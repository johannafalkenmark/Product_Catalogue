

namespace Main_App.Models;

//Är denna alltid relevant - bör denna vara med - för testningens/felsökning skull eller?

public class ResponseResult<T> where T : class //T innebär att vi kan välja vad vi ska skicka tillbaka
{
    public bool Success { get; set; }

    public string ?Message { get; set; }

    public T? Result { get; set; }
}
