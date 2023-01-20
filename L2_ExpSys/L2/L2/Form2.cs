using KnowledgeBase.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2
{
    public partial class Form2 : Form
    {
        public Form2(List<Fact> Facts)
        {
            InitializeComponent();
            int i = 0;
            foreach(var fact in Facts)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = fact.NameFact;
                dataGridView1.Rows[i].Cells[1].Value = fact.StateOfFact.ToString();
                i++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
