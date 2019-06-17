using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.lib;
using SF.Model;
namespace SF
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";

            //一般排序，字符串
            string[] arr = { "A", "C", "B", "D" };
            //int型
            int[] num = { 14, 12, 6, 89 };
            //实体分数字段排序，输出姓名
            Student st1 = new Student("nyc1", 123);
            Student st2 = new Student("nyc2", 59);
            Student st3 = new Student("nyc3", 10);
            Student[] stu = { st3, st1, st2 };
            stu = compare<Student>.order(stu, 3);
            for (int i = 0; i < stu.Length; i++)
            {
                str += stu[i].name  + "  ";
            }
            Console.Write(str);
            Console.Read();
        }
    }
}
