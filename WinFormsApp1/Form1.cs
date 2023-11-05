


using System;
using System.Collections;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Form4 form4 = new Form4();
        private Form2 form2 = new Form2();
        private Form3 form3 = new Form3();
        private Form5 form5 = new Form5();
        private Label TimeLabel;
        private System.Windows.Forms.Timer animationTimer;
        private Random random = new Random();
        private int[] intArray;
        private List<int[]> sortingSteps;
        private int currentStep;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public Form1()
        {
            TimeLabel = new Label();
            TimeLabel.Location = new Point(1, 335);
            TimeLabel.Size = new Size(300, 30);
            this.Controls.Add(TimeLabel);
            InitializeComponent();
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 1000; // �������� � �������������
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();

            if (ShellSortRadioButton.Checked)
            {
                stopwatch.Start();
                MergeSort(intArray);
                stopwatch.Stop();
            }
            if (PriorityQueueSortRadioButton.Checked)
            {
                stopwatch.Start();
                MergeSort(intArray);
                stopwatch.Stop();
            }
            if (QuickSortRadioButton.Checked)
            {
                stopwatch.Start();
                MergeSort(intArray);
                stopwatch.Stop();
            }
            // ������ ����������

            string elapsedTime = string.Format("����� ����������: {0} �����������", stopwatch.ElapsedMilliseconds);
            TimeLabel.Text = elapsedTime;
            currentStep = 0;

            // ��������� ���������� � ��������� ������ ���
            sortingSteps = new List<int[]>();
            int[] copyArray = new int[intArray.Length];
            Array.Copy(intArray, copyArray, intArray.Length);
            sortingSteps.Add(copyArray);

            // ���������� ��������������� ������ �� ������

            // ������� ListBox ����� ������� ����������
            StepsListBox.Items.Clear();

            if (ShellSortRadioButton.Checked)
            {
                MergeSort(intArray);
            }
            else if (PriorityQueueSortRadioButton.Checked)
            {
                SnakeSort(intArray);
            }
            else if (QuickSortRadioButton.Checked)
            {
                string algorithmDescription = "QuickSort - ��� �������� ����������, ������� ���������� ��������� ���������� � ������������.�� �������� ������� ������� � ��������� ������ �� ��� ���������:  ";
                string algorithmDescription2 = "���� �������� ��������, ������� ��������,� ������ - ��������, ������� ��������. ����� ��������� ��� ��������� ����������. ";


                AddStepToListBox(algorithmDescription);
                AddStepToListBox(algorithmDescription2);
                InsertionSort(intArray, 0, intArray.Length - 1);

            }
            label1.Text = "��������������� ������: " + string.Join(" ", intArray);
            animationTimer.Start();

        }

        // ����� ��� ��������� ���������� �������
        private int[] GenerateRandomArray(int size)
        {
            int[] randomArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                randomArray[i] = random.Next(1, 100); // ���������� ��������� ����� �� 1 �� 100
            }
            return randomArray;
        }

        // ����� ��� ���������� ���� ���������� � ListBox
        private void AddStepToListBox(string stepDescription)
        {
            StepsListBox.Items.Add(stepDescription);
        }

        // �������� ListBox, ����� ���������� ����� ��������
        private void RefreshListBox()
        {
            StepsListBox.Refresh();
        }
        private void RefreshListBox(int[] visualArray)
        {
            StepsListBox.Items.Clear();
            foreach (var item in visualArray)
            {
                StepsListBox.Items.Add(item);
            }
        }

        private void MergeSort(int[] arr)
        {
            string algorithmDescription = "Merge Sort - ��� ����������� � ���������� �������� ����������, ������� ��������� ��������� \"�������� � ��������\".";
            string algorithmDescription2 = "�������� ������ ����������� �� ��� ���������� (����� � ������), ����� ������ �� ��� ���������� �����������, � ����� ����� ��� ��������������� ���������� ��������� � ����.";

            AddStepToListBox(algorithmDescription);
            AddStepToListBox(algorithmDescription2);

            MergeSortRecursive(arr, 0, arr.Length - 1);
        }

        private void MergeSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortRecursive(arr, left, middle);
                MergeSortRecursive(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }

        private void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = arr[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = arr[middle + 1 + j];
            }

            int x = 0;
            int y = 0;
            int k = left;

            while (x < n1 && y < n2)
            {
                if (leftArray[x] <= rightArray[y])
                {
                    arr[k] = leftArray[x];
                    x++;
                }
                else
                {
                    arr[k] = rightArray[y];
                    y++;
                }
                k++;
            }

            while (x < n1)
            {
                arr[k] = leftArray[x];
                x++;
                k++;
            }

            while (y < n2)
            {
                arr[k] = rightArray[y];
                y++;
                k++;
            }

            DrawArray(arr);
            AddStepToListBox($"������� �����������: {string.Join(" ", leftArray)} � {string.Join(" ", rightArray)}");
        }

        private void SnakeSort(int[] arr)
        {
            string algorithmDescription1 = "Snake sort -  ���� ����� ������������ ����� ���������� ������ ������� �� ������� � ��������, ��� ������� �������� ��������������� � ������������� �������. ";



            AddStepToListBox(algorithmDescription1);
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);

                string stepDescription = $"����������� �������� {temp} �� ������� {i} ��� ������� ������������� ��������. ����������� �����������, ��� ��� {temp} - ������������ �������.";

                DrawArray(arr);
                AddStepToListBox(stepDescription);
            }
        }

        private void Heapify(int[] arr, int n, int root)
        {

            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                int swap = arr[root];
                arr[root] = arr[largest];
                arr[largest] = swap;

                string stepDescription = $"����������� �������� {swap} �� ������� {largest} ��� ����������� �������� ����. ����������� �����������, ��� ��� {swap} - ������������ ������� � ������� ����.";

                DrawArray(arr);
                AddStepToListBox(stepDescription);

                Heapify(arr, n, largest);
            }
        }

        private void InsertionSort(int[] arr, int low, int high)
        {
            string algorithmDescription = "���������� �������� - ���� ����� ��������� ���������� �������� ��� ���������� �� low �� high.";

            AddStepToListBox(algorithmDescription);

            for (int i = low + 1; i <= high; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= low && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;

                    string stepDescription = $"����������� �������� {arr[j + 1]} �� ������� {j + 2}. ����������� �����������, ��� ��� {arr[j + 1]} > {key}.";
                    DrawArray(arr);
                    AddStepToListBox(stepDescription);
                }

                arr[j + 1] = key;
            }
        }

       



        private void SortButton_Click_1(object sender, EventArgs e)
        {

        }



        private void PriorityQueueSortRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "��������������� ������: " + string.Join(" ", intArray);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int arraySize = 10; // ������ ������� (������ �������� �� ������ �������)
            intArray = GenerateRandomArray(arraySize); // ���������� ��������� ������
            ResultLabel.Text = "��������������� ������: " + string.Join(" ", intArray);



        }
        private void DrawArray(int[] arr)
        {
            // �������� PictureBox ����� ���������� ������ ���������
            pictureBox1.Image = null;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            int maxElement = arr.Max();
            int elementWidth = width / arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                int elementHeight = (int)((double)arr[i] / maxElement * height); // ������ ��������
                int x = i * elementWidth;
                int y = height - elementHeight;

                // ��������� ��������
                g.FillRectangle(Brushes.Pink, x, y, elementWidth, elementHeight);
            }

            // ���������� ����������� � PictureBox
            pictureBox1.Image = bmp;
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }

        private void StepsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mergeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

        private void snakeSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3.Show();
        }

        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form4.Show();
        }

        private void insertionSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form5.Show();

        }


    }
}
