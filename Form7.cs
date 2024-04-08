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

namespace prototype1
{
    public partial class Payment : Form
    {
        DBClass dbc = new DBClass();
        String userid = "hong1"; //Login_Form.userid;
        String card_num;
        int card_pw;
        int cvv_num;

        public Payment()
        {
            InitializeComponent();
            dbc.DB_Open();
            dbc.DB_ObjCreate();
            dbc.DB_Access();
        }
        private void ClearTextBoxes()
        {
            txtcard.Clear();
            txtcvv.Clear();
            txtpw.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcard.Text.Trim() == "")
            {
                MessageBox.Show(" 카드번호를 입력해주세요. ");
                txtcard.Focus();
            }
            else if (txtcvv.Text.Trim() == "")
            {
                MessageBox.Show(" cvc번호를 입력해주세요.");
                txtcvv.Focus();
            }
            else if (txtpw.Text.Trim() == "")
            {
                MessageBox.Show(" 결제 비밀번호를 입력해주세요.");
                txtpw.Focus();
            }
            else if (txtcard.Text.Length != 16)
            {
                MessageBox.Show(" 첫 번째 카드번호를 16자리 숫자로 정확히 입력해주세요. ");
                txtcard.Focus();
            }
            else
            {
                card_num = txtcard.Text;
                card_pw = Int32.Parse(txtpw.Text);
                cvv_num = Int32.Parse(txtcvv.Text);

                string ConStr = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                OracleConnection conn = new OracleConnection(ConStr);
                conn.Open();
                string paysql = "Insert Into payment_method Values ('" + card_num + "'," + card_pw + "," + cvv_num + ", '" + userid + "')";
                dbc.DCom.CommandText = paysql;
                dbc.DCom.ExecuteNonQuery();
                ClearTextBoxes();
                MessageBox.Show(" 결제가 완료되었습니다. ");
                this.Close();
            }
        }
    }
}
