using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EasyModbus;

namespace MB_Modbus_TCP_Test_GUI
{
    public partial class Form1 : Form
    {

        ModbusClient mbc;
        bool baglanti = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!baglanti)
                {
                    mbc = new ModbusClient(textBox1.Text, Convert.ToInt32(textBox2.Text));
                    mbc.Connect();
                    baglanti = true;
                    button1.Text = "Dur";
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    mbc.Disconnect();
                    baglanti = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button1.Text = "Bağlan";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("IP ve Port Hatasi");
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mbc.WriteSingleCoil(Convert.ToInt32(textBox3.Text), false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mbc.WriteSingleCoil(Convert.ToInt32(textBox3.Text), true);
        }
    }
}
