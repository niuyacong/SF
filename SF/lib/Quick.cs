using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.lib
{
    public class Quick<T> where T : IComparable
    {
        //O(n(logn))

        //一般以第一个数为基点，找到位置p，p左边的都比这个数小，右边的都比他大，剩下的左右两边都递归循环这个过程

        //10000的测试数据，归并排序用时0.254 快速排序用时0.002
        public static T[] quickSort(T[] arr, int n)
        {
            __quickSort(arr, 0, n - 1);
            return arr;
        }

        public static void __quickSort(T[] arr, int left, int right)
        {
            //可优化：数据少于15时，可以用插入排序
            if (left >= right)
            {
                return;
            }
            
            int p=__partition(arr,left,right);
            __quickSort(arr,left,p-1);
            __quickSort(arr,p+1,right);
        }

        public static int  __partition(T[] arr, int left, int right)
        {
            //在近乎有序的数组中，从左侧第一个值依次比较，可能比较完之后，右侧的统统比他大
            //为优化这个问题，可以 随机选择数据中的一个元素，让他与左侧第一个元素进行交换
            T first = arr[left];
            int j = left;
            for (int i = left+1; i <= right; i++)
            {
                if (arr[i].CompareTo(first) < 0)
                {
                    //可以认为j是虚拟的，给第一个数占位置
                    var m = arr[j + 1];
                    arr[j+1] = arr[i];
                    arr[i] = m;
                    j++;
                }
            }
            var end = arr[j];
            arr[left] = end;
            arr[j] = first;
            return j;
        }
        //在一组数据中存在多个重复的数字，则排序又会出现O(n^2)的情况
        //方法：i从左侧开始，找到小于第一个数字的，j从右侧（也就是末尾）开始寻找大于第一个数字的
        //满足条件，继续下一个，不满足条件，交换位置
        public static int _partition2(T[] arr, int left, int right)
        {
            //随机取一个数，和第一个位置的数字交换位置
            Random rnd = new Random();
            var sid = rnd.Next(0, right - left);
            var num = left + sid;
            var first = arr[left];
            arr[left] = arr[num];
            arr[num] = first;
            //取第一个值
            var v = arr[left];

            //arr[left+1....i]<=v;  arr[j.....right]>=v
            int i = left + 1, j = right;
            while (true)
            {
                while (i <= right && arr[i].CompareTo(v)<0) i++;
                while (j >= left + 1 && arr[j].CompareTo(v) > 0) j++;
                if (i > j) break;
                //交换i  和   j的位置
                var a = arr[j];
                arr[j] = arr[i];
                arr[i] = a;
                i++;
                j--;
            }
            //最后交换 left 和j 的位置
            arr[left] = arr[j];
            arr[j] = v;
            return j;
        }

        //三路排序，lt左边的比v小，gt右边的比v大，lt-gt之间的等于v
        public void quicksort3ways(T[]arr,int n)
        {
            __quickSort3Ways(arr, 0, n - 1);
        }

        public void __quickSort3Ways(T[] arr, int left, int right)
        {
            //如果数据量小,可以使用快速排序
            //if (right - left <= 15)
            if (left > right)
            {
                return;
            }
            var v=arr[left];
            //随机取一个数，和第一个位置的元素交换位置
            int lt = left;
            int gt = right + 1;
            int i = left + 1;
            while (i < gt)
            {
                if (arr[i].CompareTo(v)<0)
                {
                    //交换i和lt+1的元素
                    lt++;
                    i++;
                }
                else if (arr[i].CompareTo(v) > 0)
                {
                    //交换gt-1和i的位置
                    gt--;
                }
                else
                {
                    i++;
                }
            }

            //最后,交换left和lt位置的元素


            __quickSort3Ways(arr, left, lt - 1);
            __quickSort3Ways(arr, gt, right);

        }
    }
}
