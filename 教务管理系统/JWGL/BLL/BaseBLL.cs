using System;
using JWGL.Model;
using JWGL.DAL;
namespace JWGL.BLL
{
	/// <summary>
	/// BaseBLL 的摘要说明。
	/// </summary>
    /// 
    [Serializable]
	public class BaseBLL
	{
		protected static Person user;
		protected static AdminDAL admins;
		protected static StudentDAL students;
		protected static TeacherDAL teachers;
		protected static CourseDAL courses;
		protected static TermCourseDAL termCourses;

		protected BaseBLL()
        {
        }
		static BaseBLL()
		{
			admins = DataFileAccess.GetAdmins();
			students = DataFileAccess.GetStudents();
			teachers = DataFileAccess.GetTeachers();
			courses = DataFileAccess.GetCourses();
			termCourses = DataFileAccess.GetTermCourses();
            InitInitIDs();
		}
        private static void InitInitIDs()
        {
            int maxid = -1;
            maxid = admins.GetMaxID();
            if (maxid != -1) Admin.adminID = maxid;
            maxid = teachers.GetMaxID();
            if (maxid != -1) Teacher.TID = maxid;
            maxid = students.GetMaxID();
            if (maxid != -1) Student.SID = maxid;
        }
		public static Person User
		{
			get{return user;}
		}
		/*public static TermCourseBLL RetrieveTermCourse(string termCourseId)
		{
			return termCourses.RetrieveTermCourse(termCourseId);
		}*/
        internal static void SaveALL()
        {
            DataFileAccess.SaveAdmins(admins);
            DataFileAccess.SaveCourses(courses);
            DataFileAccess.SaveStudents(students);
            DataFileAccess.SaveTeachers(teachers);
            DataFileAccess.SaveTermCourses(termCourses);
        }
	}
}
