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
    [JsonPropertyName("Options")]
    public List<string> Options {get; set; } //Lägger till för att frågorna ska kunna återanvändas till olika frågetyper!
    [JsonPropertyName("Points")]
    public int Points {get; set;}
   

    public Question(string subject, string quest, string answer, int points, List<string> options = null)
    {
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;  
        Options = options ?? new List<string>();    
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

public class Fritext : Question
{  
    
    public Fritext() : base("", "", "", 0) // Tomma strängar och 0 som standardvärden
    {
    }
    
    public Fritext(string subject, string quest, string answer, int points) 
    : base(subject, quest, answer, points)
    {
    }

 

}












