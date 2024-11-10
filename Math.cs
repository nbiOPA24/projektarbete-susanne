public class Math //Klass för att träna matte
{
    public List<int> Multiplication {get; set;} //En lista för att kunna spara multiplikationstabeller
       
    public Math()
    {
        Multiplication = new List<int>(); //Initierar listan Multiplication i klassens konstruktor
    }


    public void MultiplicationTable() // En metod för att skapa en multiplikationstabell samt senare kunna öva på den valda. 
    {
        
        System.Console.WriteLine("Vilken multiplikationstabell vill du öva på?"); //UserInput -- användare väljer vilken tabell hen ska öva på. 
        if(int.TryParse(Console.ReadLine(), out int number))
        {
            for(int i = 0; i <= 10; i++)
            {
                int mTable = number * i;
                Multiplication.Add(mTable);             
            }

            Random rnd = new Random(); //Skapar en ny instans av klassen Random, för att kunna slumpa fram de tal användaren ska öva på
               

             for(int n = 0; n <= 10; n++) //En loop som körs 10 gånger, där olika tal från den valda multiplikationstabellen hämtas. 
                {
                    int rndIndex = rnd.Next(Multiplication.Count); //Slumpar fram ett index från listan Multiplikation (ÄNDRAS TILL mTable?????) 
                    int rndNumber = Multiplication[rndIndex]; //Hämtar det tal som index motsvarar. 

                    System.Console.WriteLine($"Vad är {rndNumber} * {rndIndex}? ");
                    if(int.TryParse(Console.ReadLine(), out int answer))
                    {
                        if(answer == rndNumber * rndIndex) //Kontrollerar om användaren skrivit rätt svar.
                        {
                            System.Console.WriteLine("Bra jobbat! Du svarade rätt!");
                        }
                        else
                        {
                            System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar var {rndNumber * rndIndex}"); //Skriver ut rätt svar, om användaren skrver fel. 
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Ogiltig inmatning. Ange ett heltal.");
                    }
                }
            
        }      
    }
}