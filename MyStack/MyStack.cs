using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyStack <T>
    {
        int count=0;
        T[] mass;

        public MyStack(int lenght)
        {
            this.mass = new T[lenght];
        }
        public int Count()
        {
            return count;
        }

        public void Push(T value)
        {
            if (count == mass.Length)
            {
                throw new Exception("Стек полон");
            }
            mass[count++] = value;
        }
        public void Pop()
        {
            if (count == 0)
            {
                throw new Exception("Стек пуст");
            }
            count--;
        }
        public T Top()
        {
            if (count == 0)
            { throw new Exception("Стек пуст"); }

            return mass[count-1];
        }
        public bool IsEmpty()
        {
            if (count == 0)
            { return true; }
            else
            {
                return false;
            }
        }
        public string DeletLC(string s)
        {
            string s1="";
            for (int i = 0; i < s.Length - 1; i++)
            {
                s1 += s[i];
            }
            return s1;
        }
    }
}
