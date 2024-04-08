using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace prototype1
{
    public partial class inform_Check : Form
    {
        DBClass dbc = new DBClass();
        public inform_Check()
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
            dbc.DB_Access();//***
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seat_Select seat_select = new Seat_Select();
            seat_select.ShowDialog();
        }

        private void inform_Check_Load(object sender, EventArgs e)
        {
            string flight_num = main.fi_num;
            string sqlstr = "select * from FLIGHT_INFORM where FI_NUM = '"+ flight_num +"'"; 
            dbc.DCom.CommandText = sqlstr; 
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dbc.DS, "flight_inform");
            OracleDataReader sr = dbc.DCom.ExecuteReader();
            sr.Read();
            
            if(sr["dept_ap"].ToString() == "10" || sr["arv_ap"].ToString() =="10")
            {

            }

            //textBox5.Text = sr["dept_ap"].ToString();
            //textBox7.Text = sr["arv_ap"].ToString();
            textBox6.Text = sr["dept_date"].ToString();
            textBox8.Text = sr["arv_date"].ToString();
            textBox4.Text = sr["fee"].ToString();


            if (sr["dept_ap"].ToString() == "10" || sr["arv_ap"].ToString() == "10")
            {
                if (sr["dept_ap"].ToString() == "10")
                    textBox5.Text = "ICN";
                if (sr["arv_ap"].ToString() == "10")
                    textBox7.Text = "ICN";
            }
            if (sr["dept_ap"].ToString() == "11" || sr["arv_ap"].ToString() == "11")
            {
                if (sr["dept_ap"].ToString() == "11")
                    textBox5.Text = "GMP";
                if (sr["arv_ap"].ToString() == "11")
                    textBox7.Text = "GMP";
            }
            if (sr["dept_ap"].ToString() == "20" || sr["arv_ap"].ToString() == "20")
            {
                if (sr["dept_ap"].ToString() == "20")
                    textBox5.Text = "JFK";
                if (sr["arv_ap"].ToString() == "20")
                    textBox7.Text = "JFK";
            }
            if (sr["dept_ap"].ToString() == "21" || sr["arv_ap"].ToString() == "21")
            {
                if (sr["dept_ap"].ToString() == "21")
                    textBox5.Text = "LAX";
                if (sr["arv_ap"].ToString() == "21")
                    textBox7.Text = "LAX";
            }
            if (sr["dept_ap"].ToString() == "30" || sr["arv_ap"].ToString() == "30")
            {
                if (sr["dept_ap"].ToString() == "30")
                    textBox5.Text = "NRT";
                if (sr["arv_ap"].ToString() == "30")
                    textBox7.Text = "NRT";
            }
            if (sr["dept_ap"].ToString() == "31" || sr["arv_ap"].ToString() == "31")
            {
                if (sr["dept_ap"].ToString() == "31")
                    textBox5.Text = "KIX";
                if (sr["arv_ap"].ToString() == "31")
                    textBox7.Text = "KIX";
            }
        }

    }
}
