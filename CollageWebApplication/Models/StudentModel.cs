using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollageWebApplication.Models
{
    public class StudentModel
    {
        public StudentModel(string fullName, string @class, int birthYear, int[] grades)
        {
            FullName = fullName;
            Class = @class;
            BirthYear = birthYear;
            Grades = grades;

            id = uniqueId;
            uniqueId++;
        }

        public string FullName { get; set; }
        public string Class { get; set; }
        public int BirthYear { get; set; }
        public int[] Grades { get; set; }

        public static int uniqueId;
        public int id;

        static public List<StudentModel> studentList = new List<StudentModel>();


    }
}