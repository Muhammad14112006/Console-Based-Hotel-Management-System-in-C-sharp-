using System;
using HBBS.DL;
using HBBS.UI;

namespace HBBS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdminDL.LoadAllData();
            StaffDL.LoadAllData();

            string role = "";
            while (role != "3")
            {
                MenuUI.DisplayHeader();
                role = MenuUI.GetUserRole();

                if (role == "1")
                {
                    HandleAdminPortal();
                }
                else if (role == "2")
                {
                    HandleStaffPortal();
                }
            }
        }

        static void HandleAdminPortal()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 ADMIN PORTAL ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Sign In\n2. Sign Up\n3. Back");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var (name, pass) = MenuUI.GetLoginCredentials();
                var admin = AdminDL.SignIn(name, pass);

                if (admin != null)
                {
                    string adminChoice = "";
                    while (adminChoice != "15")
                    {
                        adminChoice = MenuUI.AdminMenuDisplay();
                        switch (adminChoice)
                        {
                            case "1":
                                {
                                    AdminDL.AddAdmin(AdminUI.SignUpAdmin()); 
                                    break;
                                }
                            case "2":
                                {
                                    AdminDL.RemoveAdmin(AdminUI.GetAdminID());
                                    break;
                                }
                            case "3":
                                {
                                    AdminDL.UpdateAdminPassword(AdminUI.GetAdminID(), AdminUI.GetNewPassword());
                                    break;
                                }

                            case "4":
                                {
                                    AdminUI.ViewAdmins(AdminDL.GetAdminsList());
                                    break;
                                }
                            case "5":
                                {
                                    AdminDL.AddStaff(StaffUI.SignUpStaff());
                                    break;
                                }
                            case "6":
                                {
                                    AdminDL.RemoveStaff(StaffUI.GetStaffID());
                                    break;
                                }
                            case "7":
                                {
                                    AdminDL.UpdateStaffPassword(StaffUI.GetStaffID(), StaffUI.GetNewPassword());
                                    break;
                                }
                            case "8":
                                {
                                    StaffUI.ViewStaff(AdminDL.GetStaffList());
                                    break;
                                }

                            case "9":
                                {
                                    RoomUI.ViewRooms(AdminDL.GetRoomsList());
                                    break;
                                }
                            case "10":
                                {
                                    AdminDL.AddRoom(RoomUI.AddRoomInput());
                                    break;
                                }
                            case "11":
                                {
                                    AdminDL.RemoveRoom(RoomUI.GetRoomID());
                                    break;
                                }

                            case "12":
                                {
                                    BookingUI.ViewBookings(StaffDL.RegisterationsList);
                                    break;
                                }

                            case "13":
                                {
                                    RoomUI.ViewRooms(AdminDL.GetRoomsList());
                                    break;
                                }
                            case "14":
                                {
                                    bool isPriceUpdated = AdminDL.UpdateRoomPrice(RoomUI.GetRoomID(), RoomUI.GetNewPrice());
                                    if (isPriceUpdated)
                                    {
                                        Console.WriteLine("Room price updated successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: Room ID not found.");
                                    }
                                    break;
                                }
                            case "15":
                                {
                                    Console.WriteLine("Logging out...");
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Invalid Option.");
                                    break;
                                }
                        }
                        if (adminChoice != "15") { Console.WriteLine("\nPress any key to continue..."); Console.ReadKey(); }
                    }
                }
                else { Console.WriteLine("Invalid Credentials."); Console.ReadKey(); }
            }
            else if (choice == "2")
            {
                AdminDL.AddAdmin(AdminUI.SignUpAdmin());
                Console.WriteLine("Admin Registered!");
                Console.ReadKey();
            }
        }

        static void HandleStaffPortal()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("                   STAFF PORTAL");
            Console.WriteLine("====================================================");
            Console.WriteLine("1. Sign In\n2. Back");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var (name, pass) = MenuUI.GetLoginCredentials();
                var staff = StaffDL.SignIn(name, pass);
                if (staff != null)
                {
                    string staffChoice = "";
                    while (staffChoice != "9")
                    {
                        staffChoice = MenuUI.StaffMenuDisplay();
                        switch (staffChoice)
                        {
                            case "1":
                                {
                                    RoomUI.ViewRooms(AdminDL.GetRoomsList());
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Check in UI logic coming soon...");
                                    break;
                                }
                            case "3":
                                {
                                    StaffDL.CheckOutCustomer(BookingUI.GetBookingID());
                                    break;
                                }
                            case "4":
                                {
                                    BookingUI.ViewBookings(StaffDL.RegisterationsList);
                                    break;
                                }
                            case "5":
                                string bookID = BookingUI.GetBookingID();
                                var (newContact, newCheckOut) = BookingUI.GetUpdatedBookingDetails();
                                bool isUpdated = StaffDL.UpdateBooking(bookID, newContact, newCheckOut);
                                if (isUpdated)
                                {
                                    Console.WriteLine("Booking Updated Successfully!"); 
                                }
                                else
                                {
                                    Console.WriteLine("Booking ID not found.");
                                }
                                break;
                            case "6":
                                {
                                    StaffDL.CancelBooking(BookingUI.GetBookingID());
                                    break;
                                }
                            case "7":
                                {
                                    Console.WriteLine("Invoice generation coming soon...");
                                    break;
                                }
                            case "8":
                                {
                                    RoomUI.ViewRooms(AdminDL.GetRoomsList());
                                    break;
                                }
                            case "9":
                                {
                                    Console.WriteLine("Logging out...");
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Invalid Option.");
                                    break;
                                }
                        }
                        if (staffChoice != "9") 
                        {
                            Console.WriteLine("\nPress any key to continue..."); Console.ReadKey();
                        }
                    }
                }
                else { Console.WriteLine("Invalid Credentials."); Console.ReadKey(); }
            }
        }
    }
}