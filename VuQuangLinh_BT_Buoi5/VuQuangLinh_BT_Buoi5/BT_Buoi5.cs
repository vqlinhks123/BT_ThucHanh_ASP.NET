using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static VuQuangLinh_BT_Buoi5.Bai1;

namespace VuQuangLinh_BT_Buoi5
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
                    if (valid >= 16)
                        return true;
                    else
                    {
                        Console.WriteLine("Tuổi của nhân viên không được nhỏ hơn 16!");
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
        public bool CheckDayOfWork(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                DateTime now = DateTime.Now;
                TimeSpan interval = now - date;
                if (interval.Days > 0)
                    return true;
                else
                {
                    Console.WriteLine("Ngày vào làm không được lớn hơn thời gian hiện tại!");
                    return false;
                }    
            }
            else
            {
                Console.WriteLine("Định dạng ngày không hợp lệ!");
                return false;
            }
        }
        public bool CheckExpiredDate(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                DateTime now = DateTime.Now;
                TimeSpan interval = now - date;
                if (interval.Days < 0)
                    return true;
                else
                {
                    Console.WriteLine("Ngày hết hạn không được nhỏ hơn thời gian hiện tại!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Định dạng ngày không hợp lệ!");
                return false;
            }
        }
    }

    internal class Bai1 : CheckInput
    {
        internal struct NhanVien
        {
            internal string MaNhanVien { get; set; }
            internal string HoDem { get; set; }
            internal string Ten { get; set; }
            internal DateTime NgaySinh { get; set; }
            internal DateTime NgayVaoLam { get; set; }
        }
        List<NhanVien> dsNhanVien;
        public void ThucThiBai1()
        {         
            bool flag = false;
            int choice = -1;
            do
            {
                MenuQuanLyNhanVien();
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
                            NhapDanhSachNhanVien();
                            break;
                        case 2:
                            HienThiDanhSachNhanVien();
                            Console.WriteLine();
                            break;
                        case 3:
                            SapXepTheoNgaySinhGiamDan();
                            break;
                        case 4:
                            DanhSachTu5NamLamViec();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuQuanLyNhanVien()
        {
            Console.WriteLine("\n-----Quản Lý Nhân Viên-----");
            Console.WriteLine("1. Nhập danh sách nhân viên");
            Console.WriteLine("2. Hiển thị danh sách nhân viên đã nhập");
            Console.WriteLine("3. Sắp xếp danh sách nhân viên theo ngày sinh giảm dần");
            Console.WriteLine("4. In ra danh sách nhân viên có số năm làm việc nhiều hơn 5 năm");
            Console.WriteLine("0. Thoát chương trình");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void NhapDanhSachNhanVien()
        {
            int SoLuong;
            Console.Write("Số lượng nhân viên muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out SoLuong))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                dsNhanVien = new List<NhanVien>(SoLuong);
                for (int i = 0; i < SoLuong; i++)
                {
                    Console.WriteLine("\nNhập thông tin nhân viên thứ " + (i+1));
                    NhanVien nhan_vien_moi = new NhanVien();
                    NhapThongTinNhanVien(ref nhan_vien_moi);
                    dsNhanVien.Add(nhan_vien_moi);    
                }
            }
        }
        public void NhapThongTinNhanVien(ref NhanVien nv)
        {
            // Nhập mã nhân viên
            bool valid = true;
            do
            {
                Console.Write("Nhập mã nhân viên: ");
                nv.MaNhanVien = Console.ReadLine();
                if (CheckContainSpecialChar(nv.MaNhanVien) || CheckIsNullOrWhiteSpace(nv.MaNhanVien)) 
                    valid = false;  
                else
                    valid = true;
            } while (!valid);

            // Nhập họ đệm
            do
            {
                Console.Write("Nhập họ đệm của nhân viên: ");
                nv.HoDem = Console.ReadLine();
                if (CheckContainSpecialChar(nv.HoDem) || CheckIsNullOrWhiteSpace(nv.HoDem) || ContainsNumber(nv.HoDem))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập tên
            do
            {
                Console.Write("Nhập tên nhân viên: ");
                nv.Ten = Console.ReadLine();
                if (CheckContainSpecialChar(nv.Ten) || CheckIsNullOrWhiteSpace(nv.Ten) || ContainsNumber(nv.Ten))
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
                    nv.NgaySinh = DateTime.ParseExact(NgaySinh, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    valid = true;
                }                      
                else
                    valid = false;
            } while (!valid);

            // Nhập ngày vào làm
            do
            {
                Console.Write("Nhập ngày vào làm (dd/MM/yyyy): ");
                string NgayVaoLam = Console.ReadLine();
                if (CheckDayOfWork(NgayVaoLam))
                { 
                    nv.NgayVaoLam = DateTime.ParseExact(NgayVaoLam, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if ((nv.NgayVaoLam.Year - nv.NgaySinh.Year) < 16)
                    {
                        Console.WriteLine("Ở thời điểm vào làm nhân viên phải đủ 16 tuổi!");
                        valid = false;
                    }
                    else
                        valid = true;
                }
                else
                    valid = false;
            } while (!valid);
        }
        public void HienThiDanhSachNhanVien()
        {
            Console.WriteLine("\nDanh sách các nhân viên hiện có: ");
            int count = 1;
            foreach (NhanVien nv in dsNhanVien)
            {
                if (count <= dsNhanVien.Count)
                {
                    Console.Write("\n" + count + ". ");
                    HienThiThongTinNhanVien(nv);
                    count++;
                }    
            }
        }
        public void HienThiThongTinNhanVien(NhanVien nv)
        {
            Console.Write("Mã nhân viên: " + nv.MaNhanVien + ", Họ đệm: " + nv.HoDem + ", Tên: " + nv.Ten + ", Ngày sinh: " + nv.NgaySinh + ", Ngày vào làm: " + nv.NgayVaoLam);
        }
        public void DanhSachTu5NamLamViec()
        {
            Console.WriteLine("\nDanh sách các nhân viên làm việc từ 5 năm trở lên: ");
            int count = 1;
            DateTime now = DateTime.Now;
            foreach (NhanVien nv in dsNhanVien)
            {
                int experience = now.Year - nv.NgayVaoLam.Year;
                if (count <= dsNhanVien.Count && experience >= 5)
                {
                    Console.Write("\n" + count + ". ");
                    HienThiThongTinNhanVien(nv);
                    count++;
                }
            }
        }
        public void SapXepTheoNgaySinhGiamDan()
        {
            for (int i = 0; i < dsNhanVien.Count - 1; i++)
            {
                for (int j = i+1; j < dsNhanVien.Count; j++)
                {
                    if (DateTime.Compare(dsNhanVien[i].NgaySinh,dsNhanVien[j].NgaySinh) < 0)
                    {
                        NhanVien temp;
                        temp = dsNhanVien[i];
                        dsNhanVien[i] = dsNhanVien[j];
                        dsNhanVien[j] = temp;
                    }    
                }
            }
            Console.WriteLine("Sắp xếp thành công!");
        }
    }

    internal class Bai2 : CheckInput
    {
        internal struct Product
        {
            internal string ProductName { get; set; }
            internal double ProductPrice { get; set; }
            internal DateTime ExpiredDate { get; set; }

            internal int CalculateExpiredDay()
            {
                DateTime now = DateTime.Now;
                TimeSpan exp_day = this.ExpiredDate - now;
                if (exp_day.Days < 180 && exp_day.Days > 0)
                    return exp_day.Days;
                else
                    return 0;
            }
        }

        List<Product> list_product = new List<Product>();
        public void ThucThiBai2()
        {
            bool flag = false;
            int choice = -1;
            do
            {
                MenuManageProduct();
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
                            InputListProduct();
                            break;
                        case 2:
                            DisplayListProduct();
                            Console.WriteLine();
                            break;
                        case 3:
                            ExpiredDateWithin30Day();
                            break;
                        case 4:
                            NameOver10Char();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuManageProduct()
        { 
            Console.WriteLine("\n-----Quản Lý Sản Phẩm-----");
            Console.WriteLine("1. Nhập danh sách sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm đã nhập");
            Console.WriteLine("3. In ra các sản phẩm có ngày hết hạn trong vòng 30 ngày");
            Console.WriteLine("4. In ra các sản phẩm có tên dài hơn 10 kí tự");
            Console.WriteLine("0. Thoát chương trình");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void InputListProduct()
        {
            int num;
            Console.Write("Số lượng sản phẩm muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                list_product = new List<Product>(num);
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("\nNhập thông tin sản phẩm thứ " + (i + 1));
                    Product new_product = new Product();
                    InputProduct(ref new_product);
                    list_product.Add(new_product);
                }
            }
        }
        public void InputProduct(ref Product product)
        {
            bool valid = true;
            // Nhập tên sản phẩm
            do
            {
                Console.Write("Nhập tên sản phẩm: ");
                product.ProductName = Console.ReadLine();
                if (CheckContainSpecialChar(product.ProductName) || CheckIsNullOrWhiteSpace(product.ProductName) || ContainsNumber(product.ProductName))
                    valid = false;
                else
                    valid = true;
            } while (!valid); 

            // Nhập giá sản phẩm
            do
            {
                double price;
                Console.Write("Nhập giá sản phẩm: ");
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    if (price <= 0)
                    {
                        Console.WriteLine("Giá sản phẩm không thể âm và không bằng 0!");
                        valid= false;
                    }
                    else
                    {
                        product.ProductPrice = price;
                        valid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Giá sản phẩm không được quá lớn, không chứa kí tự, để trống hay khoảng trắng!");
                    valid = false;
                }    
            } while (!valid);

            // Nhập ngày hết hạn
            do
            {
                Console.Write("Nhập ngày hết hạn: ");
                string exp_date = Console.ReadLine();
                if (CheckExpiredDate(exp_date))
                {
                    product.ExpiredDate = DateTime.ParseExact(exp_date,"dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (product.CalculateExpiredDay() == 0)
                        valid = false;
                    else
                        valid = true;
                }    
                else
                    valid = false;
            } while (!valid);
        }
        public void DisplayListProduct()
        {
            Console.WriteLine("\nDanh sách các sản phẩm hiện có: ");
            int count = 1;
            foreach (Product product in list_product)
            {
                if (count <= list_product.Count)
                {
                    Console.Write("\n" + count + ". ");
                    DisplayProduct(product);
                    count++;
                }
            }
        }
        public void DisplayProduct(Product product)
        {
            Console.Write("Tên sản phẩm: " + product.ProductName + ", Giá sản phẩm: " + product.ProductPrice + ", Ngày hết hạn: " + product.ExpiredDate);
        }
        public void ExpiredDateWithin30Day()
        {
            Console.WriteLine("\nDanh sách các sản phẩm có ngày hết hạn trong vòng 30 ngày: ");
            int count = 1;
            foreach (Product product in list_product)
            {
                if (count <= list_product.Count && product.CalculateExpiredDay() <= 30)
                {
                    Console.Write("\n" + count + ". ");
                    DisplayProduct(product);
                    count++;
                }
            }
        }
        public void NameOver10Char()
        {
            Console.WriteLine("\nDanh sách các sản phẩm có tên dài hơn 10 kí tự: ");
            int count = 1;
            foreach (Product product in list_product)
            {
                if (count <= list_product.Count && product.ProductName.Length > 10)
                {
                    Console.Write("\n" + count + ". ");
                    DisplayProduct(product);
                    count++;
                }
            }
        }
    }
}
