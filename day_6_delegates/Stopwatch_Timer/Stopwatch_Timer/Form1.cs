
using System.Windows.Forms;
namespace Stopwatch_Timer
 
{
    public partial class Form1 : Form
    {    
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;

            if(seconds == 60)
            {
                seconds = 0;
                minutes++; 
            }
            if(minutes == 60)
            {
                minutes = 0;
                hours ++;
            }
        richTextBox1.Text = hours.ToString("D2");
        richTextBox2.Text = minutes.ToString("D2");
        richTextBox3.Text = seconds.ToString("D2");

    }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string time = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");

            System.IO.File.AppendAllText("timer.txt", time + Environment.NewLine);

            MessageBox.Show("Time Saved!");
        }
    }
}
