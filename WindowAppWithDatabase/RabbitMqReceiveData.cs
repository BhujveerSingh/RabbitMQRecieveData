using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;
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
    public partial class RabbitMqReceiveData : Form
    {
        public RabbitMqReceiveData()
        {
            InitializeComponent();
        }
        public void GetRespOrg()
        {
            if (System.DateTime.Now.Hour >= 9 && System.DateTime.Now.Hour <= 23)
            {



                string UserName = "guest";
                string Password = "guest";
                string HostName = "localhost";
                int Port = 5672;
                ConnectionFactory connectionFactory = new ConnectionFactory
                {
                    UserName = UserName,
                    Password = Password,
                    HostName = HostName,
                    Port = Port
                };
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                channel.BasicQos(0, 1, false);
                QueueDeclareOk result = channel.QueueDeclarePassive("hello");
                uint count = result != null ? result.MessageCount : 0;
                if (result.MessageCount == 0)
                {
                    System.Environment.Exit(0);
                }
                MessageReceiver messageReceiver = new MessageReceiver(channel);
                channel.BasicConsume("hello", true, messageReceiver);
                Console.ReadLine();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetRespOrg();
        }
    }




}
