public class Mathematics //Klass för att träna matte
{
    public List<int> Factors {get; set;} //En lista för att kunna spara faktorer för den tabell användaren vill öva på.
       
    public Mathematics()
    {
        Factors = new List<int>(); //Initierar listan Factors i klassens konstruktor. 
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
    //Metod för att användaren ska kunna öva multiplikation. 
    public void PracticeMultiplication()
    {
        System.Console.Write("Ange talet för den multiplikationstabell som du vill öva på: ");
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
                        System.Console.WriteLine("Du svarade rätt!");
                        System.Console.WriteLine();
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
}