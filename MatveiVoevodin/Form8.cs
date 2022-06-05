using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
/*
textBox1 - название 
textBox2 - цена 
textBox3 - количество
textBox4 - время на производство
textBox5 - использованные материалы
textBox6 - местоположение
button1 - удалить из отчета
button2 - распечатать
labelSum - Общее количество деталей в отчете
*/
namespace MatveiVoevodin
{
    public partial class Form8 : Form
    {
        Model1Container _db;
        public string printContent = "";
        Form form7;
        Product currentProduct;
        Employee currentUser;
        public Form8(Model1Container db, Form7 backForm, Employee employee)
        {
            InitializeComponent();
            this._db = db;
            this.form7 = backForm;
            this.currentUser = employee;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            form7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentUser.Report.Product.Remove(currentProduct);
            _db.SaveChanges();
            UpdateList();
            MessageBox.Show($"{currentProduct.Name.ToUpper()} удалено из отчета");
        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (Product product in currentUser.Report.Product)
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
                    textBox6.Text = currentProduct.Storage.Address;
                    button1.Enabled = true;
                }
            }
            catch { }
        }


        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(printContent, new System.Drawing.Font("Arial", 16), Brushes.Black, 0, 0);
        }

        private DocX outputDoc()
        {
            string pathDocument = "first.docx";
            DocX document = DocX.Create(pathDocument);
            document.MarginLeft = 60.0f;
            document.MarginRight = 60.0f;
            document.MarginTop = 60.0f;
            document.MarginBottom = 60.0f;

            document.InsertParagraph("Отчет\n").Bold().Font("Times New Roman").FontSize(16);
            document.InsertParagraph($"Обслуживающий сотрудник: {currentUser.Name} {currentUser.Surname} - {currentUser.Post}\n").Font("Times New Roman").FontSize(14);
            document.InsertParagraph("").FontSize(16);
            document.InsertParagraph("").FontSize(16);

            Table table = document.AddTable(currentUser.Report.Product.Count() + 1, 6);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;

            table.Rows[0].Cells[0].Paragraphs[0].Append("Название товар").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Кол-во").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Склад").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[3].Paragraphs[0].Append("Цена").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[4].Paragraphs[0].Append("Время на изготовление для 1 шт.").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[5].Paragraphs[0].Append("Материалы").Font("Times New Roman").FontSize(12).Bold();


            int row = 1;
            foreach (Product product in currentUser.Report.Product)
            {
                table.Rows[row].Cells[0].Paragraphs[0].Append(product.Name).Font("Times New Roman").FontSize(12);

                table.Rows[row].Cells[1].Paragraphs[0].Append($"{product.Amount}").Font("Times New Roman").FontSize(12);

                table.Rows[row].Cells[2].Paragraphs[0].Append(product.Storage.ToString()).Font("Times New Roman").FontSize(12);

                table.Rows[row].Cells[3].Paragraphs[0].Append($"{product.Price}").Font("Times New Roman").FontSize(12);

                table.Rows[row].Cells[4].Paragraphs[0].Append($"{product.Production_time}").Font("Times New Roman").FontSize(12);

                table.Rows[row].Cells[5].Paragraphs[0].Append($"{product.MaterialUsed}").Font("Times New Roman").FontSize(12);

            }

            table.AutoFit = AutoFit.Contents;


            document.InsertParagraph().InsertTableAfterSelf(table);

            document.Save();

            return document;

        }

        private void button2_Click(object sender, EventArgs e) // Печать отчета
        {
            DocX docs = outputDoc();

            printContent = docs.Text;
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrintPage += PrintPageHandler;
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
