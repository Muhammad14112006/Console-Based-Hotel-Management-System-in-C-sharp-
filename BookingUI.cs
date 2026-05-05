using System;
using System.Collections.Generic;
using HBBS.BL;

namespace HBBS.UI
{
    public class BookingUI
    {
        public static string GetBookingID()
        {
            Console.Write("Enter Booking ID: ");
            return Console.ReadLine();
        }

        public static void ViewBookings(List<Registerations> bookings)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("               ALL BOOKINGS ");
            Console.WriteLine("============================================");
            foreach (Registerations reg in bookings)
            {
                Console.WriteLine($"ID: {reg.getBookingId()} | Guest: {reg.getGuestName()} | Room: {reg.GetRoom().GetRoomID()}");
            }
        }

        //Function to get the inputs in order to update the Booking Details
        public static (string contact, DateTime checkout) GetUpdatedBookingDetails()
        {
            Console.Write("Enter New Contact Number: ");
            string contact = Console.ReadLine();
            Console.Write("Enter New Check-Out Date (yyyy-mm-dd): ");
            DateTime checkout = DateTime.Parse(Console.ReadLine());
            return (contact, checkout);
        }
    }
}