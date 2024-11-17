
public class User
{
    public string UserName {get; set;}
    public string UserID {get; set;}
    public bool IsOnline {get; set;}
    
    public User(string userName, string userID, bool isOnline)
    {
        UserName = userName; 
        UserID = userID;
        IsOnline = false;
    }

    public static void DeFaultUser()
    {
        
        User user1 = new User("Anna", "annapanna12", true);
        User user2 = new User("Beata", "Beata16", false);
        User user3 = new User("Caesar", "caesar13", false);
        HandleUser.users.Add(user1);
        HandleUser.users.Add(user2);
        HandleUser.users.Add(user3);               
    }

}

public static class HandleUser
{
    public static Dictionary<string, int> userScore = new Dictionary<string, int>();
    public static List<User> users = new List<User>();

    public static void LogIn()
    {

    }

}