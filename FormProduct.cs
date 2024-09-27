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
    public partial class FormProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        FormProductList frm;

        public FormProduct(FormProductList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            frm = f;
        }

        public void LoadCatagory()
        {
            cboCatagory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT catagory FROM tableCatagory", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCatagory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT brand FROM tableBrand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadVendor()
        {
            cboVendor.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT vendor FROM tableVendor", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboVendor.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = false;
            textBoxPcode.Clear();
            textBoxPcode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to save this product?", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String brand_id = "";
                    String catagory_id = "";
                    String vendor_id = "";
                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableBrand where brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        brand_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableCatagory where catagory like '" + cboCatagory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        catagory_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableVendor where vendor like '" + cboVendor.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        vendor_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tableProduct (pcode,barcode,pdescription,catagory_id,brand_id,vendor_id,buying_price,selling_price,discount,quentity,re_order,exp_date) VALUES(@pcode,@barcode,@pdescription,@catagory_id,@brand_id,@vendor_id,@buying_price,@selling_price,@discount,@quentity,@re_order,@exp_date)", cn);
                    cm.Parameters.AddWithValue("@pcode", textBoxPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", textBoxBarcode.Text);
                    cm.Parameters.AddWithValue("@pdescription", textBoxPDescription.Text);
                    cm.Parameters.AddWithValue("@catagory_id", catagory_id);
                    cm.Parameters.AddWithValue("@brand_id", brand_id);
                    cm.Parameters.AddWithValue("@vendor_id", vendor_id);
                    cm.Parameters.AddWithValue("@buying_price", textBoxBuying_price.Text);
                    cm.Parameters.AddWithValue("@selling_price", textBoxSelling_price.Text);
                    cm.Parameters.AddWithValue("@discount", textBoxDiscount.Text);
                    cm.Parameters.AddWithValue("@quentity", textBoxQty.Text);
                    cm.Parameters.AddWithValue("@re_order", textBoxRe_order.Text);
                    cm.Parameters.AddWithValue("@exp_date", textBoxExpiry_date.Value);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully added to product list.");
                    Clear();
                    frm.LoadRecords();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearAll();
                cn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you want to update this product?", "update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String brand_id = "";
                    String catagory_id = "";
                    String vendor_id = "";
                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableBrand where brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        brand_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableCatagory where catagory like '" + cboCatagory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        catagory_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tableVendor where vendor like '" + cboVendor.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        vendor_id = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("UPDATE tableProduct SET pcode=@pcode,barcode=@barcode,pdescription=@pdescription,catagory_id=@catagory_id,brand_id=@brand_id,vendor_id=@vendor_id,buying_price=@buying_price,selling_price=@selling_price,discount=@discount,quentity=@quentity,re_order=@re_order,exp_date=@exp_date where pcode like @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", textBoxPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", textBoxBarcode.Text);
                    cm.Parameters.AddWithValue("@pdescription", textBoxPDescription.Text);
                    cm.Parameters.AddWithValue("@catagory_id", catagory_id);
                    cm.Parameters.AddWithValue("@brand_id", brand_id);
                    cm.Parameters.AddWithValue("@vendor_id", vendor_id);
                    cm.Parameters.AddWithValue("@buying_price", textBoxBuying_price.Text);
                    cm.Parameters.AddWithValue("@selling_price", textBoxSelling_price.Text);
                    cm.Parameters.AddWithValue("@discount", textBoxDiscount.Text);
                    cm.Parameters.AddWithValue("@quentity", textBoxQty.Text);
                    cm.Parameters.AddWithValue("@re_order", textBoxRe_order.Text);
                    cm.Parameters.AddWithValue("@exp_date", textBoxExpiry_date.Value);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Sucessfully updated this product.");
                    Clear();
                    frm.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClearAll();
                cn.Close();
            }
        }

        private void ClearAll()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = false;
            textBoxBarcode.Clear();
            textBoxPDescription.Clear();
            cboVendor.Text = "";
            cboCatagory.Text = "";
            cboBrand.Text = "";
            textBoxBuying_price.Clear();
            textBoxSelling_price.Clear();
            textBoxDiscount.Clear();
            textBoxQty.Clear();
            textBoxRe_order.Clear();
            //textBoxExpiry_date.Clear();
            textBoxPcode.Clear();
            textBoxPcode.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void textBoxPcode_TextChanged(object sender, EventArgs e)
        {
            textBoxBarcode.Text = textBoxPcode.Text;
        }
    }
}
