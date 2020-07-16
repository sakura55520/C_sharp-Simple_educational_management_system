using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Admin : Person
    {
        public static int adminID;
        public Admin()
        {

        }
        public Admin(string name, string id, string password)
            : base(name, password)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return string.Format("ID：{0}  姓名：{1}  密码：{2}", id, name, password);
        }
    }
}
