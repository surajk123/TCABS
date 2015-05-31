
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;

using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using CPS;
//using Bing.Maps.Directions;
using System;
using Microsoft.Maps.MapControl.WPF;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public string PATH = @"Perso.xml";
       
        public Form2()
        {
            InitializeComponent();

         
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            panel2.Visible = false;

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

           
            string source = textBox1.Text;
            string destination = textBox2.Text;
            try
            {
                StringBuilder querryaddress = new StringBuilder();
                querryaddress.Append("http://maps.google.com/maps?q=");



                if (source != string.Empty)
                {
                    querryaddress.Append(source + "," + "+");

                }

                if (destination != string.Empty)
                {
                    querryaddress.Append(destination + "," + "+");

                }

                webBrowser1.Navigate(querryaddress.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR");
            }
            for (var i = 0; i < 5;i++ )
            {
                if(i<5)
                {
                    label3.Visible = true;
                    label4.Visible = true;
                    panel2.Visible = true;
                }
                else
                {

                }
            }
                
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("") && textBox4.Text.Equals("") && textBox5.Text.Equals("") && textBox6.Text.Equals("") && textBox7.Text.Equals("") && textBox8.Text.Equals("") && textBox9.Text.Equals("") && textBox10.Text.Equals("") && comboBox1.Text.Equals(""))
            {

                MessageBox.Show("FILL THE DETAILS");
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                comboBox1.Text = "";
                       
                   
            }

            else
            {
                
                try
                {
                    if (radioButton1.Checked == true)
                    {

                        // string PATH = @"Person.xml";
                        List<string> connectionStrings = new List<string>();
                        connectionStrings.Add("tcps://cloud-eu-0.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-1.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-2.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-3.clusterpoint.com:9008");

                        Dictionary<string, string> additionalParams = new Dictionary<string, string>();
                        additionalParams["account"] = "649";

                        CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "cabs", "surajkumarmishra09@gmail.com", "suraj@123", "document", "//document/id", additionalParams

                                    );
                        //cpsConn.setDebug(true);
                        //cpsConn.setCustomSSLValidation("addtrustexternalcaroot.crt", "cloud-eu.clusterpoint.com");
                        CPS_Simple cpsSimple = new CPS_Simple(cpsConn);

                        XmlWriter xmlWriter = XmlWriter.Create(PATH);

                        // xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("document");

                        xmlWriter.WriteStartElement("mobile");
                        xmlWriter.WriteString(textBox4.Text);
                        xmlWriter.WriteEndElement();
                    
                       
                        xmlWriter.WriteStartElement("name");
                        xmlWriter.WriteString(textBox3.Text);
                        xmlWriter.WriteEndElement();


                        xmlWriter.WriteStartElement("email");
                        xmlWriter.WriteString(textBox5.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("payment");
                        xmlWriter.WriteString(comboBox1.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("pickup");
                        xmlWriter.WriteString(textBox6.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("dropby");
                        xmlWriter.WriteString(textBox7.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("date");
                        xmlWriter.WriteString(textBox8.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("time");
                        xmlWriter.WriteString(textBox10.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("address");
                        xmlWriter.WriteString(textBox9.Text);
                        xmlWriter.WriteEndElement();
                        
                        xmlWriter.WriteEndDocument();

                        xmlWriter.Close();

                        string id = textBox4.Text;


                        XmlDocument doc2 = new XmlDocument();
                        doc2.Load(PATH);

                        // Insert

                            cpsSimple.insertSingle(id, doc2.DocumentElement);


                      


                        Form3 newForm = new Form3();
                        newForm.Show();
                        this.Hide();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        Class1.pickup = textBox6.Text;
                        Class1.dropby = textBox7.Text;
                        Class1.date = textBox8.Text;
                        Class1.time = textBox10.Text;
                        Form4 newForm = new Form4();
                        newForm.Show();
                        this.Hide();

                    }
                    else
                    {
                        Form3 newForm = new Form3();
                        newForm.Show();
                        this.Hide();
                    }
                   

                }

                catch (CPS_Exception ex)
                {
                    // error message can be retrieved using ex.ToString()

                  //  MessageBox.Show(ex.ToString());
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    comboBox1.Text = "";

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
