using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


public class Question //Klassen ändras, så den kan vara en subklass för olika typer av frågealternativ
{ 
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Quest { get; set; }
    public string Answer { get; set; }
    public int Points { get; set; }
    public List<string> Options { get; set; }
    public List<string> Keywords { get; set; }

    public static List<Question> AllQuestions { get; set; } = new List<Question>();

    public Question() {}

    public virtual bool CheckAnswer(string userAnswer)
    {
        return userAnswer.ToUpper() == Answer.ToUpper();
    }
    
    public static async Task LoadQuestionsFromFile(string filePath) //Metoden LoadQuestions ändras från en virtuell metod till en statisk metod.Detta för att filen egentligen bara behöver läsas in en gång och sedan filtreras i respektive frågetyp/ämnestyp. 
    {
        try
        {
            System.Console.WriteLine("Påbörjar inläsning av filen...");
            string json = await File.ReadAllTextAsync(filePath);
            AllQuestions = JsonSerializer.Deserialize<List<Question>>(json, new JsonSerializerOptions
            {
                Converters = {new QuestionConverter()}
            });
            System.Console.WriteLine($"Antal inlästa frågor: {AllQuestions.Count}");
           
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Fel vid inläsning av JSON-filen: {ex.Message}");
        }       
    }
   
}

public class QuestionConverter : JsonConverter<Question>
{
    public override Question Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;

            // Kolla om vi har en "Options" för att avgöra om det är en MultipleChoiceQuestion
            if (root.TryGetProperty("Options", out _))
            {
                // Deserialisera som MultipleChoiceQuestion
                return JsonSerializer.Deserialize<MultipleChoiceQuestion>(root.GetRawText());
            }

            // Annars deserialisera som TextQuestion
            return JsonSerializer.Deserialize<TextQuestion>(root.GetRawText());
        }
    }

    public override void Write(Utf8JsonWriter writer, Question value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}


public class MultipleChoiceQuestion : Question //Subklass för flervalsfrågor. 
{
    public List<string> Options {get; set;}
    
    public MultipleChoiceQuestion (){}
    public MultipleChoiceQuestion(string name, string subject, string quest, string answer, int points, List<string> options)
    {
        Name = name;
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;
        Options = options;
    }

    public override bool CheckAnswer(string userAnswer)
    {
        return string.Equals(userAnswer.Trim(), Answer.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}

public class TextQuestion : Question //Subklass för fritextfrågor
{
    public List<string> Keywords { get; set; }

    public TextQuestion() { }

    public TextQuestion(string name, string subject, string quest, string answer, int points, List<string> keywords)
    {
        Name = name;
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;
        Keywords = keywords;
    }

    public override bool CheckAnswer(string userAnswer)
    {
        return Keywords.Any(keyword => userAnswer.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}





  












