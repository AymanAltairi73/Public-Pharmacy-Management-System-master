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
    public partial class FormVendorList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public FormVendorList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecords();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * from tableVendor", cn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }

            dr.Close();
            cn.Close();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            FormVendor frm = new FormVendor(this);
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            String colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "Edit")
            {
                FormVendor frm = new FormVendor(this);
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.textBoxVendor.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.textBoxVAdress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.textBoxVContact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.textBoxVEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.textBoxVFax.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.ShowDialog();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("You want to remove this Vendor?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tableVendor where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Vendor removed sucessfully.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }
    }
}
