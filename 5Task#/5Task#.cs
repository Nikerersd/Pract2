using System;

class Program {
    static long PowMod(long a, int x, int p) {
        long result = 1;
        a = a % p;
        while (x > 0) {
            if (x % 2 == 1) {
                result = (result * a) % p;
            }
            a = (a * a) % p;
            x /= 2;
        }
        return result;
    }

    static void Main() {
        Console.Write("Введите этажи нужного числа: ");
        var input = Console.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        int VrCh = (int)PowMod(a, b, 10);
        int result = (int)PowMod(VrCh, c, 10);
        Console.Write("Последняя цифра: ");
        Console.WriteLine(result);
    }
}