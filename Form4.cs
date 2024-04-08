using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prototype1
{
    public partial class RSV_Cancel : Form
    {
        DBClass dbc = new DBClass();  //*****DBClass 객체 생성
        String flightsql;
        String userid = Login_Form.userid;
        String rsv_num = RSV_Search.Selected_rvnum;
        String fee;
        String fi_num;
        public RSV_Cancel()
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
            dbc.DB_Access();//***
        }

        private void RSV_Cancel_Load(object sender, EventArgs e)
        {
            String flightsql = "Select * From reservation Where user_id like '" + userid + "%' and rv_num like '" + rsv_num + "%'";
            sql_execute(flightsql, dbc.DS);
        }

        public void sql_execute(String sqlstr, DataSet dsstr)
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dsstr, "reservation");

            OracleDataReader rsv = dbc.DCom.ExecuteReader();
            rsv.Read();
            fi_num = rsv["FI_NUM"].ToString();
            //MessageBox.Show(fi_num); //테스트용

            flightsql = "Select * From flight_inform Where fi_num like '" + fi_num + "%'";
            dbc.DCom.CommandText = flightsql;
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dsstr, "reservation2");
            dataGridView1.DataSource = dsstr.Tables["reservation2"].DefaultView;
            flight_header();
            
            OracleDataReader rsv2 = dbc.DCom.ExecuteReader();
            rsv2.Read();
            fee = rsv2["FEE"].ToString();
            int num = Convert.ToInt32(fee);
            int cancel_fee = (int)(num * 0.4);
            textBox1.Text = cancel_fee.ToString();

            flightsql = "Delete From reservation Where rv_num like '" + rsv_num + "%'";
            dbc.DCom.CommandText = flightsql;
            dbc.DCom.ExecuteNonQuery();
        }

        public void flight_header()
        {
            dataGridView1.Columns[0].HeaderText = "비행편 번호";
            dataGridView1.Columns[1].HeaderText = "항공사명";
            dataGridView1.Columns[2].HeaderText = "출발공항";
            dataGridView1.Columns[3].HeaderText = "도착공항";
            dataGridView1.Columns[4].HeaderText = "출발날짜";
            dataGridView1.Columns[5].HeaderText = "도착날짜";
            dataGridView1.Columns[6].HeaderText = "운임";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결제를 완료하면 예약이 취소됩니다");

            Payment payment = new Payment();
            payment.ShowDialog();
            this.Close();
        }
    }
}
