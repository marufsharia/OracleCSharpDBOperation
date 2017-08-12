using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using MetroFramework.Forms;
using MetroFramework;

namespace CSharpDBOperation
{
    public partial class frmLogin : MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void logincheck()
        {
            try
            {
                connection CN = new connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM usertable WHERE ID='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
                OracleDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    frmHome oform = new frmHome(textBox1.Text);
                    oform.Show();
                    this.Hide();
                }
                else
                {
                    MetroMessageBox.Show(this, "\n User Name or Password is not Correct!", "Login Error | ADMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //this.Close();
                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logincheck();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logincheck();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}