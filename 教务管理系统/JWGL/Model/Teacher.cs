using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Teacher : Person
    {
        public static int TID;
        public Teacher(string name, string password)
            : base(name, password)
        {
            TID++;
            id = GetID();
        }
        private string GetID()
        {
            return 'T' + (TID).ToString();
        }
        public override string ToString()
        {
            return string.Format("ID：{0}  姓名：{1}  密码：{2}", id, name, password);
        }
    }
}
