using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototype1
{
    public partial class Form13 : Form
    {
        DBClass db = new DBClass();
        private Form14 join = new Form14();
        private main main2 = new main();
        private Form10 manage = new Form10();
        public Form13()
        {
            InitializeComponent();
            db.DB_Open();
            db.DB_ObjCreate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            join.ShowDialog();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            if (Login_Form.userid == "system")
            {
                label3.Text = " 관리자 전용 계정입니다. ";
            }
            else
            {
                label3.Text = "환영합니다 " + Login_Form.name + " 고객님 ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manage.ShowDialog();
            manage.Owner = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString(" yyyy년 MM월 dd일 hh시 mm분 ");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            manage.ShowDialog();
            manage.Owner = this;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            join.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString(" yyyy년 MM월 dd일 hh시 mm분 ");
        }
    }
}
