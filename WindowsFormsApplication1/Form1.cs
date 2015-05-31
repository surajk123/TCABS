using System;
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



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string PATH = @"Person.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox3.Text.Equals("") && textBox4.Text.Equals("") && textBox5.Text.Equals("") && textBox6.Text.Equals("") && textBox7.Text.Equals(""))
                {
                    MessageBox.Show("FILL THE DETAILS");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }

                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("FULL NAME is empty");
                    textBox1.Text = "";
                }
                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("MOBILE NUMBER is empty");
                    textBox2.Text = "";
                }
                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("EMAIL is empty");
                    textBox3.Text = "";
                }
                if (textBox4.Text.Equals("") && textBox5.Text.Equals(""))
                {
                    MessageBox.Show("PASSWORD is empty");
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    if (textBox4.Text == textBox5.Text)
                    {
                       // string PATH = @"Person.xml";
                        List<string> connectionStrings = new List<string>();
                        connectionStrings.Add("tcps://cloud-eu-0.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-1.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-2.clusterpoint.com:9008");
                        connectionStrings.Add("tcps://cloud-eu-3.clusterpoint.com:9008");

                        Dictionary<string, string> additionalParams = new Dictionary<string, string>();
                        additionalParams["account"] = "649";

                        CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "myapp", "surajkumarmishra09@gmail.com", "suraj@123", "document", "//document/id", additionalParams

                                    );
                        //cpsConn.setDebug(true);
                        //cpsConn.setCustomSSLValidation("addtrustexternalcaroot.crt", "cloud-eu.clusterpoint.com");
                        CPS_Simple cpsSimple = new CPS_Simple(cpsConn);

                        XmlWriter xmlWriter = XmlWriter.Create(PATH);

                        // xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("document");

                        xmlWriter.WriteStartElement("fname");
                        xmlWriter.WriteString(textBox1.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("id");
                        xmlWriter.WriteString(textBox2.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("email");
                        xmlWriter.WriteString(textBox3.Text);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("pwd");
                        xmlWriter.WriteString(textBox4.Text);
                        xmlWriter.WriteEndElement();


                        xmlWriter.WriteEndDocument();

                        xmlWriter.Close();

                        string id1 = "";

                        XmlDocument doc1 = new XmlDocument();
                        doc1.Load(PATH);

                        // Insert
                        cpsSimple.insertSingle(id1, doc1.DocumentElement);


                        Form1 newForm = new Form1();
                        newForm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("PASSWORD MISMATCH");
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                }
            }
            catch (CPS_Exception ex)
            {
                // error message can be retrieved using ex.ToString()
                ex.ToString();
                MessageBox.Show("MOBILE NUMBER EXISTS");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> connectionStrings = new List<string>();
                connectionStrings.Add("tcps://cloud-eu-0.clusterpoint.com:9008");
                connectionStrings.Add("tcps://cloud-eu-1.clusterpoint.com:9008");
                connectionStrings.Add("tcps://cloud-eu-2.clusterpoint.com:9008");
                connectionStrings.Add("tcps://cloud-eu-3.clusterpoint.com:9008");

                Dictionary<string, string> additionalParams = new Dictionary<string, string>();
                additionalParams["account"] = "649";
                // creating a CPS_Connection instance
                CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "myapp", "surajkumarmishra09@gmail.com", "suraj@123", "document", "//document/id", additionalParams);
                // creating a CPS_Simple instance
                CPS_Simple cpsSimple = new CPS_Simple(cpsConn);
                string ids = textBox6.Text;
                // retrieving one document
                CPS_SimpleXML document = (CPS_SimpleXML)cpsSimple.retrieveSingle(ids, CPS_Response.DOC_TYPE.DOC_TYPE_SIMPLEXML);
                textBox8.AppendText(document["pwd"]);

                if (textBox6.Text.Equals("") && textBox7.Text.Equals(""))
                {
                    MessageBox.Show("ENTER MOBILE NUMBER AND PASSWORD");
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                if (textBox6.Text.Equals(""))
                {
                    MessageBox.Show("ENTER MOBILE NUMBER ");
                    textBox6.Text = "";
                }
                if (textBox7.Text.Equals(""))
                {
                    MessageBox.Show("ENTER  PASSWORD");
                    textBox7.Text = "";
                }
                else if (textBox8.Text == textBox7.Text)
                {

                    Form2 newForm = new Form2();
                    newForm.Show();
                    this.Hide();

                }
                else
                {
                    Form1 newForm = new Form1();
                    newForm.Show();
                    this.Hide();
                }

            }
            catch (CPS_Exception ex)
            {
                // error message can be retrieved using ex.ToString()
                ex.ToString();

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }
    }
}
