using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi6
{
    internal class CheckInput
    {
        public bool ContainsNumber(string input)
        {
            if (input.Any(char.IsDigit))
            {
                Console.WriteLine("Không được chứa chữ số!");
                return true;
            }
            else
                return false;
        }
        public bool CheckContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            if (specialCharRegex.IsMatch(input))
            {
                Console.WriteLine("Không được chứa kí tự đặc biệt!");
                return true;
            }
            else
                return false;
        }
        public bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Không được để trống hay chỉ chứa khoảng trắng!");
                return true;
            }
            else
                return false;
        }
        public bool CheckBirthDay(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                DateTime now = DateTime.Now;
                TimeSpan interval = now - date;
                if (interval.Days > 0)
                {
                    int valid = now.Year - date.Year;
                    if (valid >= 18)
                        return true;
                    else
                    {
                        Console.WriteLine("Tuổi của sinh viên không được nhỏ hơn 18!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Ngày sinh nhập vào không được lớn hơn thời gian hiện tại!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Định dạng ngày không hợp lệ!");
                return false;
            }
        }
        public bool CheckCourse(int input)
        {
            DateTime now = DateTime.Now;
            if (now.Year - input < 0)
            {
                Console.WriteLine("Niên khóa nhập vào không được lớn hơn năm hiện tại!");
                return false;
            }
            else
                return true;
        }
    }

    internal struct SinhVien
    {
        internal string MaSoSinhVien { get; set; }
        internal string HoTen { get; set; }
        internal DateTime NgaySinh { get; set; }
        internal int NienKhoa { get; set; }
        internal SinhVien(string maSo, string hoVaTen, DateTime ngaySinh, int nienKhoa)
        {
            MaSoSinhVien = maSo;
            HoTen = hoVaTen;
            NgaySinh = ngaySinh;
            NienKhoa = nienKhoa;
        }
        internal string HienThiThongTin()
        {
            return $"Mã số sinh viên: {MaSoSinhVien}, Họ và tên: {HoTen}, Ngày sinh: {NgaySinh:dd/MM/yyyy}, Niên khóa: {NienKhoa}";
        }
    }

    // Bài 1: Sử dụng Generic Class
    internal class Bai1 : CheckInput
    {
        MyGeneric<SinhVien> dsSinhVien;
        
        public void ThucThiBai1()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuBai1();
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số và không được bỏ trống!");
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            NhapDanhSachSinhVien();
                            break;
                        case 2:
                            HienThiDanhSachSinhVien();
                            Console.WriteLine();
                            break;
                        case 3:
                            XoaMotSinhVien();
                            break;
                        case 4:
                            TimKiemTheoMaSoSinhVien();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai1()
        {
            Console.WriteLine("\n-----Quản Lý Sinh Viên-----");
            Console.WriteLine("1. Nhập danh sách sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên đã nhập");
            Console.WriteLine("3. Xóa 1 sinh viên trong danh sách");
            Console.WriteLine("4. Tìm kiếm sinh viên theo mã số");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void NhapDanhSachSinhVien()
        {
            int SoLuong;
            Console.Write("Số lượng sinh viên muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out SoLuong))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                Console.WriteLine("Khởi tạo danh sách gồm " + SoLuong + " sinh viên");
                dsSinhVien = new MyGeneric<SinhVien>(SoLuong);
            }                   

            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("\nNhập thông tin sinh viên thứ " + (i+1));
                SinhVien sv_moi = NhapMotSinhVien();
                dsSinhVien.AddItem(sv_moi);
            }
        }
        public SinhVien NhapMotSinhVien()
        {
            string maSo;
            string hoTen;
            DateTime ngaySinh = new DateTime();
            int nienKhoa;

            // Nhập mã sinh viên
            bool valid = true;
            do
            {
                Console.Write("Nhập mã sinh viên: ");
                maSo = Console.ReadLine();
                if (CheckContainSpecialChar(maSo) || CheckIsNullOrWhiteSpace(maSo))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập họ tên           
            do
            {
                Console.Write("Nhập họ tên sinh viên: ");
                hoTen = Console.ReadLine();
                if (CheckContainSpecialChar(hoTen) || CheckIsNullOrWhiteSpace(hoTen) || ContainsNumber(hoTen))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập ngày sinh
            do
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                string NgaySinh = Console.ReadLine();
                if (CheckBirthDay(NgaySinh))
                {
                    ngaySinh = DateTime.ParseExact(NgaySinh, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    valid = true;
                }
                else
                    valid = false;
            } while (!valid);

            // Nhập niên khóa
            do
            {
                Console.Write("Nhập niên khóa: ");
                if (!Int32.TryParse(Console.ReadLine(), out nienKhoa))
                {
                    Console.WriteLine("Niên khóa phải là số nguyên và không được để trống!");
                    valid = false;
                }   
                else
                {
                    if (!CheckCourse(nienKhoa))
                        valid = false;
                    else
                        valid = true;
                }    
            } while (!valid);

            // Khởi tạo đối tượng Sinh Viên sau khi nhập thành công
            SinhVien sv = new SinhVien(maSo, hoTen, ngaySinh, nienKhoa);
            return sv;
        }
        public void HienThiMotSinhVien(int index)
        {
            Console.WriteLine(dsSinhVien.GetItem(index).HienThiThongTin());
        }
        public void HienThiDanhSachSinhVien()
        {
            Console.WriteLine("\nDanh sách sinh viên hiện có: ");
            for (int i = 0; i < dsSinhVien.Count(); i++)
            {
                HienThiMotSinhVien(i);
            }
        }
        public void XoaMotSinhVien()
        {
            int index = ViTriTrongDanhSach();
            if (index != -1)
            {
                dsSinhVien.RemoveItem(index);
                Console.WriteLine("Đã xóa thành công sinh viên!");
            }    
            else
                Console.WriteLine("Không tìm thấy sinh viên để xóa!");
        }
        public int ViTriTrongDanhSach()
        {
            string maSoCanXoa;
            bool valid;
            do
            {
                Console.Write("\nNhập mã sinh viên cần tìm: ");
                maSoCanXoa = Console.ReadLine();
                if (CheckContainSpecialChar(maSoCanXoa) || CheckIsNullOrWhiteSpace(maSoCanXoa))
                    valid = false;
                else
                    valid = true;                
            } while (!valid);

            for (int i = 0; i < dsSinhVien.Count(); i++)
            {
                if (maSoCanXoa == dsSinhVien.GetItem(i).MaSoSinhVien)
                    return i;
            }
            return -1;
        }
        public void TimKiemTheoMaSoSinhVien()
        {
            int index = ViTriTrongDanhSach();
            if (index != -1)
            {
                Console.WriteLine("\nThông tin sinh viên cần tìm là: ");
                HienThiMotSinhVien(index);
            }   
        }
    }

    // Bài 2: Sử dụng Dictionary
    internal class Bai2 : CheckInput
    {

        Dictionary<string, SinhVien> sinhVienDict = new Dictionary<string, SinhVien>();
        public void AddItem(SinhVien sv)
        {
            sinhVienDict.Add(sv.MaSoSinhVien, sv);
        }
        public SinhVien GetItem(string maSoSinhVien)
        {
            return sinhVienDict[maSoSinhVien];
        }

        public void ThucThiBai2()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuBai2();
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số và không được bỏ trống!");
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            NhapDanhSachSinhVien();
                            break;
                        case 2:
                            HienThiDanhSachSinhVien();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai2()
        {
            Console.WriteLine("\n-----Quản Lý Sinh Viên Dùng Dictionary-----");
            Console.WriteLine("1. Nhập danh sách sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên đã nhập");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }    
        public void NhapDanhSachSinhVien()
        {
            int SoLuong;
            Console.Write("Số lượng sinh viên muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out SoLuong))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                Console.WriteLine("Khởi tạo danh sách gồm " + SoLuong + " sinh viên");
            }

            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("\nNhập thông tin sinh viên thứ " + (i + 1));
                SinhVien sv_moi = NhapMotSinhVien();
                AddItem(sv_moi);
            }
        }
        public SinhVien NhapMotSinhVien()
        {
            string maSo;
            string hoTen;
            DateTime ngaySinh = new DateTime();
            int nienKhoa;

            // Nhập mã sinh viên
            bool valid = true;
            do
            {
                Console.Write("Nhập mã sinh viên: ");
                maSo = Console.ReadLine();
                if (CheckContainSpecialChar(maSo) || CheckIsNullOrWhiteSpace(maSo))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập họ tên           
            do
            {
                Console.Write("Nhập họ tên sinh viên: ");
                hoTen = Console.ReadLine();
                if (CheckContainSpecialChar(hoTen) || CheckIsNullOrWhiteSpace(hoTen) || ContainsNumber(hoTen))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập ngày sinh
            do
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                string NgaySinh = Console.ReadLine();
                if (CheckBirthDay(NgaySinh))
                {
                    ngaySinh = DateTime.ParseExact(NgaySinh, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    valid = true;
                }
                else
                    valid = false;
            } while (!valid);

            // Nhập niên khóa
            do
            {
                Console.Write("Nhập niên khóa: ");
                if (!Int32.TryParse(Console.ReadLine(), out nienKhoa))
                {
                    Console.WriteLine("Niên khóa phải là số nguyên và không được để trống!");
                    valid = false;
                }
                else
                {
                    if (!CheckCourse(nienKhoa))
                        valid = false;
                    else
                        valid = true;
                }
            } while (!valid);

            // Khởi tạo đối tượng Sinh Viên sau khi nhập thành công
            SinhVien sv = new SinhVien(maSo, hoTen, ngaySinh, nienKhoa);
            return sv;
        }
        public void HienThiMotSinhVien(KeyValuePair<string, SinhVien> input)
        {
            Console.WriteLine(GetItem(input.Value.MaSoSinhVien).HienThiThongTin());
        }
        public void HienThiDanhSachSinhVien()
        {
            Console.WriteLine("\nDanh sách sinh viên hiện có: ");
            foreach (KeyValuePair<string, SinhVien> item in sinhVienDict)
            {
                HienThiMotSinhVien(item);
            }    
        }
    }

    // Bài 3: Hoán vị các kiểu dữ liệu khác nhau
    internal class Bai3 : CheckInput
    {
        public void ThucThiBai3()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuBai3();
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số và không được bỏ trống!");
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            HoanViHaiSoNguyen();
                            break;
                        case 2:
                            HoanViHaiSoThuc();
                            Console.WriteLine();
                            break;
                        case 3:
                            HoanViHaiChuoi();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai3()
        {
            Console.WriteLine("\n-----Hoán Vị-----");
            Console.WriteLine("1. 2 số nguyên");
            Console.WriteLine("2. 2 số thực");
            Console.WriteLine("3. 2 chuỗi");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void HoanViHaiSoNguyen()
        {
            int num1 = 0, num2 = 0;
            bool valid;
            do
            {
                Console.WriteLine("Nhập vào 2 số nguyên: ");
                if (!Int32.TryParse(Console.ReadLine(), out num1) || !Int32.TryParse(Console.ReadLine(),out num2))
                {
                    Console.WriteLine("Yêu cầu nhập vào 2 số nguyên!");   
                    valid = false;
                }
                else valid = true;
            } while (!valid);
            Swap<int>(ref num1 , ref num2);
            Console.WriteLine(num1 + " " + num2);
        }
        public void HoanViHaiSoThuc()
        {
            double num1 = 0, num2 = 0;
            bool valid;
            do
            {
                Console.WriteLine("Nhập vào 2 số thực: ");
                if (!Double.TryParse(Console.ReadLine(), out num1) || !Double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Yêu cầu nhập vào 2 số thực!");
                    valid = false;
                }
                else valid = true;
            } while (!valid);
            Swap<double>(ref num1, ref num2);
            Console.WriteLine(num1 + " " + num2);
        }
        public void HoanViHaiChuoi()
        {
            bool valid;
            string str1, str2;
            do
            {
                Console.WriteLine("Nhập vào 2 chuỗi: ");
                str1 = Console.ReadLine();
                str2 = Console.ReadLine();
                if (CheckContainSpecialChar(str1) || CheckIsNullOrWhiteSpace(str1) || CheckContainSpecialChar(str2) || CheckIsNullOrWhiteSpace(str2))
                {
                    Console.WriteLine("Yêu cầu nhập vào 2 chuỗi!");
                    valid = false;
                }
                else valid = true;
            } while (!valid);
            Swap<string>(ref str1, ref str2);
            Console.WriteLine(str1 + "," + str2);
        }
        public void Swap<T>(ref T element1, ref T element2)
        {
            T temp = element1;
            element1 = element2;
            element2 = temp;
        }
    }
}
