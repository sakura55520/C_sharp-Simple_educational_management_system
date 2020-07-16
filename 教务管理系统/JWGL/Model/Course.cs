using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Course
    {
        string id;
        string name;
        int gra;
        public Course(string id, string name, int gra)
        {
            this.id = id;
            this.name = name;
            this.gra = gra;
        }
        public string CourseID
        {
            get { return this.id; }
        }
        public string CourseName
        {
            get { return this.name; }
        }
        public int CourseGra
        {
            get { return this.gra; }
        }
    }
}
