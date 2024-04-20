#include <iostream>

using namespace std;

int NODsKoef(int c, int m, int& x, int& y) {
    if (m == 0) {
        x = 1;
        y = 0;
        return c;
    }

    int x1, y1;
    int nod = NODsKoef(m, c % m, x1, y1);

    x = y1;
    y = x1 - (c / m) * y1;

    return nod;
}

int ObratnCh(int c, int m) {
    int x, y;
    int gcd = NODsKoef(c, m, x, y);
    if (gcd != 1) {
        return -1;
    } 
    else {
        return (x % m + m) % m;
    }
}

int main() {
    int c, d, m;
    cout << "Введите c и m через пробел" << endl;
    cin >> c >> m;
    if (ObratnCh(c,m) != -1) {
        d = ObratnCh(c, m);
        cout << "d = " << d << endl;
    }
    else {
        cout << "Для данных значений обратного числа d по модулю не существует." << endl;
    }
}