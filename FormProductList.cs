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
    public partial class FormProductList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public FormProductList()
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
            FormProduct frm = new FormProduct(this);
            frm.LoadCatagory();
            frm.LoadBrand();
            frm.LoadVendor();
            frm.Show();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT p.pcode,p.barcode,p.pdescription,c.catagory,b.brand,p.quentity,p.buying_price,p.selling_price,p.discount,p.re_order,v.vendor,p.exp_date FROM tableProduct as p inner join tableBrand as b on b.id = p.brand_id inner join tableCatagory as c on c.id = p.catagory_id inner join tableVendor as v on v.id = p.vendor_id ", cn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i += 1;///pcode,barcode,pdescription,catagory_id,brand_id,vendor_id,buying_price,selling_price,discount,quentity,re_order,exp_date
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[3].ToString(), dr[4].ToString(), dr[2].ToString(), dr[5].ToString(),dr[6].ToString(), dr[7].ToString(),dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
            }

            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "Edit")
            {
                FormProduct frm = new FormProduct(this);
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.textBoxBarcode.Enabled = false;
                frm.textBoxPcode.Enabled = false;
                LoadRecords();
                frm.LoadBrand();
                frm.LoadCatagory();
                frm.LoadVendor();
                frm.textBoxPcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.textBoxBarcode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.cboCatagory.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.cboBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.textBoxPDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.textBoxQty.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.textBoxBuying_price.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.textBoxSelling_price.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.textBoxDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                frm.textBoxRe_order.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                frm.cboVendor.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                frm.textBoxExpiry_date.CustomFormat = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                frm.ShowDialog();
            }
            else if (colname == "Delete")
            {
                if (MessageBox.Show("You want to remove this product?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tableProduct where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product removed sucessfully.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void FormProductList_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

     
    }


}
