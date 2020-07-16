using System;
using System.Collections.Generic;
using JWGL.Model;
namespace JWGL.DAL
{
	/// <summary>
	/// CourseDAL ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class CourseDAL
	{
		private List<Course> courses;
		public CourseDAL()
		{
			this.courses = new List<Course>();
		}
		/// <summary>
		/// �����¿γ�
		/// </summary>
		/// <param name="newCourse"></param>
		/// <returns></returns>
		public bool AddNewCourse(Course course)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (course.CourseID == courses[i].CourseID)
				{
					return false;
				}
			}
			this.courses.Add(course);
			return true;
		}

		/// <summary>
		/// ���ݿγ̱�ż����γ�
		/// </summary>
		/// <param name="courseID"></param>
		/// <returns></returns>
		public Course RetrieveCourse(string courseID)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (courseID == courses[i].CourseID)
				{
					return courses[i];
				}
			}			
			return null;
		}

		/// <summary>
		/// �������пγ�
		/// </summary>
		/// <returns></returns>
		public Course[] RetrieveAll()
		{
			return courses.ToArray();
            
		}

		/// <summary>
		/// ���ݿγ�IDɾ���γ�
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool RemoveCourse(string courseID)
		{
			for(int i=0;i<courses.Count;i++)
			{
                if (courseID == courses[i].CourseID)
				{
					courses.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
	}
}
