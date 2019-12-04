using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.heap
{
   public  class MaxHeap
    {
       private int[] item;
       private int count;

       public MaxHeap(int count)
       {
           item = new int[count+1];
           count = 0;
       }

       public void Insert(int n)
       {
           item[count + 1] = n;
           count++;
       }
    }
}
