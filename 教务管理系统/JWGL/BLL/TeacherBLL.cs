using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class TeacherBLL : BaseBLL
    {
        internal static void PointTermCourse()//课程成绩登记
        {
            ListTeacherCourse();
            Console.WriteLine();
            Console.Write("请输入您要打分的学期课程ID：");
            string termcourseID = Console.ReadLine();
            TermCourse termcourse = termCourses.RetrieveTermCourse(termcourseID);
            if (termcourse == null)
            {
                Console.WriteLine("<<<<错误提示：此课程不存在！");
                Console.WriteLine("**************************");
                return;
            }
            if (termcourse.TTeacherID != user.ID)
            {
                Console.WriteLine("<<<<错误提示：此课程不是您授课！");
                Console.WriteLine("**************************");
                return;
            }
            for (int i = 0; i < termcourse.StudentSelect.Count; i++)
            {
                Console.Write("当前学生ID:{0} ，请输入分数：", termcourse.StudentSelect[i].stuID);
                double score = double.Parse(Console.ReadLine());
                termcourse.StudentSelect[i].change(score);
            }
            if (termcourse.StudentSelect.Count == 0)
                Console.WriteLine("无");
        }

        internal static void ListTeacherCourse()//查询在授学期课程
        {
            TermCourse[] termcourse = termCourses.TeachCourses(user.ID);
            Console.WriteLine();
            Console.WriteLine("************************");
            if (termcourse.Length == 0) Console.WriteLine("无");
            for (int i = 0; i < termcourse.Length; i++)
            {
                Console.WriteLine("学期课程ID:{0}  课程名称:{1}  教师:{2}", termcourse[i].ID, TermCourseBLL.QueryCName(termcourse[i].TCourseID), TermCourseBLL.QueryTName(termcourse[i].TTeacherID));
            }
            Console.WriteLine();
            Console.WriteLine("************************");
        }

        internal static void AddNewCourse()//新增授课课程
        {
            Console.WriteLine();
            Console.Write("请输入您要授课的课程ID:");
            string courseID = Console.ReadLine();
            if (courses.RetrieveCourse(courseID) == null)
            {
                Console.WriteLine("查无此课程");
                return;
            }
            TermCourse termcourse = new TermCourse(user.ID, courseID);
            if (termCourses.AddNewTermCourse(termcourse))
            {
                Console.WriteLine(">>>>成功添加新课程记录");
                Console.WriteLine("**************************");
            }
            else
            {
                Console.WriteLine("<<<<错误提示：您可能已经在授此课程！");
                Console.WriteLine("**************************");
            }
        }

        internal static void ProMy()//个人信息 
        {
            Console.WriteLine("**************************");
            Console.WriteLine(user.ToString());
            Console.WriteLine("**************************");
        }
    }
}
