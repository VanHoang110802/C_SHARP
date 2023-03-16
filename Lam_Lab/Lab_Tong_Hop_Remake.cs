using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LAB_TONG_HOP
{
    internal class Program
    {
        const int Max_Phan_Tu = 100;
        const int Nam_Goc = 2023;
        static int Lua_Chon;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Menu();

        }
        static void Menu()
        {

            int luaChon;
            bool checkMenu = true;
            do
            {
                Info();
                Console.SetCursorPosition(0, 0);
                NoiDungMenu();

                try
                {
                    luaChon = Convert.ToInt32(Console.ReadLine());
                    Lua_Chon = luaChon;
                    switch (luaChon)
                    {
                        case 0:
                            {

                                Environment.Exit(0);
                                break;
                            }
                        case 1:
                            {
                                Bai1();
                                break;
                            }
                        case 2:
                            {
                                Bai2();
                                break;
                            }
                        case 3:
                            {
                                Bai3();
                                break;
                            }
                        case 4:
                            {
                                Bai4();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Lựa chọn nhập không hợp lệ, xin hãy kiểm tra lại!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (checkMenu);
        }

        static void Info()
        {
            Console.SetCursorPosition(60, 2);
            Console.Write("Họ tên:     Trương Văn Hoàng");
            Console.SetCursorPosition(60, 3);
            Console.Write("Mssv:       PH31092");
            Console.SetCursorPosition(60, 4);
            Console.Write("Giảng viên: Nguyễn Khánh Huyền (huyennk6)");
        }
        static void NoiDungMenu()
        {
            for (int i = 0; i < 110; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n\t[1]: Kiểm tra số chẵn lẻ");
            Console.WriteLine("\t[2]: Kiểm tra ngày tháng");
            Console.WriteLine("\t[3]: Mảng điểm");
            Console.WriteLine("\t[4]: Mảng thông tin sinh viên Poly");
            Console.WriteLine("\t[0]: Thoát");
            for (int i = 0; i < 110; ++i)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(1, 7);
            Console.Write("Vui lòng nhập lựa chọn:");

            for (int i = 1; i < 29; ++i)
            {
                if (i != 6)
                {
                    Console.SetCursorPosition(55, i);
                    Console.WriteLine("|");
                }
            }
            Console.SetCursorPosition(77, 7); Console.WriteLine("Kết quả");
            for (int i = 0; i < 110; ++i)
            {
                Console.SetCursorPosition(i, 29);
                Console.Write("-");
            }
            Console.SetCursorPosition(25, 7);
        }

        static void NhapMangSo(int[] a, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                bool checkPhanTu = true;
                do
                {
                    Console.Write($"Nhập số thứ {i + 1} = ");
                    try
                    {
                        a[i] = Convert.ToInt32(Console.ReadLine());
                        checkPhanTu = false;
                    }
                    catch
                    {
                        Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                    }
                } while (checkPhanTu);
            }
        }
        static void KiemTraChanLe(int[] a, int n)
        {
            Console.SetCursorPosition(57, 10);
            Console.Write("Các số chẵn là: ");
            for (int i = 0; i < n; ++i)
            {
                if (a[i] % 2 == 0)
                {
                    Console.Write($"{a[i]} ");
                }

            }
            Console.SetCursorPosition(57, 11);
            Console.Write("Các số lẻ là: ");
            for (int i = 0; i < n; ++i)
            {
                if (a[i] % 2 != 0)
                {
                    Console.Write($"{a[i]} ");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void Bai1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(8, 1);
            Console.Write("[1]: Kiểm tra số chẵn lẻ");
            Console.ResetColor();
            Console.SetCursorPosition(1, 8);
            int n = -1;
            do
            {
                Console.Write("\nNhập số lượng phần tử: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n < 0 || n > Max_Phan_Tu)
                    {
                        Console.Write("Số lượng phần tử nhập không hợp lệ!");
                        Console.ReadKey();

                    }
                }
                catch
                {
                    Console.Write("Dữ liệu nhập không được phép chấp nhận!");
                    Console.ReadKey();

                }
            } while (n < 0 || n > Max_Phan_Tu);

            int[] a = new int[n];
            NhapMangSo(a, n);
            KiemTraChanLe(a, n);
        }

// **************************************************************************************************
        static bool CheckThang2(int nam)
        {
            if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0)) return true;
            else return false;
        }
        static int CheckNgay(int thang, int nam)
        {
            if (thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12)
            {
                return 31;
            }
            else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                return 30;
            }
            else
            {
                if (CheckThang2(nam))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
        }

        static void NgayKeTiep(int nam, int thang, int ngay)
        {
            int cNgay = CheckNgay(thang, nam);
            int namTiepTheo = nam;
            int thangTiepTheo = thang;
            int ngayTiepTheo = ngay;

            if (nam > 0 && (thang > 0 && thang < 13) && (ngay > 0 && ngay <= cNgay))
            {
                ngayTiepTheo = ngay + 1;

                if (thang != 12 && ngay == cNgay)
                {
                    ngayTiepTheo = 1;
                    thangTiepTheo = thang + 1;
                }
                else if (thang == 12 && ngay == cNgay)
                {
                    ngayTiepTheo = 1;
                    namTiepTheo = nam + 1;
                    thangTiepTheo = 1;
                }
                else if (thang == 2)
                {
                    if (CheckThang2(nam))
                    {
                        if (ngay == 29)
                        {
                            ngayTiepTheo = 1;
                            thangTiepTheo = thang + 1;
                        }
                    }
                    else
                    {
                        if (ngay == 28)
                        {
                            ngayTiepTheo = 1;
                            thangTiepTheo = thang + 1;
                        }
                    }
                }
            }
            Console.SetCursorPosition(57, 11);
            Console.WriteLine($"Ngày tiếp theo: {ngayTiepTheo}/{thangTiepTheo}/{namTiepTheo}");
        }

        static void NgayKeTruoc(int nam, int thang, int ngay)
        {
            int cNgay = CheckNgay(thang, nam);
            int namTruocDo = nam;
            int thangTruocDo = thang;
            int ngayTruocDo = ngay;

            if (nam > 0 && (thang > 0 && thang < 13) && (ngay > 0 && ngay <= cNgay))
            {

                ngayTruocDo = ngay - 1;

                if (thang != 1 && ngay == 1)
                {

                    if (thang == 2 || thang == 4 || thang == 6 || thang == 8 || thang == 9 || thang == 11)
                    {
                        ngayTruocDo = 31;
                        thangTruocDo = thang - 1;
                    }

                    if (thang == 3)
                    {
                        if (CheckThang2(nam))
                        {
                            ngayTruocDo = 29;
                            thangTruocDo = thang - 1;
                        }
                        else
                        {
                            ngayTruocDo = 28;
                            thangTruocDo = thang - 1;
                        }
                    }

                    if (thang == 5 || thang == 7 || thang == 10 || thang == 12)
                    {
                        ngayTruocDo = 30;
                        thangTruocDo = thang - 1;
                    }
                }
                //nếu tháng nhập vào là tháng 1 và ngày 1 thì ngày tháng năm trước đó sẽ là ngày 31 tháng 12 năm trước đó
                else if (thang == 1 && thang == 1)
                {
                    ngayTruocDo = 31;
                    namTruocDo = nam - 1;
                    thangTruocDo = 12;
                }
            }
            Console.SetCursorPosition(57, 10);
            Console.WriteLine($"Ngày trước đó: {ngayTruocDo}/{thangTruocDo}/{namTruocDo}");
        }

        static void Bai2()
        {
        quaylai1:
            Console.Clear();
            Info();
            Console.SetCursorPosition(1, 7);
            Console.Write($"Vui lòng nhập lựa chọn: {Lua_Chon}");
            Console.SetCursorPosition(0, 0);

            NoiDungMenu();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(8, 2);
            Console.Write("[2]: Kiểm tra ngày tháng");
            Console.SetCursorPosition(1, 8);
            Console.ResetColor();

            int ngayHienTai, thangHienTai, namHienTai;
            do
            {
                Console.Write("\nVui lòng nhập ngày hiện tại: ");
                try
                {
                    ngayHienTai = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                }
            } while (true);

            do
            {
                Console.Write("Vui lòng nhập tháng hiện tại: ");
                try
                {
                    thangHienTai = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                }
            } while (true);

            do
            {
                Console.Write("Vui lòng nhập năm hiện tại: ");
                try
                {
                    namHienTai = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                }
            } while (true);

            if (ngayHienTai < 1 || ngayHienTai > CheckNgay(thangHienTai, namHienTai))
            {
                Console.WriteLine("Ngày nhập không hợp lệ, xin hãy kiểm tra lại!");
                Console.ReadKey();
                goto quaylai1;
            }
            else if (thangHienTai < 1 || thangHienTai > 12)
            {
                Console.WriteLine("Tháng nhập không hợp lệ, xin hãy kiểm tra lại!");
                Console.ReadKey();
                goto quaylai1;
            }
            else if (namHienTai < 1800 || namHienTai > Nam_Goc)
            {
                Console.WriteLine("Năm nhập không hợp lệ, xin hãy kiểm tra lại!");
                Console.ReadKey();
                goto quaylai1;
            }
            Console.SetCursorPosition(57, 9);
            Console.WriteLine($"Ngày vừa nhập: {ngayHienTai}/{thangHienTai}/{namHienTai}");
            NgayKeTiep(namHienTai, thangHienTai, ngayHienTai);
            NgayKeTruoc(namHienTai, thangHienTai, ngayHienTai);
            Console.ReadKey();
            Console.Clear();
        }

// **************************************************************************************************
        static void NhapMangDiem(double[] a, int n)
        {

            for (int i = 0; i < n; ++i)
            {
                bool checkDiem = true;
                do
                {
                    Console.Write($"Nhập điểm thứ {i + 1} = ");
                    try
                    {
                        a[i] = Convert.ToDouble(Console.ReadLine());
                        if (a[i] < 0 || a[i] > 10)
                        {
                            Console.WriteLine("Điểm nhập không hợp lệ, xin hãy kiểm tra lại!");
                        }
                        else checkDiem = false;
                    }
                    catch
                    {
                        Console.WriteLine("Dữ liệu nhập không được phép chấp nhận!");
                    }
                } while (checkDiem);
            }
        }

        static void XuatMangDiem(double[] a, int n, int x, int y)
        {
            for (int i = 0; i < n; ++i)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write($"{a[i]}");
                Console.Write(a[i] < 5 ? " - Trượt" : " - Đỗ");
            }
        }
        static void Bai3()
        {
            Console.Clear();
            Info();
            Console.SetCursorPosition(1, 7);
            Console.Write($"Vui lòng nhập lựa chọn: {Lua_Chon}");
            Console.SetCursorPosition(0, 0);

            NoiDungMenu();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(8, 3);
            Console.Write("[3]: Mảng điểm");
            Console.SetCursorPosition(1, 8);
            Console.ResetColor();

            int n = -1;
            do
            {
                Console.Write("Nhập số lượng điểm: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n < 0 || n > Max_Phan_Tu)
                    {
                        Console.Write("Số lượng điểm nhập không hợp lệ!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.Write("Dữ liệu nhập không được phép chấp nhận!");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (n < 0 || n > Max_Phan_Tu);

            double[] a = new double[n];
            NhapMangDiem(a, n);
            Console.SetCursorPosition(57, 9);
            Console.WriteLine("Nhập vào:");
            XuatMangDiem(a, n, 57, 11);

            Array.Sort(a);
            Console.SetCursorPosition(77, 9);
            Console.WriteLine("Sắp tăng: ");
            XuatMangDiem(a, n, 77, 11);

            Array.Sort(a);
            Array.Reverse(a);
            Console.SetCursorPosition(97, 9);
            Console.WriteLine("Sắp giảm: ");
            XuatMangDiem(a, n, 97, 11);

            Console.ReadKey();
            Console.Clear();
        }

// **************************************************************************************************

        static void Bai4()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(8, 4);
            Console.Write("[4]: Mảng thông tin sinh viên Poly");

            Console.SetCursorPosition(1, 8);
            Console.ResetColor();

            int n = -1;
            do
            {
                Console.Write("Nhập số lượng sinh viên: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n < 1 || n > Max_Phan_Tu)
                    {
                        Console.WriteLine("Số lượng sinh viên nhập không hợp lệ");
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được cho phép!");
                }

            } while (n < 1 || n > Max_Phan_Tu);

            string[] ten = new string[n];
            string[] Msv = new string[n];
            string[] tempMSV = new string[n];
            int[] namSinh = new int[n];
            int[] tuoiSv = new int[n];
            int namHienTai = 2023;

            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");
                Console.Write("Tên: ");
                ten[i] = Console.ReadLine();

                bool checkTrung;
                do
                {
                    Console.Write("Mã số sinh viên: ");
                    checkTrung = false;
                    Msv[i] = Console.ReadLine();
                    int lengthString = Msv[i].Length;
                    if (i > 0)
                    {
                        for (int j = i - 1; j >= 0; --j)
                        {
                            if (Msv[i] == Msv[j] || lengthString < 3)
                            {
                                Console.WriteLine("Mã số sinh viên này đã được tồn tại hoặc không hợp lệ!");
                                checkTrung = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (lengthString < 3)
                        {
                            Console.WriteLine("Mã số sinh viên này đã được tồn tại hoặc không hợp lệ!");
                            checkTrung = true;
                        }
                    }

                } while (checkTrung);

                do
                {
                    Console.Write("Năm sinh: ");
                    try
                    {
                        namSinh[i] = Convert.ToInt32(Console.ReadLine());
                        if (namSinh[i] < 1800 || namSinh[i] > 2023)
                        {
                            Console.WriteLine("Năm sinh nhập không hợp lệ, xin hãy kiểm tra lại!");
                        }
                        else
                            break;
                    }
                    catch
                    {

                        Console.WriteLine("Dữ nhập nhập không được cho phép!");
                    }
                } while (true);

            }

            int luaChon, checkNhapTuoi;

            Console.WriteLine("Bạn có muốn thêm tuổi cho từng sinh viên không?");
            do
            {
                checkNhapTuoi = 0;

                Console.Write("\n[1]. Yes\n[2]. No\nBạn chọn: ");
                try
                {
                    luaChon = Convert.ToInt32(Console.ReadLine());
                    if (luaChon == 1)
                    {
                        checkNhapTuoi = 1;
                        break;
                    }
                    else if (luaChon == 2)
                    {
                        checkNhapTuoi = 2;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lựa chọn nhập không hợp lệ, xin hãy kiểm tra lại!");
                    }
                }
                catch
                {
                    Console.WriteLine("Dữ liệu nhập không được cho phép!");
                }

            } while (checkNhapTuoi < 1 || checkNhapTuoi > 2);

            if (checkNhapTuoi == 1)
            {

                for (int i = 0; i < n; ++i)
                {
                    tuoiSv[i] = namHienTai - namSinh[i];
                }

                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine($"\nThông tin sinh viên thứ {i + 1}:");
                    Console.WriteLine($"- Họ & tên: {ten[i]}\n- Mã số sinh viên: {Msv[i]}\n- Năm sinh của sinh viên: {namSinh[i]}\n- Tuổi của sinh viên: {tuoiSv[i]}");
                }

            }
            else
            {
                int y = 11;
                for (int i = 0; i < n; ++i)
                {
                    int x = 0;
                    Console.SetCursorPosition(57, y + i + x++);
                    Console.WriteLine($"Thông tin sinh viên thứ {i + 1}:");
                    Console.SetCursorPosition(57, y + i + x++);
                    Console.WriteLine($"- Họ & tên: {ten[i]}");
                    Console.SetCursorPosition(57, y + i + x++);
                    Console.WriteLine($"- Mã số sinh viên: {Msv[i]}");
                    Console.SetCursorPosition(57, y + i + x++);
                    Console.WriteLine($"- Năm sinh của sinh viên: {namSinh[i]}");
                    Console.SetCursorPosition(57, y + i + x++);
                    y += 4;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}