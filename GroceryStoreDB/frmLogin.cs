using LibrarySystem324;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStoreDB
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            char c = '\u2022';
            txtPassword.PasswordChar = c;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool OK = false;


            DataTable dt = DBEngine.GetTable("select * from Employee where upper(email) ='" +
                txtLoginID.Text.ToUpper() + "' and Phone='" + txtPassword.Text + "'");

            OK = dt.Rows.Count > 0;


            if (OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
