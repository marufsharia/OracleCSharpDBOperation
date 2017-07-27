using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using MetroFramework;

namespace CSharpDBOperation
{
    public partial class frmHome : MetroForm
    {
        private string userID = null;

        public frmHome(string id)
        {
            InitializeComponent();
            this.userID = id;
        }

        private void DbFeatures_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM usertable where ID='" + userID + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {
                lbluser.Text = thisReader["username"].ToString();
                lbladdress.Text = thisReader["address"].ToString();
                lblid.Text = thisReader["ID"].ToString();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "\n\nAre You Want To Log Out?", "LOG OUT | ADMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                new frmLogin().Show();
                this.Hide();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "\n\nAre You Want To Log Out?", "LOG OUT | ADMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                new frmLogin().Show();
                this.Hide();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}