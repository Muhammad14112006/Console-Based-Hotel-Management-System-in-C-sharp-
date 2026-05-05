using System;
using System.Collections.Generic;
using HBBS.BL;

namespace HBBS.UI
{
    public class RoomUI
    {
        public static Room AddRoomInput()
        {
            Console.Write("Enter Room ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Room Status (Available/Booked): ");
            string status = Console.ReadLine();
            Console.Write("Enter Room Price: ");
            double price = double.Parse(Console.ReadLine());

            return new Room(id, status, "None", price);
        }

        public static int GetRoomID()
        {
            Console.Write("Enter Room ID: ");
            return int.Parse(Console.ReadLine());
        }

        public static double GetNewPrice()
        {
            Console.Write("Enter New Room Price: ");
            return double.Parse(Console.ReadLine());
        }

        public static void ViewRooms(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("                ROOM STATUS");
            Console.WriteLine("==============================================");
            Console.WriteLine("ID\tStatus\t\tPrice\tGuest");
            foreach (Room r in rooms)
            {
                Console.WriteLine($"{r.GetRoomID()}\t{r.GetRoomStatus()}\t{r.GetRoomPrice()}\t{r.GetRoomGuestName()}");
            }
        }
    }
}