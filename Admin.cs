using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBBS.BL
{
    public class Admin : User
    {
        private int AdminID;
       
        public Admin(string name, string pass, string contact, int AdminID)
        {
            this.name = name;
            this.pass = pass;
            this.contact = contact;
            this.AdminID = AdminID;
        }

        // Getter Functions
        public string GetAdminName()
        {
            return this.name;
        }

        public string GetPass()
        {
            return this.pass;
        }
        public void SetPassword(string newPassword)
        {
            this.pass = newPassword;
        }

        public int GetAdminID()
        {
            return this.AdminID;
        }

        // To help neatness in file handling
        public string ToFileString()
        {
            return $"{GetAdminID()},{GetAdminName()},{GetPass()}"; // Convert objecct into comma seperated string
        }

        public static Admin FromFileString(string line) // This func is static cz it is used to create an object from a string, and we dont have an object to call it on yet
        {
            string[] data = line.Split(',');
            return new Admin(data[1], data[2], "", int.Parse(data[0]));
        }
    }
}
