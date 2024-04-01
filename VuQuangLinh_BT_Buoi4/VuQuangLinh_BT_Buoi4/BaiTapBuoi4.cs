using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VuQuangLinh_BT_Buoi4.Bai1;

namespace VuQuangLinh_BT_Buoi4
{
    // Class Bai 1
    internal class Bai1
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
            bool valid = false;
            int choice = -1;
            do
            {
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
                    valid = false;
                }
                switch (choice)
                {
                    case 0: Console.WriteLine("Thoat khoi bai 1!"); valid = true; break;
                    case 1: InsertBook(); break;
                    case 2: DisplayListBooks(); break;
                    case 3: SearchByTitle(); break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); valid = false; break;
                }
            } while (valid != true);
        }
        public void InsertBook()  // Them sach moi
        {
            bool valid = true;
            do
            {
                Book new_book = new Book();
                Console.WriteLine("\nNhap thong tin cuon sach moi: ");
                Console.Write("Nhap tieu de sach: ");
                new_book.title = Console.ReadLine();
                Console.Write("Nhap ten tac gia: ");
                new_book.author = Console.ReadLine();
                Console.Write("Nhap nam xuat ban: ");
                try
                {
                    new_book.year_publish = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    valid = false;
                }

                list_books.Add(new_book); // Them vao danh sach cac cuon sach

            } while (valid == false);
        }

        public void DisplayListBooks() // Hien thi tat ca sach
        {
            Console.WriteLine("\nThong tin tat ca cac cuon sach: ");
            foreach (Book book in list_books)
            {
                Console.WriteLine();
                Display(book);
            }
        }
        public void Display(Book book) // Hien thi 1 cuon sach
        {
            Console.WriteLine("Tieu de: " + book.title);
            Console.WriteLine("Tac gia: " + book.author);
            Console.WriteLine("Nam XB: " + book.year_publish);     
        }
        public void SearchByTitle() // Tim kiem theo tieu de sach
        {
            Console.Write("Nhap vao tieu de cuon sach muon tim: ");
            string search = Console.ReadLine();
            foreach (Book book in list_books)
            {
                if (book.title == search)
                {
                    Console.WriteLine("Cac cuon sach co tieu de " + '"' + search + '"' + " la: ");
                    Display(book);
                }          
                else
                    Console.WriteLine("Khong tim thay ket qua!");
            }
        }
    }


    // Class Bai 2
    internal class Bai2
    {
        public void ExecuteTask2()
        {

        }
    }


    // Class Bai 3
    internal class Bai3
    {
        public void ExecuteTask3()
        {

        }
    }

}
