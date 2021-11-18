using System;
using System.IO;
class Program
{

    static string[,] userDetails;

    static string path = "userDetails.csv";

    static Hash hasher = new Hash();
    public static void Main(string[] args)
    {
        ReadInCsv();
        Login();
    }

    static void Login()
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
                }
                else
                {
                    Console.WriteLine("suck it.");
                }
            }
            else
            {
                Console.WriteLine("suck it.");
            }
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