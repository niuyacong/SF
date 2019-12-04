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
        //static void Main(string[] args)
        //{
        //    string str = "";

        //    //一般排序，字符串
        //    string[] arr = { "A", "C", "B", "D" };
        //    //int型
        //    int[] num = { 14, 12, 6, 89 };
        //    //shell 排序
        //    //num = compare<int>.ShellSort(num,4);
        //    //归并排序
        //    num = compare1<int>.MergeOrder(num, 4);
        //    for (int i = 0; i < num.Length; i++)
        //    {
        //        str += num[i] + "  ";
        //    }

        //    //实体分数字段排序，输出姓名

        //    //Student st1 = new Student("nyc1", 123);
        //    //Student st2 = new Student("nyc4", 59);
        //    //Student st3 = new Student("nyc5", 59);
        //    //Student[] stu = { st3, st1, st2 };
        //    //stu = compare<Student>.order(stu, 3);
        //    //for (int i = 0; i < stu.Length; i++)
        //    //{
        //    //    str += stu[i].name  + "  ";
        //    //}

        //    string result = "";
        //    int[] test = compare<int>.GenraNum(10000);
        //    int[] newtest = compare<int>.CopyNum(test, 10000);
        //    //result = compare<int>.TestSort("Test", compare<int>.order, test, 100000);
        //    //result += compare<int>.TestSort("insertTest", compare<int>.InsertOrder, test, 100000);
        //    //result += compare<int>.TestSort("shellTest", compare<int>.ShellSort, test, 100000);
        //    result += compare<int>.TestSort("mergeTest", compare1<int>.MergeOrder, test, 10000);
        //    result += compare<int>.TestSort("quickSort", Quick<int>.quickSort, newtest, 10000);
        //    //test=null;
        //    Console.Write(result);
        //    Console.Read();
        //}
       public List<int> orderlist = new List<int>();
        static void Main(string[] args)
        {
            var list=new List<int>();
            for(int i=1;i<11;i++){
                list.Add(i);
            }
            var orderlist = new List<int>();
            for(int i=1;i<list.Count+1;i++)
            {
                orderlist.Add(i);
            }

        }
        static string  returnresult(List<int> list,List<int>orderlist)
        {
           var  result = new List<int>();
           var  len = new List<int>();
            var end = Math.Floor(decimal.Parse((list.Count / 3).ToString()));
            if (end != list.Count)
            {

                for (int i = int.Parse(end.ToString()) + 1; i < list.Count; i++)
                {
                    result.Add(list[i]);
                    len.Add(orderlist[i]);
                }
            }
            if (list.Count == 1)
            {
                return result[0]+","+len[0];
            }
            if (list.Count == 1)
            {
               return result[1]+","+len[1];
            }
            for (int i = 0; i < end; i++)
            {
                result.Add(list[i * 3 + 0]);
                len.Add(orderlist[i * 3 + 0]);
                result.Add(list[i * 3 + 1]);
                len.Add(orderlist[i * 3 + 1]);
            }
            if (result.Count >= 3)
            {
                returnresult(result, len);
            }
             
        }
    }
}
