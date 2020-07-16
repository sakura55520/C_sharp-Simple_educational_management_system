using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWGL.Model;
using JWGL.DAL;

namespace JWGL.BLL
{
    class LoginBLL : BaseBLL
    {
        internal static bool Login(string useID, string usePD, out string p)
        {
            p = "";
            switch (useID.ToLower()[0])
            {
                case 'a':
                    user = (Admin)admins.Retrieve(useID);
                    break;
                case 't':
                    user = (Teacher)teachers.Retrieve(useID);
                    break;
                case 's':
                    user = (Student)students.Retrieve(useID);
                    break;
                default:
                    p = "用户ID格式不正确！";
                    return false;
            }
            if (user != null)
                if (user.Password == usePD)
                {
                    p = "欢迎登陆教务管理系统！";
                    return true;
                }
                else
                {
                    p = "密码错误";
                    return false;
                }
            else
            {
                p = "用户ID不存在！";
                return false;
            }
        }
    }
}
