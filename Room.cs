using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBS.BL
{
    public class Room
    {
        private int RoomID;
        private string RoomStatus;
        private string GuestName;
        private double RoomPrice;

        // Constructors
        public Room()
        {
        }

        public Room(int id, string status, string guestName, double price)
        {
            RoomID = id;
            RoomStatus = status;
            GuestName = guestName;
            RoomPrice = price;
        }

        // Get/Set Functions
        public int GetRoomID()
        {
            return RoomID;
        }
        //there is no SetRoomID(). This prevents anyone from changing it

        // Room Status has both GET and SET
        public string GetRoomStatus()
        {
            return RoomStatus;
        }
        public void SetRoomStatus(string newStatus)
        {
            RoomStatus = newStatus;
        }

        // Room guest name has both GET and SET cz guest's name might be written wrong and might need some correction
        public string GetRoomGuestName()
        {
            return GuestName;
        }
        public void SetRoomGuestName(string newName)
        {
            GuestName = newName;
        }

        // Room price has both GET and SET cz the Admin can change the price of the room whenever he wants, and we will add a condition to prevent negative prices
        public double GetRoomPrice()
        {
            return RoomPrice;
        }
        public void SetRoomPrice(double newPrice)
        {
            if (newPrice > 0)
            {
                RoomPrice = newPrice;
            }
            else
            {
                Console.WriteLine("Error: Room price must be greater than zero.");
            }
        }
       
        // the functions below are written in BL cz they are not directly dealing with the file
        public string ToFileString()
        {
            return $"{RoomID},{RoomStatus},{GuestName},{RoomPrice}"; //To convert attributes in an object into a string 
        }

        public static Room FromFileString(string line)
        {
            string[] parts = line.Split(',');
            return new Room(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]));
        }
    }
}
