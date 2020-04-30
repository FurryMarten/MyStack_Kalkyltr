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
    public partial class Form1 : Form
    { 
       
        public Form1()
        {
            InitializeComponent();          
            comboBox1.Items.Add("LIFO");
            comboBox1.Items.Add("FIFO");
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (Timoshka2(textBox2.Text) == false)
                { button1.BackColor = Color.Red; }
                else { button1.BackColor = Color.White; }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
     
     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e,KeyPressEventArgs e1)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            textBox2.Text = "";
           
            textBox1.Text = "";
           
        }
        public bool Timoshka2(string String)
        {
            MyStack<char> M1 = new MyStack<char> (String.Length);
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

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
