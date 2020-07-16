 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWGL.Model
{
    [Serializable]
    public class Person
    {
        protected string name;
        protected string id;
        protected string password;
        public Person()
        { }
        public Person(string name,string password)
        {
            this.name = name;
            this.password = password;
        }
        public string ID
        {
            get { return this.id; }
        }
        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }
        public string Name
        {
            get { return this.name; }
        }
    }
}
