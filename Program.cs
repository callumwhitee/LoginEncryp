using System;
using System.IO;
class Program
{

    static string[,] userDetails;

    static string path = "userDetails.csv";

    static Hash hasher = new Hash();
    public static void Main(string[] args)
    {
        Console.Clear(); 
        // var a = hasher.Verify("abc", "$HASH$10000$Nt5xVUa8X9/7YQErB/V8VScoF9DjqaEkY/I1MHWlds1C8Eea");
        // Console.WriteLine(a);

        bool loggedOut = true;
        while(loggedOut)
        {
            if(Login())
            {
                loggedOut = false;
                MainMenu();
            }
        }
    }

    static bool Login()
    {
        ReadInCsv();
        Console.Clear();
        Console.WriteLine("Please Enter Your Username");
        Console.Write("> ");
        string enteredUsername = Console.ReadLine();
        Console.WriteLine("Please Enter Your Password");
        Console.Write("> ");
        string enteredPassword = Console.ReadLine();

        for(int i = 0; i < userDetails.GetLength(0); i++)
        {
            if(  (enteredUsername == userDetails[i,0]) && (hasher.Verify(enteredPassword, userDetails[i,1])))
            {
                if(hasher.Verify(enteredPassword, userDetails[i,1]))
                {
                    Console.WriteLine("You Have Entered Your Correct Details");
                    Thread.Sleep(1000);
                    return true;
                }
                
            }
        }
        Console.WriteLine("You Have Not Entered A Correct Username Or Password.");
        Console.WriteLine("Please Try Again");
        Thread.Sleep(1750);
        return false;
    }



    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("What Would You Like To Do?");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("New Login");
        Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("> ");
        string answer = Console.ReadLine().ToLower();
        if(answer == "new login")
        {
            NewLogin();
        }
    }




    static void NewLogin()
    {
        Console.Clear();
        Console.WriteLine("Enter Your New Username");
        Console.Write("> ");
        string newUsername = Console.ReadLine();
        Console.WriteLine("Enter Your New Password");
        Console.Write("> ");
        string newPassword = Console.ReadLine();
        Console.Clear();
        string hashedPassword = hasher.hash(newPassword);
        try
        {
            using(StreamWriter file = new StreamWriter(@path, true))
            {
                file.WriteLine();
                file.Write(newUsername + "," + hashedPassword);
            }
            Console.WriteLine("Successfully added the new details");
            Thread.Sleep(1500);
            MainMenu();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }










    static void ReadInCsv()
    {
        string[] readIn = new string[File.ReadAllLines(path).Length];
        int colomns = 2;
        int rows = readIn.Length;

        userDetails = new string[rows, colomns];

        readIn = File.ReadAllLines(path);

        string[] temp = new string[colomns];

        for(int i = 0; i < rows; i++)
        {
            temp = readIn[i].Split(',');
            for(int j = 0; j < colomns; j++)
            {
                userDetails[i,j] = temp[j];
            }
        }
    }

   
}