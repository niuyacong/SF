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
            //shell 排序
            //num = compare<int>.ShellSort(num,4);
            //归并排序
            num = compare1<int>.MergeOrder(num, 4);
            for (int i = 0; i < num.Length; i++)
            {
                str += num[i] + "  ";
            }

            //实体分数字段排序，输出姓名

            //Student st1 = new Student("nyc1", 123);
            //Student st2 = new Student("nyc4", 59);
            //Student st3 = new Student("nyc5", 59);
            //Student[] stu = { st3, st1, st2 };
            //stu = compare<Student>.order(stu, 3);
            //for (int i = 0; i < stu.Length; i++)
            //{
            //    str += stu[i].name  + "  ";
            //}

            //string result = "";
            //int[] test = compare<int>.GenraNum(100000);
            //int[] newtest = compare<int>.CopyNum(test, 100000);
            //result = compare<int>.TestSort("Test", compare<int>.order, test, 100000);
            //result += compare<int>.TestSort("insertTest", compare<int>.InsertOrder, test, 100000);
            //result += compare<int>.TestSort("shellTest", compare<int>.ShellSort, newtest, 100000);
            //result += compare<int>.TestSort("mergeTest", compare1<int>.MergeOrder, newtest, 100000);
            //test=null;
            Console.Write(str);
            Console.Read();
        }
    }
}
