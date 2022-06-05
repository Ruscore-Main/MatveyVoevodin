using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 label1 фио
label2 должность
button1 - составление отчета

 */
namespace MatveiVoevodin
{
    public partial class Form6 : Form
    {
        Employee currentUser;
        Model1Container _db;
        Form1 form1;

        public Form6(Model1Container db, Form1 backForm, Employee user)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.currentUser = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(_db, this, currentUser);
            this.Hide();
            form7.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = $"{currentUser.Surname} {currentUser.Name} {currentUser.Patronymic}";
            label2.Text = $"{currentUser.Post}";
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
