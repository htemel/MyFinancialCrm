using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri

            var ziraatBankBalance = db.TblBanks.Where(x => x.BankTitle == "Ziraat Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.TblBanks.Where(x => x.BankTitle == "Vakıfbank").Select(x => x.BankBalance).FirstOrDefault();
            var isBankBalance = db.TblBanks.Where(x => x.BankTitle == "İş Bankası").Select(x => x.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblIsBankBalance.Text = isBankBalance.ToString() + " ₺";

            //Banka Hareketleri
            var bankProcess1 = db.TblBankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.BankProcessDescription + " " + bankProcess1.BankProcessAmount + " " + bankProcess1.BankProcessDate;

            var bankProcess2=db.TblBankProcesses.OrderByDescending(x=>x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.BankProcessDescription + " " + bankProcess2.BankProcessAmount + " " + bankProcess2.BankProcessDate;

            var bankProcess3=db.TblBankProcesses.OrderByDescending(x=>x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.BankProcessDescription + " " + bankProcess3.BankProcessAmount + " " + bankProcess3.BankProcessDate;

            var bankProcess4 = db.TblBankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.BankProcessDescription + " " + bankProcess4.BankProcessAmount + " " + bankProcess4.BankProcessDate;

            var bankProcess5 = db.TblBankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.BankProcessDescription + " " + bankProcess5.BankProcessAmount + " " + bankProcess5.BankProcessDate;

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling fr = new FrmBilling();
            fr.Show();
            this.Hide();
        }
    }
}
