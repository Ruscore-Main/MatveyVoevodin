using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatveiVoevodin
{
    public partial class OperatorForm : Form
    {
        Employee currentUser;
        Model1Container _db;
        Form1 form1;
        public OperatorForm(Model1Container db, Form1 backForm, Employee user)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.currentUser = user;
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"{currentUser.Surname} {currentUser.Name} {currentUser.Patronymic}";
            label2.Text = $"{currentUser.Post}";
        }

        private void OperatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(_db, this, currentUser);
            form7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(_db, this);
            form3.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
