using HBBS.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HBBS.DL
{
    internal class AdminDL
    {
        // 1. Hum ny Static lists use ki cz we need single single lists for all Admins, Staffs, and Rooms across the entire application.
        private static List<Admin> Admins = new List<Admin>();
        private static List<Staff> Staffs = new List<Staff>();
        private static List<Room> Rooms = new List<Room>();


        // 2. File Paths
        private static string adminPath = "E:\\2nd Semester\\OOP\\Mids Proj\\Admins.txt";
        private static string staffPath = "E:\\2nd Semester\\OOP\\Mids Proj\\Staffs.txt";
        private static string roomPath = "E:\\2nd Semester\\OOP\\Mids Proj\\Rooms.txt";


        // ROOM MANAGEMENT (CRUD)

        public static void AddRoom(Room r)
        {
            Rooms.Add(r);
            SaveRoomsToFile();
        }

        public static List<Room> GetRoomsList()
        {
            return Rooms;
        }

        public static void SaveRoomsToFile()
        {
            using (StreamWriter file = new StreamWriter(roomPath, false))
            {
                foreach (Room r in Rooms)
                {
                    file.WriteLine(r.ToFileString());
                }
            }
        }

        public static void LoadRoomsFromFile()
        {
            if (File.Exists(roomPath))
            {
                Rooms.Clear(); // Clear current list to avoid duplicates
                foreach (string line in File.ReadAllLines(roomPath))
                {
                    Rooms.Add(Room.FromFileString(line)); //From File string will take data from file and convert it into Room object and add it to list
                }
            }
        }

        //Remove Room Function
        public static bool RemoveRoom(int roomID)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].GetRoomID() == roomID)
                {
                    Rooms.RemoveAt(i);
                    SaveRoomsToFile(); // Immediately save changes
                    return true;
                }
            }
            return false;
        }

        //Update Room Price Function
        public static bool UpdateRoomPrice(int roomID, double newPrice)
        {
            foreach (Room r in Rooms)
            {
                if (r.GetRoomID() == roomID)
                {
                    r.SetRoomPrice(newPrice); // Using the setter you already wrote!
                    SaveRoomsToFile(); // Immediately save changes
                    return true;
                }
            }
            return false;
        }

        // STAFF MANAGEMENT (CRUD)

        public static void AddStaff(Staff s)
        {
            Staffs.Add(s);
            SaveStaffsToFile();
        }

        public static List<Staff> GetStaffList()
        {
            return Staffs;
        }

        public static void SaveStaffsToFile()
        {
            using (StreamWriter file = new StreamWriter(staffPath, false))
            {
                foreach (Staff s in Staffs)
                {
                    // Using separate Get functions for encapsulation
                    file.WriteLine(s.ToFileString());
                }
            }
        }

        public static void LoadStaffsFromFile()
        {
            if (File.Exists(staffPath))
            {
                Staffs.Clear();
                foreach (string line in File.ReadAllLines(staffPath))
                {
                    Staffs.Add(Staff.FromFileString(line));
                }
            }
        }

        //Remove Staff
        public static bool RemoveStaff(int staffID)
        {
            for (int i = 0; i < Staffs.Count; i++)
            {
                if (Staffs[i].GetStaffID() == staffID)
                {
                    Staffs.RemoveAt(i);
                    SaveStaffsToFile(); // Immediately save changes
                    return true;
                }
            }
            return false;
        }

        //Update Staff Password Function
        public static bool UpdateStaffPassword(int staffID, string newPassword)
        {
            foreach (Staff s in Staffs)
            {
                if (s.GetStaffID() == staffID)
                {
                    s.SetPassword(newPassword);
                    SaveStaffsToFile(); // Immediately save changes
                    return true;
                }
            }
            return false;
        }

        // ADMIN MANAGEMENT (CRUD)

        public static void AddAdmin(Admin a)
        {
            Admins.Add(a);
            SaveAdminsToFile();
        }

        public static List<Admin> GetAdminsList()
        {
            return Admins;
        }

        public static void SaveAdminsToFile()
        {
            using (StreamWriter file = new StreamWriter(adminPath, false))
            {
                foreach (Admin a in Admins)
                {
                    file.WriteLine(a.ToFileString());
                }
            }
        }

        public static void LoadAdminsFromFile()
        {
            if (File.Exists(adminPath))
            {
                Admins.Clear();
                foreach (string line in File.ReadAllLines(adminPath))
                {
                    Admins.Add(Admin.FromFileString(line));
                }
            }
        }


        // The following function loads all the data from all files when the program starts.
        public static void LoadAllData()
        {
            LoadAdminsFromFile();
            LoadStaffsFromFile();
            LoadRoomsFromFile();
        }

        //Sign In function
        public static Admin SignIn(string name, string password)
        {
            foreach (Admin a in Admins)
            {
                if (a.GetAdminName() == name && a.GetPass() == password)
                {
                    return a;
                }
            }
            return null;
        }

        //RemoveAdmin function
        public static bool RemoveAdmin(int adminID)
        {
            for (int i = 0; i < Admins.Count; i++)
            {
                if (Admins[i].GetAdminID() == adminID)
                {
                    Admins.RemoveAt(i);
                    SaveAdminsToFile();
                    return true;
                }
            }
            return false;
        }

        //Update Admin Password Function
        public static bool UpdateAdminPassword(int adminID, string newPassword)
        {
            foreach (Admin a in Admins)
            {
                if (a.GetAdminID() == adminID)
                {
                    a.SetPassword(newPassword);
                    SaveAdminsToFile(); // Immediately save changes
                    return true;
                }
            }
            return false;
        }

    }
}