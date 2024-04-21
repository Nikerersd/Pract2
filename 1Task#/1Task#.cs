using System;

class Program {
    static bool IsPrime(int p) {
        if (p <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(p); i++) {
            if (p % i == 0) return false;
        }
        return true;
    }

    static int NOD(int a, int b) {
        if (b == 0) {
            return a;
        }
        return NOD(b, a % b);
    }

    static bool IsEuler(int a, int x, int p) {
        return NOD(a, p) == 1;
    }

    static int Euler(int p) {
        int result = p;
        for (int i = 2; i * i <= p; i++) {
            if (p % i == 0) {
                while (p % i == 0)
                    p /= i;
                result -= result / i;
            }
        }
        if (p > 1)
            result -= result / p;
        return result;
    }

    static bool IsInt(string n) {
        if (n[0] == '-') {
            n = '1' + n.Substring(1);
        }
        foreach (char c in n) {
            if (!char.IsDigit(c)) {
                Console.WriteLine("Некорректные данные");
                return false;
            }
        }
        return true;
    }

    static int PowMod(int a, int x, int p) {
        int result = 1;
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
        string astr, xstr, pstr, bstr, ystr;
        int a, x, p, b, y;

        Console.WriteLine("Введите a: ");
        astr = Console.ReadLine();
        if (!IsInt(astr)) {
            return;
        };
        a = int.Parse(astr);
        Console.WriteLine("Введите x: ");
        xstr = Console.ReadLine();
        if (!IsInt(xstr)) {
            return;
        };
        x = int.Parse(xstr);
        Console.WriteLine("Введите b: ");
        bstr = Console.ReadLine();
        if (!IsInt(bstr)) {
            return;
        };
        b = int.Parse(bstr);
        Console.WriteLine("Введите y: ");
        ystr = Console.ReadLine();
        if (!IsInt(ystr)) {
            return;
        };
        y = int.Parse(ystr);
        Console.WriteLine("Введите p: ");
        pstr = Console.ReadLine();
        if (!IsInt(pstr)) {
            return;
        };
        p = int.Parse(pstr);

        if (!IsPrime(p)) {
            if (!IsEuler(a, x, p)) {
                Console.WriteLine($"Для {a}^{x} mod {p} теорема Эйлера не выполняется");
            }
            if (!IsEuler(b, y, p)) {
                Console.WriteLine($"Для {b}^{y} mod {p} теорема Эйлера не выполняется");
            }
            if (IsEuler(a, x, p) && IsEuler(b, y, p)) {
                if (PowMod(a, x % Euler(p), p) == PowMod(b, y % Euler(p), p)) {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x % Euler(p), p)}) = ({b}^{y} mod {p} = {PowMod(b, y % Euler(p), p)})");
                }
                else {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x % Euler(p), p)}) != ({b}^{y} mod {p} = {PowMod(b, y % Euler(p), p)})");
                }
            }
            else {
                if (PowMod(a, x, p) == PowMod(b, y, p)) {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x, p)}) = ({b}^{y} mod {p} = {PowMod(b, y, p)})");
                }
                else {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x, p)}) != ({b}^{y} mod {p} = {PowMod(b, y, p)})");
                }
            }
        } 
        else {
            if (!IsEuler(a, x, p)) {
                Console.WriteLine($"Для {a}^{x} mod {p} теорема Ферма не выполняется");
            }
            if (!IsEuler(b, y, p)) {
                Console.WriteLine($"Для {b}^{y} mod {p} теорема Ферма не выполняется");
            }
            if (IsEuler(a, x, p) && IsEuler(b, y, p)) {
                if (PowMod(a, x % (p - 1), p) == PowMod(b, y % (p - 1), p)) {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x % (p - 1), p)}) = ({b}^{y} mod {p} = {PowMod(b, y % (p - 1), p)})");
                }
                else {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x % (p - 1), p)}) != ({b}^{y} mod {p} = {PowMod(b, y % (p - 1), p)})");
                }
            }
            else {
                if (PowMod(a, x, p) == PowMod(b, y, p)) {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x, p)}) = ({b}^{y} mod {p} = {PowMod(b, y, p)})");
                }
                else {
                    Console.WriteLine($" ({a}^{x} mod {p} = {PowMod(a, x, p)}) != ({b}^{y} mod {p} = {PowMod(b, y, p)})");
                }
            }
        }
    }
}