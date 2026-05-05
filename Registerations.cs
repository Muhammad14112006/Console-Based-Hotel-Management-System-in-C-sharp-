using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBS.BL
{
    public class Registerations
    {
        private string BookingID;
        private string GuestName;
        private string GContact;
        private DateTime CheckInDate;
        private DateTime CheckOutDate;
        private Room room;  // Composition relationship with Room class

        //Constructors
        Registerations() { }
        // Change this in Registerations.cs
        public Registerations(string BookingID, string GuestName, string GContact, DateTime CheckInDate, DateTime CheckOutDate, Room room)
        {
            this.BookingID = BookingID;
            this.GuestName = GuestName;
            this.GContact = GContact;
            this.CheckInDate = CheckInDate;
            this.CheckOutDate = CheckOutDate;
            this.room = room;
        }

        // Getter Functions
        public string getBookingId()
        {
            return this.BookingID;
        }
        public string getGuestName()
        {
            return this.GuestName;
        }
        public string getGContact()
        {
            return this.GContact;
        }
        public DateTime GetCheckInDate()
        {
            return this.CheckInDate;
        }
        public DateTime GetCheckOutDate()
        {
            return this.CheckOutDate;
        }
        public Room GetRoom()
        {
            return this.room;
        }

        //Setter Functions
        public void SetGContact(string newContact)
        {
            this.GContact = newContact;
        }

        public void SetCheckOutDate(DateTime newDate)
        {
            this.CheckOutDate = newDate;
        }

        // To help neatness in file handling
        public string ToFileString()
        {
            return $"{getBookingId()},{getGuestName()},{getGContact()},{GetCheckInDate().ToString("yyyy-MM-dd")},{GetCheckOutDate().ToString("yyyy-MM-dd")},{room.ToFileString()}"; // Convert objecct into comma seperated string
        }

        public static Registerations FromFileString(string line) // This func is static cz it is used to create an object from a string, and we dont have an object to call it on yet
        {
            string[] data = line.Split(',');
            Room r = new Room(int.Parse(data[5]), data[6], data[7], double.Parse(data[8]));
            return new Registerations(data[0], data[1], data[2], DateTime.Parse(data[3]), DateTime.Parse(data[4]), r);
        }
    }
}
