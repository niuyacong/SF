using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.lib
{
    public class Merge<T> where T : IComparable
    {
        //O(nlogn)排序都可以进行两点优化
        //1、左右两边都是有序的，那么可以先进行中间相邻两数的比较，如果左小于右，那么左右两边可以不再进行排序
        //2、当进行排序的数组足够小的时候，越接近于有序数组，插入排序优于归并排序

        //实现归并排序，分组进行插入排序，合并成大组再进行插入排序，依次变大组进行排序
        public static T[] MergeSortBU(T[] arr,int n)
        {
            for (int size = 1; size <= n; size += size)//每次间隔是两倍的长度
            {
                //i+size<n 处理越界问题
                for (int i = 0; i+size < n; i += size + size)//间隔内的数进行排序
                {
                    compare1<T>.__merge(arr, i, i + size - 1,Math.Min( i + size + size - 1,n-1));//Math.min 也是处理越界问题的
                }
            }
            return arr;
        }
    }
}
