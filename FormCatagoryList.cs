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
    public partial class FormCatagoryList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public FormCatagoryList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecords();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            FormCatagory frm = new FormCatagory(this);
            frm.Show();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tableCatagory order by id", cn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["catagory"].ToString());
            }

            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "Edit")
            {
                FormCatagory frm = new FormCatagory(this);
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.textBoxCatagory.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.ShowDialog();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("You want to remove this Catagory?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tableCatagory where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Catagory removed sucessfully.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }
    }
}
