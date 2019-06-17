using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.lib
{
    public class compare<T> where T : IComparable
    {

       public static T[] order(T[] arr, int n)
       {

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
    }
}
