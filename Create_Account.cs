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
using CST4708_Project.TableClass;

namespace CST4708_Project
{
    public partial class Create_Account : Form
    {
        public Create_Account()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_email.Text ?? tb_fName.Text ?? tb_lName.Text ?? tb_Login.Text ?? tb_password.Text))
                {
                    MessageBox.Show("Please fill in all the information");
                }
            else
                {
                try { UserTable.rowInsert(tb_Login.Text, tb_password.Text, tb_fName.Text, tb_lName.Text, tb_email.Text);
                    MessageBox.Show("Account Created");
                }
                catch (Exception ex) {
                    MessageBox.Show("Account with this loging already exists");
                }
                   
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_page r1 = new Login_page();
            r1.ShowDialog();
            this.Close();
        }
    }

}
