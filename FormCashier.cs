using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sinhala_POS_VERSION
{
    public partial class FormCashier : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public FormCashier()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            timer1.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblDate1.Text = dateTime.ToLongDateString();
            this.lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        public void GetTransNo()
        {
            try
            {
                String sdate = DateTime.Now.ToString("yyyyMMdd");
                String transNo;
                int count;
                cn.Open();
                cm = new SqlCommand("select top 1 transNo from tableCart where transNo like '" + sdate.ToString() + "%' order by id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transNo = dr[0].ToString();
                    count = int.Parse(transNo.Substring(8, 4));
                    lblTransNo.Text = sdate + (count + 1);
                }
                else
                {
                    transNo = sdate + "1001";
                    lblTransNo.Text = transNo;
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetTransNo();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FormSearchProductInStock f = new FormSearchProductInStock();
            f.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDailySale_Click(object sender, EventArgs e)
        {
            FormDailyC dc = new FormDailyC();
            dc.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormCashierPW cp = new FormCashierPW();
            cp.Show();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            FormDiscount d = new FormDiscount();
            d.Show();
        }

        private void btnCancelSales_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
