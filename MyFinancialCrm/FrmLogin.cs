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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtUsername.Text;
                var password = txtPassword.Text;

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Kullanıcı adı veya şifre boş geçilemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    var loginControl = db.Users.Any(x => x.Username == userName && x.Password == password);

                    if (loginControl)
                    {
                        FrmBanks frm = new FrmBanks();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sistemsel Hata! Lütfen sistem yöneticinize başvurunuz" + ex, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
