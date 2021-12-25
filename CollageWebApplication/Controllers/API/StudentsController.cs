using CollageWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollageWebApplication.Controllers.API
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(StudentModel.studentList);
            }
            catch
            {
                return Ok(new { Massage = "No students been found" });
            }
        }

        // GET: api/Students/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                StudentModel expectedstudent = StudentModel.studentList.Find(student => student.id == id);
                return Ok(expectedstudent);
            }
            catch
            {
                return Ok(new { Massage = "No student been found" });
            }
        }

        // POST: api/Students
        public IHttpActionResult CreateNewStudent([FromBody] StudentModel student)
        {
            try
            {
                StudentModel newStudent = student;
                StudentModel.studentList.Add(newStudent);
                return Ok(new { Massage = "Student Been Added", StudentModel.studentList });
            }
            catch
            {
                return Ok(new { Massage = "Error adding new student." });
            }
        }

        [HttpPut]
        // PUT: api/Students/5
        public IHttpActionResult EditStudent(int id, [FromBody] StudentModel student)
        {
            for (int i = 0; i < StudentModel.studentList.Count; i++)
            {
                if (StudentModel.studentList[i].id == id)
                {
                    StudentModel.studentList[i].FullName = student.FullName;
                    StudentModel.studentList[i].Class = student.Class;
                    StudentModel.studentList[i].BirthYear = student.BirthYear;
                    StudentModel.studentList[i].Grades = student.Grades;
                    return Ok(new { Massage = "Student Been Edited", StudentModel.studentList });
                }
            }
            return Ok(new { Massage = "No student been found" });
        }

        // DELETE: api/Students/5
        public IHttpActionResult DeleteStudent(int id)
        {
            for (int i = 0; i < StudentModel.studentList.Count; i++)
            {
                if (StudentModel.studentList[i].id == id) StudentModel.studentList.RemoveAt(i);
                return Ok(new { Massage = "Student been deleted", StudentModel.studentList });
            }
            return Ok(new { Massage = "No student been found" });
        }
    }
}
