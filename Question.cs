using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Question
{   
    //[JsonPropertyName("Subject")] Onödig kod? Kommenterar bort så länge!
    public string Subject {get; set;}
    //[JsonPropertyName("Quest")]
    public string Quest {get; set;}
    //[JsonPropertyName("Answer")]
    public string Answer {get; set;}
    //[JsonPropertyName("Options")]
    public List<string> Options {get; set; } //Lägger till för att frågorna ska kunna återanvändas till olika frågetyper!
    //[JsonPropertyName("Points")]
    public int Points {get; set;}
    //[JsonPropertyName("Keywords")] //Lägger till för att fritextfrågorna ska funka även om anv inte skriver meningen helt rätt. 
    public List<string> Keywords {get; set;}
   

    public Question(string subject, string quest, string answer, int points, List<string> options = null, List<string> keywords = null)
    {
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;  
        Options = options ?? new List<string>(); //Lista för options. ?? kontrollerar om värdet finns, annars skapas en tom sträng. 
        Keywords = keywords ?? new List<string>();   //Lista för heywords. ?? kontrollerar om värdet finns, annars skapas en tom sträng. 
    }
       public bool CheckAnswer(string userAnswer) //metod för att kontrollera om svaret är rätt. Ändra?????
    {
        if(userAnswer.ToUpper() == Answer.ToUpper())
        
        return true;

        else
        {
            return false;
        }        
    }

    

    
  
}




  












