using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStack
{
    public partial class Calc:Form
    {
        Button[] bt = new Button[10];
        Button[] bt1 = new Button[6];
        List<string> L1;
        MyStack<char> M1;
        Queue<string> Q1;
        string PR = "|+-*/()";//Определние индекса для массва приоритетов
        int[,] MassivePr = new int[6, 8];
        public Calc()
        {
            InitializeComponent();


        }

        private void Calc_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            PP(MassivePr);
            string s1 = "1234567890";
            string s2 = "()+-*/";
            int x = 12;
            int y = 14;
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i] = new Button();
                
                if (i != 0 && i % 3 == 0)
                {
                    x = 12;
                    y += 32;
                }
                this.panel1.Controls.Add(bt[i]);
                bt[i].Click += new EventHandler(button2_Click); 
                bt[i].SetBounds(x, y, 41, 27);
                bt[i].Text = Convert.ToString(s1[i]);

               
                x += 46;                
            }
             x = 7;
            y = 14;
            for (int i = 0; i < bt1.Length; i++)
            {
                bt1[i] = new Button();
                if (i != 0 && i % 2 == 0)
                {
                    x = 7;
                    y += 32;
                }
                this.panel2.Controls.Add(bt1[i]);
                bt1[i].SetBounds(x, y, 41, 27);
                bt1[i].Text = Convert.ToString(s2[i]);
                bt1[i].Click += new EventHandler(button2_Click); 
                x += 46; 
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button vvod = new Button();
            vvod = sender as Button;
            textBox1.Text += vvod.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Timoshka2(textBox1.Text) == false)
            { button5.BackColor = Color.Red; }
            else
            { button5.BackColor = Color.Lime; }            
        }
        public bool Timoshka2(string String)
        {
             M1 = new MyStack<char> (String.Length);
            bool flag = false;
            for (int i = 0; i < String.Length; i++)
            {
                if ((char)String[i] == 40 || (char)String[i] == 91 || (char)String[i] == 123)
                {
                    M1.Push((char)String[i]);
                   
                }


                if (((char)String[i] == 41) || ((char)String[i] == 93) || (char)String[i] == 125)
                {
                    if (M1.IsEmpty() != true)
                    {
                        if (M1.Top() == ((char)String[i] - 2) || M1.Top() == ((char)String[i] - 1))
                        {

                            M1.Pop();
                          


                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag == false && M1.IsEmpty() == true)
            { return true; }
            else
            { return false; }
            
        }
        bool Check(string String)
        {
            bool flag = false;
            if(String.Length!=0)
            {
                if (String[0] != '+' && String[0] != '-' && String[0] != '*' && String[0] != '/' && String[0] != ')' && String[String.Length - 1] != '(' && String[String.Length - 1] != '+' && String[String.Length - 1] != '-' && String[String.Length - 1] != '*' && String[String.Length - 1] != '/')
                {

                    for (int i = 1; i < String.Length; i++)
                    {
                        if (String[i] == 42 || String[i] == 43 || String[i] == 45 || String[i] == 47)
                        {
                            if (String[i + 1] == 42 || String[i + 1] == 43 || String[i + 1] == 45 || String[i + 1] == 47)
                            {
                                flag = true;
                                break;
                            }
                            if (String[i - 1] == 42 || String[i - 1] == 43 || String[i - 1] == 45 || String[i - 1] == 47)
                            {
                                flag = true;
                                break;
                            }
                            if (String[i + 1] == ')')
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (String[i] == 40)
                        {
                            if (i > 0 && String[i - 1] <= 57 && String[i - 1] >= 48)
                            {
                                flag = true;
                                break;
                            }
                            if (i > 0 && String[i - 1] == 41)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (String[i] == 41)
                        {
                            if (i < String.Length - 1 && String[i + 1] <= 57 && String[i + 1] >= 48)
                            {
                                flag = true;
                                break;
                            }
                            if (i > 0 && String[i - 1] == 40)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                else
                { return true; }
            }
            else
            {
                flag = true;

            }


            return flag;

        }
        bool Nulle(string String)
        {
            if (String.Contains("/0") == true)
            {
                return true;
            }
            else
                return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check(textBox1.Text) == true || Nulle(textBox1.Text) == true || pr(textBox1.Text) == true)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Lime;
                string ach="";
                Q1 = Parse(textBox1.Text, ref ach);
                label2.Text = "";
                label2.Text = ach;
                ach = "";
                
                Q1 = Zapis_(Q1, ref ach);
                label3.Text = "";
                label3.Text = ach;
              
               
               
                char a=' ';
               textBox2.Text = Convert.ToString(Vichislenie(Q1,ref a));
                if (a == '~')
                {
                    textBox2.Text = Convert.ToString(a);
                MessageBox.Show("Деление на 0");
                }
            }
        }
        Queue<string> Parse(string String, ref  string st)
        {
            L1 = new List<string>();
            string tmp = "";
            int count=0;
            for (int i=0;i<String.Length;i++)
            {
                if (String[i] >= 48 && String[i] <= 57)
                {
                    tmp += String[i];
                    while (i < String.Length - 1 && String[i + 1] >= 48 && String[i + 1] <= 57)
                    {
                        i++;
                        tmp += String[i];
                    }
                    L1.Add(tmp);
                    st += tmp+" ";
                    count++;
                    tmp = "";
                }
                else { L1.Add(Convert.ToString(String[i]));
                st += String[i] + " ";
                count++;}
            }
            Queue<string> TMP = new Queue<string>(count+1);
           
            for (int i = 0; i < count; i++)
            {
                TMP.Push(L1[i]);
                
            }
            return TMP;
        }
        int Index(char ind)
        {
            for (int i = 0; i < PR.Length; i++)
            {
                if (ind == PR[i])
                { return i;
                
                }
            }
            return 7;

        }
        void PP(int[,] P)
        {
            P[0, 0] = 4;
            P[0, 1] = 1;
            P[0, 2] = 1;
            P[0, 3] = 1;
            P[0, 4] = 1;
            P[0, 5] = 1;
            P[0, 6] = 5;
            P[0, 7] = 6;

            P[1, 0] = 2;
            P[1, 1] = 2;
            P[1, 2] = 2;
            P[1, 3] = 1;
            P[1, 4] = 1;
            P[1, 5] = 1;
            P[1, 6] = 2;
            P[1, 7] = 6;

            P[2, 0] = 2;
            P[2, 1] = 2;
            P[2, 2] = 2;
            P[2, 3] = 1;
            P[2, 4] = 1;
            P[2, 5] = 1;
            P[2, 6] = 2;
            P[2, 7] = 6;

            P[3, 0] = 2;
            P[3, 1] = 2;
            P[3, 2] = 2;
            P[3, 3] = 2;
            P[3, 4] = 2;
            P[3, 5] = 1;
            P[3, 6] = 2;
            P[3, 7] = 6;

            P[4, 0] = 2;
            P[4, 1] = 2;
            P[4, 2] = 2;
            P[4, 3] = 2;
            P[4, 4] = 2;
            P[4, 5] = 1;
            P[4, 6] = 2;
            P[4, 7] = 6;

            P[5, 0] = 5;
            P[5, 1] = 1;
            P[5, 2] = 1;
            P[5, 3] = 1;
            P[5, 4] = 1;
            P[5, 5] = 1;
            P[5, 6] = 3;
            P[5, 7] = 6;

            
        }
        Queue<string> Zapis_ (Queue<string> TMPQ, ref string st)
        {
            TMPQ.Push("|");
            Queue<string> Qreturn = new Queue<string>(TMPQ.Count()-1);
            MyStack<string> TMPM = new MyStack<string>(TMPQ.Count());
           
            
            TMPM.Push("|");
            
                bool flag = false;
            while(flag == false)
            {
                if (TMPQ.Top() != "+" && TMPQ.Top() != "-" && TMPQ.Top() != "*" && TMPQ.Top() != "/" && TMPQ.Top() != "(" && TMPQ.Top() != ")" && TMPQ.Top() != "|")
                { Qreturn.Push(TMPQ.Top());
                  st+=TMPQ.Top();
                TMPQ.Pop();
                
                }
                else
                {
                    int tmp = MassivePr[Index(Convert.ToChar(TMPM.Top())), Index(Convert.ToChar(TMPQ.Top()))];
                    if (tmp == 1)
                    {
                        TMPM.Push(TMPQ.Top());
                        TMPQ.Pop();
                    }
                    if (tmp == 2)
                    {
                        Qreturn.Push(TMPM.Top());
                        st += TMPM.Top();
                        TMPM.Pop();
                    }
                    if (tmp == 3)
                    {
                        TMPM.Pop();
                        TMPQ.Pop();
                    }
                    if (tmp == 4)
                    {
                        break;
                    }
                    if (tmp == 5)
                    {
                        throw new Exception("Неправильные входные данные");
                    }
                    if (tmp == 6)
                    {
                        Qreturn.Push(TMPQ.Top());
                       st+=(TMPQ.Top());
                        TMPQ.Pop();
                    }
                }
            }
            
                return Qreturn;
                
            
        }
        double Vichislenie(Queue<string> S,ref char s1)
        {
            MyStack<double> M2 = new MyStack<double>(S.Count());
            
            double result = 0;
            double p1 = 0;
            double p2 = 0;
            bool flag = true;
            while (S.IsEmpty() != true)
            {
                if (S.Top() == "+" || S.Top() == "-" || S.Top() == "*" || S.Top() == "/")
                {
                    if (S.Top() == "+")
                    {
                        S.Pop();
                        p1 = M2.Top();
                        M2.Pop();
                        p2 = M2.Top();
                        M2.Pop();
                        M2.Push(p1 + p2);
                        
                        if (S.IsEmpty() == true)
                        { result = M2.Top();
                        break;
                        }
                    }
                    if (S.Top() == "*")
                    {
                        S.Pop();
                        p1 = M2.Top();
                        M2.Pop();
                        p2 = M2.Top();
                        M2.Pop();
                        M2.Push(p1 * p2);
                        if (S.IsEmpty() == true)
                        { result = M2.Top();
                        break;
                        }
                    }
                    if (S.Top() == "-")
                    {
                        S.Pop();
                        p1 = M2.Top();
                        M2.Pop();
                        p2 = M2.Top();
                        M2.Pop();
                        M2.Push(p2 - p1);
                        if (S.IsEmpty() == true)
                        { result = M2.Top();
                        break;
                        }
                    }
                    if (S.Top() == "/")
                    {
                        S.Pop();
                        p1 = M2.Top();
                        M2.Pop();
                        p2 = M2.Top();
                        M2.Pop();
                        if (p1 != 0)
                        {
                            M2.Push(p2 / p1);
                        }
                        else
                        {
                            s1 = '~';
                            flag = false;
                            break;
                        }
                        if (S.IsEmpty() == true)
                        { result = M2.Top();
                        break;
                        }
                    }
                }
                else
                {
                    M2.Push(Convert.ToInt64(S.Pop()));
                }
            }
            if (flag != false)
                return result;
            else return 0;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
                label3.Text="";
            textBox2.Text="";
            button5.BackColor = Color.Lime;
        }

        private void button6_Click(object sender, EventArgs e)
        {
          textBox1.Text = M1.DeletLC(textBox1.Text);
        }
        public bool pr(string s)
        {
            if (s.Contains('+') == false && s.Contains('-') == false && s.Contains('*') == false && s.Contains('/') == false)
            {
                return true;
            }
            else return false;
        }
                
                
    }
}
