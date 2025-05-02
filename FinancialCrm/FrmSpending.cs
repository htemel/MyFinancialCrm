using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmSpending: Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmSpending_Load(object sender, EventArgs e)
        {
            var values = db.TblCategories.ToList();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
            comboBox1.DataSource = values;

        }
        private void btnBillList_Click(object sender, EventArgs e)
        {
            //var values=db.TblSpendings.ToList();
            //dataGridView1.DataSource = values;

            var query = from x in db.TblSpendings
                        select new
                        {
                            Tarih=x.SpendingDate,
                            Açıklama=x.SpendingTitle,
                            Miktar=x.SpendingAmount,
                            Kategori=x.TblCategories.CategoryName

                        };
            dataGridView1.DataSource = query.ToList();

        }

        

        

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            TblSpendings tblSpendings = new TblSpendings();
            tblSpendings.SpendingTitle = txtSpendingComment.Text;
            tblSpendings.SpendingAmount = Convert.ToDecimal(txtSpendingAmount.Text);
            tblSpendings.SpendingDate = Convert.ToDateTime(dateTimePicker1.Text);
            tblSpendings.SpendingFKCategoryId = Convert.ToInt32(comboBox1.SelectedValue);
            db.TblSpendings.Add(tblSpendings);
            db.SaveChanges();
            MessageBox.Show("Yapılan Harcama Başarıyla Kaydedildi.");
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtSpendingId.Text);
            var deleteValue=db.TblSpendings.Find(id);
            db.TblSpendings.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarıyla Silindi.");
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtSpendingId.Text);
            var updateValue=db.TblSpendings.Find(id);
            updateValue.SpendingTitle = txtSpendingComment.Text;
            updateValue.SpendingAmount = Convert.ToDecimal(txtSpendingAmount.Text);
            updateValue.SpendingDate = Convert.ToDateTime(dateTimePicker1.Text);
            updateValue.SpendingFKCategoryId = Convert.ToInt32(comboBox1.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarıyla Güncellendi.");
        }

        private void btnBankForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {
            FrmBankProcessForm frm= new FrmBankProcessForm();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
