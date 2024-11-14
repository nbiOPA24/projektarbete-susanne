using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using Microsoft.VisualBasic;

//En klass som innehåller en lista för frågor och en lista för felaktiga svar. 
//Innehåller även kod för att ladda Json-filen till programmet.  
public class Subject
{   
    public string Name {get; set; }
    public List<Question> score = new List<Question>();//Ändra till dictionary istället?
    public List<Question> wrongAnswer = new List<Question>();
    //public List<Question> Questions {get; set; }
    

    public Subject(string name)
    {
        Name = name;        
    }   

    public List<Question> GetQuestionsForSubject()
    {
        return Question.AllQuestions.Where(q => q.Subject == Name).ToList();
    }
    
   
    /*private void FritextFråga() //Metod för fritextfråga - Flytta till filen Questions????
    {       
        var rnd = new Random();
        int numOfQuestions = Math.Min(5, Questions.Count);

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
            else if(rndQuestion.Keywords != null && rndQuestion.Keywords.Any(keyword => userAnswer.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)) 
            {
                System.Console.WriteLine("Ditt svar innehåller ett eller flera nyckelord. Rätt svar!");
            }      
            else
            {
                System.Console.WriteLine("Ditt svar var tyvärr fel");//Frågan läggs till i en lista för fel svar, som används när anv vill öva på frågorna igen. 
                wrongAnswer.Add(rndQuestion);                
            }
        }
        System.Console.WriteLine("Inga frågor kvar att besvara.");            
    }
   
/*
    public void FlervalsFråga() //Metod för flervalsfråga - Flytta till filen Questions?
    {
        List<Question> mulitChoiceQuestions = Questions.FindAll(q => q.Options != null && q.Options.Count > 0);
        if(mulitChoiceQuestions.Count == 0)
        {
            System.Console.WriteLine("Det saknas flervalsfrågor i ämnet att besvara");
            return;        }       
        
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

            System.Console.WriteLine("---Ange siffran framför rätt svar---");
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
                    score.Add(rndQuestion);
                }
                
                else
                {
                    System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar var {rndQuestion.Answer}");//Frågan läggs till i en lista för nytt försök
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

    public void PracticeWrongQuestions() //Metod för att användaren ska kunna öva på frågorna som hen svarat fel på. 
    {
        if (wrongAnswer.Count == 0)
        {
            System.Console.WriteLine("Det finns inga frågor att öva på. Bra jobbat!");
            return;
        }

        System.Console.WriteLine("-------------------------------------");
        System.Console.WriteLine("Öva på de frågor som du svarat fel på");
        int index = 0;
        while (index < wrongAnswer.Count)
        {
            var rndQuestion = wrongAnswer[index]; //indexering gör itereringen i listan wrongAnswer mer flexibel. Foreach-loopen funkade inte. 
            System.Console.WriteLine($"{rndQuestion.Quest}");

            if(rndQuestion.Options != null && rndQuestion.Options.Count > 0)
            {
                for (int i = 0; i < rndQuestion.Options.Count; i++)
                {
                    System.Console.WriteLine($"{i + 1}. {rndQuestion.Options[i]}");
                }

                System.Console.WriteLine("---Skriv siffran framför det rätta alternativet---");
                int userInput;

                if(int.TryParse(Console.ReadLine(), out userInput) && userInput > 0 && userInput <= rndQuestion.Options.Count)
                {
                    var userChoice = rndQuestion.Options[userInput - 1].Trim().TrimEnd('.');
                    if(userChoice.Equals(rndQuestion.Answer.Trim().TrimEnd('.'), StringComparison.OrdinalIgnoreCase))
                    {
                        System.Console.WriteLine("Den här gången svarade du rätt. Bra jobbat!");
                        System.Console.WriteLine();
                        wrongAnswer.RemoveAt(index);
                    }
                    else
                    {
                        System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {rndQuestion.Answer}.");
                        index++;
                    }                  
                }
                else
                {
                    System.Console.WriteLine("Ogiltigt val. Försök igen!");
                }
            }
            else //blir else if när ytterligare frågor tillkommer
            {
                System.Console.Write("Skriv in ditt svar: ");
                string userAnswer = Console.ReadLine();

                if(rndQuestion.CheckAnswer(userAnswer))
                {
                    System.Console.WriteLine("Den här gången svarade du rätt. Bra jobbat!");
                    System.Console.WriteLine();
                    wrongAnswer.RemoveAt(index);
                }
                else
                {
                    System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {rndQuestion.Answer}.");
                    index++;
                } 
            }
            if (index >= wrongAnswer.Count)
            {
                System.Console.WriteLine("----------------------------");
                System.Console.WriteLine("Alla frågor är nu besvarade!");
            }
        }
    } */
    
}

