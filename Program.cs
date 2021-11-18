using System;
using System.IO;
class Program
{

    static string[,] userDetails;

    static string path = "userDetails.csv";

    static Hash hasher = new Hash();
    public static void Main(string[] args)
    {
        bool loggedOut = true;
        ReadInCsv();
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
        Console.Clear();
        Console.WriteLine("Please Enter Your Username");
        Console.Write("> ");
        string enteredUsername = Console.ReadLine();
        Console.WriteLine("Please Enter Your Password");
        Console.Write("> ");
        string enteredPassword = Console.ReadLine();

        for(int i = 0; i < userDetails.GetLength(0); i++)
        {
            if(enteredUsername == userDetails[i,0])
            {
                if(hasher.Verify(enteredPassword, userDetails[i,1]))
                {
                    Console.WriteLine("You Have Correctly Entered Your Password");
                    return true;
                }
                else
                {
                    Console.WriteLine("You Have Entered An Incorrect Login");
                    Thread.Sleep(750);
                    Console.WriteLine("Please Retry");
                    Thread.Sleep(2000);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("You Have Entered An Incorrect Login");
                Thread.Sleep(750);
                Console.WriteLine("Please Retry");
                Thread.Sleep(2000);
                return false;
            }
        }
        return false;
    }



    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Hello WOrld");
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