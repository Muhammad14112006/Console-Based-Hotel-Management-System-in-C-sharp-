using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBS.BL
{
    public class Staff: User
    {
        private int StaffID;

        public Staff(string name, string pass, string contact, int StaffID)
        {
            this.name = name;
            this.pass = pass;
            this.contact = contact;
            this.StaffID = StaffID;
        }

        // Getter Functions
        public int GetStaffID()
        {
            return this.StaffID;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetPassword()
        {
            return this.pass;
        }
        public void SetPassword(string newPassword)
        {
            this.pass = newPassword;
        }

        // Functions to help neatness in file handling
        public string ToFileString()
        {
            return $"{GetStaffID()},{GetName()},{GetPassword()}"; // Convert objecct into comma seperated string
        }

        public static Staff FromFileString(string line) // This func is static cz it is used to create an object from a string, and we dont have an object to call it on yet
        {
            string[] data = line.Split(',');
            return new Staff(data[1], data[2], "", int.Parse(data[0]));
        }
    }
}
