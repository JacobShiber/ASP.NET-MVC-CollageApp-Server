using CollageWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollageWebApplication.Controllers.API
{
    public class TeachersController : ApiController
    {
        // GET: api/Teachers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(TeacherModel.teacherList);
            }
            catch
            {
                return Ok(new { Massage = "No teachers been found" });
            }
        }

        // GET: api/Teachers/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                TeacherModel expectedteacher = TeacherModel.teacherList.Find(teacher => teacher.id == id);
                return Ok(expectedteacher);
            }
            catch
            {
                return Ok(new { Massage = "No teacher been found" });
            }
        }

        // POST: api/Teachers
        public IHttpActionResult CreateNewTeacher([FromBody] TeacherModel teacher)
        {
            try
            {
                TeacherModel newTeacher = teacher;
                TeacherModel.teacherList.Add(newTeacher);
                return Ok(new { Massage = "Teacher Been Added", TeacherModel.teacherList });
            }
            catch
            {
                return Ok(new { Massage = "Error adding new teacher." });
            }
        }

        [HttpPut]
        // PUT: api/Teachers/5
        public IHttpActionResult EditTeacher(int id, [FromBody] TeacherModel teacher)
        {
            for (int i = 0; i < TeacherModel.teacherList.Count; i++)
            {
                if (TeacherModel.teacherList[i].id == id)
                {
                    TeacherModel.teacherList[i].FullName = teacher.FullName;
                    TeacherModel.teacherList[i].Salary = teacher.Salary;
                    TeacherModel.teacherList[i].StartingYear = teacher.StartingYear;
                    TeacherModel.teacherList[i].Experties = teacher.Experties;
                    return Ok(new { Massage = "Teacher Been Edited", TeacherModel.teacherList });
                }
            }
            return Ok(new { Massage = "No teacher been found" });
        }

        // DELETE: api/Teachers/5
        public IHttpActionResult DeleteTeacher(int id)
        {
            for (int i = 0; i < TeacherModel.teacherList.Count; i++)
            {
                if (TeacherModel.teacherList[i].id == id) TeacherModel.teacherList.RemoveAt(i);
                return Ok(new { Massage = "Teacher been deleted", TeacherModel.teacherList });
            }
            return Ok(new { Massage = "No teacher been found" });
        }
    }
}
