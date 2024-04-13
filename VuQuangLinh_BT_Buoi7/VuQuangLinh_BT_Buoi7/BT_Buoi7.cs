using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static VuQuangLinh_BT_Buoi7.Bai1;
using static VuQuangLinh_BT_Buoi7.Bai2;

namespace VuQuangLinh_BT_Buoi7
{
    public class Bai1 : CheckInput
    {
        internal class Book
        {
            internal string Title { get; set; }
            internal string Author { get; set; }
            internal string ISBN { get; set; }
            internal int Price { get; set; }
            internal Book(string tieu_de, string tac_gia, string _isbn, int gia)
            {
                Title = tieu_de;
                Author = tac_gia;
                ISBN = _isbn;
                Price = gia;
            }
            internal string Display()
            {
                return $"Tiêu đề: {Title}, Tác giả: {Author}, ISBN: {ISBN}, Giá: {Price}";
            }
        }
        internal class Library
        {
            private List<Book> books;
            internal Library(int size)
            {
                books = new List<Book>(size);
            }
            internal void AddBook(Book book)
            {
                books.Add(book);
            }
            internal Book GetBook(int index)
            {
                return books[index];
            }
            internal int Count()
            {
                return books.Count;
            }
            internal Book SearchByAuthor(string author)
            {
                return books.FirstOrDefault(book => book.Author == author);
            }
            internal Book SearchByISBN(string _isbn)
            {
                return books.FirstOrDefault(book => book.ISBN == _isbn);
            }
            internal void BorrowBook(string _isbn)
            {
                var borrow_book = SearchByISBN(_isbn);
                if (borrow_book != null)
                {
                    books.Remove(borrow_book);
                    Console.WriteLine($"Bạn đã mượn cuốn sách: {borrow_book.Title}");
                }
                else
                {
                    Console.WriteLine("Cuốn sách này không có trong thư viện!");
                }
            }
            internal void ReturnBook(Book book)
            {
                books.Add(book);
                Console.WriteLine($"Bạn đã trả lại cuốn sách: {book.Title}");
            }
        }

        Library manageBooks;

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
                            ThemSach();
                            Console.WriteLine();
                            break;
                        case 2:
                            HienThiTatCaSach();
                            Console.WriteLine();
                            break;
                        case 3:
                            TimKiemSach();
                            Console.WriteLine();
                            break;
                        case 4:
                            MuonSach();
                            Console.WriteLine();
                            break;
                        case 5:
                            TraSach();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai1()
        {
            Console.WriteLine("\n-----Quản Lý Sách Trong Thư Viện-----");
            Console.WriteLine("1. Thêm sách mới");
            Console.WriteLine("2. Hiển thị tất cả sách");
            Console.WriteLine("3. Tìm kiếm sách");
            Console.WriteLine("4. Mượn sách");
            Console.WriteLine("5. Trả sách");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void ThemSach()
        {
            int SoLuong;
            Console.Write("Số lượng sách muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out SoLuong))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                Console.WriteLine("Khởi tạo danh sách gồm " + SoLuong + " cuốn sách");
                manageBooks = new Library(SoLuong);
            }
            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("\nNhập thông tin cuốn sách thứ " + (i + 1));
                Book new_book = NhapThongTinSach();
                manageBooks.AddBook(new_book);
            }
        }
        internal Book NhapThongTinSach()
        {
            string tieu_de;
            string tac_gia;
            string _isbn;
            int price;
            // Nhập tiêu đề sách
            bool valid = true;
            do
            {
                Console.Write("Nhập tiêu đề sách: ");
                tieu_de = Console.ReadLine();
                if (CheckContainSpecialChar(tieu_de) || CheckIsNullOrWhiteSpace(tieu_de))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập tên tác giả         
            do
            {
                Console.Write("Nhập tên tác giả: ");
                tac_gia = Console.ReadLine();
                if (CheckContainSpecialChar(tac_gia) || CheckIsNullOrWhiteSpace(tac_gia) || ContainsNumber(tac_gia))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập mã ISBN
            do
            {
                Console.Write("Nhập mã số ISBN: ");
                _isbn = Console.ReadLine();
                if (CheckContainSpecialChar(_isbn) || CheckIsNullOrWhiteSpace(_isbn) || ContainsLetter(_isbn))            
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập giá sách
            do
            {
                Console.Write("Nhập giá sách: ");
                if (!Int32.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Giá cuốn sách phải là số nguyên và không được để trống!");
                    valid = false;
                }
                else
                {
                    if (price <= 0)
                    {
                        Console.WriteLine("Giá tiền không được bằng 0 hay là số âm!");
                        valid = false;
                    }
                    else
                        valid = true;
                } 
            } while (!valid);

            // Khởi tạo đối tượng Book sau khi nhập thành công
            Book new_book = new Book(tieu_de, tac_gia, _isbn, price);
            return new_book;
        }
        public void HienThiTatCaSach()
        {
            Console.WriteLine("\nDanh sách các cuốn sách đang có: ");
            for (int i = 0; i < manageBooks.Count(); i++)
            {
                Console.WriteLine((i+1) + ". " + manageBooks.GetBook(i).Display());
            }
        }
        public void TimKiemSach()
        {
            Console.WriteLine("\nNhập 1 để tìm kiếm theo tên tác giả, nhập 2 để tìm theo ISBN");
            int choice;
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lựa chọn phải là số nguyên và không được để trống!");
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Nhập vào tên tác giả của cuốn sách cần tìm: ");    
                        string author = Console.ReadLine();
                        if (CheckContainSpecialChar(author) || CheckIsNullOrWhiteSpace(author) || ContainsNumber(author))
                            break;
                        else
                        {
                            Book search_by_author = manageBooks.SearchByAuthor(author);
                            Console.WriteLine(search_by_author.Display());
                        }
                        break;
                    case 2:
                        Console.WriteLine("Nhập vào ISBN của cuốn sách cần tìm: ");
                        string isbn = Console.ReadLine();
                        if (CheckContainSpecialChar(isbn) || CheckIsNullOrWhiteSpace(isbn) || ContainsLetter(isbn))
                            break;
                        else
                        {
                            Book search_by_isbn = manageBooks.SearchByISBN(isbn);
                            Console.WriteLine(search_by_isbn.Display());
                        }
                        break;
                    default:
                        Console.WriteLine("Lựa chọn của bạn chưa đúng!"); break;
                }
            }    
        }
        public void MuonSach()
        {
            Console.WriteLine("Nhập vào ISBN của cuốn sách cần mượn: ");
            string isbn = Console.ReadLine();
            if (CheckContainSpecialChar(isbn) || CheckIsNullOrWhiteSpace(isbn) || ContainsLetter(isbn))
                return;
            else
            {
                Book search_by_isbn = manageBooks.SearchByISBN(isbn);
                Console.WriteLine(search_by_isbn.Display());
            }
            manageBooks.BorrowBook(isbn);
        }
        public void TraSach()
        {
            Console.WriteLine("Nhập thông tin sách trả: ");
            Book return_book = NhapThongTinSach();
            manageBooks.ReturnBook(return_book);
        }
    }
    public class Bai2 : CheckInput
    {
        public abstract class NhanVien
        {
            public string MaNhanVien { get; set; }
            public string TenNhanVien { get; set; }
            public abstract int TinhLuong();

            public string HienThiThongTin()
            {
                return $"Mã nhân viên: {MaNhanVien}, Tên nhân viên: {TenNhanVien}, Lương: {TinhLuong()}";
            }
        }
        internal class NhanVienToanThoiGian : NhanVien
        {
            public int LuongHangThang { get; set; }
            public override int TinhLuong()
            {
                return LuongHangThang;
            }
            public NhanVienToanThoiGian(string maNhanVien, string tenNhanVien, int luongHangThang)
            {
                MaNhanVien = maNhanVien;
                TenNhanVien = tenNhanVien;
                LuongHangThang = luongHangThang;
            }
        }
        internal class NhanVienBanThoiGian : NhanVien
        {
            public int LuongTheoGio { get; set; }
            public int SoGioLamViec { get; set; }
            public override int TinhLuong()
            {
                return  LuongTheoGio * SoGioLamViec;
            }
            public NhanVienBanThoiGian(string maNhanVien, string tenNhanVien, int luongTheoGio, int soGioLamViec)
            {
                MaNhanVien = maNhanVien;
                TenNhanVien = tenNhanVien;
                LuongTheoGio = luongTheoGio;
                SoGioLamViec = soGioLamViec;
            }
        }
        internal class NhanVienThucTap : NhanVien
        {
            public int LuongTheoTuan { get; set; }
            public override int TinhLuong()
            {
                return LuongTheoTuan * 4;
            }
            public NhanVienThucTap(string maNhanVien,string tenNhanVien,int luongTheoTuan)
            {
                MaNhanVien = maNhanVien;
                TenNhanVien = tenNhanVien;
                LuongTheoTuan = luongTheoTuan;
            }
        }

        List<NhanVien> dsNhanVien;
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
                            NhapDanhSachNhanVien();
                            Console.WriteLine();
                            break;
                        case 2:
                            TinhToanLuongChoNhanVien();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai2()
        {
            Console.WriteLine("\n-----Quản Lý Nhân Viên-----");
            Console.WriteLine("1. Nhập danh sách nhân viên");
            Console.WriteLine("2. Tính toán lương cho nhân viên");
            Console.WriteLine("0. Thoát");
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
                Console.WriteLine("Khởi tạo danh sách gồm " + SoLuong + " nhân viên");
                dsNhanVien = new List<NhanVien>(SoLuong);
            }

            for (int i = 0; i < SoLuong; i++)
            {
                Console.WriteLine("Nhập thông tin nhân viên thứ " + (i + 1));
                bool flag = false;
                int choice;
                do
                {
                    MenuNhapNhanVien();
                    if (!Int32.TryParse(Console.ReadLine(), out choice))
                        Console.WriteLine("Dữ liệu nhập vào phải là số và không được bỏ trống!");
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                NhapMotNhanVien(choice);
                                flag = true; Console.WriteLine(); break;
                            case 2:
                                NhapMotNhanVien(choice);
                                flag = true; Console.WriteLine(); break;
                            case 3:
                                NhapMotNhanVien(choice);
                                flag = true; Console.WriteLine(); break;
                            default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                        }
                    }
                } while (!flag);
            }
            
        }
        public void MenuNhapNhanVien()
        {
            Console.WriteLine("-----Chọn Kiểu Nhân Viên-----");
            Console.WriteLine("1. Nhân viên toàn thời gian");
            Console.WriteLine("2. Nhân viên bán thời gian");
            Console.WriteLine("3. Nhân viên thực tập");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void NhapMotNhanVien(int classify)
        {
            string maSo;
            string hoTen;

            // Nhập mã nhân viên
            bool valid = true;
            do
            {
                Console.Write("Nhập mã nhân viên: ");
                maSo = Console.ReadLine();
                if (CheckContainSpecialChar(maSo) || CheckIsNullOrWhiteSpace(maSo))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập họ tên           
            do
            {
                Console.Write("Nhập họ tên nhân viên: ");
                hoTen = Console.ReadLine();
                if (CheckContainSpecialChar(hoTen) || CheckIsNullOrWhiteSpace(hoTen) || ContainsNumber(hoTen))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập dựa theo phân loại nhân viên
            if (classify == 1) // Nhân viên toàn thời gian
            {
                // Nhập lương hàng tháng
                int luongThang;
                do
                {
                    Console.Write("Nhập tiền lương hàng tháng: ");
                    if (!Int32.TryParse(Console.ReadLine(), out luongThang))
                    {
                        Console.WriteLine("Tiền lương phải là số nguyên và không được để trống!");
                        valid = false;
                    }
                    else
                    {
                        if (luongThang <= 0)
                        {
                            Console.WriteLine("Tiền lương không được bằng 0 hay là số âm!");
                            valid = false;
                        }
                        else
                            valid = true;
                    }
                } while (!valid);
                NhanVien nv_fulltime = new NhanVienToanThoiGian(maSo,hoTen,luongThang);
                dsNhanVien.Add(nv_fulltime);
            }
            else if (classify == 2) // Nhân viên bán thời gian
            {
                // Nhập lương theo giờ
                int luongTheoGio;
                do
                {
                    Console.Write("Nhập tiền lương theo giờ: ");
                    if (!Int32.TryParse(Console.ReadLine(), out luongTheoGio))
                    {
                        Console.WriteLine("Tiền lương phải là số nguyên và không được để trống!");
                        valid = false;
                    }
                    else
                    {
                        if (luongTheoGio <= 0)
                        {
                            Console.WriteLine("Tiền lương không được bằng 0 hay là số âm!");
                            valid = false;
                        }
                        else
                            valid = true;
                    }
                } while (!valid);

                // Nhập số giờ làm việc trong tháng
                int gioLamViec;
                do
                {
                    Console.Write("Nhập tổng số giờ làm việc trong tháng (nhân viên partime làm từ 4-6 giờ/ngày): ");
                    if (!Int32.TryParse(Console.ReadLine(), out gioLamViec))
                    {
                        Console.WriteLine("Thời gian làm phải là số nguyên và không được để trống!");
                        valid = false;
                    }
                    else
                    {
                        if (gioLamViec <= 0 || gioLamViec > 180)
                        {
                            Console.WriteLine("Thời gian làm không được nhỏ hơn hoặc bằng 0, hay lớn hơn 180 giờ!");
                            valid = false;
                        }
                        else
                            valid = true;
                    }
                } while (!valid);
                NhanVien nv_parttime = new NhanVienBanThoiGian(maSo,hoTen,luongTheoGio,gioLamViec);
                dsNhanVien.Add(nv_parttime);
            }
            else // Nhân viên thực tập
            {
                // Nhập lương theo tuần
                int luongTheoTuan;
                do
                {
                    Console.Write("Nhập tiền lương theo tuần: ");
                    if (!Int32.TryParse(Console.ReadLine(), out luongTheoTuan))
                    {
                        Console.WriteLine("Tiền lương phải là số nguyên và không được để trống!");
                        valid = false;
                    }
                    else
                    {
                        if (luongTheoTuan <= 0)
                        {
                            Console.WriteLine("Tiền lương không được bằng 0 hay là số âm!");
                            valid = false;
                        }
                        else
                            valid = true;
                    }
                } while (!valid);
                NhanVien nv_intern = new NhanVienThucTap(maSo,hoTen,luongTheoTuan);
                dsNhanVien.Add(nv_intern);
            }
        }
        public void TinhToanLuongChoNhanVien()
        {
            foreach (NhanVien nv in dsNhanVien)
            {
                Console.WriteLine(nv.HienThiThongTin());
            }    
        }
    }
    public class Bai3 : CheckInput
    {
        public class Product
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public int Price { get; set; }
            public Product(string productId, string productName, int price)
            {
                ProductId = productId;
                ProductName = productName;
                Price = price;
            }
            public string Display()
            {
                return $"Mã sản phẩm: {ProductId}, Tên sản phẩm: {ProductName}, Giá: {Price}";
            }
        }
        public interface IProduct
        {
            void Insert(Product product);
            void Update(Product product);
            void Delete(string productId);
            Product Search(string productId);
            void DeleteMultiple(List<string> productIds);
        }
        public class ImplementIProduct : IProduct
        {
            private List<Product> products;
            public ImplementIProduct(int size)
            {
                products = new List<Product>(size);
            }
            public Product getProduct(int index)
            {
                return products[index];
            }
            public int Count()
            {
                return (int)products.Count;
            }
            public void Insert(Product product)
            {
                products.Add(product);
            }
            public void Update(Product product)
            {
                var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Price = product.Price;
                    Console.WriteLine("Cập nhật thành công sản phẩm có mã là " + product.ProductId);
                }
                else
                    Console.WriteLine("Mã sản phẩm cần cập nhật không khớp với sản phẩm hiện có trong danh sách!");
            }
            public void Delete(string productId)
            {
                var product = products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    products.Remove(product);
                    Console.WriteLine("Xóa thành công sản phẩm có mã là " + productId);
                }
                else
                    Console.WriteLine("Không tìm thấy sản phẩm cần xóa!");
            }
            public Product Search(string productId)
            {
                return products.FirstOrDefault(p => p.ProductId == productId);
            }
            public void DeleteMultiple(List<string> productIds)
            {
                foreach (var id in productIds)
                {
                    Delete(id);
                }
            }
        }
        ImplementIProduct manageProduct;
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
                            ImportListProduct();
                            Console.WriteLine();
                            break;
                        case 2:
                            DisplayListProduct();
                            Console.WriteLine();
                            break;
                        case 3:
                            DeleteProduct();
                            Console.WriteLine();
                            break;
                        case 4:
                            UpdateProduct();
                            Console.WriteLine();
                            break;
                        case 5:
                            DeleteManyProduct();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        public void MenuBai3()
        {
            Console.WriteLine("\n-----Quản Lý Sản Phẩm-----");
            Console.WriteLine("1. Nhập danh sách sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Xóa 1 sản phẩm theo mã");
            Console.WriteLine("4. Update sản phẩm");
            Console.WriteLine("5. Xóa nhiều sản phẩm");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public void ImportListProduct()
        {
            int num;
            Console.Write("Số lượng sản phẩm muốn thêm: ");
            if (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                manageProduct = new ImplementIProduct(num);
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("\nNhập thông tin sản phẩm thứ " + (i + 1));
                    Product new_product = ImportProduct();                  
                    manageProduct.Insert(new_product);
                }
            }
        }
        public Product ImportProduct()
        {
            bool valid = true;
            //Nhập mã sản phẩm
            string productId;
            do
            {
                Console.Write("Nhập mã sản phẩm: ");
                productId = Console.ReadLine();
                if (CheckContainSpecialChar(productId) || CheckIsNullOrWhiteSpace(productId))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập tên sản phẩm
            string productName;
            do
            {
                Console.Write("Nhập tên sản phẩm: ");
                productName = Console.ReadLine();
                if (CheckContainSpecialChar(productName) || CheckIsNullOrWhiteSpace(productName) || ContainsNumber(productName))
                    valid = false;
                else
                    valid = true;
            } while (!valid);

            // Nhập giá sản phẩm
            int price;
            do
            {
                Console.Write("Nhập giá sản phẩm: ");
                if (Int32.TryParse(Console.ReadLine(), out price))
                {
                    if (price <= 0)
                    {
                        Console.WriteLine("Giá sản phẩm không thể âm và không bằng 0!");
                        valid = false;
                    }
                    else
                        valid = true;
                }
                else
                {
                    Console.WriteLine("Giá sản phẩm không được quá lớn, không chứa kí tự, để trống hay khoảng trắng!");
                    valid = false;
                }
            } while (!valid);
            // Khởi tạo sản phẩm mới
            Product new_product = new Product(productId,productName,price);
            return new_product;
        }
        public void DisplayListProduct()
        {
            for (int i = 0; i < manageProduct.Count(); i++)
            {
                Console.WriteLine((i+1) + ". " + manageProduct.getProduct(i).Display());
            }    
        }
        public void DeleteProduct()
        {
            string productId;
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            productId = Console.ReadLine();
            if (CheckContainSpecialChar(productId) || CheckIsNullOrWhiteSpace(productId))
                return;
            else
                manageProduct.Delete(productId);
        }
        public void UpdateProduct()
        {
            // Nhập mã sản phẩm cần cập nhật trong danh sách
            Console.Write("Nhập mã sản phẩm cần cập nhật thông tin: ");
            string productId = Console.ReadLine();
            if (CheckContainSpecialChar(productId) || CheckIsNullOrWhiteSpace(productId))
                return;
            // Cập nhật tên sản phẩm nếu có
            Console.Write("Cập nhật tên sản phẩm: ");
            string productName = Console.ReadLine();
            if (CheckContainSpecialChar(productName) || CheckIsNullOrWhiteSpace(productName) || ContainsNumber(productName))
                return;
            // Cập nhật giá sản phẩm nếu có
            int price;
            Console.Write("Cập nhật giá sản phẩm: ");
            if (Int32.TryParse(Console.ReadLine(), out price))
            {
                if (price <= 0)
                {
                    Console.WriteLine("Giá sản phẩm không thể âm và không bằng 0!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Giá sản phẩm không được quá lớn, không chứa kí tự, để trống hay khoảng trắng!");
                return;
            }
            // Khởi tạo sản phầm và cập nhật
            Product updated_product = new Product(productId,productName,price);
            manageProduct.Update(updated_product);
        }
        public void DeleteManyProduct()
        {
            int num;
            Console.Write("Số lượng mã sản phẩm muốn xóa: ");
            if (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
            }
            else
            {
                bool valid;
                string productId;
                List<string> listProductIdToDelete = new List<string>(num);
                for (int i = 0; i < num; i++)
                {                  
                    do
                    {
                        Console.Write("Nhập mã sản phẩm thứ " + (i+1) + " muốn xóa: ");
                        productId = Console.ReadLine();
                        if (CheckContainSpecialChar(productId) || CheckIsNullOrWhiteSpace(productId))
                            valid = false;
                        else
                            valid = true;
                    } while (!valid);
                    listProductIdToDelete.Add(productId);
                }
                manageProduct.DeleteMultiple(listProductIdToDelete);
                foreach (string id in listProductIdToDelete)
                    Console.WriteLine("Đã xóa thành công các sản phẩm có mã là " + id);
            }
        }
    }
}
