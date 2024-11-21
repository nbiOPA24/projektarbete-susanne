using System.Text.Json; // För JsonSerializer
using System.Text.Json.Serialization; // För avancerade JSON-funktioner, som attribut

class Program
{
    //LanguageQuestion languageQuestion = new LanguageQuestion(); --> används inte i klassen Program? ta bort?  
    //Mainmetoden håller meny för de val som användaren gör initialt i programmet - väljer vad hen vill öva på. 
    
    public static void Main()
    {           
        HandleUser myhandleUser = new HandleUser(); 
        var users = new List<User>();
         myhandleUser.DefaultUser(users);

        User currentUser = null;       
                 

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("Välkommen till elev-Quiz!");
        Console.WriteLine("Välj det ämne som du vill öva på.");
        Console.WriteLine("Väljer du att logga in sparas dina poäng, och du kan se vad dina poäng motsvarar i betyg");
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("Vill du logga in, eller fortsätta utan att vara inloggad användare?");
        Console.WriteLine();
        Console.WriteLine("Klicka på tangenten [J] på ditt tangentbord för att logga in eller skapa en ny användare.");
        Console.WriteLine("Vill du fortsätta utan att vara inloggad, klicka på [N]");
        string userInput = Console.ReadLine();
        if(userInput.ToLower() == "j")
        {
            currentUser = myhandleUser.LogInMenu(users);
        }
        else if(currentUser == null)
        {
            Console.WriteLine("Du fortsätter som gäst, och kommer inte att spara dina poäng");            
        }       
        
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Välj ett ämne:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Svenska");
            Console.WriteLine("2. Engelska");
            Console.WriteLine("3. Samhällsorienterande ämnen");
            Console.WriteLine("4. Matte");
            Console.WriteLine("5. Naturkunskap ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("6. Se vilket betyg dina poäng motsvarar");
            Console.WriteLine("7. Se samtliga frågor");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine("9. Admin - skapa frågor.");
            Console.WriteLine();
            string choice = Console.ReadLine();

            List<Question> subjectQuestions = null;            
            string selectedSubject = ""; //Sätter ett initialvärde för variabeln, då det annars ger kompilator-fel. 
            
            switch (choice)
            {
                case "1":
                    
                    Console.WriteLine("Svenska");
                    selectedSubject = "SV";
                    //subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject); //Här bestäms vilka frågor som ska hämtas från filen till listan subjectQuestions
                    break;
                                                     
                
                case "2":
                    Console.WriteLine("EN"); 
                    LanguageQuestion.LanguageQuestionMenu();                  
                    continue;

                case "3":
                    Console.WriteLine("Samhällsorienterande ämnen");
                    selectedSubject = "SO"; 
                    //subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject); 
                    break;

                case "4":
                    Console.WriteLine("Matte");
                    Mathematics myMathematics = new Mathematics();
                    myMathematics.MathMenu();           
                    continue; //Behöver sättas till continue för att jag inte använder mig av ämnen från questions-filen. 

                case "5":
                    Console.WriteLine("Naturkunskap");
                    selectedSubject = "NA"; 
                    //subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject);
                              
                    break;

                case "6":
                    Console.WriteLine("Se dina poäng"); //Logik för att räkna poäng 
                    foreach(var subject in currentUser.Score)
                    {
                        Console.WriteLine($"{subject.Key}: {subject.Value}");
                    }               
                    continue;

                case "7":
                    Console.WriteLine("Adminklass:");//Här ska man kunna lägga in frågor och ev även kunna se olika elevers poäng!                  
                    break;

                case "8":
                    Console.WriteLine("Avslutar programmet.");
                    isRunning = false;
                    break;
                case "9":
                    Console.WriteLine("Admin - Skapa nya frågor.");
                    Adminklass.AdminMenu();
                    
                    break;


                default:
                    Console.WriteLine("Felaktig inmatning");
                    continue;
            }

            if (subjectQuestions != null && subjectQuestions.Count > 0)
                {
                    HandleQuiz.ChooseQuestionMenu(subjectQuestions, selectedSubject, currentUser);
                }
                else if (subjectQuestions != null && subjectQuestions.Count == 0)
                {
                    Console.WriteLine("Inga frågor hittades för det valda ämnet");
                }
                else
                {
                    Console.WriteLine("Tack för idag!");
                }
            
        }
        
    }
    
 
}