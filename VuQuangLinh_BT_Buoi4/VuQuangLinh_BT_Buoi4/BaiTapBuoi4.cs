using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static VuQuangLinh_BT_Buoi4.Bai1;
using static VuQuangLinh_BT_Buoi4.Bai3;

namespace VuQuangLinh_BT_Buoi4
{
    // Cac ham kiem tra input
    public class CheckInput
    {
        public bool ContainsNumber(string input)
        {
            return input.Any(char.IsDigit);
        }
        public bool ContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            return specialCharRegex.IsMatch(input);
        }
        public bool CheckYear(int input)
        {
            return (input < 0 || input > DateTime.Now.Year);
        }
        public bool CheckIsNum(string data, int num)
        {
            return Int32.TryParse(data, out num);
        }
        public bool CheckFloat(string data, float num)
        {
            return float.TryParse(data, out num);
        }
        public bool CheckDouble(string data, double num)
        {
            return double.TryParse(data, out num);
        }
        public bool CheckDateTime(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {               
                return true;
            }
            else
            {
                Console.WriteLine("Đinh dang ngay khong hop le.");
                return false;
            }
        }
        public void CheckBillId(string input)
        {
            if (ContainSpecialChar(input))
            {
                Console.WriteLine("Ma hoa don khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ma hoa don khong duoc de trong!");
                return;
            }
        }
    }


    // Class Bai 1
    internal class Bai1 : CheckInput
    {
        List<Book> list_books = new List<Book>();
        public struct Book
        {
            public string title { get; set; }
            public string author { get; set; }
            public int year_publish { get; set; }
        }
        public void ExecuteTask1()
        {
            bool flag = false;         
            do
            {
                int choice = -1;
                Console.WriteLine("\n------Menu quan ly sach------");
                Console.WriteLine("1. Them sach moi");
                Console.WriteLine("2. Hien thi danh sach cac cuon sach");
                Console.WriteLine("3. Tim kiem sach theo tieu de");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 1!"); flag = true; break;
                    case 1: AddBook(); break;
                    case 2: DisplayListBooks(); break;
                    case 3: SearchByTitle(); break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void AddBook()  // Them sach moi
        {
            Book new_book = new Book();
            Console.WriteLine("\nNhap thong tin cuon sach moi: ");

            // Xu li nhap tieu de
            Console.Write("Nhap tieu de sach: ");
            new_book.title = Console.ReadLine();
            if (ContainSpecialChar(new_book.title))
            {
                Console.WriteLine("Tieu de khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_book.title))
            {
                Console.WriteLine("Tieu de khong duoc de trong!");
                return;
            }

            // Xu li nhap ten tac gia
            Console.Write("Nhap ten tac gia: ");
            new_book.author = Console.ReadLine();
            if (ContainsNumber(new_book.author))
            {
                Console.WriteLine("Ten tac gia khong duoc chua chu so!");
                return;
            }
            if (ContainSpecialChar(new_book.author))
            {
                Console.WriteLine("Ten tac gia khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_book.title))
            {
                Console.WriteLine("Ten tac gia khong duoc de trong!");
                return;
            }

            // Xu li nhap nam xuat ban
            Console.Write("Nhap nam xuat ban: ");
            string year;
            year = Console.ReadLine();
            if (!CheckIsNum(year, new_book.year_publish))
            {
                Console.WriteLine("Nam xuat ban phai la so va khong duoc bo trong!");
                return;
            }
            else
                new_book.year_publish = Int32.Parse(year);

            if (CheckYear(new_book.year_publish))
            {
                Console.WriteLine("Nam xuat ban phai la so nguyen duong va khong lon hon nam hien tai!");
                return;
            }

            // Them vao danh sach cac cuon sach
            list_books.Add(new_book);
        }

        public void DisplayListBooks() // Hien thi tat ca sach
        {
            if (list_books.Count == 0)
            {
                Console.WriteLine("Khong co thong tin cuon sach nao!");
            }
            else
            {
                Console.WriteLine("\nThong tin cac cuon sach dang co: ");
                foreach (Book book in list_books)
                {
                    Console.WriteLine();
                    Display(book);
                }
            }          
        }
        public void Display(Book book) // Hien thi 1 cuon sach
        {
            Console.WriteLine("Tieu de: " + book.title + ", " + "Tac gia: " + book.author + ", " + "Nam XB: " + book.year_publish); 
        }
        public void SearchByTitle() // Tim kiem theo tieu de sach
        {
            Console.Write("Nhap vao tieu de cuon sach muon tim: ");
            string search = Console.ReadLine();
            bool flag = false;
            foreach (Book book in list_books)
            {
                if (book.title == search)
                {
                    flag = true;
                    Console.WriteLine("Cac cuon sach co tieu de " + '"' + search + '"' + " la: ");
                    Display(book);
                }                     
            }
            if (!flag)
                Console.WriteLine("Khong tim thay ket qua!");
        }
        
    }


    // Class Bai 2
    internal class Bai2 : CheckInput
    {
        List<Student> list_students = new List<Student>();
        public struct Student
        {
            public string name { get; set; }
            public int age { get; set; }
            public float average_score { get; set; }
        }
        public void ExecuteTask2()
        {
            bool flag = false;
            do
            {
                int choice = -1;
                Console.WriteLine("\n------Menu quan ly hoc sinh------");
                Console.WriteLine("1. Them hoc sinh moi");
                Console.WriteLine("2. Hien thi danh sach hoc sinh");
                Console.WriteLine("3. Tim hoc sinh theo ten");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 2!"); flag = true; break;
                    case 1: AddStudent(); break;
                    case 2: DisplayListStudents(); break;
                    case 3: SearchByName(); break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void AddStudent()  // Them hoc sinh moi
        {
            Student new_student = new Student();
            Console.WriteLine("\nNhap thong tin hoc sinh moi: ");

            // Xu li nhap ten
            Console.Write("Nhap ten: ");
            new_student.name = Console.ReadLine();
            if (ContainsNumber(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong duoc chua chu so!");
                return;
            }
            if (ContainSpecialChar(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_student.name))
            {
                Console.WriteLine("Ten hoc sinh khong duoc de trong!");
                return;
            }

            // Xu li nhap tuoi
            Console.Write("Nhap tuoi: ");
            string age = Console.ReadLine();
            if (!CheckIsNum(age, new_student.age))
            {
                Console.WriteLine("Tuoi hoc sinh phai la mot so nguyen va khong duoc bo trong!");
                return;
            }
            else
                new_student.age = Int32.Parse(age);
            if (new_student.age < 5 || new_student.age > 18)
            {
                Console.WriteLine("Tuoi hoc sinh phai tu 6 den 18 tuoi");
                return;
            }

            // Xu li nhap diem trung binh
            Console.Write("Nhap diem trung binh: ");
            string avarage = Console.ReadLine();
            if (!CheckFloat(avarage, new_student.average_score))
            {
                Console.WriteLine("Diem trung binh phai la so thuc va khong duoc bo trong!");
                return;
            }
            else
                new_student.average_score = float.Parse(avarage);
            if (new_student.average_score < 0 || new_student.average_score > 10)
            {
                Console.WriteLine("Diem trung binh phai nam trong khoang tu 0 den 10");
                return;
            }

            list_students.Add(new_student); // Them vao danh sach hoc sinh
        }

        public void DisplayListStudents() // Hien thi tat ca hoc sinh
        {
            if (list_students.Count == 0)
            {
                Console.WriteLine("Khong co thong tin hoc sinh nao!");
            }
            else
            {
                Console.WriteLine("\nThong tin cac hoc sinh dang co: ");
                foreach (Student student in list_students)
                {
                    Console.WriteLine();
                    Display(student);
                }
            }
        }
        public void Display(Student student) // Hien thi 1 hoc sinh
        {
            Console.WriteLine("Ten: " + student.name + ", " + "Tuoi: " + student.age + ", " + "DTB: " + student.average_score);
        }
        public void SearchByName() // Tim kiem theo ten hoc sinh
        {
            Console.Write("Nhap vao ten hoc sinh muon tim: ");
            string search = Console.ReadLine();
            bool flag = false;
            foreach (Student student in list_students)
            {
                if (student.name == search)
                {
                    flag = true;
                    Console.WriteLine("Cac hoc sinh co ten " + '"' + search + '"' + " la: ");
                    Display(student);
                };
            }
            if (!flag)
                Console.WriteLine("Khong tim thay ket qua!");
        }
    }


    // Class Bai 3
    internal class Bai3 : CheckInput
    {
        public struct Bill
        {
            public string bill_id { get; set; }
            public DateTime publish_day { get; set; }
            public double total_money { get; set; }
            public double debt_money { get; set; }
            public int debt_status { get; set; }
            public string customer_name { get; set; }
        }
        public enum status 
        { 
            ConNo = 1, 
            HetNo = 0
        }
        List<Bill> list_bills = null;
        public void ExecuteTask3()
        {
            bool flag = false;
            do
            {
                int choice = -1;
                Console.WriteLine("\n------Menu quan ly hoa don------");
                Console.WriteLine("1. Nhap vao danh sach hoa don");
                Console.WriteLine("2. Xoa no cho 1 hoa don");
                Console.WriteLine("3. Xuat danh sach hoa don");
                Console.WriteLine("4. Tra cuu hoa don con no theo cac moc thoi gian");
                Console.WriteLine("5. Xuat danh sach hoa don khong con no ra file text");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 3!"); flag = true; break;
                    case 1:                     
                        Console.WriteLine("Nhap vao so luong hoa don can them: ");
                        int quantity = -1;
                        string data = Console.ReadLine();
                        if (!CheckIsNum(data, quantity))
                        {
                            Console.WriteLine("Ban can nhap vao mot so va khong duoc de trong!");
                            return;
                        }
                        else
                        {
                            quantity = Int32.Parse(data);
                        }                         
                        AddBill(quantity);
                        break;
                    case 2:
                        Console.Write("Nhap ma hoa don ma ban muon xoa no: ");
                        string id = Console.ReadLine();
                        CheckBillId(id);
                        foreach (Bill bill in list_bills)
                        {
                            if (String.Compare(bill.bill_id, id) == 0)
                            {
                                ResetDebt(bill);
                            }
                        }
                        break;
                    case 3:
                        DisplayBillsByCondition();
                        break;
                    case 4:
                        SearchDebtBillByTime();
                        break;
                    case 5:
                        ExportToFile();
                        break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void AddBill(int quantity)
        {
            list_bills = new List<Bill>(quantity);
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine("\nNhap thong tin hoa don thu " + (i + 1));
                Bill new_bill = new Bill();            
                InputBill(ref new_bill);
                list_bills.Add(new_bill);
            }
        }
                    
        public void InputBill(ref Bill bill)
        {
            // Xu li nhap ma hoa don
            Console.Write("Nhap vao ma hoa don: ");
            bill.bill_id = Console.ReadLine();
            CheckBillId(bill.bill_id);

            // Xu li nhap ngay phat hanh
            Console.Write("Nhap ngay phat hanh (dd/MM/yyyy): ");
            string date = Console.ReadLine();
            if (CheckDateTime(date))
                bill.publish_day = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            else
                return;

            // Xu li nhap tong so tien
            Console.Write("Nhap tong so tien: ");
            string total_money = Console.ReadLine();
            if (!CheckDouble(total_money, bill.total_money))
            {
                Console.WriteLine("So tien khong duoc la ki tu va khong duoc de trong!");
                return;
            }
            else
                bill.total_money = Double.Parse(total_money);
            if (bill.total_money < 0)
            {
                Console.WriteLine("So tien khong duoc la so am!");
                return;
            }

            // Xu li nhap so tien con no
            Console.Write("Nhap so tien con no: ");
            string debt_money = Console.ReadLine();
            if (!CheckDouble(debt_money, bill.debt_money))
            {
                Console.WriteLine("So tien khong duoc la ki tu va khong duoc de trong!");
                return;
            }
            else
                bill.debt_money = Double.Parse(debt_money);
            if (bill.debt_money < 0)
            {
                Console.WriteLine("So tien khong duoc la so am!");
                return;
            }

            // Xu li nhap trang thai no
            UpdateDebtStatus(ref bill);

            // Xu li nhap ten khach hang
            Console.Write("Nhap ten khach hang: ");
            bill.customer_name = Console.ReadLine();
            if (ContainsNumber(bill.customer_name))
            {
                Console.WriteLine("Ten khach hang khong duoc chua chu so!");
                return;
            }
            if (ContainSpecialChar(bill.customer_name))
            {
                Console.WriteLine("Ten khach hang khong duoc chua ki tu dac biet!");
                return;
            }
            if (string.IsNullOrWhiteSpace(bill.customer_name))
            {
                Console.WriteLine("Ten khach hang khong duoc de trong!");
                return;
            }
        }
        public void DisplayABill(Bill bill)
        {
            Console.Write("Ma hoa don: " + bill.bill_id + ", Ngay phat hanh: " + bill.publish_day + ", Tong so tien: " + bill.total_money + ", So tien con no: " + bill.debt_money + ", Trang thai no: " + bill.debt_status + " Ten khach hang: " + bill.customer_name);
        }
        public void DisplayBills(List<Bill> list_bills)
        {
            int order = 1;
            Console.WriteLine("\nThong tin tat ca cac hoa don ma ban tim:");
            foreach (Bill bill in list_bills)
            {
                if (order <= list_bills.Count)
                {
                    Console.Write("\n" + order + ".");
                    DisplayABill(bill);
                    order++;
                }              
            }
        }
        public void DisplayBillsByCondition()
        {
            bool flag = false;
            string data;
            int choice = -1;
            do
            {
                Console.WriteLine("\n1. Xuat tat ca hoa don");
                Console.WriteLine("2. Xuat theo ma hoa don");
                Console.WriteLine("3. Xuat hoa don con no/het no");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("Nhap lua chon: ");

                data = Console.ReadLine();
                if (!Int32.TryParse(data, out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }
                switch (choice)
                {
                    case 0: flag = true; break;
                    case 1:
                        DisplayBills(list_bills);
                        break;
                    case 2:
                        Console.WriteLine("Nhap ma hoa don ma ban muon hien thi: ");
                        string id = Console.ReadLine();
                        CheckBillId(id);
                        DisplayBillById(id);
                        break;
                    case 3:
                        DisplayBillByDebtStatus();
                        break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void DisplayBillById(string input)
        {
            foreach (Bill bill in list_bills)
            {
                if (String.Compare(bill.bill_id, input) == 0)
                {
                    DisplayABill(bill);
                }
            }
        }
        public void DisplayBillByDebtStatus()
        {
            bool flag = false;
            string data;
            int choice = -1;
            do
            {
                Console.WriteLine("\n1. Con no");
                Console.WriteLine("2. Het no");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("Nhap lua chon: ");

                data = Console.ReadLine();
                if (!Int32.TryParse(data, out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }
                switch (choice)
                {
                    case 0: flag = true; break;
                    case 1:
                        Console.WriteLine("\nDanh sach cac hoa don con no la: ");
                        DisplayDebtBill();
                        break;
                    case 2:
                        Console.WriteLine("\nDanh sach cac hoa don het no la: ");
                        DisplayNoneDebtBill();
                        break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void DisplayDebtBill()
        {
            foreach (Bill bill in list_bills)
            {
                if (bill.debt_status == 1)
                {
                    DisplayABill(bill);
                }
            }
        }
        public void DisplayNoneDebtBill()
        {
            foreach (Bill bill in list_bills)
            {
                if (bill.debt_status == 0)
                {
                    DisplayABill(bill);
                }
            }
        }
        public void ResetDebt (Bill bill)
        {
            ResetDebtMoney(ref bill);
            UpdateDebtStatus(ref bill);           
        }
        public void ResetDebtMoney(ref Bill bill)
        {
            bill.debt_money = 0;
        }
        public void UpdateDebtStatus(ref Bill bill)
        {
            if (bill.debt_money > 0)
                bill.debt_status = (int)status.ConNo;
            else
                bill.debt_status = (int)status.HetNo;
        }

        public void SearchDebtBillByTime()
        {
            bool flag = false;
            string data;
            int choice = -1;
            do
            {
                Console.WriteLine("\n1. Tu 30 ngay");
                Console.WriteLine("2. Tu 60 ngay");
                Console.WriteLine("3. Tu 90 ngay");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("Nhap lua chon: ");

                data = Console.ReadLine();
                if (!Int32.TryParse(data, out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }
                switch (choice)
                {
                    case 0: flag = true; break;
                    case 1:
                        Console.WriteLine("\nDanh sach cac hoa don con no tu 30 ngay la: ");
                        DisplayDebtBillFrom30();
                        break;
                    case 2:
                        Console.WriteLine("\nDanh sach cac hoa don con no tu 60 ngay la: ");
                        DisplayDebtBillFrom60();
                        break;
                    case 3:
                        Console.WriteLine("\nDanh sach cac hoa don con no tu 90 ngay la: ");
                        DisplayDebtBillFrom90();
                        break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); break;
                }
            } while (!flag);
        }
        public void DisplayDebtBillFrom30()
        {
            DateTime now = DateTime.Now;
            TimeSpan interval;
            int result;
            foreach (Bill bill in list_bills)
            {
                interval = now - bill.publish_day;
                result = (int)Math.Round(interval.TotalDays);
                if (result >= 30 && result < 60)
                    DisplayABill(bill);
            }
        }
        public void DisplayDebtBillFrom60()
        {
            DateTime now = DateTime.Now;
            TimeSpan interval;
            int result;
            foreach (Bill bill in list_bills)
            {
                interval = now - bill.publish_day;
                result = (int)Math.Round(interval.TotalDays);
                if (result >= 60 && result < 90)
                    DisplayABill(bill);
            }
        }
        public void DisplayDebtBillFrom90()
        {
            DateTime now = DateTime.Now;
            TimeSpan interval;
            int result;
            foreach (Bill bill in list_bills)
            {
                interval = now - bill.publish_day;
                result = (int)Math.Round(interval.TotalDays);
                if (result >= 90)
                    DisplayABill(bill);
            }
        }
        public void ExportToFile()
        {
            string filePath = @"C:\Users\acer\Desktop\hetno.txt";
            StreamWriter writer = new StreamWriter(filePath);
            var danhSachKhongNo = list_bills.Where(Bill => Bill.debt_status  == 0);
            using (StreamWriter sw = new StreamWriter(filePath)) 
            {
                foreach (var bill in danhSachKhongNo)
                {
                    sw.WriteLine(hd.ToString());
                    sw.WriteLine("-----------------------");
                }
            }

            Console.WriteLine("Đã xuất hóa đơn không còn nợ ra file text.");
        }
    }

}
