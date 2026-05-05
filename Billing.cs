using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HBBS.BL
{
    public class Billing
    {
        private int BookingID;
        private double TotalAmount;
        private DateTime BillingDate;
        private Registerations registration;

        // Constructors
        public Billing() { }
        public Billing(int BookingID, double TotalAmount, DateTime BillingDate, Registerations registerations)
        {
            this.BookingID = BookingID;
            this.TotalAmount = TotalAmount;
            this.BillingDate = BillingDate;
            this.registration = registerations;
        }

        // Getters
        public int GetBookingID()
        {
            return BookingID;
        }
        public double GetTotalAmount()
        {
            return TotalAmount;
        }
        public DateTime GetBillingDate()
        {
            return BillingDate;
        }
        public Registerations GetRegistration()
        {
            return registration;
        }

        //To Calculate total anount 
        public void GenerateBill(Registerations reg)
        {
            // This function will calculate the total amount based on the room price and the number of days stayed, and set the billing date to the current date
            TotalAmount = reg.GetRoom().GetRoomPrice() * (reg.GetCheckOutDate() - reg.GetCheckInDate()).Days; //.Days will give us the number of days between check-in and check-out in integer form
            BillingDate = DateTime.Now; // This will set the billing date to the current date and time
        }

        // To help neatness in file handling
        public string ToFileString()
        {
            // pehly bookingid, total amount, billing date comma seperated string mein convert ho jae gi
            //phir registerations class ky attributes us mein add ho ky ToFileString ho jaein gy...
            //Object Room is an attribute of Registerations class, so wo baad mein again ToFileString ho jae ga.
            //Total 11 attributes hain, 3 Billing class ke aur 8 Registerations class ke (including Room class ky attributes)
            return $"{BookingID},{TotalAmount},{BillingDate:yyyy-MM-dd},{registration.ToFileString()}";
        }

        public static Billing FromFileString(string FileString)
        {
            string[] parts = FileString.Split(','); // Split the string into parts using comma as a separator
            int bID = int.Parse(parts[0]);
            double TAmount = double.Parse(parts[1]);
            DateTime bDate = DateTime.Parse(parts[2]);
            Room r = new Room(int.Parse(parts[8]), parts[9], parts[10], double.Parse(parts[11]));
            Registerations reg = new Registerations(parts[3], parts[4], parts[5], DateTime.Parse(parts[6]), DateTime.Parse(parts[7]), r);


            return new Billing(bID, TAmount, bDate, reg); // Create a new Billing object using the parsed values and return it
        }
    }
}