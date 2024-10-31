using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

public class Subject
{    
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
        if(allQuestions != null)
        {
            Questions = allQuestions.FindAll(quest => quest.Subject == Name);
        }
        else
        {
            System.Console.WriteLine("Filen med frågorna kunde inte läsas in.");
        }
    }
    public async Task ChooseType()
    {
        Console.WriteLine("Välj typ av fråga:");
        Console.WriteLine("1. Fritextfråga");
        Console.WriteLine("2. Flervalsfråga");
        string input = Console.ReadLine();
        bool isFlervalsFråga = input == "2";

        if (isFlervalsFråga)
        {
            Console.WriteLine("Flervalsfråga");
            // Logik för flervalsfråga
        }
        else
        {
            FritextFråga();
        }
    }   
    
    private void FritextFråga()
    {
        var rnd = new Random();
        while(Questions.Count > 0)
        {
            var rndQuestion = Questions[rnd.Next(Questions.Count)];
            Questions.Remove(rndQuestion);

            System.Console.WriteLine(rndQuestion.Quest);
            string userAnswer = Console.ReadLine();

            if(userAnswer.Equals(rndQuestion.Answer, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("Du svarade rätt!");//Poäng ska läggas till i en lista för respektive ämne
            }           

            else
            {
                System.Console.WriteLine("Ditt svar var tyvärr fel");//Frågan ska läggas till i en lista för nytt försök
            }
        }
        System.Console.WriteLine("Inga frågor inom ämnet kvar.");     
       
    }
}






    