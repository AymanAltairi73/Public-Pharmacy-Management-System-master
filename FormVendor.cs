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
    public partial class FormVendor : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        FormVendorList f;

        public FormVendor(FormVendorList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
        }

        private void Clear()
        {
            textBoxVendor.Clear();
            textBoxVAdress.Clear();
            textBoxVContact.Clear();
            textBoxVEmail.Clear();
            textBoxVFax.Clear();
            textBoxVendor.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to save this vendor?", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tableVendor (vendor,adress,contact,e_mail,fax) VALUES(@vendor,@adress,@contact,@e_mail,@fax)", cn);
                    cm.Parameters.AddWithValue("@vendor", textBoxVendor.Text);
                    cm.Parameters.AddWithValue("@adress", textBoxVAdress.Text);
                    cm.Parameters.AddWithValue("@contact", textBoxVContact.Text);
                    cm.Parameters.AddWithValue("@e_mail", textBoxVEmail.Text);
                    cm.Parameters.AddWithValue("@fax", textBoxVFax.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully added to vendor list.");
                    Clear();
                    f.LoadRecords();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to update this vendor?", "update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tableVendor SET vendor = @vendor,adress = @adress,contact = @contact,e_mail = @e_mail,fax = @fax where id like '" + lblID.Text + "'", cn);
                    cm.Parameters.AddWithValue("@vendor", textBoxVendor.Text);
                    cm.Parameters.AddWithValue("@adress", textBoxVAdress.Text);
                    cm.Parameters.AddWithValue("@contact", textBoxVContact.Text);
                    cm.Parameters.AddWithValue("@e_mail", textBoxVEmail.Text);
                    cm.Parameters.AddWithValue("@fax", textBoxVFax.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully updated this vendor.");
                    Clear();
                    f.LoadRecords();
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
            Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }
    }
}
