using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project_manager
{
    public partial class userLogin : Form
    {
        public userLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            signUp signup = new signUp();
            signup.Show();
            this.Hide();
        }

        private void userLogin_Load(object sender, EventArgs e)
        {

        }

        private void userNameBox_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(64, 52, 76);
            label2.BackColor = Color.FromArgb(32, 26, 48);
        }

        private void userPasswdBox_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(64, 52, 76);
            label1.BackColor = Color.FromArgb(32, 26, 48);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool userNotFound = false;
            //look for entered user name
            using (var context = new taskManagerEntities())
            {
                var blog = context.contributors
                                .Where(b => b.name == userNameBox.Text && b.passwd == userPasswdBox.Text)
                                .FirstOrDefault();
                if (blog == null || blog.name == null)
                {
                    userNotFound=true;
                }
                

                if(userNotFound)
                {
                    MessageBox.Show("Incorrect user name or password");
                }
                else
                {
                    UserForm userForm = new UserForm();
                    userForm.Show();
                    this.Hide();
                }

            }
             
        }
    }
}