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
public class Subject
{   public List<Question> wrongAnswer = new List<Question>();
    public List<Question> Questions {get; set; }
    public string Name {get; set; }

    public Subject(string name)
    {
        Name = name;
        Questions = new List<Question>(); 
    }   

    public virtual async Task LoadQuestionsAsync(string filePath) //Kod för att ladda jsonfilen till programmet. Ändra den här till olika frågor?
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
    
    private void FritextFråga() //Metod för fritextfråga - Flytta till filen Questions????
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
                System.Console.WriteLine("Ditt svar var tyvärr fel");//Frågan ska läggas till i en lista för nytt försök
                wrongAnswer.Add(rndQuestion);                
            }
        }
        System.Console.WriteLine("Inga frågor kvar att besvara.");            
    }

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

                System.Console.WriteLine("Skriv siffran framför det rätta alternativet");
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
                System.Console.WriteLine("Alla frågor är nu besvarade!");
            }
        }
    } 
    
}

public class LanguageQuestion //Separat klass för språk, då övningarna inte kommer att genereras från json-filen. 
{
    private Dictionary<string, string> glossary = new Dictionary<string, string>(); //lista av typen dictionary, som sparar glosor på svenska/engelska

    public LanguageQuestion()//Konstruktor som innehåller metod för hårdkodade glosor
    {
        DefaultGlossary();
    }   

    public void DefaultGlossary() //Dictionary med hårdkodade frågor
    {
        glossary["Forskning "] = "Research";
        glossary["Utveckling "] = "Development";
        glossary["Möjlighet "] = "Opportunity";
        glossary["Erfarenhet"] = "Experience";
        glossary["Framtid "] = "Future";
        glossary["Samhälle "] = "Society";
        glossary["Kultur "] = "Culture";
        glossary["Diskussion "] = "Discussion";
        glossary["Engagemang "] = "Engagement";
        glossary["Fråga "] = "Question";
        glossary["Tolerans "] = "Tolerance";
        glossary["Förändring "] = "Change";               

    } 
    
    public static void LanguageQuestionMenu() //Meny för språkövningar (nu enbart engelska) som anropas från main-metoden.
    {
        bool isRunning = true;
        LanguageQuestion languageQuestions = new LanguageQuestion();
        
        while(isRunning)
        {
            
            System.Console.WriteLine("Gör ett av följande val: ");
            System.Console.WriteLine("1. Lägg till glosor till ordboken");
            System.Console.WriteLine("2. Öva på glosor");
            System.Console.WriteLine("3. Lägg till ord i meningar");
            System.Console.WriteLine("4. Se hårdkodade frågor");
            System.Console.WriteLine("5. Återgå till hvudmenyn");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                {
                    System.Console.WriteLine();
                    languageQuestions.GlossaryAddWord(); //Här återgår jag till ChooseType, vilket jag inte vill. VARFÖR???
                    break;
                }
                case "2":
                {
                    System.Console.WriteLine("---Öva på glosor---");
                    break;
                }
                 case "3":
                {
                    System.Console.WriteLine("---Ersätt ord i meningar---");
                    break;
                }
                case "4":
                {
                    System.Console.WriteLine(); 
                    languageQuestions.PrintGlossary();
                    
                    break;
                }
                case "5":
                {
                    System.Console.WriteLine("---Återgå till hvudmenyn---"); //Här återgår jag till ChooseType, vilket jag inte vill. ÄNDRA!
                    isRunning = false;
                    break;
                }
                default:
                {
                    System.Console.WriteLine("Felaktig inmatning! Ange en siffra mellan 1 och 4.");//Kan behöva ändras om ytterligare alternativ tillkommer. 
                    break;
                }
            }
        }
    }
    public void GlossaryAddWord()//En metod där användren själv kan lägga till glosor som hen vill öva på. 
    {  
        bool isRunning = true;
        while(isRunning)
        {
            System.Console.WriteLine("---Här lägger du till de glosor som du vill öva på--- ");
            System.Console.WriteLine();
        
            System.Console.Write("Skriv in ordet på svenska: ");
            string glossSwedish = Console.ReadLine();//lägger till det svenska ordet i dictionary!
            
            System.Console.Write("Skriv in ordet på engelska: ");
            string glossEnglish = Console.ReadLine(); // Lägg till det engelska ordet i dictionary!

            glossary[glossSwedish] = glossEnglish;
           
            System.Console.WriteLine($"Glosan {glossSwedish} - {glossEnglish} har lagts till i ordboken");
            System.Console.WriteLine("------------------------------------------------------------------");

            System.Console.WriteLine("Vill du lägga till ytterligare frågor? Klicka på tangenten [J]");
            string userInput = Console.ReadLine(); 

            if(userInput.ToLower() != "j")
            {
                break;
            }   
        }
    }

    public void PrintGlossary()
    {
        DefaultGlossary();
        {            
            foreach(var keyValuePair in glossary)
            System.Console.WriteLine($"Svenska: {keyValuePair.Key} // Engelska: {keyValuePair.Value}");            
        }     
    }      
}






    