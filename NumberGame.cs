using System;
using System.Windows.Forms;

namespace NumberGame
{
    public partial class Form1 : Form
    {
        int num;      
        int count = 0;   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            button1.Enabled = false;
            maskedTextBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Random r = new Random();
            num = r.Next(0, 101); 

            count = 0; 
            listBox1.Items.Clear(); 
            maskedTextBox1.Clear(); 
            errorProvider1.Clear(); 

            
            button1.Enabled = true;
            maskedTextBox1.Enabled = true;

            listBox1.Items.Add("Yeni oyun başladı. Ədədi daxil edin.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                errorProvider1.SetError(maskedTextBox1, "Axtarılan ədəd xanası boş ola bilməz!");
                return;
            }
            else
            {
                errorProvider1.Clear(); 
            }

            int enteredNum;
          
            if (!int.TryParse(maskedTextBox1.Text, out enteredNum))
            {
                errorProvider1.SetError(maskedTextBox1, "Lütfən düzgün ədəd daxil edin!");
                return;
            }

            count++; 

            if (enteredNum < num)
            {
                listBox1.Items.Add("Daxil edilən ədəd yanlışdır. Təsadüfi ədəddən kiçikdir.");
                listBox1.Items.Add("Cəhd sayı: " + count);
            }
            else if (enteredNum > num)
            {
                listBox1.Items.Add("Daxil edilən ədəd yanlışdır. Təsadüfi ədəddən böyükdür.");
                listBox1.Items.Add("Cəhd sayı: " + count);
            }
            else
            {
             
                listBox1.Items.Add("Oyunu qazandınız!");
                listBox1.Items.Add("Cəhd sayı: " + count);

               
                button1.Enabled = false;
                maskedTextBox1.Enabled = false;
            }

            maskedTextBox1.Clear(); 
            maskedTextBox1.Focus(); 
        }
    }
}