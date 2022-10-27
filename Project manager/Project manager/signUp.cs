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
    public partial class signUp : Form
    {
        Regex userNameRegex = new Regex("^[A-Za-z]{1,10}$");
        Regex phoneNumRegex = new Regex("^[0-9]{10}$");
        Regex occupationRegx = new Regex("^[A-Za-z]{1,15}$");
        public signUp()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            userLogin user = new userLogin();
            user.Show();
            this.Hide();
        }

        private void userNameBox_Validating(object sender, CancelEventArgs e)
        {
            validate(userNameBox, userNameRegex, e);
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            //getting gender text
            String genderText;
            if (maleRadioButton.Checked)
            {
                genderText = "m";
            }
            else
            {
                genderText = "f";
            }

            // select ticked 
            int i;
            string tickedItem;
            tickedItem = "";
            for (i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    tickedItem = checkedListBox1.Items[i].ToString();
                }
            }


            if (passwdTextBox.Text.Equals(confirmTextBox.Text) == false)
            {
                MessageBox.Show("Password doesn't match");
            }
            else if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //save user to database
                
                    var context = new taskManagerEntities();
                    var user = new contributor()
                    {
                        name = userNameBox.Text,
                        gender = genderText,
                        passwd = passwdTextBox.Text,
                        occupation = occupationBox.Text,
                        experience = tickedItem,
                        phoneNum = phoneBox.Text
                    };
                    context.contributors.Add(user);
                    context.SaveChanges();

                userLogin userLogin = new userLogin();
                this.Hide();
                userLogin.Show();
            }
        }

        private void phoneBox_Validating(object sender, CancelEventArgs e)
        {
            validate(phoneBox,phoneNumRegex,e);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            validate(occupationBox, occupationRegx, e);
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (maleRadioButton.Checked == false && femaleRadioButton.Checked == false)
            {
                e.Cancel = true;
                groupBox1.Focus();
                errorProvider.SetError(groupBox1, "Invalid input");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(groupBox1, null);
            }
        }


        public void validate(TextBox textBox, Regex regex, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text) || (regex.IsMatch(textBox.Text) == false))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "Invalid input");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(confirmTextBox.Text))
            {
                e.Cancel = true;
                confirmTextBox.Focus();
                errorProvider.SetError(confirmTextBox, "Invalid input");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(confirmTextBox, null);
            }
        }

        private void passwdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwdTextBox.Text))
            {
                e.Cancel = true;
                passwdTextBox.Focus();
                errorProvider.SetError(passwdTextBox, "Invalid input");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(passwdTextBox, null);
            }
        }
    }
}
