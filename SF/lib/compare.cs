using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.lib
{
    public class compare<T> where T : IComparable
    {
        //O(n^2)选择排序算法，扫描数组，找到最小的
        
       public static T[] order(T[] arr, int n)
       {
           //O(n^2)排序  从每一位一次向后比较，和比它小的交换位置
           //10000个数比较用时0.365  100000测试个数增加10倍，用时为36.592
           for (int i = 0; i < n; i++)
           {

               int minIndex = i;
               for (int j = i + 1; j < n; j++)//循环，直到找出最小的
               {
                   if (arr[j].CompareTo(arr[minIndex]) < 0)
                   {
                       minIndex = j;
                   }
               }
               //swap(arr[i], arr[minIndex]);//交换当前位置，与剩余位置中最小的那个
               T left = arr[i];
               T right = arr[minIndex];
               arr[i] = right;
               arr[minIndex] = left;
           }
           return arr;

       }
        //O(n^2)插入排序算法
        //将第二个数与第一个数，进行比较，小的话，交换位置。
        //比较第三个数与第二个数，小的话，交换位置，继续和第一个比较。大于第二个数的情况，不用再进行比较，
        //因此这种排序优于依次向后比较的排序
       //10000个测试数据,用时0.254 100000个测试数据，用时25.42 也是n^2的关系
        //shell sort希尔排序
       public static T[] InsertOrder(T[] arr, int n)
       {
           for (int i = 1; i < n; i++)
           {
               //把在循环中的交换过程进行优化
               //把将要比较的数复制一份
               //依次比较，将数值放进去
               T left = arr[i];
               int j;
               for (j = i; j > 0&&arr[j].CompareTo(arr[j-1])<0; j--)
               {
                   arr[j] = arr[j - 1];
               }
               arr[j] = left;
           }
           return arr;
       }
       //冒泡排序Bubble Sort  O（n2）
        //Step1：比较相邻的元素。如果第一个比第二个大，就交换他们两个

        //Step2：对每一对元素均进行此操作，经过一轮后最大的元素应位于最后一位

        //Step3：从第一个元素重复进行前两步，每一轮最后一个元素都不参与比较，进行n轮

        //算法结束。
        public static T[] BubbleSort(T[] arr,int n){
            for(int i=n;i>0;i--){
                int flag = 0;
                for(int j=i;j<i;j++){
                    if(arr[j].CompareTo(arr[j+1])>0){
                        T left=arr[j];
                        arr[j]=arr[j+1];
                        arr[j+1]=left;
                        flag = 1;
                    }
                }
                if (flag == 0)//交换，说明顺序有问题，没交换，说明后来的顺序已排好，循环结束
                {
                    break;
                }
            }
            return arr;
        }

       //希尔排序（Shell Sort）---插入排序的优化  O(nlogn)
        //Step1：先将整个待排元素序列分割成若干个子序列（由相隔某个“增量”的元素组成的）分别进行直接插入排序,分别进行插入排序时，原来相对位置并不发生变化。

        //Step2：依次缩减增量再进行排序。

        //Step3：待整个序列中的元素基本有序（增量足够小）时，再对全体元素进行一次直接插入排序。

        //算法结束。

        //因为直接插入排序在元素基本有序的情况下（接近最好情况），效率是很高的，因此希尔排序相较于前几种方法有较大的提升。
        public static T[] ShellSort(T[] arr,int n)
        {
            int f =(int) Math.Floor(decimal.Parse( n.ToString())/ 2);
            while (f > 0)
            {
                int num = (int)Math.Floor(decimal.Parse(n.ToString()) / f);
                int ext = n % f > 0 ? num++ : num;//可以分为几组
                for (int i = f; i < n; i+=f)
                {
                    if (arr[i].CompareTo(arr[i - f]) < 0)
                    {
                        T left = arr[i];
                        int j = i - f;
                        while (j >= 0 && arr[j].CompareTo(left)>0)
                        {
                            arr[j + f] = arr[j];
                            j -= f;
                        }
                        arr[j + f] = left;
                    }
                }
                f--;
            }
            return arr;
        }

        //检测排序是否正确 
        public static bool Issort(Func< T[], int,T[]> orders,T[] arr,int n){
            for(int i=n-1;i>0;i--){
                if(arr[i].CompareTo(arr[i-1])<0){
                    return false;
                }
            }
            return true;
        }
        //返回排序所用的时间
        public static string  TestSort(string sortname,Func< T[], int,T[]> orders,T[] arr,int n){
            DateTime start=DateTime.Now;
            orders(arr,n);
            DateTime end=DateTime.Now;
            if (!Issort(orders, arr, n))
            {
                return "失败。。";
            }
            //计算相差秒数
             TimeSpan span = start-end;
            double s=span.TotalSeconds;
            return sortname+"测试时间为："+start.ToString("yyyy-MM-dd HH:mm:ss")+"结束时间："+end.ToString("yyyy-MM-dd HH:mm:ss")+"共"+s.ToString();
        }
        //随机生成数字
        public static int[] GenraNum(int n)
        {
            int[] num = new int[n];
            for (int i = 0; i < n; i++)
            {
                Random random = new Random(DateTime.Now.Second+i);
                int r=random.Next(0, 10000);
                num[i] = r;
            }
            return num;
        }

        //copy同一份数组
        //数组复制需要深复制，浅复制会指向同一地址，一个数据变化，另一个也变化
        public static int[] CopyNum(int[] arr,int n)
        {
            int[] newarr = new int[n];
            Array.Copy(arr, 0, newarr, 0, arr.Length);
            return newarr;
        }
    }
}
