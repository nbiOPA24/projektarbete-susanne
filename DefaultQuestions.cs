using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class DefaultQuestion
{
    [JsonPropertyName("question")]
    public string Text { get; set; }

    [JsonPropertyName("answer")]
    public string Answer { get; set; }

    [JsonPropertyName("difficulty")]
    public int Difficulty { get; set; }
}


public class HandleDefaultQuestions
{
    private readonly string filePath;

    public HandleDefaultQuestions(string filePath)
    {
        this.filePath = filePath;
    }

    public async Task<List<DefaultQuestion>>ReadQuestionsAsync()
    {
        using FileStream openStream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<DefaultQuestion>>(openStream);
    }
    

    public async Task WriteDefaultQuestionsAsync(List<DefaultQuestion> defaultQuestion)
    {
        using FileStream createStream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(createStream, defaultQuestion, new JsonSerializerOptions { WriteIndented = true });

    }
}




