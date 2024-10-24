class Admin
{
    private HandleQuestion handleQuestion = new HandleQuestion(); //Skapar en instans för att kunna hantera frågor från klassen HandleQuestion!
    private TestaStreamReader testaStreamReader;

    public void Menu()
    {
        System.Console.WriteLine("1. Lägg till en fråga ");        
        System.Console.WriteLine("2. Se samtliga frågor "); 
        System.Console.WriteLine("3.Se hårdkodade frågor ");         
        System.Console.WriteLine("4.Ta bort en fråga");        
        System.Console.WriteLine("5. Återgå till huvudmeny");
        string input = Console.ReadLine();

        switch(input)
        {
            case "1": 
            CreateNewQuestion();
            break;

            case "2": 
            ShowQuestions(); //Visar de egenskapade frågorna
            break;

            case "3":  //Visar de hårdkodade frågorna
            DefaultQuestions(); 
            break;

            case "4": 
            System.Console.WriteLine(); //EJ KLART!
            break;

            case "5": 
            System.Console.WriteLine(); //EJ KLART!
            break;
        }        
    }
        
   

    public void CreateNewQuestion() //Ny metod i adminklassen, för att kunna skapa nya frågor
    {
        handleQuestion.CreateAndAddQuestion();
    }

    public void ShowQuestions() //En metod för att kunna se samtliga frågor
    {
        Console.WriteLine("Lista över frågor:");
        foreach (var question in handleQuestion.questions)
        {
            Console.WriteLine($"Ämne: {question.Subject}, Fråga: {question.Quest}, Svar: {question.Answer}, Poäng: {question.Points}");
                       
        }        
    }

    public void DefaultQuestions()
    {   
        testaStreamReader = new TestaStreamReader();
        TestaStreamReader.TestaSR(handleQuestion);
        
       
    } 
    
    
        
    
}

