using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Question
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

    /*public static async Task<List<Question>> LoadQuestion(string filePath)
    {
        using FileStream openStream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<List<Question>>(openStream);
    }*/
}

public class Fritext : Question
{  
    public Fritext(string subject, string quest, string answer, int points) 
    : base(subject, quest, answer, points)
    {
    }

    public bool CheckAnswer(string userAnswer)
    {
        if(userAnswer.ToUpper() == Answer.ToUpper())
        
        return true;

        else
        {
            return false;
        }
    }

    public void AskQuestion()
    {
        System.Console.WriteLine(Quest);
        string userAnswer = Console.ReadLine();

        
        //Här saknas kod för att slumpa fram ex. fem frågor och skriva ut...
        if(CheckAnswer (userAnswer))
        {
            System.Console.WriteLine("Du svarade rätt!");//Logik i respektive ämne! Lägg till poäng till lista.
        }
        else
        {
            System.Console.WriteLine("Du svarade tyvärr fel."); //Logik i respektive ämne! Lägg till fråga till lista för att köra igen.
        }
    }      


}












