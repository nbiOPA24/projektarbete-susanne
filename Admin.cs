class Adminklass
{
    /*static void ShowAllQuestions(List<Question> questions)
    {
        foreach(var question in questions)
        {
            System.Console.WriteLine($"Ämne: {question.Subject}, Fråga: {question.Quest}, Svar: {question.Answer}, Poäng: {question.Points} ");
        }
    }'*/


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
                Console.WriteLine("---Skapa ny flervalsfråga---");
                Question.CreateNewQuestion(questions);
            
               
                break;

                case "2":
                Console.WriteLine("---Skapa ny fritextfråga---");
                
                break;

                case "3":
                Console.WriteLine("");
                break;

                case "4":
                Console.WriteLine("---Visa alla frågor---");
                break;

                case "5":
                Console.WriteLine("Återgå till huvudmenyn");
                isRunning = false;
                break;

            }
        }
    }
}