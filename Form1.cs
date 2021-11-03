using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "가계부";

            dataGridView1.DataSource = DataManager.Incomes;
            dataGridView2.DataSource = DataManager.Expenditures;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
            dataGridView2.CurrentCellChanged += dataGridView2_CurrentCellChanged;
        }

        private void 수입관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void 지출관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Income income = dataGridView1.CurrentRow.DataBoundItem as Income;
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Expenditure expenditure = dataGridView2.CurrentRow.DataBoundItem as Expenditure;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
