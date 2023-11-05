using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Text = "Алгоритм";
            label3.Text = "Алгоритм сортировки вставкой (Insertion Sort) - это один из простейших алгоритмов сортировки. Он работает путем поочередной вставки элементов массива в упорядоченную последовательность. Алгоритм сортировки вставкой подходит для небольших массивов и уже почти упорядоченных данных.\r\n\r\nОсновной идеей сортировки вставкой является разделение входного массива на две части: отсортированную часть и неотсортированную часть. Алгоритм начинает с одного элемента и поочередно вставляет следующие элементы в отсортированную часть массива так, чтобы последовательность оставалась упорядоченной. Процесс продолжается до тех пор, пока не вставятся все элементы.";
            label3.MaximumSize = new Size(700, 0);
            label3.AutoSize = true;

            label1.Text = "Описание Алгоритма InsertionSort";
            label1.Font = new Font("Arial", 30, FontStyle.Regular);
            label2.Font = new Font("Arial", 15, FontStyle.Regular);
            pictureBox1.Image = new Bitmap("C:\\Users\\karina\\Downloads\\Insertion-sort-example-300px.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
