using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex28_WPFTusindfrydGUI.Model
{
    public class Employee
    {
        static private int count = 0;
        private int id;
        private string name;
        private int age;
        private string cpr;
        private string imgPath;
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age;} set { age = value; } }
        public string Cpr { get { return cpr; } set { cpr = value; } }
        public string ImgPath { get { return imgPath; } set { imgPath = value; } }

        public Employee(string name, int age, string cpr, string imgPath)
        {
            count++;
            this.Id = count;
            this.Name = name;
            this.Age = age;
            this.Cpr = cpr;
            this.ImgPath = imgPath;
            
        }

    }
}
