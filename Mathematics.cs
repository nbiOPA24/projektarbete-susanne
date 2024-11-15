
using System.Diagnostics;
public class Mathematics //Klass för att träna matte
{
    public List<int> Factors {get; set;} //En lista för att kunna spara faktorer för den tabell användaren vill öva på.
       
    public Mathematics()
    {
        Factors = new List<int>(); //Initierar listan Factors i klassens konstruktor. 
    }
    public void MathMenu()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("Välj vad du vill öva på: ");
            Console.WriteLine("1. Multiplikationstabeller");
            Console.WriteLine("2. Multiplikationstabellen på tid");
            Console.WriteLine("3. Återgå till huvumeny");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                {
                    PracticeMultiplication();
                    break;
                }
                case "2":
                {
                    MultiplicationGame();                    
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Återgår till huvudmenyn");
                    isRunning = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Ogiltig inmatning");
                    break;
                }
               
            }

        }
        
    }

        //Metod för att skapa en multiplikationstabell för det tal som användaren har valt.
        //Metoden skapar en lista för multiplikationstabellen och anropas senare i koden. 
    public void MultiplicationTable() 
    {

        Factors.Clear(); //Rensar listan med tal inför varje omgång. 
        for(int i = 1; i <= 10; i++)
        {
            Factors.Add(i); //Skapar en lista med 10 nummer, som senare används som ett index. 
        }
    } 
    public void PracticeMultiplication()
    {
        Console.Write("Ange talet för den multiplikationstabell som du vill öva på: ");
        if(int.TryParse(Console.ReadLine(), out int chosenTable))
        {
            MultiplicationTable();
            Random rnd = new Random(); //Skapar en ny instans av klassen Random, för att kunna slumpa fram de tal användaren ska öva på

            while(Factors.Count > 0) //En loop som körs så länge det finns tal kvar i multiplikationstbellen att öva på
            {
                int rndIndex = rnd.Next(Factors.Count); //Slumpar fram index från listan Factors
                int factor = Factors[rndIndex]; //Hämtar faktorn från index
                int product = factor * chosenTable; //Beräknar produkten av rndIndex och faktorn

                System.Console.Write($"Vad är {factor} * {chosenTable}? ");
                if(int.TryParse(Console.ReadLine(), out int userAnswer))
                {
                    if(userAnswer == product)
                    {
                        Console.WriteLine("Du svarade rätt!");
                        Console.WriteLine();
                        Factors.RemoveAt(rndIndex);
                    }
                    else
                    {
                        System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {product}");
                    }
                }
                else
                {
                    System.Console.WriteLine("Felaktig inmatning. Ange svaret som ett heltal.");
                }
            }

            System.Console.WriteLine("Inga fler tal att beräkna. Bra jobbat!");

        }
        else
        {
            System.Console.WriteLine("Ogiltig inmatning. Skriv in ett heltal!");
        }

    } 
    //Metod för ett multiplikationsspel, där användaren svarar på olika tal på tid.
    //10 tal slumpas fram. Tidtagning börjar när användaren har klickat på enter. 
    //Efter att samtliga tal beräknats får användaren ett resultat, med tid och antal tal hen svarat fel på. 
     public void MultiplicationGame()
    {
        List<int> wrongAnswers = new List<int>();//Lista för felsvar. 
       
        Console.WriteLine("Välkommen till multiplikationsspelet!");
        Console.WriteLine("Här får du svara på 10 olika tal på tid");
        Console.WriteLine("Tiden startar när du får det första talet.");
        Console.WriteLine("När du svarat på alla tal får du den totala tiden.");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("------Klicka på enter för att börja spelet---------");
        Console.WriteLine("---------------------------------------------------");
        Console.ReadKey();       

        
        Random rnd = new Random();
        Stopwatch totalStopwatch = Stopwatch.StartNew();     // Startpunkt för tidtagning

       for(int i = 0; i < 10; i ++) //En for-loop, som kör 10 gånger
       {
            int factor1 = rnd.Next(1, 12);//Slumpar fram ett tal mellan 1 och 12
            int factor2 = rnd.Next(1, 12);
            int product = factor1 * factor2; //beräkning för rätt svar

            Console.Write($"Vad är {factor1} * {factor2}? "); //fråga till användare
            if(int.TryParse(Console.ReadLine(), out int userAnswer))
            {
                if(userAnswer == product)
                {
                    Console.WriteLine("Rätt svar!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ditt svar var tyvärr fel"); //Skriver ut om svaret var fel. 
                    Console.WriteLine();
                    wrongAnswers.Add(userAnswer); //Fel svar läggs till listan
                }                
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Ange ditt svar som ett heltal");
            }
       }
       totalStopwatch.Stop();
       Console.WriteLine($"Inga fler tal. Din totala tid blev: {totalStopwatch.Elapsed.TotalSeconds} sekunder."); //Skriver ut den totala tiden.
       Console.WriteLine($"Du svarade fel på {wrongAnswers.Count} frågor");//Skriver ut antal frågor användaren svarat fel på
       Console.WriteLine("Bra jobbat!"); 
    }       
}

