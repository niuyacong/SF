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
    }
}
