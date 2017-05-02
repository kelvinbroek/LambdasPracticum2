using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace practicum2
{
    public partial class Form1 : Form
    {
        IList<string> methods = new List<string>();
        IList<string> lambdas = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Int32.Parse(num1Text.Text);
            int num2 = Int32.Parse(num2Text.Text);
            int num3 = Int32.Parse(num3Text.Text);

            String output = MethodRunner.RunAllMethods(num1, num2, num3);
            methodOutput.Text = output;

            output = LambdaRunner.RunAllMethods(num1, num2, num3);
            lambdaOutput.Text = output;

            foreach (string s in methodOutput.Lines)
            {
                string[] a = s.Split('=');
                methods.Add(a.Last());
            }

            foreach (string s in lambdaOutput.Lines)
            {
                string[] a = s.Split('=');
                lambdas.Add(a.Last());
            }

            if (uitkomst())
            {
                System.Windows.Forms.MessageBox.Show("gelijk");
            }
        }

        private bool uitkomst()
        {
            bool gelijk = false;
            for (int i = 0; i < 5; i++)
            {
                if (methods[i].Equals(lambdas[i]))
                {
                    gelijk = true;
                }
                else
                {
                    gelijk = false;
                }
            }
            return gelijk;
        }
    }
}
