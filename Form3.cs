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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Text = "지출 관리";

            dataGridView1.DataSource = DataManager.Expenditures;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
        }

        public void dataGridView1_CurrentCellChanged(object sedner, EventArgs e)
        {
            try
            {
                Expenditure expenditure = dataGridView1.CurrentRow.DataBoundItem as Expenditure;
                textBox1.Text = expenditure.Num.ToString();
                textBox2.Text = expenditure.Contents;
                textBox3.Text = expenditure.Money.ToString();
                dateTimePicker1.Value = expenditure.Date;
            }
            catch (Exception exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.Expenditures.Exists(x => x.Num == int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("이미 존재하는 내역입니다.");
                }
                else
                {
                    Expenditure expenditure = new Expenditure()
                    {
                        Num = int.Parse(textBox1.Text),
                        Contents = textBox2.Text,
                        Money = int.Parse(textBox3.Text),
                        Date = dateTimePicker1.Value
                    };
                    DataManager.Expenditures.Add(expenditure);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Expenditures;
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
                Expenditure expenditure = DataManager.Expenditures.Single(x => x.Num == int.Parse(textBox1.Text));
                expenditure.Contents = textBox2.Text;
                expenditure.Money = int.Parse(textBox3.Text);
                expenditure.Date = dateTimePicker1.Value;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Expenditures;
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
                Expenditure expenditure = DataManager.Expenditures.Single(x => x.Num == int.Parse(textBox1.Text));
                DataManager.Expenditures.Remove(expenditure);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Expenditures;
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("존재하지 않는 내역입니다");
            }
        }
    }
}
