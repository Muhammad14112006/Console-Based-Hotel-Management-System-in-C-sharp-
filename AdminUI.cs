using System;
using System.Collections.Generic;
using HBBS.BL;

namespace HBBS.UI
{
    public class AdminUI
    {
        public static Admin SignUpAdmin()
        {
            Console.Write("Enter Admin Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter Contact: ");
            string contact = Console.ReadLine();
            Console.Write("Enter Admin ID: ");
            int id = int.Parse(Console.ReadLine());
            return new Admin(name, pass, contact, id);
        }

        public static int GetAdminID()
        {
            Console.Write("Enter Admin ID: ");
            return int.Parse(Console.ReadLine());
        }

        public static string GetNewPassword()
        {
            Console.Write("Enter New Admin Password: ");
            return Console.ReadLine();
        }

        public static void ViewAdmins(List<Admin> admins)
        {
            Console.WriteLine("\n--- LIST OF ADMINS ---");
            Console.WriteLine("ID\tName");
            foreach (Admin a in admins)
            {
                Console.WriteLine($"{a.GetAdminID()}\t{a.GetAdminName()}");
            }
        }
    }
}