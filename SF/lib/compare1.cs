using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.lib
{
    //此类中均未O(nlogn)排序算法
  public  class compare1<T> where T : IComparable
    {
      //归并排序(递归拆分，归并，在归并的顺序)
        //相同的数据量测试 100000插入排序用时22.35 归并排序用时0.027
      public static T[] MergeOrder(T[]arr ,int n)
      {
          //拆分的每个子数组也进行自己的归并排序
          __mergeorder(arr,0,n-1);
          return arr;
      }
      //递归拆分
      public static void __mergeorder(T[] arr, int l,int r)
      {
          //if (l >= r)
          //{
          //    return;
          //}
          //优化：在数据小的情况，近乎有序的概率比较大，使用插入排序有优势
          //当n足够小的时候，O(n^2)要比O(nlogn)要快，so..
          if (r - l <= 15)//15??
          {
              InsertOrder(arr, l, r);
              return;
          }

          int mid=(l+r)/2;
          __mergeorder(arr,l,mid);
          __mergeorder(arr,mid+1,r);
          if (arr[mid].CompareTo(arr[mid + 1])>0) //mid左边是有序的，从小到大，右边也是有序的，所以比较中间就可以了，可以节省时间
          { 
          __merge(arr,l,mid,r);//拆分的数组进行归并
          }
      }
      public static void __merge(T[]arr ,int l,int mid,int r){
          //此操作是复制一份arr[l-r]的副本到aux
          T[] aux=new T[r-l+1];
         for(int i=l;i<=r;i++){
             aux[i-l]=arr[i];
         }
          //
         int left=l,right=mid+1;
         for(int k=l;k<=r;k++){
             if(left>mid)//如果左边大于中间的索引了，说明右边没有循环完
             {
                 arr[k]=aux[right-l];
                 right++;
             }
             else if(right>r){
                 arr[k]=aux[left-l];
                 left++;
             }
             else if (aux[left - l].CompareTo(aux[right - l]) < 0)
             {
                 arr[k]=aux[left-l];
                 left++;
             }else{
                 arr[k]=aux[right-l];
                 right++;
             }
         }
      }
      public static T[] InsertOrder(T[] arr, int l,int r)
      {
          for (int i = l==0?1:l; i < r; i++)
          {
              //把在循环中的交换过程进行优化
              //把将要比较的数复制一份
              //依次比较，将数值放进去
              T left = arr[i];
              int j;
              for (j = i; j > 0 && arr[j].CompareTo(arr[j - 1]) < 0; j--)
              {
                  arr[j] = arr[j - 1];
                  arr[j - 1] = left;
              }

          }
          return arr;
      }
    }
}
