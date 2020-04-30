using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Queue<T>
    {
        T[] Q1;
        int first = 0;
        int last = 0;
        int count = 0;
        public Queue(int length)
        {
            this.Q1 = new T[length];
        }
        public void Push(T value)
        {
            if (count == Q1.Length)
            { throw new Exception("Stack is full"); }
            
            Q1[last++] = value;
            count++;
            if (last == Q1.Length)
            { last = 0; }
            
        }
        public T Pop()
        {
            if (count == 0)
            { throw new Exception("Stack is empty"); }
            T tmp = Q1[first];
            first++;
            count--;
            if (first == Q1.Length)
            {
                first = 0;
            }
            return tmp;
        }
        public T Top()
        {
            if (count == 0)
            {
                throw new Exception("Stack is empty");
            }
            return Q1[first];
        }
        public bool IsEmpty()

        {
            if (count == 0)
            {
                return true;

            }
            else return false;
        }

        public T TopIndex(int i)
        {
            if (count != 0)
            { return Q1[i]; }
            else
            { throw new Exception("Вах!"); }
        }
        public int Count()
        {
            return count;
        }
        public int First()
        { return first; }
        public int Last()
        { return last; }
      
        public string DeletLC(string s)
        {
            string s1 = "";
            for (int i = 1; i < s.Length; i++)
            {
                s1 += s[i];
            }
            return s1;
        }
        public string Print(Queue<string> I)
        {
            
            

            string s="";
            int tmpCount = I.Count();
            int tmpLast = I.Last();
            int tmpFirst = I.First();
            for(int i=tmpFirst;i<tmpLast;i++)
            {

                s += "\r\n" + I.TopIndex(i);
                
            }
            
            return s;
        }

    }
}
