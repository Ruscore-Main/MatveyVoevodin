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
/*
    textBox1 - название 
    textBox2 - цена 
    textBox3 - количество
    textBox4 - время на производство
    textBox5 - использованные материалы
    textBox6 - местоположение
    button1 - изменить
    button2 - удалить
    button3 - добавить
    listBox1 - список деталей
*/
    public partial class Form3 : Form
    {
        Model1Container _db;
        Form backForm;
        Product currentProduct;
        public Form3(Model1Container db, Form form)
        {
            InitializeComponent();
            this._db = db;
            this.backForm = form;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(_db, this);
            this.Hide();
            form4.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            backForm.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Storage storage in _db.StorageSet)
            {
                comboBox1.Items.Add(storage);
            }
            UpdateList();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Product product in _db.ProductSet)
            {
                listBox1.Items.Add(product);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                currentProduct = listBox1.SelectedItem as Product;
                if (currentProduct != null)
                {
                    textBox1.Text = currentProduct.Name;
                    textBox2.Text = Convert.ToString(currentProduct.Price);
                    textBox3.Text = Convert.ToString(currentProduct.Amount);
                    textBox4.Text = currentProduct.Production_time;
                    textBox5.Text = currentProduct.MaterialUsed;
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(currentProduct.Storage);
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _db.ProductSet.Remove(currentProduct);
            _db.SaveChanges();
            UpdateList();
            MessageBox.Show("Успешно удалено!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                currentProduct.Name = textBox1.Text;
                currentProduct.Price = Convert.ToInt32(textBox2.Text);
                currentProduct.Amount = Convert.ToInt32(textBox3.Text);
                currentProduct.Production_time = textBox4.Text;
                currentProduct.MaterialUsed = textBox5.Text;
                currentProduct.Storage = comboBox1.SelectedItem as Storage;

                _db.SaveChanges();
                UpdateList();
                MessageBox.Show("Успешно изменено!");
            }
            catch
            {
                MessageBox.Show("Неправильный формат данных!");
            }
        }
    }
}
