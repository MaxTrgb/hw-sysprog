namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int start = (int)numericUpDown1.Value;
            int stop = (int)numericUpDown2.Value;
            int threadsNum = (int)numericUpDown3.Value;
                           
            runProgram(start, stop, threadsNum);
        }
        public void runProgram(int start, int stop, int threadsNum)
        {
            Thread[] threads = new Thread[threadsNum];

            for (int i = 0; i < threadsNum; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = start; j <= stop; j++)
                    {
                        Invoke((Action)(() =>
                        {
                            listBox1.Items.Add(j); 

                        }));
                    }
                });
                threads[i].Start();
            }
        }
    }
}
