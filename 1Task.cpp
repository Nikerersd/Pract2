#include <iostream>
#include <cmath>
#include <string>
#include <cctype>
using namespace std;
// Функция для проверки простоты числа
bool is_prime(int n) {
    if (n <= 1) return false;
    for (int i = 2; i <= sqrt(n); ++i) {
        if (n % i == 0) return false;
    }
    return true;
}
bool is_Ferm(int a, int x, int p) {
    if (a%p!=0 && a>=1) {
        return true;
    }
    return false;
}
bool is_Int (string n) {
    if (n[0] == '-') {
        n[0] = '1';
    }
    for (char c : n) {
        if (!isdigit(c)) {
            cout << "Некорректные данные" << endl;
            return false;
        }
    }
    return true;
}
// Функция для вычисления a^x mod p используя метод двоичного разложения степени
int pow_mod(int a, int x, int p) {
    int result = 1;
    a = a % p; // Уменьшаем a по модулю p
    while (x > 0) {
        if (x % 2 == 1) {
            result = (result * a) % p;
        }
        a = (a * a) % p;
        x /= 2;
    }
    return result;
}

int main() {
    string astr, xstr, pstr, bstr, ystr;
    int a, x, p, b, y;
    
    cout << "Введите a: ";
    cin >> astr;
    if (!is_Int(astr))  {
        return 1;
    };
    a = stoi(astr);
    cout << "Введите x: ";
    cin >> xstr;
    if (!is_Int(xstr))  {
        return 1;
    };
    x = stoi(xstr);
    cout << "Введите b: ";
    cin >> bstr;
    if (!is_Int(bstr))  {
        return 1;
    };
    b = stoi(bstr);
    cout << "Введите y: ";
    cin >> ystr;
    if (!is_Int(ystr))  {
        return 1;
    };
    y = stoi(ystr);
    cout << "Введите p (простое число): ";
    cin >> pstr;
    if (!is_Int(pstr))  {
        return 1;
    };
    p = stoi(pstr);
    // Проверяем, простое ли число p
    if (!is_prime(p)) {
        cout << "Число p должно быть простым." << endl;
    } 
    else {
        if (!is_Ferm(a,x,p)) {
            cout << "Для" << a << "^" << x << " mod " << p << " теорема Ферма не выполняется" << endl;
        }
        if (!is_Ferm(b,y,p)) {
            cout << "Для" << b << "^" << y << " mod " << p << " теорема Ферма не выполняется" << endl;
        }
        if (is_Ferm(a,x,p) && is_Ferm(b,y,p)) {
            if (pow_mod(a,x%(p-1),p)==pow_mod(b,y%(p-1),p)) {
                cout << " (" << a << "^" << x << " mod " << p << " = " << pow_mod(a,x%(p-1),p) << ") = (" << b << "^" << y << " mod " << p << " = " << pow_mod(b,y%(p-1),p) << ")" << endl;
            }
            else {
                cout << " (" << a << "^" << x << " mod " << p << " = " << pow_mod(a,x%(p-1),p) << ") != (" << b << "^" << y << " mod " << p << " = " << pow_mod(b,y%(p-1),p) << ")" << endl;
            }
        }
        else {
            if (pow_mod(a,x,p)==pow_mod(b,y,p)) {
                cout << " (" << a << "^" << x << " mod " << p << " = " << pow_mod(a,x,p) << ") = (" << b << "^" << y << " mod " << p << " = " << pow_mod(b,y,p) << ")" << endl;
            }
            else {
                cout << " (" << a << "^" << x << " mod " << p << " = " << pow_mod(a,x,p) << ") != (" << b << "^" << y << " mod " << p << " = " << pow_mod(b,y,p) << ")" << endl;
            }
        }
    }
    return 0;
}