using System;
using System.Reflection;
using System.Windows.Forms;

namespace Sinhala_POS_VERSION
{
    public partial class Form1 : Form
    {
        String select;

        public Form1()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCatagory_Click(object sender, EventArgs e)
        {
            runCategory();
            select = "catagory";
        }

        private void runCategory()
        {
            panel3.Controls.Clear();
            FormCatagoryList frm = new FormCatagoryList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            // WindowState = DefaultMaximumSize(720);
            frm.BringToFront();
            frm.Show();
        }

        private void runBrand()
        {
            panel3.Controls.Clear();
            FormBrandList frm = new FormBrandList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            runBrand();
            select = "brand";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            runProduct();
            select = "product";
        }

        private void runProduct()
        {
            panel3.Controls.Clear();
            FormProductList frm = new FormProductList();
            // FormProduct f = new FormProduct(frm);
            //frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void runVendor()
        {
            panel3.Controls.Clear();
            FormVendorList frm = new FormVendorList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            runVendor();
            select = "vendor";
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            FormCashier C = new FormCashier();
            C.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            FormProductList frm = new FormProductList();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            FormProductList frm = new FormProductList();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FormProductList frm = new FormProductList();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("yeh");
        }

        private void runSystem()
        {
            panel3.Controls.Clear();
            FormSystemSettings frm = new FormSystemSettings();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void runUser()
        {
            panel3.Controls.Clear();
            FormUserSettings frm = new FormUserSettings();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void runRecords()
        {
            panel3.Controls.Clear();
            FormReports frm = new FormReports();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void runSaleRecords()
        {
            panel3.Controls.Clear();
            FormSalesRecords frm = new FormSalesRecords();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(select == "product")
            {
                runProduct();
            }
            else if (select == "brand")
            {
                runBrand();
            }
            else if (select == "catagory")
            {
                runCategory();
            }
            else if (select == "vendor")
            {
                runVendor();
            }
            else if (select == "system_settings")
            {
                runSystem();
            }
            else if (select == "user_settings")
            {
                runUser();
            }
            else if (select == "all_records")
            {
                runRecords();
            }
            else if (select == "sale_records")
            {
                runSaleRecords();
            }

        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            runSystem();
            select = "system_settings";
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            runUser();
            select = "user_settings";
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            runRecords();
            select = "all_records";
        }

        private void btnSaleRecords_Click(object sender, EventArgs e)
        {
            runSaleRecords();
            select = "sale_records";
        }
    }
}
