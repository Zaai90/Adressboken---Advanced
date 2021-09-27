using System;

static class ConsoleUtils
{
    public static string ReadString(string prompt = "")
    {
        if (!string.IsNullOrWhiteSpace(prompt))
        {
            Console.WriteLine(prompt);
        }

        string output = Console.ReadLine();
        return (output);

    }

    public static int ReadInt(string prompt = "")
    {
        if (!string.IsNullOrWhiteSpace(prompt))
        {
            Console.WriteLine(prompt);
        }

        int output = int.Parse(Console.ReadLine());
        return (output);

    }
}