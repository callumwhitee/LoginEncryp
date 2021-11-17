using System;
class Program
{
    public static void Main(string[] args)
    {
        var PasswordHasher = new Hash();
        Console.WriteLine("Enter Four Passwords");
        for(int i = 0; i < 4; i ++)
        {
            Console.Write("> ");
            string a = Console.ReadLine();
            var hash = PasswordHasher.hash(a, 10000);
            Console.WriteLine(hash);
        }

    }
}