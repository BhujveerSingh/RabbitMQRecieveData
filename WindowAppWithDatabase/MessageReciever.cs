using System;
using System.Text;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Apigen;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using WindowAppWithDatabase;
using System.Net;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Web.UI;

namespace WindowAppWithDatabase
{
    public class MessageReceiver : DefaultBasicConsumer
    {

        private readonly IModel _channel;

        public MessageReceiver(IModel channel)
        {

            _channel = channel;

        }
        string recievedtext = string.Empty;
        string lblSuccessSend = string.Empty;
        string lblErrorSend = string.Empty;
        string LoadedData = "";
        SqlCommand cmd;
        DataRow dr; SqlConnection con;
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            try
            {
                string mess = Encoding.UTF8.GetString(body);
                string kut = mess.Replace("ISODate(", "");
                string tik = kut.Replace("\")", "\"");
                recievedtext = tik;
                //starts saving 
                string json1 = recievedtext;
                if (!string.IsNullOrEmpty(recievedtext))
                {

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    dynamic data = JObject.Parse(json1);
                    if (!string.IsNullOrEmpty(recievedtext))
                    {
                        if (data.ToString().Contains("requestType"))
                        {
                            if (data["requestType"] == "BatchCreateAndUpdateResponse")
                            {
                                if (data.ToString().Contains("assessmentAgencyDetails"))
                                {
                                    lblSuccessSend = "Assessment Agency Response Details Added SuccessFully!!";
                                   
                                }
                                else
                                {
                                    lblSuccessSend = "Batch Details Response Addedd Successfully!!!";
                                   
                                }
                            }

                        }
                    }
                }
                else
                {

                }
            }
            catch
            {


            }
        }
     
    }
}
