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

        // Hämta slumpmässig fråga
        if (Questions.Count > 0)
        {
            var rnd = new Random();
            var rndQuestion = Questions[rnd.Next(Questions.Count)];

            if (isFlervalsFråga)
            {
                Console.WriteLine("Flervalsfråga");
                // Logik för flervalsfråga
            }
            else
            {
                FritextFråga(rndQuestion);
            }
        }
        else
        {
            Console.WriteLine("Inga frågor att svara på.");
        } 
    }   
    
    private void FritextFråga(Question question)
    {
        System.Console.WriteLine(question.Quest);
        string userAnswer = Console.ReadLine();
    
        if(userAnswer.Equals(question.Answer, StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("Du svarade rätt!"); //Poängen ska läggas till i en lista för ämnet SV. 
        }
        else
        {
            System.Console.WriteLine("Du svarade tyvärr fel"); //Frågan ska läggas till i en lista över fel svar, där användaren får försöka igen.
        }
    }
}






    