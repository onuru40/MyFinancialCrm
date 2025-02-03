using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUsername.Text;
                var updatedUserValue = db.Users.SingleOrDefault(x => x.Username == userName);

                if (updatedUserValue != null)
                {
                    if (txtPassword.Text == txtPasswordAgain.Text)
                    {
                        updatedUserValue.Password = txtPasswordAgain.Text;
                        db.SaveChanges();

                        MessageBox.Show("Şifre Güncelleme Başarılı");
                        txtPassword.Clear();
                        txtPasswordAgain.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz şifreler eşleşmiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Clear();
                        txtPasswordAgain.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sistemsel Hata! Lütfen sistem yöneticinize başvurunuz" + ex, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
