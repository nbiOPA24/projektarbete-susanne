using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class Question
{   
    [JsonPropertyName("Subject")]
    public string Subject {get; set;}
    [JsonPropertyName("Quest")]
    public string Quest {get; set;}
    [JsonPropertyName("Answer")]
    public string Answer {get; set;}
    [JsonPropertyName("Points")]
    public int Points {get; set;}

    public Question(string subject, string quest, string answer, int points)
    {
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;      
    }

    public static async Task<List<Question>> LoadQuestion(string filePath)
    {
        using FileStream openStream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<Question>>(openStream);
    }
}










