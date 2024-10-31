using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

public class Subject
{
    string filePath = "questions.json";
    public List<Question> Questions {get; set; }
    public string Name {get; set; }

    public Subject(string name)
    {
        Name = name;
        Questions = new List<Question>(); 
    }   

    public virtual async Task LoadQuestionsAsync(string filePath)
    {
        using FileStream openStream = File.OpenRead(filePath);
        var allQuestions = await JsonSerializer.DeserializeAsync<List<Question>>(openStream);
        Questions = allQuestions.FindAll(quest => quest.Subject == Name);
        
     
    }
}
public class Svenska : Subject
{
    public List<Fritext> FritextQuestions {get; set;}
    
    public Svenska(string name)
    : base(name)
    {
        FritextQuestions = new List<Fritext>();
    }

    public override async Task LoadQuestionsAsync(string filePath)
    {
        using FileStream openStream = File.OpenRead(filePath);
        var allQuestions = await JsonSerializer.DeserializeAsync<List<Question>>(openStream);
        
        foreach(var question in allQuestions)
        {
            if (question.Subject == Name && question is Fritext fritextQuestion)
            {
                FritextQuestions.Add(fritextQuestion);
            }
        }
    }

    public async void ChooseTypeSV()
    {  
        Fritext fritext = new Fritext();
        string filePath = "questions.json";
        
        System.Console.WriteLine("Här väljer du typ av fråga: ");          
        System.Console.WriteLine("1. Fritextfråga");
        System.Console.WriteLine("2. Flervalsfråga");
        string input = Console.ReadLine();

        switch(input)
        {
            case "1":
            System.Console.WriteLine("Du valde fritextfråga");
            LoadQuestionsAsync(filePath); 
            
            fritext.AskQuestion();

            break;

            case "2":
            System.Console.WriteLine("Du valde flervalsfråga");
            break;

            case "3":
            System.Console.WriteLine("Återgår till huvudmenyn");
            break;

            default:
            System.Console.WriteLine("Ogiltig inmatning");
            break;
        }
    }
    
}




    