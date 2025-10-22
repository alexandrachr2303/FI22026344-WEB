﻿public class Numbers
{
    private static readonly double N = 25;

    public static double Formula(double z)
    {
        return Round((z + Math.Sqrt(4 + Math.Pow(z, 2))) / 2);
    }

    public static double Recursive(double z)
    {
        return Round(Recursive(z, N) / Recursive(z, N - 1));
    }

    public static double Iterative(double z)
    {
        return Round(Iterative(z, N) / Iterative(z, N - 1));
    }

    private static double Recursive(double z, double n)
    {
        if (n == 0 || n == 1) return 1;
        return z * Recursive(z, n - 1) + Recursive(z, n - 2);  

    }

    private static double Iterative(double z, double n)
    {
        double prev = 1, curr = 1, next = 0;
        for (int i = 2; i <= n; i++)
        {
            next = z * curr + prev;
            prev = curr;
            curr = next;
        }
        return curr;
    }

    private static double Round(double value)
    {
        return Math.Round(value, 10, MidpointRounding.AwayFromZero);
    }

    public static void Main(String[] args)
    {
        String[] metallics = {
            "Platinum", // [0]
            "Golden", // [1]
            "Silver", // [2]
            "Bronze", // [3]
            "Copper", // [4]
            "Nickel", // [5]
            "Aluminum", // [6]
            "Iron", // [7]
            "Tin", // [8]
            "Lead", // [9]
        };
        for (var z = 0; z < metallics.Length; z++)
        {
            Console.WriteLine("\n[" + z + "] " + metallics[z]);
            Console.WriteLine(" ↳ formula(" + z + ")   ≈ " + Formula(z));
            Console.WriteLine(" ↳ recursive(" + z + ") ≈ " + Recursive(z));
            Console.WriteLine(" ↳ iterative(" + z + ") ≈ " + Iterative(z));
        }
    }
}

// https://chatgpt.com/share/68f82c20-a0b0-800c-99f9-fbf8378a7607//
//https://www.estradawebgroup.com/Post/Funciones-recursivas-en-C/20602//