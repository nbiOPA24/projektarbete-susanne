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
}






    