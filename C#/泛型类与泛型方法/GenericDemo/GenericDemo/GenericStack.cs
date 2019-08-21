using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    /// <summary>
    /// 出栈入栈通用类
    /// </summary>
    /// <typeparam name="T">任意类型</typeparam>
    public class GenericStack<T>
    {
        private T[] stack;      //栈
        private int stackPoint; //位置指针
        private int size;       //栈数据容量

        public GenericStack(int size)
        {
            this.size = size;
            this.stack = new T[size];
            this.stackPoint = -1;
        }

        public void Push(T item)
        {
            if (stackPoint>=size)
            {
                Console.WriteLine("栈空间已满");
            }
            else
            {
                stackPoint += 1;
                stack[stackPoint] = item;
            }
        }
        public T Pop()
        {
                T result = stack[stackPoint];
                stackPoint--;
                return result;
        }
    }
}
