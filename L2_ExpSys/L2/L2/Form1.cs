using Interface;
using L2.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2
{
    public partial class Form1 : Form
    {
        LogicalMachine logicalMachine;

        public Form1()
        {
            InitializeComponent();
            logicalMachine = new LogicalMachine();
            logicalMachine.LoadKnowladgeBase();
            logicalMachine.GetCurentRule();
            textBox1.Text = logicalMachine.CurQuestion;
            if (logicalMachine.AnswersWays.Count>1)
            {
                groupBox1.Visible = false;
                for (int i=0; i< logicalMachine.AnswersWays.Count;i++)
                {
                    comboBox1.Items.Add(logicalMachine.AnswersWays[i]);
                }
            }
            else
            {                
                groupBox1.Visible = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        bool otv = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (logicalMachine.ResaltAnswer != null)
            {
                textBox2.Text = logicalMachine.ResaltAnswer;
                button3.Enabled=true;
                
            }
            else
            {
                if (groupBox1.Visible == true)
                {
                    UserAnswer userAnswer = new UserAnswer(otv);
                    logicalMachine.AddDataFromUser(userAnswer);
                }
                else if (comboBox1.Items.Count!=0)
                {
                    UserAnswer userAnswer = new UserAnswer(comboBox1.SelectedItem.ToString());
                    logicalMachine.AddDataFromUser(userAnswer);
                }
                else
                    logicalMachine.GetCurentRule();

                textBox2.Text = logicalMachine.ResaltAnswer;
                textBox1.Text = logicalMachine.CurQuestion;
                comboBox1.Items.Clear();
                comboBox1.Text="Get Answer";
                if (logicalMachine.AnswersWays.Count > 1)
                {
                    groupBox1.Visible = false;
                    for (int i = 0; i < logicalMachine.AnswersWays.Count; i++)
                    {
                        comboBox1.Items.Add(logicalMachine.AnswersWays[i]);
                    }
                }
                else
                {
                    groupBox1.Visible = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            logicalMachine.Restart();
            logicalMachine.GetCurentRule();
            textBox1.Text = logicalMachine.CurQuestion;
            if (logicalMachine.AnswersWays.Count > 1)
            {
                groupBox1.Visible = false ;
                for (int i = 0; i < logicalMachine.AnswersWays.Count; i++)
                {
                    comboBox1.Items.Add(logicalMachine.AnswersWays[i]);
                }
            }
            else
            {
                groupBox1.Visible = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;              
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                otv = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                otv = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logicalMachine.ShowGeneratedFacts();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
