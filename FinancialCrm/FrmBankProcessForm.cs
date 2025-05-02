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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinancialCrm
{
    public partial class FrmBankProcessForm: Form
    {
        public FrmBankProcessForm()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        
        private void FrmBankProcessForm_Load(object sender, EventArgs e)
        {
            var values = db.TblBanks.ToList();
            cmbProcessCategori.DisplayMember = "BankTitle";
            cmbProcessCategori.ValueMember = "BankId";
            cmbProcessCategori.DataSource = values;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBankForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            
            var query = from x in db.TblBankProcesses join y in db.TblBanks on x.BankProcessFKBankId equals y.BankId
                        select new
                        {
                            İşlemId = x.BankProcessId,
                            Açıklama = x.BankProcessDescription,
                            İşlem_Tipi = x.BankProcessType,
                            Miktar = x.BankProcessAmount,
                            Tarih = x.BankProcessDate,
                            Banka=y.BankTitle
                        };
            dataGridView1.DataSource=query.ToList();

        }

        private void btnProcessCreate_Click(object sender, EventArgs e)
        {
            
        }
    }
}
