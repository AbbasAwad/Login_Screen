using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loge_Screen1
{
    public partial class Form1 : Form
    {
        int loginFailedAttempts = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void _ReastLoginForm()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            loginFailedAttempts = 0;
            lblMessageError.ResetText();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="abbas" && txtPassword.Text == "123" )
            {
                _ReastLoginForm();
                new Form2().Show();
                this.Hide();
            }
            else
            {
                    lblMessageError.Text = "Inavlid User Name Or Password!! \n You have "
                                        + (2 - loginFailedAttempts) + " attempts before lock your account";
                loginFailedAttempts++;
                if(loginFailedAttempts==3)
                {
                    button1.Enabled = false;
                    lblMessageError.Text = "You Are Locked after 3 Faild Trails!!" +
                                           " \n Contact System Administrators to Unlock Your Account";
                    return;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            CenterToScreen();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timerElapsed;
            timer.Start();
        }
        private void timerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lblClock.Invoke((MethodInvoker)delegate
            {
                lblDate.Text = DateTime.Now.ToString("dddd, MMMM yyyy");
                lblClock.Text = DateTime.Now.ToString("hh:mm:ss");
                lblSup.Text = DateTime.Now.ToString("tt"); //AM PM
            });
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
