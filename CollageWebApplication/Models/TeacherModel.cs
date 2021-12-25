using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollageWebApplication.Models
{
    public class TeacherModel
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public int StartingYear { get; set; }
        public string[] Experties { get; set; }

        public static int uniqueId;
        public int id;

        public TeacherModel(string fullName, int salary, int startingYear, string[] experties)
        {
            FullName = fullName;
            Salary = salary;
            StartingYear = startingYear;
            Experties = experties;

            id = uniqueId;
            uniqueId++;
        }

        static public List<TeacherModel> teacherList = new List<TeacherModel>();
    }
}