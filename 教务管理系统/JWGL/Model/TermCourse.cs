using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class TermCourse
    {
        [Serializable]
        public struct studentcourse
        {
            public string stuID;
            public double score;
            studentcourse(string id, double sc)
            {
                stuID = id;
                score = sc;
            }
            public void change(double score)
            {
                if (score >= 0) this.score = score;
            }
        }
        public List<studentcourse> StudentSelect;
        string id;
        string courseID = "";
        string teacherID = "";  
        public TermCourse(string teacherID,string courseID)
        {
            this.teacherID = teacherID;
            this.courseID = courseID;
            this.id = courseID + teacherID;
            this.StudentSelect = new List<studentcourse>();
        }
        public string TID
        {
            get { return id; }
        }
        public string TCourseID
        {
            set { courseID = value; }
            get { return courseID; }
        }
        public string TTeacherID
        {
            set { teacherID = value; }
            get { return teacherID; }
        }
        public string ID
        {
            get { return this.id; }
        }
    }
}
