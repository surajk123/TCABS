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
    public partial class Form4 : Form
    {
        public string PATH = @"Person.xml";

       


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Class1.pickup;
            textBox2.Text = Class1.dropby;
            textBox3.Text = Class1.date;
            textBox4.Text = Class1.time;
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
                CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "cabs", "surajkumarmishra09@gmail.com", "suraj@123", "document", "//document/id", additionalParams);
                // creating a CPS_Simple instance
                CPS_Simple cpsSimple = new CPS_Simple(cpsConn);

               for (int i=0;i<15;i++)
               {
                   var id = "textbox1.text";

                   CPS_SimpleXML document = (CPS_SimpleXML)cpsSimple.retrieveSingle(id, CPS_Response.DOC_TYPE.DOC_TYPE_SIMPLEXML);
                   textBox5.AppendText(id);
               }
                

           /*   string query = Utils.CPS_Term("pickup", "category") + Utils.CPS_Term("8", "id");
      // return documents starting with the first one - offset 0
     int offset = 0;
      // return not more than 5 documents
     int docs = 5;
      // return these fields from the documents
     Dictionary<string, string> list = new Dictionary<string, string>();
     list["document"] = "yes";
    
      // order by year, from largest to smallest
     string ordering = Utils.CPS_NumericOrdering("id", "descending");
 
      // Searching for documents
      // note that only the query parameter is mandatory - the rest are optional
     CPS_SearchRequest searchRequest = new CPS_SearchRequest(query, offset, docs, list);
    // searchRequest.setOrdering(ordering);
 
     CPS_SearchResponse searchResponse = (CPS_SearchResponse)cpsConn.sendRequest(searchRequest);
    int count = searchResponse.getHits();
    textBox5.Text = count.ToString();
    


     if (count>0)
     {
         textBox5.AppendText("Found " + searchResponse.getHits() + " documents\r\n");
         textBox5.AppendText("Showing from " + searchResponse.getFrom() + " to " + searchResponse.getTo() + "\r\n");

         Dictionary<string, CPS_SimpleXML> documents = (Dictionary<string, CPS_SimpleXML>)searchResponse.getDocuments(CPS_Response.DOC_TYPE.DOC_TYPE_SIMPLEXML);

         foreach (KeyValuePair<string, CPS_SimpleXML> pair in documents)
         {
             textBox5.AppendText(pair.Value["car_params"]["make"] + " " + pair.Value["car_params"]["model"] + "\r\n");
             textBox5.AppendText("First registration: " + pair.Value["car_params"]["year"] + "\r\n");
         }
     }
     else
         textBox5.AppendText("Nothing found.\r\n");*/


            }
    

             catch (CPS_Exception ex)
                  {
                      // error message can be retrieved using ex.ToString()
                      MessageBox.Show(ex.ToString());

                  }
        }

        private void button1_Click(object sender, EventArgs e)
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
                CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "cabs", "surajkumarmishra09@gmail.com", "suraj@123", "document", "//document/id", additionalParams);
                // creating a CPS_Simple instance
                CPS_Simple cpsSimple = new CPS_Simple(cpsConn);
                string ids = textBox6.Text;
                // retrieving one document
                CPS_SimpleXML document = (CPS_SimpleXML)cpsSimple.retrieveSingle(ids, CPS_Response.DOC_TYPE.DOC_TYPE_SIMPLEXML);
                textBox7.AppendText(document["pwd"]);

                if (textBox6.Text.Equals("") )
                {
                    MessageBox.Show("ENTER MOBILE NUMBER");
                    textBox6.Text = "";
                    
                }
                
                
                else if (textBox6.Text == textBox7.Text)
                {

                    Form6 newForm = new Form6();
                    newForm.Show();
                    this.Hide();

                }
                else
                {
                    Form4 newForm = new Form4();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
    
}
