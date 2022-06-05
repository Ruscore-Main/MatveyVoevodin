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
 textBox1 - логин
textBox2 - пароль
button1 - вход
 */
namespace MatveiVoevodin
{
    public partial class Form1 : Form
    {
        Model1Container _db = new Model1Container();
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2(_db, this);
            this.Hide();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = _db.EmployeeSet.FirstOrDefault(el => el.Login == textBox1.Text && el.Password == textBox2.Text);
            // Если найден
          /*Технолог
            Бухгалтер
            Оператор*/
            if (employee != null)
            {
                switch (employee.Post)
                {
                    case "Технолог":
                        {
                            Form5 form5 = new Form5(_db, this, employee);
                            form5.Show();
                            this.Hide();
                            break;
                        }
                    case "Бухгалтер":
                        {
                            Form6 form6 = new Form6(_db, this, employee);
                            form6.Show();
                            this.Hide();
                            break;
                        }
                    case "Оператор":
                        {
                            OperatorForm operatorForm = new OperatorForm(_db, this, employee);
                            operatorForm.Show();
                            this.Hide();
                            break;
                        }
                }
            }
            // Если не найден
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_db.StorageSet.Count() == 0)
            {
                Storage storage1 = new Storage()
                {
                    Address = "г. Казань",
                    Capacity = 2000
                };

                Storage storage2 = new Storage()
                {
                    Address = "г. Воронеж",
                    Capacity = 2000
                };

                _db.StorageSet.Add(storage1);
                _db.StorageSet.Add(storage2);
                _db.SaveChanges();
            }
        }
    }
}
