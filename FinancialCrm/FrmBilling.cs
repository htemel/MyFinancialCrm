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
    public partial class FrmBilling: Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title=txtBillTitle.Text;
            decimal amount=decimal.Parse( txtBillAmount.Text);
            string period= txtBillPeriod.Text;

            TblBills bills = new TblBills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.TblBills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi.","Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtBillId.Text);
            var removeValue=db.TblBills.Find(id);   
            db.TblBills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi.", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);
            var updateValue = db.TblBills.Find(id);
            updateValue.BillTitle = title;
            updateValue.BillAmount = amount;
            updateValue.BillPeriod = period;
            db.SaveChanges();

            MessageBox.Show("Ödeme Başarılı Bir Şekilde Güncellendi.", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }
    }
}
