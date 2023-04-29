using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Создайте приложение размером до 720х480 пикселов и разместите
//на главной форме необходимые элементы управления для получения информации:
//■ Фамилия
//■ Имя
//■ Отчество
//■ Пол
//■ Год и дата рождения
//■ Семейный статус
//■ Дополнительная информация
//Добавьте кнопку Save и обработчик нажатия кнопки для сохранения информации из элементов управления в файл.
//Добавьте кнопку Load и обработчик нажатия кнопки для восстановления информации из файла в элементы управления.
namespace Anketa
{
    public partial class Form1 : Form
    {
        string familia;
        string name;
        string otchestvo;
        string date;
        string pol;
        string status;
        string info;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            familia = textBox1.Text;
            name = textBox2.Text;
            otchestvo = textBox3.Text;
            date = Convert.ToString(dateTimePicker1.Value.ToShortDateString()) ;
            pol = textBox4.Text;
            status = textBox5.Text; 
            info = textBox6.Text;

            List<string> list = new List<string>() { familia, name, otchestvo,
            date, pol, status, info };    
            

            using (StreamWriter writer = new StreamWriter("Save.txt"))
            {
                // Записуємо значення у файл.
                foreach(string item in list)
                writer.WriteLine(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("Save.txt"))
            {
                // Записуємо значення back.

                textBox1.Text = reader.ReadLine();
                textBox2.Text = reader.ReadLine();
                textBox3.Text = reader.ReadLine();
                dateTimePicker1.Value = Convert.ToDateTime(reader.ReadLine());
                textBox4.Text = reader.ReadLine();
                textBox5.Text = reader.ReadLine();
                textBox6.Text = reader.ReadLine();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
