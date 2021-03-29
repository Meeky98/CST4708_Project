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
            if (String.IsNullOrWhitespace(tb_email)(tb_fName)(tb_lName)(tb_Login)(tb_password))
                {
                    MessageBox.Show("Please fill in all the information");
                }
            else
                {
                    UserTable.rowInsert(tb_Login.Text, tb_password.Text, tb_fName.Text, tb_lName.Text, tb_email.Text);
                    MessageBox.Show("Account Created");
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
