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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "Алгоритм";
            label3.Text = "Сортировка слиянием (Merge Sort) - это эффективный и стабильный алгоритм сортировки, который применяет стратегию \"разделяй и властвуй\". Основная идея заключается в разбиении массива на две равные или приблизительно равные половины, сортировке каждой из них, а затем объединении (слиянии) результатов сортировки обратно в один упорядоченный массив.";
            label3.MaximumSize = new Size(700, 0);
            label3.AutoSize = true;

            label1.Text = "Описание Алгоритма MergeSort";
            label1.Font = new Font("Arial", 30, FontStyle.Regular);
            label2.Font = new Font("Arial", 15, FontStyle.Regular);
            pictureBox1.Image = new Bitmap("C:\\Users\\karina\\Downloads\\Merge-sort-example-300px.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
