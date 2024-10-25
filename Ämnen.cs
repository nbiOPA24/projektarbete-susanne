class Ämne

{
    public static void Menu()
    {
      System.Console.WriteLine();
        System.Console.WriteLine("Välj ett ämne : ");
        System.Console.WriteLine("1. Svenska ");
        System.Console.WriteLine("2. Engelska ");
        System.Console.WriteLine("3. SO ");
        System.Console.WriteLine("4. Matte ");
        System.Console.WriteLine("5. Idrott ");
        System.Console.WriteLine("6. Se dina betyg ");
        System.Console.WriteLine("7. Admin");
        System.Console.WriteLine("8. Avsluta programmet ");
    
        System.Console.WriteLine();
        string choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
            System.Console.WriteLine("Svenska");
            break;

            case "2":
            System.Console.WriteLine("Engelska");
            break;

            case "3":
            System.Console.WriteLine("SO");
            break;

            case "4":
            System.Console.WriteLine("Matte");
            break;

            case "5":
            System.Console.WriteLine("Idrott");
            break;

                
        }
        

    }

}
