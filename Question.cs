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
    
    public string Subject {get; set;}   
    public string Quest {get; set;}    
    public string Answer {get; set;}   
    public List<string> Options {get; set; } //Lägger till för att frågorna ska kunna återanvändas till olika frågetyper!
    public int Points {get; set;}
    public List<string> Keywords {get; set;}//Lägger till för att fritextfrågorna ska funka även om anv inte skriver meningen helt rätt. 
   

    public Question(string subject, string quest, string answer, int points, List<string>? options = null, List<string>? keywords = null)//Sätter ett frågetecken efter string för att göra dem till nullable referenstyper
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





  












