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
    public partial class FormCatagory : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        FormCatagoryList frm;

        public FormCatagory(FormCatagoryList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            frm = f;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = false;
            textBoxCatagory.Clear();
            textBoxCatagory.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to save this catagory?", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tableCatagory (catagory) VALUES(@catagory)", cn);
                    cm.Parameters.AddWithValue("@catagory", textBoxCatagory.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully added to catagory list.");
                    Clear();
                    frm.LoadRecords();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to update this catagory?", "update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tableCatagory SET catagory = @catagory where id like '" + lblID.Text + "'", cn);
                    cm.Parameters.AddWithValue("@catagory", textBoxCatagory.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully updated this catagory.");
                    Clear();
                    frm.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBoxCatagory.Clear();
        }
    }
}
