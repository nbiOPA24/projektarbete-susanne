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
    public string Name {get; set;}
    public string Subject {get; set;}   
    public string Quest {get; set;}    
    public string Answer {get; set;}   
    public List<string> Options {get; set; } //Lägger till för att frågorna ska kunna återanvändas till olika frågetyper!
    public int Points {get; set;} //Variabel för poängräkning
    public List<string> Keywords {get; set;}//Lägger till för att fritextfrågorna ska funka även om anv inte skriver meningen helt rätt.
    public List<string> WrongAnswers {get; set;}
    public static List<Question> AllQuestions {get; set;} = new List<Question>();//Ändras till en statisk variabel för att kunna användas i den statiska metoden LoadQuestions
   

    public Question(string name, string subject, string quest, string answer, int points, List<string>? options = null, List<string>? keywords = null, List<string>? wrongAnswers = null, List<string>? questions = null)
    {
        Name = name;
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;  
        Options = options ?? new List<string>(); //Lista för options. ?? kontrollerar om värdet finns, annars skapas en tom sträng. 
        Keywords = keywords ?? new List<string>();   //Lista för keywords. ?? kontrollerar om värdet finns, annars skapas en tom sträng. 
        WrongAnswers = wrongAnswers ?? new List<string>();// Lista för fel svar. Används när anv ska fortsätta öva på de frågor där hen svarat fel.
        
    }
    public static async Task LoadQuestionsFromFile(string filePath) //Metoden LoadQuestions ändras från en virtuell metod till en statisk metod.Detta för att filen egentligen bara behöver läsas in en gång och sedan filtreras i respektive frågetyp/ämnestyp. 
    {
        using FileStream openStream = File.OpenRead(filePath);
        AllQuestions = await JsonSerializer.DeserializeAsync<List<Question>>(openStream)?? new List<Question>();
    }
       public virtual bool CheckAnswer(string userAnswer) //metod för att kontrollera om svaret är rätt. Ändras till en virtuell metod så varje subklass kan använda den på sitt sätt.
    {
        if(userAnswer.ToUpper() == Answer.ToUpper())
        
        return true;

        else
        {
            return false;
        }        
    } 

    
}





  












