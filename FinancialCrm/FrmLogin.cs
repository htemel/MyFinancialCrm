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
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        

       

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var item in db.TblUser)
            {
                if (txtUserName.Text == item.UserName && txtUserPassword.Text == item.UserPassword)
                {
                    new FrmBanks().Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Geçersiz Kullanıcı Adı veya Şifre","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            
        }

        

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserPassword.Text = "";
        }

        private void lblClear_MouseHover(object sender, EventArgs e)
        {
            lblClear.ForeColor = Color.Red;
            lblClear.Cursor = Cursors.Hand;
        }

        private void lblClear_MouseLeave(object sender, EventArgs e)
        {
            lblClear.ForeColor = Color.MidnightBlue;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExit_MouseHover(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Red;
            lblExit.Cursor = Cursors.Hand;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.MidnightBlue;
        }

        
    }
}
