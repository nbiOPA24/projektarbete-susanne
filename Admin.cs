using System.Runtime.CompilerServices;

public class Admin
{ 
    public static void AdminMenu()
    {
        List<Question> questions = new List<Question>();       
        bool isRunning = true;

        while(isRunning)
        {
            Console.WriteLine("---Vilken typ av fråga vill du skapa?");
            Console.WriteLine("1. Flervalsfråga");
            Console.WriteLine("2. Fritextfråga");
            Console.WriteLine("3. Annan fråga");
            Console.WriteLine("4. Visa alla frågor");
            Console.WriteLine("5. Återgå till huvudmeny");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                Console.WriteLine("---Skapa ny fråga---");
                CreateNewQMenu(questions);            
                         
                break; 

                case "3":
                Console.WriteLine("---Annan adminfunktion---");
                break;

                case "4":
                Console.WriteLine("---Visa alla frågor---");
                
                break;

                case "5":
                Console.WriteLine("---Återgå till huvudmenyn---");
                isRunning = false;
                break;

            }
        }
    }
      public static void CreateNewQMenu(List<Question> questions)
    {  
        bool isRunning = true; 
        while(isRunning)
        {
            Console.WriteLine("Vilken typ av fråga vill du skapa?");
            Console.WriteLine("1. Fritextfråga");
            Console.WriteLine("2. Flevalsfråga");
            Console.WriteLine("3. Annan fråga");
            Console.WriteLine("4. Återgå till huvumenyn");
            string input = Console.ReadLine();

            Console.Write("Skriv in siffran som motsvarar det ämne frågan tillhör (SV = 0, NA = 1, SO = 2): ");
            Subject subjectType = (Subject)int.Parse(Console.ReadLine());
            Console.Write("Skriv in frågan: ");
            string quest = Console.ReadLine();
            Console.Write("Skriv in det rätta svaret: ");
            string correctAnswer = Console.ReadLine();
            Console.Write("Skriv in antal poäng som frågan kan ge: ");
            int points = int.Parse(Console.ReadLine());

            if(input == "1")
            {
                questions.Add(new TextQuestion(subjectType, quest, correctAnswer, points));
            }

            else if(input == "2")
            {
                Console.WriteLine("Ange alternativen, separerade med komma-tecken");
                List<string> options = Console.ReadLine().Split(',').ToList();
                questions.Add(new MultipleChoiceQuestion(subjectType, quest, options, correctAnswer, points));
            }

            Console.WriteLine("Frågan tillagd.");
            Console.WriteLine("Vill du lägga till ytterligare frågor? [J] / [N]");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "j")
            {
                continue;
            }
            else
            {
                Console.WriteLine("Återgår till huvudmenyn");//Adminmenyn?
                break; 
            }
        }
    }
}

 
    

