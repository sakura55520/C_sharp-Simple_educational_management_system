using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class StudentBLL : BaseBLL
    {
        internal static void ChooseTermCourse()//选择学期课程
        {
            Console.WriteLine();
            Console.Write("请输入你要选修的课程ID(=课程ID+教师ID):");
            string termcourseID = Console.ReadLine();
            if (termCourses.RetrieveTermCourse(termcourseID) == null)
            {
                Console.WriteLine(">>>>错误提示：学期课程ID有误！");
                Console.WriteLine("**************************");
                return;
            }
            if (termCourses.AddNewStudent(user.ID, termcourseID))
            {
                Console.WriteLine("<<<<选课操作成功！");
                Console.WriteLine("**************************");
            }
            else
            {
                Console.WriteLine(">>>>错误提示：您已选过这门课！");
                Console.WriteLine("**************************");
            }
        }

        internal static void RemoveTermCourse()//退选学期课程
        {
            Console.WriteLine();
            Console.Write("请输入你要退选的课程ID(=课程ID+教师ID):");
            string termcourseID = Console.ReadLine();
            if (termCourses.RetrieveTermCourse(termcourseID) == null)
            {
                Console.WriteLine(">>>>错误提示：学期课程ID有误！");
                Console.WriteLine("**************************");
                return;
            }
            if (termCourses.RemoveStuTermCourse(user.ID, termcourseID))
            {
                Console.WriteLine("<<<<退选课操作成功！");
                Console.WriteLine("**************************");
            }
            else
            {
                Console.WriteLine(">>>>错误提示：您尚未选过这门课！");
                Console.WriteLine("**************************");
            }
        }

        internal static void ProMy()//个人信息
        {
            Console.WriteLine("**************************");
            Console.WriteLine(user.ToString());
            Console.WriteLine("**************************");
        }

        internal static void ListStudentCourse()//查询已选课程
        {
            TermCourse[] studentcourse = termCourses.StudentCourses(user.ID);
            Console.WriteLine("");
            Console.WriteLine("************************");
            if (studentcourse.Length == 0) Console.WriteLine("无！！！");
            for (int i = 0; i < studentcourse.Length; i++)
            {
                Console.WriteLine("学期课程ID:{0}  课程名称:{1}  教师:{2}", studentcourse[i].ID, TermCourseBLL.QueryCName(studentcourse[i].TCourseID), TermCourseBLL.QueryTName(studentcourse[i].TTeacherID));
            }
            Console.WriteLine("************************");
            Console.WriteLine();
        }
    }
}
