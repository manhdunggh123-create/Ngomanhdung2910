
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

struct HangHoa {
    string maHH;
    string tenHH;
    string ngayXuat;
    double giaXuat;
};

void nhapMang(HangHoa a[], int n) {
    for (int i = 0; i < n; i++) {
        cout << "\nNhap hang hoa thu " << i + 1 << ":\n";

        cout << "Ma hang hoa: ";
        getline(cin, a[i].maHH);

        cout << "Ten hang hoa: ";
        getline(cin, a[i].tenHH);

        cout << "Ngay xuat (dd/mm/yyyy): ";
        getline(cin, a[i].ngayXuat);

        cout << "Gia xuat (trieu dong): ";
        cin >> a[i].giaXuat;
        cin.ignore(10000, '\n');
    }
}

void xuatMotHangHoa(HangHoa hh) {
    cout << left
         << setw(15) << hh.maHH
         << setw(25) << hh.tenHH
         << setw(18) << hh.ngayXuat
         << fixed << setprecision(2) << hh.giaXuat << endl;
}

void xuatMang(HangHoa a[], int n) {
    cout << left
         << setw(15) << "Ma hang hoa"
         << setw(25) << "Ten hang hoa"
         << setw(18) << "Ngay xuat"
         << "Gia xuat (trieu dong)" << endl;

    for (int i = 0; i < n; i++) {
        xuatMotHangHoa(a[i]);
    }
}

void quickSort(HangHoa a[], int left, int right) {
    int i = left;
    int j = right;
    double pivot = a[(left + right) / 2].giaXuat;

    while (i <= j) {
        while (a[i].giaXuat < pivot) {
            i++;
        }

        while (a[j].giaXuat > pivot) {
            j--;
        }

        if (i <= j) {
            HangHoa temp = a[i];
            a[i] = a[j];
            a[j] = temp;

            i++;
            j--;
        }
    }

    if (left < j) {
        quickSort(a, left, j);
    }

    if (i < right) {
        quickSort(a, i, right);
    }
}

void timKiemNhiPhan(HangHoa a[], int n, double X) {
    int left = 0;
    int right = n - 1;
    int pos = -1;

    while (left <= right) {
        int mid = (left + right) / 2;

        if (a[mid].giaXuat == X) {
            pos = mid;
            break;
        } else if (a[mid].giaXuat < X) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    if (pos == -1) {
        cout << "\nKhong tim thay hang hoa co gia xuat bang "
             << X << endl;
        return;
    }

    int first = pos;
    int last = pos;

    while (first > 0 && a[first - 1].giaXuat == X) {
        first--;
    }

    while (last < n - 1 && a[last + 1].giaXuat == X) {
        last++;
    }

    cout << "\nCac hang hoa co gia xuat bang "
         << X << " trieu dong:\n";

    cout << left
         << setw(15) << "Ma hang hoa"
         << setw(25) << "Ten hang hoa"
         << setw(18) << "Ngay xuat"
         << "Gia xuat (trieu dong)" << endl;

    for (int i = first; i <= last; i++) {
        xuatMotHangHoa(a[i]);
    }
}

int main() {
    HangHoa a[100];
    int n;
    double X;

    cout << "Nhap so luong hang hoa: ";
    cin >> n;
    cin.ignore(10000, '\n');

    if (n <= 0 || n > 100) {
        cout << "So luong hang hoa khong hop le!";
        return 0;
    }

    nhapMang(a, n);

    cout << "\nDANH SACH HANG HOA VUA NHAP\n";
    xuatMang(a, n);

    quickSort(a, 0, n - 1);

    cout << "\nDANH SACH HANG HOA SAU KHI SAP XEP\n";
    xuatMang(a, n);

    cout << "\nNhap gia xuat X can tim (trieu dong): ";
    cin >> X;

    timKiemNhiPhan(a, n, X);

    return 0;
}
