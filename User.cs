
//Userklassen håller användarens egenskaper i form av användarnamn lösenord,
//samt en dictionary för att hålla användarens poäng i respektive ämne.
//Lagt till lista för WrongAnswers eftersom det är knutet till den specifika användaren och inte till frågan! 
using System.Runtime.CompilerServices;

public class User
{
    public string UserName {get; set;}    
    public string UserPassword {get; set;}
    public List<Question> WrongAnswers {get; set;} = new List<Question>(); //Lägger listan för fel svar här istället pga är knuten till den specifika användaren.    
    public Dictionary<string, int> Score {get; set;} //Ändrar Score från att vara en egenskap till att vara en dictionary, då ett dict kan hålla både subject och points. 

    public User(string userName, string userPassword) 
    {
        UserName = userName; 
        UserPassword = userPassword;
        Score = new Dictionary<string, int>();        
    }
      List<Question> questions;
    List<User> users;   

    public void AddWrongAnswer(Question question) //Metod som lägger till fel svar i listan wrongAnswers
    {
        WrongAnswers.Add(question);
    }

    public void PracticeWrongAnswers() //metod för att öva på fel svar. VAr ska den ligga???
    {
        if(WrongAnswers.Count != 0)
        {
            foreach(var q in WrongAnswers)
            {
                Console.WriteLine($"Fråga: {q.Quest}");
            }
            
        }
        else
        {
            Console.WriteLine("Inga frågor att öva på. Bra jobbat!");
        }

    }
    
}
//En klass som håller samman de delar av programmet som gäller inloggning i programmet. 
//Här finns metod för att skapa en ny användare. 
//Finns också en metod för att logga in en befintlig användare. 
//Finns även en metod där jag skapat tre default-användare som kan användas vid testning. 

public class HandleUser //Ändrar klassen från statisk till ickestatisk, då en klass som hanterar unika användare  med unika värden, och därmed alltid borde instansieras. 
{    
    public List<User> users = new List<User>();

    public User LogInMenu(List<User> users)
    {
        Console.WriteLine("-------------Gör ett av följande val--------------------");
        Console.WriteLine("Klicka på [L] om du redan har ett inlogg till programmet");
        Console.WriteLine("Klicka på [C] om du vill skapa inloggning till programmet");
        Console.WriteLine("Klicka på [P] för att skriva ut samtliga användare");
        Console.WriteLine("---------------------------------------------------------");
        string input = Console.ReadLine();
        if(input == "l")
        {
            return LogIn(users);
        }
        else if(input == "c")
        {
            CreateNewUser();
            return null;
        }
        else if(input == "p")
        {
            PrintDefaultUser(users);
            return null;
        }
        else
        {
            Console.WriteLine("Felaktig inmatning");
            return null;
        }
    }

    public void CreateNewUser() //Metod för att skapa ny användare och lägga till användare i listan users. 
    {
        Console.Write("Skriv in ditt namn: ");
        string newUserName = Console.ReadLine();        
        Console.Write("Skriv ett lösenord: ");
        string newUserPassword = Console.ReadLine();

        var newUser = new User(newUserName, newUserPassword); 
        newUser.Score.Add("SV", 0); //Sätter det initiala värdet för poäng per ämne till 0 i dictionaryn för Score. 
        newUser.Score.Add("NA", 0);
        newUser.Score.Add("SO", 0);
        newUser.Score.Add("MA", 0);
        newUser.Score.Add("EN", 0);
        users.Add(newUser);      
    }
    public User LogIn(List<User> users) //Metod för att logga in i systemet 
    {
        Console.Write("Skriv in ditt användarnamn: ");
        string userName = Console.ReadLine();
        Console.Write("Skriv in ditt lösenord: ");
        string userPassword = Console.ReadLine();       

        foreach(var user in users) //
        {
            if(user.UserName == userName && user.UserPassword == userPassword) //Ändrar funktionen i metoden, så man i en och samma rad kontrollerar användarnamn + lösenord. 
            {
                Console.WriteLine("Du är nu inloggad!");                
                return user;
            }
            else
            {
                Console.WriteLine("Något gick fel. Du använder programmet som gäst. ");
            }
        }
        Console.WriteLine("Ingen användare hittad eller felaktigt lösenord angett");
        return null;          
    }

    public void DefaultUser(List<User> users) //Metod för att lägga till hårdkodade användare i programmet
    {    
        string defaultUser = "anna test";
        string defaultPassword = "abc123";        

        var newDefaultUser = new User(defaultUser, defaultPassword);
        newDefaultUser.Score.Add("SV", 0); //Sätter det initiala värdet för poäng per ämne till 0 i dictionaryn för Score. 
        newDefaultUser.Score.Add("NA", 0);
        newDefaultUser.Score.Add("SO", 0);
        newDefaultUser.Score.Add("MA", 0);
        newDefaultUser.Score.Add("EN", 0);
        users.Add(newDefaultUser);        
    }

    public void PrintDefaultUser(List<User> users)
    {
        foreach(var user in users)
        {
            Console.WriteLine($"{user.UserName} {user.UserPassword}");
        }       
    }
}