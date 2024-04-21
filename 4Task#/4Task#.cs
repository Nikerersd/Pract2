using System;
using System.Collections.Generic;

class Program
{
    static bool IsPrime(int p)
    {
        if (p <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(p); i++)
        {
            if (p % i == 0) return false;
        }
        return true;
    }

    static int Random(int min, int max)
    {
        Random rand = new Random();
        return rand.Next(min, max + 1);
    }

    static int Euler(int p)
    {
        int result = p;
        for (int i = 2; i * i <= p; i++)
        {
            if (p % i == 0)
            {
                while (p % i == 0)
                    p /= i;
                result -= result / i;
            }
        }
        if (p > 1)
            result -= result / p;
        return result;
    }

    static int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b, a % b);
    }

    static int ExtendedGCD(int c, int m, out int x, out int y)
    {
        if (m == 0)
        {
            x = 1;
            y = 0;
            return c;
        }

        int x1, y1;
        int gcd = ExtendedGCD(m, c % m, out x1, out y1);

        x = y1;
        y = x1 - (c / m) * y1;

        return gcd;
    }

    static int ModularInverse(int c, int m)
    {
        int x, y;
        int gcd = ExtendedGCD(c, m, out x, out y);
        if (gcd != 1)
        {
            return -1;
        }
        else
        {
            return (x % m + m) % m;
        }
    }

    static long PowMod(long a, long x, long p)
    {
        long result = 1;
        a = a % p;
        while (x > 0)
        {
            if (x % 2 == 1)
            {
                result = (result * a) % p;
            }
            a = (a * a) % p;
            x /= 2;
        }
        return result;
    }

    static int Encode(string message, int N, int openKey, List<int> encoded)
    {
        foreach (char c in message)
        {
            long ASC = c;
            if (ASC > N)
            {
                return -1;
            }
            long encr = PowMod(ASC, openKey, N);
            encoded.Add((int)encr);
        }
        return 0;
    }

    static void Decode(long encSym, int N, int closedKey, List<int> decoded)
    {
        long decr = PowMod(encSym, closedKey, N);
        decoded.Add((int)decr);
    }

    static void Main()
    {
        int p = 10, q = 10;
        while (!IsPrime(p))
        {
            p = Random(1000, 7000);
        }
        while (!IsPrime(q))
        {
            q = Random(1000, 7000);
        }
        int N = p * q;
        int euler = Euler(N);
        int openKey = Random(1000, euler);
        while (GCD(openKey, euler) != 1)
        {
            openKey = Random(1000, euler);
        }
        int closedKey = ModularInverse(openKey, euler);
        Console.WriteLine("Enter the encryption text");
        string message = Console.ReadLine();
        List<int> encoded = new List<int>();
        int enc = Encode(message, N, openKey, encoded);
        if (enc == -1)
        {
            Console.WriteLine("Error!");
            return;
        }
        List<int> decoded = new List<int>();
        Console.WriteLine("Encrypted text: ");
        foreach (long i in encoded)
        {
            Decode(i, N, closedKey, decoded);
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Decrypted text: ");
        foreach (long i in decoded)
        {
            char c = (char)i;
            Console.Write(c);
        }
    }
}