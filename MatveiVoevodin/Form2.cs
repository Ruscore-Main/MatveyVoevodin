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
 textBox1 - имя
textBox2 - Фамилия
textBox3 - Отчество
textBox4 - логин
textBox5 - пароль
comboBox1 - должность
button1 - зарегестрироваться
 */
namespace MatveiVoevodin
{
    public partial class Form2 : Form
    {
        Form1 form1;
        Model1Container _db;
        public Form2(Model1Container db, Form1 backForm)
        {
            InitializeComponent();
            this._db = db;
            this.form1 = backForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var validateResult = ValidateTest.ValidateRegistration(textBox4.Text, textBox5.Text, textBox1.Text, textBox2.Text);
            if (validateResult == "Успешно")
            {
                Employee employee = new Employee()
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    Patronymic = textBox3.Text,
                    Login = textBox4.Text,
                    Password = textBox5.Text,
                    Post = Convert.ToString(comboBox1.SelectedItem)
                };
                _db.EmployeeSet.Add(employee);
                _db.SaveChanges();
                MessageBox.Show("Успешно!");
                this.Close();
            }
            else
            {
                MessageBox.Show(validateResult);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
