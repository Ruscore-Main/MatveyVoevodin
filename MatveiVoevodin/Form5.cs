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
 label1 - ФИО
label2 - должность
 button1 - данные по деталям
 */
namespace MatveiVoevodin
{
    public partial class Form5 : Form
    {
        Employee currentUser;
        Model1Container _db;
        Form1 form1;
        public Form5(Model1Container db, Form1 backForm, Employee user)
        {
            InitializeComponent();
            this.form1 = backForm;
            this._db = db;
            this.currentUser = user;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = $"{currentUser.Surname} {currentUser.Name} {currentUser.Patronymic}";
            label2.Text = $"{currentUser.Post}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(_db, this);
            this.Hide();
            form3.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
