using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Diagnostics;
using CPS;


using Microsoft.Maps.MapControl.WPF;
namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            Random random = new Random();
             int l12 = random.Next(5, 15);
                label12.Text = l12.ToString()+"mins";
                int l13 = random.Next(5, 15);
                label13.Text = l13.ToString() + "mins";
                int l14 = random.Next(5, 15);
                label14.Text = l14.ToString() + "mins";
                int l15 = random.Next(5, 15);
                label15.Text = l15.ToString() + "mins";
                int l16 = random.Next(5, 15);
                label16.Text = l16.ToString() + "mins";
                int l17 = random.Next(5, 15);
                label17.Text = l17.ToString() + "mins";
                int l18 = random.Next(5, 15);
                label18.Text = l18.ToString() + "mins";
                int l19 = random.Next(5, 15);
                label19.Text = l19.ToString() + "mins";
                int l20 = random.Next(5, 15);
                label20.Text = l20.ToString() + "mins";
                int l21 = random.Next(5, 15);
                label21.Text = l21.ToString() + "mins";
            
           
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Class1.address = "https://www.uber.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.address = "https://www.uber.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.address = "https://www.uber.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Class1.address = "https://www.olacabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.address = "https://www.olacabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1.address = "https://www.olacabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1.address = "http://dotcabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Class1.address = "http://dotcabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Class1.address = "http://dotcabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class1.address = "http://dotcabs.com/";
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
}







































































































                 