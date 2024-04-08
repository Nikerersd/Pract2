#include <iostream>
#include <cmath>
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
    int a, x, p, b, y;
    
    cout << "Введите a: ";
    cin >> a;
    
    cout << "Введите x: ";
    cin >> x;
    
    cout << "Введите b: ";
    cin >> b;
    
    cout << "Введите y: ";
    cin >> y;

    cout << "Введите p (простое число): ";
    cin >> p;
    
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