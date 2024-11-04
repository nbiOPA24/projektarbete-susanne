using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Data;

public class Subject
{   public List<Question> wrongAnswer = new List<Question>();
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
        while(true)
        {
            Console.WriteLine("Välj typ av fråga:");
            Console.WriteLine("1. Fritextfråga");
            Console.WriteLine("2. Flervalsfråga");
            Console.WriteLine("3. Öva på frågor där du svarat fel");
            Console.WriteLine("4. Återgå till huvudmenyn");
            string input = Console.ReadLine();
            
            if (input == "1")
            {
                FritextFråga();                
            }
            
            else if(input == "2")
            {
                FlervalsFråga();
            }
            else if(input == "3")
            {
                System.Console.WriteLine("Öva på de frågor där du svara");
            }
            else if(input == "4")
            {
                System.Console.WriteLine("Återgår till huvudmenyn");
                break;
            }
            else
            {
                System.Console.WriteLine("Ogiltig inmatning");
            }

        }
        
    }   
    
    private void FritextFråga()
    {       
        var rnd = new Random();
        int numOfQuestions = Math.Min(10, Questions.Count);

        for(int i = 0; i < numOfQuestions; i++)
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
                wrongAnswer.Add(rndQuestion);                
            }
        }
        System.Console.WriteLine("Inga frågor kvar att besvara.");            
    }

    private void FlervalsFråga()
    {
        List<Question> mulitChoiceQuestions = Questions.FindAll(q => q.Options != null && q.Options.Count > 0); //Lista som filtrerar fram flervalsfrågor. Onödig???
        if(mulitChoiceQuestions.Count == 0)
        {
            System.Console.WriteLine("Det saknas flervalsfrågor i ämnet att besvara");
            return;
        }       
        
        var rnd = new Random();
        int numOfQuestions = Math.Min(5, Questions.Count);
        for(int i = 0; i < numOfQuestions; i++)
        {
            var rndQuestion = mulitChoiceQuestions[rnd.Next(mulitChoiceQuestions.Count)];
            mulitChoiceQuestions.Remove(rndQuestion);

            System.Console.WriteLine($"{rndQuestion.Quest}");
            int optionNum = 1;
            foreach(var option in rndQuestion.Options)
            {                
                System.Console.WriteLine($"{optionNum}. {option}");
                optionNum ++;
                
            }

            System.Console.WriteLine("Ange siffran framför rätt svar: ");
            int input;
            if(int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= rndQuestion.Options.Count)
            {
                string optionInput = rndQuestion.Options[input -1].Trim().TrimEnd('.');
                string correctAnswer = rndQuestion.Answer.Trim().TrimEnd('.');
                
                if(optionInput.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))                
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Du svarade rätt!"); //Poäng ska läggas till i en lista för respektive ämne
                    System.Console.WriteLine(".........................");
                }
                
                else
                {
                    System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar var {rndQuestion.Answer}");//Frågan ska läggas till i en lista för nytt försök
                    wrongAnswer.Add(rndQuestion);  
                    System.Console.WriteLine(".........................");              
                }
            }
            else
            {
                System.Console.WriteLine("Ogiltigt val. Försök igen!");
            }

        }
        System.Console.WriteLine("Inga fler flervalsfrågor att besvara");
        System.Console.WriteLine("*************************************");
        System.Console.WriteLine();
    }

    

}






    