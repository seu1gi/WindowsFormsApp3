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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "수입 관리";

            dataGridView1.DataSource = DataManager.Incomes;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
        }

        public void dataGridView1_CurrentCellChanged(object sedner, EventArgs e)
        {
            try
            {
                Income income = dataGridView1.CurrentRow.DataBoundItem as Income;
                textBox1.Text = income.Num.ToString();
                textBox2.Text = income.Contents;
                textBox3.Text = income.Money.ToString();
                dateTimePicker1.Value = income.Date;
            }
            catch (Exception exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e) //추가
        {
            try
            {
                if (DataManager.Incomes.Exists(x => x.Num == int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("이미 존재하는 내역입니다.");
                }
                else
                {
                    Income income = new Income()
                    {
                        Num = int.Parse(textBox1.Text),
                        Contents = textBox2.Text,
                        Money = int.Parse(textBox3.Text),
                        Date = dateTimePicker1.Value
                    };
                    DataManager.Incomes.Add(income);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Incomes;
                DataManager.Save();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e) //수정
        {
            try
            {
                Income income = DataManager.Incomes.Single(x => x.Num == int.Parse(textBox1.Text));
                income.Contents = textBox2.Text;
                income.Money = int.Parse(textBox3.Text);
                income.Date = dateTimePicker1.Value;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Incomes;
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("존재하지 않는 내역입니다");
            }
        }

        private void button3_Click(object sender, EventArgs e) //삭제
        {
            try
            {
                Income income = DataManager.Incomes.Single(x => x.Num == int.Parse(textBox1.Text));
                DataManager.Incomes.Remove(income);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Incomes;
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("존재하지 않는 내역입니다");
            }
        }

    }
}
