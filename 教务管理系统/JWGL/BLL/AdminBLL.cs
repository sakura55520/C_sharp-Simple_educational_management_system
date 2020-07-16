using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class AdminBLL : BaseBLL
    {
        #region 老师管理
        internal static bool AddTeacher(string Name, string Password, out string error)
        {
            Teacher T = new Teacher(Name,Password);
            if(teachers.Add(T))
            {
                error = "添加成功!";
                return true;
            }
            else
            {
                error = "添加失败!";
                return false;
            }        
        }
        internal static Person RetrieveTeacher(string id, out string error)
        {
            Person x1 = teachers.Retrieve(id);
            if (x1 != null)
            {
                error = "老师存在";
            }
            else error = "老师不存在";
            return x1;
        }
        internal static bool DeleteTeacher(string id, out string error)
        {
            if (teachers.Remove(id))
            {
                error = "删除成功";
                return true;
            }
            else
            {
                error = "删除失败";
                return false;
            }
        }
        internal static Person[] RetrieveAllTeachers()
        {
            return teachers.RetrieveAll();
        }
        internal static bool ChangPWTeacher(string id, out string error)
        {
            Console.Write("请输入新密码:");
            string newPW=Console.ReadLine();
            bool T = teachers.ChangPW(id, newPW);
            if(T==false)
            {
                error = "教师ID不存在";
                return false;
            }
            error = "教师ID存在";
            return true;
        }
        #endregion

        #region 学生管理
        internal static Person[] RetrieveAllStudents()
        {
            return students.RetrieveAll();
        }
        internal static Person RetrieveStudent(string id, out string error)
        {
            Person x1 = students.Retrieve(id);
            if (x1 != null)
            {
                error = "学生存在";
            }
            else error = "学生不存在";
            return x1;
        }
        internal static bool DeleteStudent(string id, out string error)
        {
            if (students.Remove(id))
            {
                error = "删除成功";
                return true;
            }
            else
            {
                error = "删除失败";
                return false;
            }
        }
        internal static bool AddStudent(string Name, string Password, out string error)
        {
            Student S = new Student(Name, Password);
            if (students.Add(S))
            {
                error = "添加成功";
                return true;
            }
            else
            {
                error = "添加失败";
                return false;
            }
        }
        internal static bool ChangPWStudent(string id, out string error)
        {
            Console.Write("请输入新密码:");
            string newPW = Console.ReadLine();
            bool S = students.ChangPW(id, newPW);
            if (S == false)
            {
                error = "学生ID不存在";
                return false;
            }
            error = "学生ID存在";
            return true;
        }
        #endregion
    }
}
