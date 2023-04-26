namespace Tama
{
    
    public partial class Form1 : Form
    {
        public bool sleep = false;
        public void check() 
        {
            if (progressBar2.Value == 0) 
            {
                pictureBox1.Image = imageList1.Images[6];
            }
            if (progressBar3.Value < 300000) { pictureBox1.Image = imageList1.Images[4]; }
            else if (progressBar3.Value < 500000) { pictureBox1.Image = imageList1.Images[3]; }
            else if (progressBar3.Value > 600000) { pictureBox1.Image = imageList1.Images[0]; }
            else if (progressBar3.Value > 850000) { pictureBox1.Image = imageList1.Images[1]; }
        }
        public Form1()
        {
            InitializeComponent();
            check();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar3.Value + 6000 > progressBar3.Maximum)
            {
                progressBar3.Value += progressBar3.Maximum - progressBar3.Value;
            }
            else progressBar3.Value += 6000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sleep)
            {
                sleep = false;
                button1.Enabled = true;
                button2.Enabled = true;
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
            else 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar3.Value - 100 >= 0) progressBar3.Value -= 100;
            else progressBar3.Value -= progressBar3.Value;
            if (progressBar4.Value + 100 <= progressBar4.Maximum) progressBar4.Value+= 100;
            else progressBar4.Value += progressBar4.Maximum - progressBar4.Value;
            if (progressBar1.Value + 100 <= progressBar1.Maximum) progressBar1.Value += 100;
            else progressBar1.Value += progressBar1.Maximum - progressBar1.Value;
            check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value - 10000 < progressBar1.Minimum)
            {
                progressBar1.Value -= progressBar1.Value;
            }
            else progressBar1.Value -= 10000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar4.Value != 0)
            {
                if (progressBar4.Value - 500 < progressBar4.Minimum)
                {
                    progressBar4.Value -= progressBar4.Value;
                }
                else progressBar4.Value -= 500;
                if (progressBar1.Value + 300 > progressBar1.Maximum)
                {
                    progressBar1.Value += progressBar1.Maximum - progressBar1.Value;
                }
                else progressBar1.Value += 300;
            }
            else 
            {
                sleep = true;
                button3_Click(null, null);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0 || 
                progressBar4.Value <= 0 ||
                progressBar3.Value <= 0) 
            {
                timer4.Enabled = true;
            }
            else timer4.Enabled = false;
        }
        int Time = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            Time++;
            label5.Visible = true;
            label5.Text = $"Покращіть показники, інакше персонаж втратись своє здоров'я! У вас залишилос {60 - Time}";
            if (Time == 60) 
            {
                progressBar1.Value = 500000;
                progressBar4.Value = 500000;
                progressBar3.Value = 500000;
                Time = 0;
                if (progressBar2.Value - 50000 <= 0)
                {
                    progressBar2.Value -= progressBar2.Value;
                    pictureBox1.Image = imageList1.Images[6];
                    label6.Visible = true;
                    progressBar1.Value = 0;
                    progressBar4.Value = 0;
                    progressBar3.Value = 0;
                    label6.Text = "Нажаль персонаж вмер :(";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    timer1.Enabled = false;
                    timer3.Enabled = false;
                    timer4.Enabled = false;
                }
                else progressBar2.Value -= 50000;
                label5.Visible = false;
            }
        }
    }
}