using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollageWebApplication.Models
{
    public class UserModel
    {
        

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public bool IsActive
        {
            get; set;
        }

        public static int uniqueId;
        public int id;

        static public List<UserModel> usersList = new List<UserModel>();

        public UserModel(string firstName, string lastName, int birthYear, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            IsActive = isActive;
            id = uniqueId;
            uniqueId++;
        }
    }
}