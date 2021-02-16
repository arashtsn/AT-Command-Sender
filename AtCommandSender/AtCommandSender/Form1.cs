using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtCommandSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SerialPort _serialPort;
        private void button1_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort(textBox1.Text, 9600);

            try {

                _serialPort.Open();
                _serialPort.DiscardInBuffer();
                Thread.Sleep(2000);
                if (_serialPort.IsOpen)
                {
                    log("port opened");
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button1.Enabled = false;
                }
                else
                    log("error when opening port");

            } catch(Exception ex)
            {
                log(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                _serialPort.Close();
                Thread.Sleep(2000);
                if (!_serialPort.IsOpen)
                {
                    log("port closed");
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button1.Enabled = true;
                }
                else
                    log("error when closing port");

            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log("command sended waiting for response in 10 sec");
            Thread.Sleep(1000);

            this._serialPort.WriteLine( textBox2.Text+ "\r");
            Thread.Sleep(10000);
           // this._serialPort.ReadExisting
            log(this._serialPort.ReadExisting());
           
        }


        private void log(string str)
        {
            richTextBox1.AppendText(str + "\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
