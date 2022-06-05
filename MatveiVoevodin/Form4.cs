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
    textBox1 - название 
    textBox2 - цена 
    textBox3 - количество
    textBox4 - время на производство
    textBox5 - использованные материалы
    comboBox1 - местоположение
    button1 - добавить
*/
namespace MatveiVoevodin
{
    public partial class Form4 : Form
    {
        Form3 form3;
        Model1Container _db;
        public Form4(Model1Container db, Form3 backForm)
        {
            InitializeComponent();
            this.form3 = backForm;
            this._db = db;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Storage storage in _db.StorageSet)
            {
                comboBox1.Items.Add(storage);
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Name = textBox1.Text,
                Price = Convert.ToInt32(textBox2.Text),
                Amount = Convert.ToInt32(textBox3.Text),
                Production_time = textBox4.Text,
                MaterialUsed = textBox5.Text,
                Storage = comboBox1.SelectedItem as Storage
            };


            _db.ProductSet.Add(product);
            _db.SaveChanges();
            form3.UpdateList();
            MessageBox.Show("Успешно добавлено!");
            this.Close();
        }
    }
}
