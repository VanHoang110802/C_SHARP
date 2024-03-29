using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class QuanLySach
    {
        List<Sach> _lstSach;
        Sach _sach;

        public QuanLySach()
        {
            _lstSach = new List<Sach>();
        }

        public void NhapThongTin()
        {

            int checkTiepTuc = 0;
            string tiepTuc, chuanHoa;
            bool checkIDTrung = false;
            do
            {
                _sach = new Sach();
                _sach.NhapThongTin();
                _lstSach.Add(_sach);

                int soLuongPhanTu = _lstSach.Count;
                if (soLuongPhanTu > 1)
                {
                    for (int i = 0; i < soLuongPhanTu - 1; ++i)
                    {
                        for (int j = i + 1; j < soLuongPhanTu; ++j)
                        {
                            if (_lstSach[i].IdSach == _lstSach[j].IdSach)
                            {
                                checkIDTrung = true;
                                break;
                            }
                        }
                        if (checkIDTrung == true)
                        {
                            break;
                        }
                    }
                }
                if (checkIDTrung == false)
                {
                    do
                    {
                        Console.Write("\nBan co muon nhap tiep khong? (co/khong) ");
                        tiepTuc = Console.ReadLine();
                        chuanHoa = _sach.ChuanHoaChuoi(tiepTuc);
                        checkTiepTuc = _sach.CheckInput(chuanHoa, "Co", "Khong");

                        if (checkTiepTuc == -1)
                        {
                            Console.WriteLine("\nLua chon nhap khong hop le, xin hay kiem tra lai!!\n");
                        }
                        else
                            break;

                    } while (true);

                    if (checkTiepTuc == 0)
                    {
                        Console.Write("\nDa luu thong tin!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Ma ID nay da bi trung truoc do, xin hay kiem tra lai!!\n");

                    checkIDTrung = false;
                    int demLai = _lstSach.Count;
                    _lstSach.RemoveAt(demLai - 1);

                }
                Console.WriteLine();
            } while (checkTiepTuc != 0);
        }

        public void SapXepSach()
        {
            int demSoLuong = _lstSach.Count;
            if (demSoLuong > 0)
            {
                int luaChonSX;
                do
                {
                    Console.WriteLine("Ban muon sap xep kieu gi?");
                    Console.WriteLine("\t[1]: Tang dan");
                    Console.WriteLine("\t[2]: Giam dan");
                    Console.Write("Ban chon: ");
                    luaChonSX = Convert.ToInt32(Console.ReadLine());
                    if (luaChonSX < 1 || luaChonSX > 2)
                        Console.WriteLine("Lua chon nhap khong hop le!!");
                } while (luaChonSX < 1 || luaChonSX > 2);


                if (luaChonSX == 1)
                    _lstSach.Sort(delegate (Sach s1, Sach s2) { return s1.IdSach.CompareTo(s2.IdSach); });

                else
                    _lstSach.Sort(delegate (Sach s1, Sach s2) { return s2.IdSach.CompareTo(s1.IdSach); });


                Console.WriteLine("Sap xep thanh cong!!!");
            }
            else
            {
                Console.WriteLine("\nXin hay nhap thong tin!!!");
            }
            
        }

        public void XuatThongTin()
        {
            int demSoLuong = _lstSach.Count;
            if (demSoLuong > 0)
            {
                for (int i = 0; i < demSoLuong; ++i)
                {
                    Console.WriteLine();
                    _lstSach[i].XuatThongTin();
                }
            }
            else
            {
                Console.WriteLine("\nXin hay nhap thong tin!!!");
            }
        }

    }
}
