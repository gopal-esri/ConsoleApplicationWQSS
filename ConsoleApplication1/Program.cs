using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Convert our JSON in into bytes using ascii encoding
                ASCIIEncoding encoding = new ASCIIEncoding();
                //byte[] data = encoding.GetBytes(tbJSONdata.Text);

                //  HttpWebRequest 
                Uri url = new Uri("website_address");
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                //webrequest.Method = "POST";
                webrequest.Method = "GET";
                webrequest.ContentType = "application/x-www-form-urlencoded";
                webrequest.Headers.Add("STARLIMSUser", "WQSS");
                webrequest.Headers.Add("STARLIMSPass", "WQSS");
                webrequest.Headers.Add("WQSS_REQ_ID", "chrom12345wqss");
                webrequest.Headers.Add("WQSS_REQ_NAME", "ROUTINE_FILE");


                //  Declare & read the response from service
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

                // Fetch the response from the POST web service
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string result = loResponseStream.ReadToEnd();
                loResponseStream.Close();

                webresponse.Close();
                ViewBag.output = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.ToString());
                throw;
            }

            
        }
    }
}
