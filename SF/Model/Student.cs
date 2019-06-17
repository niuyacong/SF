using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    public class Student :IComparable
    {
       public string name { get; set; }
       public int score { get; set; }
       public Student(string name, int score)
       {
           this.name = name;
           this.score = score;
       }
       public int CompareTo(object obj)
       {
           Student stu = (Student)obj;
           if (this.score > stu.score)
               return 1;
           else if (this.score == stu.score)
               return 0;
           else
               return -1;
       }
    
    }
}
