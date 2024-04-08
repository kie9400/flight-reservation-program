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
    public partial class RSV_Change : Form
    {
        DBClass dbc = new DBClass();  //*****DBClass 객체 생성
        String fi_num;
        String dept_date;
        public RSV_Change()
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
            dbc.DB_Access();//***
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql_execute(main.rsv_num, dbc.DS);
            //날짜를 새로 입력받아서 기존 정보랑 합쳐서 테이블에서 열을 구함
            //flight_inform -> fee, dept_date
            //reservation -> user_id


        }

        public void sql_execute(String sqlstr, DataSet dsstr)
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dsstr, "flight");

            OracleDataReader flight = dbc.DCom.ExecuteReader();
            flight.Read();
            fi_num = flight["FI_NUM"].ToString();

            String flightsql = "Select * From flight_infrom Where  = '" + dept_date + "'";
            dbc.DCom.CommandText = flightsql;
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dsstr, "Selected_flight");

            OracleDataReader sflight = dbc.DCom.ExecuteReader();
            sflight.Read();
            fi_num = sflight["fi_num"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dept_date = dateTimePicker1.Value.ToString("yy/MM/dd");
        }
    }
}
