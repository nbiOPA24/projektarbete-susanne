public class LanguageQuestion //Separat klass för språk, då övningarna inte kommer att genereras från json-filen. 
{
    private Dictionary<string, string> glossary = new Dictionary<string, string>(); //lista av typen dictionary, som sparar glosor på svenska/engelska
    public List<string> wrongAnswers = new List<string>(); //Lista för fel svar, som används för att användren ska kunna öva på de frågor där hen svarat fel. 

    public LanguageQuestion()//Konstruktor som innehåller metod för hårdkodade glosor
    {
        DefaultGlossary();
    }   

    public void DefaultGlossary() //Metod för Dictionary med hårdkodade frågor
    {
        glossary["Forskning "] = "Research";
        glossary["Utveckling "] = "Development";
        glossary["Möjlighet "] = "Opportunity";
        glossary["Erfarenhet"] = "Experience";
        /*glossary["Framtid "] = "Future";
        glossary["Samhälle "] = "Society";
        glossary["Kultur "] = "Culture";
        glossary["Diskussion "] = "Discussion";
        glossary["Engagemang "] = "Engagement";
        glossary["Fråga "] = "Question";
        glossary["Tolerans "] = "Tolerance";
        glossary["Förändring "] = "Change"; */             

    } 
    
    public static void LanguageQuestionMenu() //Meny för språkövningar (nu enbart för engelska språket...) som anropas från main-metoden.
    {
        bool isRunning = true;
        LanguageQuestion languageQuestions = new LanguageQuestion();
        
        while(isRunning)
        {
            
            System.Console.WriteLine("Gör ett av följande val: ");
            System.Console.WriteLine("1. Lägg till glosor till ordboken");
            System.Console.WriteLine("2. Öva på glosor");
            System.Console.WriteLine("3. Lägg till ord i meningar");
            System.Console.WriteLine("4. Se samtliga frågor"); //Admin behörighet?
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
                    languageQuestions.PracticeGlossary();
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
                    languageQuestions.PrintGlossary();//Skriver ut frågor - både hårdkodade och egentillagda
                    
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

    public void PracticeGlossary() //Metod för användaren att öva på de glosor som finns i listan. Ev. slumpa fram 10 glosor?
    {     
        
        foreach(var gloss in glossary)
        {
            System.Console.WriteLine($"Skriv ordet '{gloss.Key}' på engelska");
            string userAnswer = Console.ReadLine();

            if(userAnswer.Equals(gloss.Value,StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("Du svarade rätt!"); //Lägg till logik för att lägga till poäng i lista!
            }
            else
            {
                System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {gloss.Value}"); //Lägg till logik för attt lägga i övrningslista!
                wrongAnswers.Add(gloss.Key);
                
            }
        }

        if(wrongAnswers.Count > 0)
        {
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("Samtliga glosor besvarade");
            System.Console.Write("Vill du öva på de frågor där du svarat fel?");
            string userAnswer = Console.ReadLine();

            if(userAnswer.ToLower() == "j")
            {
                PracticeWrongAnswers();
            }
            /*else
            {
                System.Console.WriteLine("Bra jobbat med glosorna! Återgå till tidigare meny.");
            }*/
        }      
    }   
    public void PracticeWrongAnswers()
    {
        foreach(var q in wrongAnswers)
        {
            System.Console.WriteLine($"Skriv orden {q} på engelska");
            string userAnswer = Console.ReadLine();

            if(userAnswer.Equals(glossary[q], StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("Bra jobbat! Denna gång svarade du rätt!");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine($"Ditt svar är tyvärr fel. Rätt svar är {glossary[q]}");
                System.Console.WriteLine();
            }
        }
        wrongAnswers.Clear();      
    } 
}






    