using System;
using System.Collections.Generic;
using JWGL.Model;

namespace JWGL.DAL
{
	/// <summary>
	/// TermCourseDAL 的摘要说明。
	/// </summary>
	[Serializable]
	public class TermCourseDAL
	{
		private List<TermCourse> termCourses;

		public TermCourseDAL()
		{
			this.termCourses = new List<TermCourse>();
		}

		/// <summary>
		/// 增加学期新课程
		/// </summary>
		/// <param name="newTermCourse"></param>
		/// <returns></returns>
		public bool AddNewTermCourse(TermCourse newTermCourse)
		{
			for(int i = 0;i<termCourses.Count;i++)
			{
				if(newTermCourse.ID == ((TermCourse)termCourses[i]).ID)
					return false;
			}
			termCourses.Add(newTermCourse);
			return true;
		}
		/// <summary>
		/// 根据学期开设课程的ID取消该课程
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool RemoveTermCourse(string ID)
		{
			for(int i=0;i<termCourses.Count;i++)
			{
				if(ID == ((TermCourse)termCourses[i]).ID)
				{
					termCourses.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 根据学期开设课程的ID检索开设课程
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public TermCourse RetrieveTermCourse(string ID)
		{
			for(int i=0;i<termCourses.Count;i++)
			{
				if(ID == termCourses[i].ID)
				{
					return termCourses[i];
				}
			}
			return null;
		}
        
		/// <summary>
		/// 返回学期开设的所有课程
		/// </summary>
		/// <returns></returns>
		public TermCourse[] RetrieveAll()
		{
			return termCourses.ToArray();
		}
	
		/// <summary>
		/// 根据教师ID检索任课信息
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public TermCourse[] TeachCourses (string ID)
		{
            List<TermCourse> teachCourses = new List<TermCourse>();
			for(int i=0;i<termCourses.Count;i++)
			{
                if (ID == termCourses[i].TTeacherID)
				{
					teachCourses.Add(termCourses[i]);
				}
			}
			return teachCourses.ToArray();
		}
        public bool AddNewStudent(string stuID, string termcourseID) //学生选课
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (termCourses[i].ID == termcourseID)
                {
                    for (int j = 0; j < termCourses[i].StudentSelect.Count; j++)
                    {
                        if (termCourses[i].StudentSelect[j].stuID == stuID)
                            return false;
                    }
                    TermCourse.studentcourse newstudent = new TermCourse.studentcourse();
                    newstudent.stuID = stuID;
                    newstudent.score = -1;
                    termCourses[i].StudentSelect.Add(newstudent);
                    return true;
                }
            }
            return false;
        }
        public bool RemoveStuTermCourse(string stuID, string termcourseID)//学生退课
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (termCourses[i].ID == termcourseID)
                {
                    for (int j = 0; j < termCourses[i].StudentSelect.Count; j++)
                    {
                        if (termCourses[i].StudentSelect[j].stuID == stuID)
                        {
                            termCourses[i].StudentSelect.RemoveAt(j);
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
        public TermCourse[] StudentCourses(string stuID)//学生查询已选课程
        {
            List<TermCourse> studentcourse = new List<TermCourse>();
            for (int i = 0; i < termCourses.Count; i++)
            {
                for (int j = 0; j < termCourses[i].StudentSelect.Count; j++)
                {
                    if (termCourses[i].StudentSelect[j].stuID == stuID)
                    {
                        studentcourse.Add(termCourses[i]);
                        break;
                    }
                }
            }
            return studentcourse.ToArray();
        }
	}
}
