using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class TermCourseBLL : BaseBLL
    {
        internal static bool AddTermcourse(TermCourse s)
        {
            return termCourses.AddNewTermCourse(s);
        }

        internal static TermCourse[] RetrieveAllTermCourse()
        {
            return termCourses.RetrieveAll();
        }

        internal static string QueryCName(string p)
        {
            Course c = courses.RetrieveCourse(p);
            return c.CourseName;
        }

        internal static string QueryTName(string p)
        {
            Person t = teachers.Retrieve(p);
            return t.Name;
        }

        internal static TermCourse QueryTermCourse(string id, out string error)
        {
            if (termCourses.RetrieveTermCourse(id) == null)
            {
                error = "没有找到次课程";
                return null;
            }
            else
            {
                error = "找到此课程";
                return termCourses.RetrieveTermCourse(id);
            }
        }
    }
}