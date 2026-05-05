using System;
using System.Collections.Generic;
using HBBS.BL;

namespace HBBS.UI
{
    public class StaffUI
    {
        public static Staff SignUpStaff()
        {
            Console.Write("Enter Staff Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter Contact: ");
            string contact = Console.ReadLine();
            Console.Write("Enter Staff ID: ");
            int id = int.Parse(Console.ReadLine());
            return new Staff(name, pass, contact, id);
        }

        public static int GetStaffID()
        {
            Console.Write("Enter Staff ID: ");
            return int.Parse(Console.ReadLine());
        }

        public static string GetNewPassword()
        {
            Console.Write("Enter New Staff Password: ");
            return Console.ReadLine();
        }

        public static void ViewStaff(List<Staff> staffList)
        {
            Console.Clear();
            Console.WriteLine("\n================================================");
            Console.WriteLine("                 LIST OF STAFF ");
            Console.WriteLine("==================================================");
            Console.WriteLine("ID\tName");
            foreach (Staff s in staffList)
            {
                Console.WriteLine($"{s.GetStaffID()}\t{s.GetName()}");
            }
        }
    }
}