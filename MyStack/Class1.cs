using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Class1<T>
    {
        T[] Q1;
        int first = 0;
        int last = 0;
        int count = 0;
        public Class1(int length)
        {
            this.Q1 = new T[length];
        }
        public void Push(T value)
        {
            if (count == Q1.Length)
            { throw new Exception("Stack is full"); }
            
            Q1[first++] = value;
            count++;
            if (first == Q1.Length)
            { first = 0; }
            
        }
        public T Pop()
        {
            if (count == 0)
            { throw new Exception("Stack is empty"); }
            T tmp = Q1[last];
            last++;
            count--;
            if (last == Q1.Length)
            {
                last = 0;
            }
            return tmp;
        }
        public T Top()
        {
            if (count == 0)
            {
                throw new Exception("Stack is empty");
            }
            return Q1[last];
        }
        public bool IsEmpty()

        {
            if (count == 0)
            {
                return true;

            }
            else return false;
        }
        public int Count()
        {
            return count;
        }
        public string TMP()
        {
            return " "+first+" "+last;
        }
        public string DeletLC(string s)
        {
            string s1 = "";
            for (int i = 1; i < s.Length; i++)
            {
                s1 += s[i];
            }
            return s1;
        }
    }
}
