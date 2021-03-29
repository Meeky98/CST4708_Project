using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CST4708_Project;
using CST4708_Project.TableClass;

namespace CST_Project_Checkout_Page
{
    public partial class Checkout : Form
    {
        ArrayList orderId, AmountList;

        public Checkout(ArrayList orderId, double total, String userId, ArrayList AmountList)
        {
            InitializeComponent();
            userID = userId;
            this.AmountList = AmountList;
            this.orderId = orderId;
            label14.Text = total.ToString();
            
        }
        string userID;
        DataTable mydt;
        SqlConnection myconn;
        SqlCommand mycmd;
        SqlDataAdapter myadapter;
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

             mydt = new DataTable();

            
            
            myconn = new SqlConnection();
            //myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dariel Meeks\\Downloads\\Project(1).mdf Integrated Security=True;Connect Timeout=30";
            myconn.ConnectionString = UserTable.getAutoConnString();
                     
            myconn.Open();
            mycmd = new SqlCommand();
            mycmd.Connection = myconn;
            Random rnd = new Random();
            int order = rnd.Next(10000);

            if (String.IsNullOrWhiteSpace(textBox1.Text?? textBox2.Text?? textBox3.Text ??textBox4.Text??textBox5.Text??textBox6.Text?? textBox7.Text))
                {
                    MessageBox.Show("Please enter all information");
                }
            else
                {
                     mydt = new DataTable();

                     myadapter = new SqlDataAdapter();
                     myadapter.SelectCommand = mycmd;
                  
                        for (int i = 0; i < orderId.Count; i++) {
                                mycmd.CommandText = "UPDATE Order_T " +
                                "SET is_purchased ='Yes' " +
                                "where order_id=" + orderId[i].ToString();
                          
                     
                     mycmd.ExecuteNonQuery();

                     myadapter.UpdateCommand = mycmd;
                     mycmd.CommandText = "UPDATE Product_T " +
                                "SET on_hand = on_hand - "+AmountList[i].ToString()+" " +
                                "Where product_id in (Select product_id from Order_T where order_id=" + orderId[i].ToString()+")";
                    mycmd.ExecuteNonQuery();

                        }
                    

              
            MessageBox.Show("Thank you "+userID+" for your purchase. Your order number is #"+order+".");
            this.Hide();
            Main_menu m1 = new Main_menu(userID);
            m1.ShowDialog();
            this.Close();
            }
          
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}

