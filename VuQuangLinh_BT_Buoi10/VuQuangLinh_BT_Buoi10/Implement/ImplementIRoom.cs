using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.DataObject;
using VuQuangLinh_BT_Buoi10.Interfaces;
using VuQuangLinh_BT_Buoi10.Validation_and_Notification;

namespace VuQuangLinh_BT_Buoi10.Implement
{
    internal class ImplementIRoom : IRoom
    {
        Notification notify = new Notification();
        Validation validate = new Validation();
        List<Room> listRoom = new List<Room>();

        public bool CheckBeforeAdd()
        {
            if (validate.CheckFullRoom(listRoom.Count))
            {
                notify.returnMsg = "Số phòng trong khách sạn đã đầy!";
                Console.WriteLine(notify.returnMsg);
                return false;
            }
            else
                return true;
        }
        // Thêm phòng
        public void AddRoom()
        {
            Room new_room = InputRoomToManage();
            if (CheckBeforeAdd())
            {
                listRoom.Add(new_room);
                notify.returnMsg = "\nThêm phòng thành công!";
                Console.WriteLine(notify.returnMsg);
            }
        }
        public void Remove(int ID)
        {
            Room remove_room = listRoom.FirstOrDefault(r => r.ID == ID);
            listRoom.Remove(remove_room);
        }

        // Xóa phòng
        public void RemoveRoom()
        {
            int ID = 0;
            // Nhập ID phòng muốn xóa
            Console.Write("Nhập số phòng muốn xóa: ");
            try
            {
                ID = int.Parse(Console.ReadLine());
                Remove(ID);
                notify.returnMsg = "Xóa thành công phòng số" + ID;
                Console.WriteLine(notify.returnMsg);
            }
            catch
            {
                notify.returnMsg = "Số phòng nhập vào không hợp lệ!";
                Console.WriteLine(notify.returnMsg);
            }
        }
        public void CheckListRoom()
        {
            DisplayListRoom();
        }
        public void ModifyRoomInfo()
        {

        }
        public bool CheckBookedRoom(int ID)
        {
            foreach (Room room in listRoom)
            {
                if (room.ID == ID && room.Status == false)
                    return true;
            }
            return false;
        }
        public bool CheckExistRoom(int ID)
        {
            foreach (Room room in listRoom)
            {
                if (room.ID == ID)
                    return true;
            }
            return false;
        }
        public int GetTypeOfRoom(int ID)
        {
            int result = 0;
            foreach (Room room in listRoom)
            {
                if (room.ID == ID)
                    result = room.Type;
            }
            return result;
        }
        public void DisplayListRoom()
        {
            foreach (Room room in listRoom)
            {
                Console.WriteLine(room.Display());
            }
        }

        //Nhập thông tin phòng vào hệ thống
        public Room InputRoomToManage()
        {
            int ID = 0;
            int Type = 0;
            bool Status = false;
            bool valid = false;

            // Nhập ID phòng
            do
            {
                Console.Write("Nhập số phòng: ");
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    valid = true;
                    if (!validate.CheckIDRoom(ID))
                    {
                        valid = false;
                        notify.returnMsg = "Số phòng nhập vào không hợp lệ!";
                        Console.WriteLine(notify.returnMsg);
                    }
                    if (CheckExistRoom(ID))
                    {
                        valid = false;
                        notify.returnMsg = "Số phòng này đã tồn tại!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Số phòng nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Nhập loại phòng
            do
            {
                Console.Write("Nhập loại phòng (1. Phòng VIP, 2. Phòng 4 giường, 3. Phòng 3 giường, 4. Phòng giường đôi, 5. Phòng giường đơn): ");
                try
                {
                    Type = int.Parse(Console.ReadLine());
                    if (Type == 1 || Type == 2 || Type == 3 || Type == 4 || Type == 5)
                        valid = true;
                    else
                    {
                        valid = false;
                        notify.returnMsg = "Loại phòng nhập vào không hợp lệ!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Dữ liệu nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Nhập trạng thái phòng
            do
            {
                Console.Write("Nhập trạng thái phòng (1. Đã được đặt, 2. Còn trống): ");
                try
                {
                    int status = int.Parse(Console.ReadLine());
                    if (status == 1 || status == 2)
                    {
                        if (status == 1)
                            Status = false;
                        else
                            Status = true;
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        notify.returnMsg = "Trạng thái nhập vào không hợp lệ!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Dữ liệu nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Khởi tạo phòng
            Room room = new Room(ID, Type, Status);
            return room;
        }

        // Nhập thông tin phòng khi đặt phòng cho khách hàng
        public Room InputRoomToBook()
        {
            int ID = 0;
            int Type = 0;
            bool Status = false;
            bool valid = false;

            // Nhập ID phòng
            do
            {
                Console.Write("Nhập số phòng: ");
                try
                {
                    ID = int.Parse(Console.ReadLine());
                    valid = true;
                    if (!validate.CheckIDRoom(ID))
                    {
                        valid = false;
                        notify.returnMsg = "Số phòng nhập vào không hợp lệ!";
                        Console.WriteLine(notify.returnMsg);
                    }
                    if (CheckBookedRoom(ID))
                    {
                        valid = false;
                        notify.returnMsg = "Phòng này đã được đặt rồi!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Số phòng nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Lấy dữ liệu loại phòng
            Type = GetTypeOfRoom(ID);

            // Kiểm tra thông tin trạng thái phòng
            Status = CheckBookedRoom(ID);
            if (Status == true)
            {
                notify.returnMsg = "Phòng này đã được đặt!";
                Console.WriteLine(notify.returnMsg);
                return null;
            }
            else
            {
                // Khởi tạo phòng
                Room room = new Room(ID, Type, Status);
                return room;
            }
        }
    }
}
