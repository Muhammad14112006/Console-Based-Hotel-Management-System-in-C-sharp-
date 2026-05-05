using System;

namespace HBBS.UI
{
    public class MenuUI
    {
        public static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================================================");
            Console.WriteLine(@"                 _    _   ____    ____     _____ ");
            Console.WriteLine(@"                | |  | | |  _ \  |  _ \   / ____|");
            Console.WriteLine(@"                | |__| | | |_) | | |_) | | (___  ");
            Console.WriteLine(@"                |  __  | |  _ <  |  _ <   \___ \ ");
            Console.WriteLine(@"                | |  | | | |_) | | |_) |  ____) |");
            Console.WriteLine(@"                |_|  |_| |____/  |____/  |_____/ ");
            Console.WriteLine("");
            Console.WriteLine("                  HOTEL BOOKING & BILLING SYSTEM");
            Console.WriteLine("==========================================================================");
            Console.ResetColor();

            Console.WriteLine("\n             Developed by: Gajni (Muhammad Hassaan)");
            Console.WriteLine("                               UET Lahore");
            Console.WriteLine("--------------------------------------------------------------------------\n");
        }

        public static string GetUserRole()
        {
            Console.WriteLine("Please Select Your Role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Staff");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Option: ");
            return Console.ReadLine();
        }

        public static (string name, string pass) GetLoginCredentials()
        {
            Console.Write("Enter Username: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            return (name, pass);
        }

        public static string AdminMenuDisplay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================================");
            Console.WriteLine("            Admin Menu     ");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            Console.WriteLine("1. Add New Admin\n2. Remove Admin\n3. Update Admin Password\n4. View Admin List");
            Console.WriteLine("5. Add Staff\n6. Remove Staff\n7. Update Staff Password\n8. View Staff List");
            Console.WriteLine("9. View Rooms Status\n10. Add Rooms\n11. Remove Rooms\n12. View All Bookings");
            Console.WriteLine("13. View Room Prices\n14. Update Room Prices\n15. Exit");
            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }

        public static string StaffMenuDisplay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================================");
            Console.WriteLine("              Staff Dashboard      ");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            Console.WriteLine("1. View Available Rooms\n2. Check In Customers\n3. Check Out Customers");
            Console.WriteLine("4. View Bookings\n5. Update Guest Booking\n6. Cancel Booking");
            Console.WriteLine("7. Generate Invoice\n8. View Room Prices\n9. Exit");
            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
    }
}