using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Security.Cryptography;


namespace pass_generator
{
    public partial class Form1 : Form
    {
        string path = Environment.CurrentDirectory + "/" + "Passwords" + ".html";
        Random r1 = new Random();
        int jsid;
        public Form1()
        {
            InitializeComponent();
            generate();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("/////////////////////////////////////////////////////////////////<br>//  File created by fl1k's password generator  //<br>/////////////////////////////////////////////////////////////////<br><br><br>");
                    sw.WriteLine("<style>\ndiv#pass {\nline-height: 1.4;\n}\n#pass span {\ndisplay: inline-block;\nwidth: 70px;\n}\n </style>\n<script>\nfunction copy(pass_loc){\nvar txt = document.getElementById(pass_loc);\ntxt.select();\ndocument.execCommand(\"Copy\");\n}\n</script>\n<div id=pass>");
                }
            }
            jsid = File.ReadLines(path).Count();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jsid = File.ReadLines(path).Count();
            if (textBox2.TextLength >= 1)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"\n\n\n<span>Date:</span> <input type=\"text\" value=\"{DateTime.Now}\"><br>");
                    sw.WriteLine($"<span>Username:</span> <input type=\"text\" value=\"{textBox4.Text}\"><br>");
                    sw.WriteLine($"<span>Password:</span> <input type=\"text\" value=\"{textBox2.Text}\" id=\"{jsid}\">");
                    sw.WriteLine($"<button onclick=copy(\"{jsid}\")>Copy</button><br>");
                    sw.WriteLine($"<span>Reminder:</span> <input type=\"text\" value=\"{textBox3.Text}\">  <p>--------------------------------------------------------------</p><br>");
                    MessageBox.Show("Password added to the HTML file.", "Password Manager / Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There is no password generated.", "Password Manager / Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generate()
        {
            string rs = string.Empty;
            char[] array = textBox5.Text.ToCharArray();
            if (checkBox5.Checked == false)
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    int point = r1.Next(0, textBox5.TextLength - 1);
                    rs += array.GetValue(point);
                }
            }
            else if (checkBox5.Checked == true)
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    int point = r1.Next(0, textBox5.TextLength);
                    if (!rs.Contains(array.GetValue(point).ToString()))
                        rs += array.GetValue(point);
                    else
                        i--;
                }
            }
            textBox2.Text = rs;
        }

        private void check(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            else if (checkBox1.Checked && checkBox2.Checked && checkBox4.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM[];',./{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox1.Checked && checkBox3.Checked && checkBox4.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnm1234567890[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                textBox5.Text = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox1.Checked && checkBox2.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            else if (checkBox1.Checked && checkBox3.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnm1234567890";
            else if (checkBox1.Checked && checkBox4.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnm[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox2.Checked && checkBox3.Checked)
                textBox5.Text = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            else if (checkBox2.Checked && checkBox4.Checked)
                textBox5.Text = "QWERTYUIOPASDFGHJKLZXCVBNM[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox3.Checked && checkBox4.Checked)
                textBox5.Text = "1234567890[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else if (checkBox1.Checked)
                textBox5.Text = "qwertyuiopasdfghjklzxcvbnm";
            else if (checkBox2.Checked)
                textBox5.Text = "QWERTYUIOPASDFGHJKLZXCVBNM";
            else if (checkBox3.Checked)
                textBox5.Text = "1234567890";
            else if (checkBox4.Checked)
                textBox5.Text = "[];',.{}|:<>?!@#$%^&*()_+=-~`";
            else
            {
                button1.Enabled = false;
                textBox5.Text = " ";
            }

            if (checkBox5.Checked == true)
                numericUpDown1.Maximum = textBox5.TextLength;
            else
                numericUpDown1.Maximum = 2048;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox2.SelectAll();
            Clipboard.SetText(textBox2.Text);
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Focus();
            textBox2.SelectAll();
            Clipboard.SetText(textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button[] buttons = { button1, button2, button3, button4 };
            TextBox[] txtb = { textBox2, textBox3, textBox4, textBox5 };
            foreach (Button b in buttons)
            {
                b.BackColor = Color.FromArgb(35, 35, 35);
                b.TabStop = false;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
            }

            foreach (TextBox txt in txtb)
            {
                txt.BackColor = Color.FromArgb(35, 35, 35);
                txt.TabStop = false;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            this.numericUpDown1.BackColor = Color.FromArgb(35, 35, 35);
        }
    }
}
