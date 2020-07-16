using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Student : Person
    {
        public static int SID;
        public Student(string name, string password)
            : base(name,password)
        {
            SID++;
            id = GetID();
        }
        private string GetID()
        {
            return 'S' + (SID).ToString();
        }
        public override string ToString()
        {
            return string.Format("ID：{0}  姓名：{1}  密码：{2}", id, name, password);
        }
    }
}
