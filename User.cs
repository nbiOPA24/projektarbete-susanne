
public class User
{
    public string UserName {get; set;}
    public string UserID {get; set;}
    public string UserPassword {get; set;}
    public int Score {get; set;} //Lägger till Score, då det är en unik egenskap som hänger ihop med den inloggade användaren
    public bool IsOnline {get; set;} //Lägger till isOnline, för jag tänker att det borde skapas en användarlista när användern loggar in, som håller de poäng som användaren skrapar ihop. 
    
    
    public User(string userName, string userID, string userPassword, bool isOnline) 
    {
        UserName = userName; 
        UserID = userID;
        UserPassword = userPassword;
        Score = 0; //0 sätts som startvärde för alla användare.
        IsOnline = isOnline; 
        
    }
}


//En klass som håller samman de delar av programmet som gäller inloggning i programmet. 
//Här finns metod för att skapa en ny användare. 
//Finns också en metod för att logga in en befintlig användare. 
//Finns även en metod där jag skapat tre default-användare som kan användas vid testning. 




public static class HandleUser
{
    
    //public static Dictionary<string, int> userScore = new Dictionary<string, int>(); //Dict istället för list???
    public static List<User> users = new List<User>();

    public static void LogInMenu(List<User> users)
    {
        Console.WriteLine("Klicka på [J] om du redan har ett inlogg till programmet");
        Console.WriteLine("Klicka på [C] om du vill skapa inloggning till programmet");
        Console.WriteLine("Klicka på [P] för att skriva ut samtliga användare");
        string input = Console.ReadLine();
        if(input == "j")
        {
            HandleUser.LogIn(users);
        }
        else if(input == "c")
        {
            HandleUser.CreateNewUser();
        }
        else if(input == "p")
        {
            HandleUser.DeFaultUser();
        }
        else
        {
            Console.WriteLine("Felaktig inmatning");
        }
    }

    public static void CreateNewUser() //Metod för att skapa ny användare och lägga till användare i listan users. 
    {
        Console.Write("Skriv in ditt namn: ");
        string newUserName = Console.ReadLine();
        Console.Write("Skriv in ditt användarID: "); //Utveckling - slumpa fram utifrån användarens namn!!!
        string newUserID = Console.ReadLine();
        Console.Write("Ange ett lösenord: ");
        string newUserPassword = Console.ReadLine();

        User newUser = new User(newUserName, newUserID, newUserPassword, false); //isOnline sätts som false. 
        users.Add(newUser);      
    }
    public static void LogIn(List<User> users) //Metod för att logga in i systemet
    {
        Console.Write("Skriv in ditt användarnamn: ");
        string userName = Console.ReadLine();
        Console.Write("Skriv in ditt lösenord: ");
        string userPassword = Console.ReadLine();
        
        User user = null; //user sätts som null, dels för att reservera plats i minnet och dels för att avgöra om en användare finns i listan när listan itereras senare i programmet. 

        foreach(var u in users) //
        {
            if(u.UserName == userName)
            {
                user = u; //null ersätts med objektet user
            }
        }

        if(user != null)
        {
            Console.Write("Skriv in ditt lösenord: ");
            if(userPassword.Equals(user.UserPassword))
            {
                Console.WriteLine("Du är nu inloggad");
            } 
            else
            {
            Console.WriteLine("Felaktigt lösenord");
            }           
        }
        else
        {
            Console.WriteLine("Ingen användare med angivet namn hittad. Kontrollera användarnamn, eller skap en ny användare.");
        }    
    }

     public static void DeFaultUser() //Metod för att lägga till hårdkodade användare i programmet
    {        
        User user1 = new User("Anna", "annapanna12", "abc123", false);
        User user2 = new User("Beata", "beata16", "abc123", false);
        User user3 = new User("Caesar", "caesar13", "abc123", false);
        users.Add(user1);
        users.Add(user2);
        users.Add(user3); 

        foreach(var user in users)
        {
            Console.WriteLine(user.UserID, user.UserName);
        }
    }
}