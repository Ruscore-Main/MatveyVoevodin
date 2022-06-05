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
textBox6 - местоположение
button1 - добавить в отчет
button2 - перейти в отчет
 */
namespace MatveiVoevodin
{
    public partial class Form7 : Form
    {
        Model1Container _db;
        Form backForm;
        Product currentProduct;
        Employee currentUser;
        public Form7(Model1Container db, Form form, Employee employee)
        {
            InitializeComponent();
            this._db = db;
            this.backForm = form;
            this.currentUser = employee;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(_db, this, currentUser);
            this.Hide();
            form8.Show();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            backForm.Show();
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
                    textBox6.Text = currentProduct.Storage.Address;
                    button1.Enabled = true;
                }
            }
            catch { }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            foreach (Product product in _db.ProductSet)
            {
                listBox1.Items.Add(product);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Добавление в отчет
        {
            if (currentUser.Report == null)
            {
                currentUser.Report = new Report();
            }

            currentUser.Report.Product.Add(currentProduct);
            _db.SaveChanges();
        }
    }
}
