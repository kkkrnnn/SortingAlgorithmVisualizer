using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = "Алгоритм";
            label3.Text = "Сортировка змейкой для двумерного массива — это нестандартный способ " +
                "обхода и упорядочивания элементов в двумерном массиве. Этот метод представляет собой комбинацию обхода матрицы по строкам и столбцам," +
                " при которой элементы упорядочиваются в специфическом порядке." + "Принцип сортировки \"змейкой\" для двумерного массива следующий:\r\n\r\nНачните с верхнего левого угла двумерной матрицы.\r\n\r\nДвигайтесь вправо по первой строке, добавляя элементы в результирующий список или другую структуру данных.\r\n\r\nПосле достижения края строки перейдите на следующую строку и двигайтесь влево, продолжая добавлять элементы в результирующий список.\r\n\r\nПовторяйте этот процесс, чередуя направление (вправо или влево) после каждой строки.\r\n\r\nПродолжайте обход до тех пор, пока не пройдете все строки и столбцы двумерной матрицы.\r\n\r\nПосле завершения этого процесса, элементы из двумерного массива будут упорядочены \"змейкой\" в одномерной структуре данных, как, например, список или одномерный массив.\r\n\r\nЭтот метод обхода может использоваться для задач, где требуется обработка элементов двумерной матрицы в специфическом порядке." +
                "";
            label3.MaximumSize = new Size(700, 0);
            label3.AutoSize = true;

            label1.Text = "Описание Алгоритма SnakeSort";
            label1.Font = new Font("Arial", 30, FontStyle.Regular);
            label2.Font = new Font("Arial", 15, FontStyle.Regular);
            pictureBox1.Image = new Bitmap("C:\\Users\\karina\\Downloads\\SnakeSort.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
