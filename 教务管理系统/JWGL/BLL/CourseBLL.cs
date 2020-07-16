using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class CourseBLL : BaseBLL
    {
        internal static bool Addcourse(Course s)
        {
            if (courses.AddNewCourse(s) == false)
                return false;
            return true;
        }
        internal static Course QueryCourse(string id, out string error)
        {
            Course s = courses.RetrieveCourse(id);
            if (s != null)
            {
                error = "查询到此课程";
                return s;
            }
            else
            {
                error = "无此课程";
                return null;
            }
        }

        internal static Course RetrieveCourse(string id, out string error)
        {
            Course s = courses.RetrieveCourse(id);
            if (s != null)
            {
                error = "查询到此课程";
                return s;
            }
            else
            {
                error = "无此课程";
                return null;
            }
        }
        internal static bool DeleteCourse(string id, out string error)
        {
            bool K = courses.RemoveCourse(id);
            if (K == true)
            {
                error = "删除成功";
            }
            else
            {
                error = "删除失败";
            }
            return K;
        }

        internal static Course[] RetrieveAllCourse()
        {
            return courses.RetrieveAll();
        }
    }
}
