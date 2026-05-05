using HBBS.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace HBBS.DL
{
    public class StaffDL
    {
        // list of registrations
        public static List<Registerations> RegisterationsList = new List<Registerations>();
        private static List<Billing> Bills = new List<Billing>();

        private static string billsPath = "E:\\2nd Semester\\OOP\\Mids Proj\\Bills.txt";
        private static string RegPath = "E:\\2nd Semester\\OOP\\Mids Proj\\Registerations.txt";
        public static void AddRegistration(Registerations reg)
        {
            RegisterationsList.Add(reg);
            SaveToFile();
        }

        // Getter for paths
        public string GetRegPath()
        {
            return RegPath;
        }
        public string GetBillsPath()
        {
            return billsPath;
        }


        // BILLING MANAGEMENT (CRUD) 

        public static void AddBill(Billing b)
        {
            Bills.Add(b);
            SaveBillsToFile();
        }

        public static List<Billing> GetBillsList()
        {
            return Bills;
        }

        public static void SaveBillsToFile()
        {
            using (StreamWriter file = new StreamWriter(billsPath, true))
            {
                foreach (Billing b in Bills)
                {
                    file.WriteLine(b.ToFileString());
                }
            }
        }

        public static void LoadBillsFromFile()
        {
            if (File.Exists(billsPath))
            {
                Bills.Clear();
                foreach (string line in File.ReadAllLines(billsPath))
                {
                    Bills.Add(Billing.FromFileString(line));
                }
            }
        }

        // REGISTRATION MANAGEMENT (CRUD)
        public static void SaveToFile()
        {
            using (StreamWriter file = new StreamWriter(RegPath, true))
            {
                foreach (Registerations r in RegisterationsList)
                {
                    //  saving registration + room details (composition)
                    file.WriteLine(r.ToFileString());
                }
            }
        }

        public static void LoadRegFromFile()
        {
            if (File.Exists(RegPath))
            {
                RegisterationsList.Clear(); // Clear current list to avoid duplicates
                foreach (string line in File.ReadAllLines(RegPath))
                {
                    RegisterationsList.Add(Registerations.FromFileString(line)); //From File string will take data from file and convert it into Registration object and add it to list
                }
            }
        }

        // Load All Data from files
        public static void LoadAllData()
        {
            LoadRegFromFile();
            LoadBillsFromFile();
        }

        //Sign In Function
        public static Staff SignIn(string name, string password)
        {
            foreach (Staff s in AdminDL.GetStaffList())
            {
                if (s.GetName() == name && s.GetPassword() == password)
                {
                    return s;
                }
            }
            return null;
        }

        // BOOKING MANAGEMENT 

        //Cancel Booking Function
        public static bool CancelBooking(string bookingID)
        {
            for (int i = 0; i < RegisterationsList.Count; i++)
            {
                if (RegisterationsList[i].getBookingId() == bookingID)
                {
                    //to maake the room available again
                    RegisterationsList[i].GetRoom().SetRoomStatus("Available");
                    AdminDL.SaveRoomsToFile(); // Save the room's new status in the file

                    // Removed the booking
                    RegisterationsList.RemoveAt(i);
                    SaveToFile(); // Save the updated registrations list
                    return true;
                }
            }
            return false;
        }

        //CheckOutCustomer Function
        public static bool CheckOutCustomer(string bookingID)
        {
            for (int i = 0; i < RegisterationsList.Count; i++)
            {
                if (RegisterationsList[i].getBookingId() == bookingID)
                {
                    RegisterationsList[i].GetRoom().SetRoomStatus("Available");
                    AdminDL.SaveRoomsToFile();

                    RegisterationsList.RemoveAt(i);
                    SaveToFile();
                    return true;
                }
            }
            return false;
        }

        //Function to update guest's checkout date or add a contact.
        public static bool UpdateBooking(string bookingID, string newContact, DateTime newCheckOut)
        {
            foreach (Registerations reg in RegisterationsList)
            {
                if (reg.getBookingId() == bookingID)
                {
                    reg.SetGContact(newContact);
                    reg.SetCheckOutDate(newCheckOut);
                    SaveToFile(); 
                    return true;
                }
            }
            return false;
        }
    }
}
