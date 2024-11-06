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
                PracticeWrongQuestions();
               
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

    public void FlervalsFråga()
    {
        List<Question> mulitChoiceQuestions = Questions.FindAll(q => q.Options != null && q.Options.Count > 0);
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

    public void PracticeWrongQuestions() //Ny metod för att användaren ska kunna öva på frågorna som hen svarat fel på. 
    {
        if (wrongAnswer.Count == 0)
        {
            System.Console.WriteLine("Det finns inga frågor att öva på. Bra jobbat!");

        }

        System.Console.WriteLine("Öva på de frågor där du svarat fel: ");
        foreach(var question in wrongAnswer)
        {
            System.Console.WriteLine(question.Quest);

            if(question.Options != null && question.Options.Count > 0) //Kontrollerar om det är en flervalsfråga! Om nej, gå till else-satsen. 
            {
                for(int i = 0; i < question.Options.Count; i++)
                {
                    System.Console.WriteLine($"{i + 1}. {question.Quest[i]}");
                    System.Console.WriteLine("Ange siffran som motsvarar rätt svar: ");
                    int input;

                    if(int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= question.Options.Count)
                    {
                        string optionInput = question.Options[input - 1].Trim().TrimEnd('.');
                        if(optionInput.Equals(question.Answer.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            System.Console.WriteLine("Den här gången svarade du rätt. Bra jobbat!");
                            wrongAnswer.Remove(question);
                            System.Console.WriteLine("------------------------");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}. Försök igen!");
                        System.Console.WriteLine("------------------------------");
                    }                                         
                }
            }
            else
            {
                System.Console.WriteLine("Skriv ditt svar: ");
                string userAnswer = Console.ReadLine();

                if(question.CheckAnswer(userAnswer))
                {
                    System.Console.WriteLine("Den här gången svarade du rätt. Bra jobbat!");
                    wrongAnswer.Remove(question);
                    System.Console.WriteLine("------------------------");
                }
                else
                {
                    System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}. Försök igen!");
                    System.Console.WriteLine("------------------------------");
                } 
            }
        }
    } 
}






    