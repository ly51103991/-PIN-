using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace ComDemoProject
{
    public partial class SetPort : Form
    {
        public static SerialPort sp = new SerialPort();
        public static SerialPort sp2 = new SerialPort();
        public SetPort()
        {
            InitializeComponent();
        }

        private void SetPort_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;

            //初始化数据
            for (int i = 0; i < 10; i++)
            {
                obxComPort.Items.Add("COM" + (i + 1).ToString());
                obxComPort2.Items.Add("COM" + (i + 1).ToString());
            }
            obxComPort.SelectedIndex = 0;

            obxBaudRate.Items.Add("1200");
            obxBaudRate.Items.Add("2400");
            obxBaudRate.Items.Add("4800");
            obxBaudRate.Items.Add("9600");
            obxBaudRate.Items.Add("19200");
            obxBaudRate.Items.Add("38400");
            obxBaudRate.Items.Add("43000");
            obxBaudRate.Items.Add("56000");
            obxBaudRate.Items.Add("57600");
            obxBaudRate.Items.Add("115200");
            obxBaudRate.Items.Add("117600");
            obxBaudRate.Items.Add("240000");
            obxBaudRate.SelectedIndex = 3;

            obxStopBits.Items.Add("0");
            obxStopBits.Items.Add("1");
            obxStopBits.Items.Add("1.5");
            obxStopBits.Items.Add("2");
            obxStopBits.SelectedIndex = 1;

            obxDataBits.Items.Add("8");
            obxDataBits.Items.Add("7");
            obxDataBits.Items.Add("6");
            obxDataBits.Items.Add("5");
            obxDataBits.SelectedIndex = 0;

            obxParity.Items.Add("无");
            obxParity.Items.Add("奇校验");
            obxParity.Items.Add("偶校验");
            obxParity.SelectedIndex = 0;


            obxComPort2.SelectedIndex = 0;

            obxBaudRate2.Items.Add("1200");
            obxBaudRate2.Items.Add("2400");
            obxBaudRate2.Items.Add("4800");
            obxBaudRate2.Items.Add("9600");
            obxBaudRate2.Items.Add("19200");
            obxBaudRate2.Items.Add("38400");
            obxBaudRate2.Items.Add("43000");
            obxBaudRate2.Items.Add("56000");
            obxBaudRate2.Items.Add("57600");
            obxBaudRate2.Items.Add("115200");
            obxBaudRate2.Items.Add("117600");
            obxBaudRate2.Items.Add("240000");
            obxBaudRate2.SelectedIndex = 3;

            obxStopBits2.Items.Add("0");
            obxStopBits2.Items.Add("1");
            obxStopBits2.Items.Add("1.5");
            obxStopBits2.Items.Add("2");
            obxStopBits2.SelectedIndex = 1;

            obxDataBits2.Items.Add("8");
            obxDataBits2.Items.Add("7");
            obxDataBits2.Items.Add("6");
            obxDataBits2.Items.Add("5");
            obxDataBits2.SelectedIndex = 0;

            obxParity2.Items.Add("无");
            obxParity2.Items.Add("奇校验");
            obxParity2.Items.Add("偶校验");
            obxParity2.SelectedIndex = 0;

            bool comExistence = false;
            obxComPort.Items.Clear();
            obxComPort2.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    obxComPort.Items.Add("COM" + (i + 1).ToString());
                    obxComPort2.Items.Add("COM" + (i + 1).ToString());
                    comExistence = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (comExistence)
            {
                obxComPort.SelectedIndex = 0;
                obxComPort2.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有找到任何可用串口", "错误提示");
            }
        }

        private void CheckCom_Click()
        {
            bool comExistence = false;
            obxComPort.Items.Clear();
            obxComPort2.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    obxComPort.Items.Add("COM" + (i + 1).ToString());
                    obxComPort2.Items.Add("COM" + (i + 1).ToString());
                    comExistence = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (comExistence)
            {
                obxComPort.SelectedIndex = 0;
                obxComPort2.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有找到任何可用串口", "错误提示");
            }
        }

        private void btnCheckCom_Click(object sender, EventArgs e)
        {
            CheckCom_Click();
        }

        //  设置串口名
        private void SetPortProperty()
        {
            sp = new SerialPort();
            sp.PortName = obxComPort.Text.Trim();                //设置串口名
            sp.BaudRate = Convert.ToInt32(obxBaudRate.Text.Trim());  //设置串口波特率
            float f = Convert.ToSingle(obxStopBits.Text.Trim());     //设置停止位

            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }

            sp.DataBits = Convert.ToInt16(obxDataBits.Text.Trim()); //设置数据位
            string s = obxParity.Text.Trim();
            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }

            sp.ReadTimeout = -1;     //  设置超时读取时间
            sp.RtsEnable = true;

            // 定义Data Received 事件 ，  当串口收到数据后触发事件
            //sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
        }

        private void SetPortProperty2()
        {
            sp2 = new SerialPort();
            sp2.PortName = obxComPort2.Text.Trim();                //设置串口名
            sp2.BaudRate = Convert.ToInt32(obxBaudRate2.Text.Trim());  //设置串口波特率
            float f2 = Convert.ToSingle(obxStopBits2.Text.Trim());     //设置停止位

            if (f2 == 0)
            {
                sp2.StopBits = StopBits.None;
            }
            else if (f2 == 1)
            {
                sp2.StopBits = StopBits.One;
            }
            else if (f2 == 1.5)
            {
                sp2.StopBits = StopBits.OnePointFive;
            }
            else if (f2 == 2)
            {
                sp2.StopBits = StopBits.Two;
            }
            else
            {
                sp2.StopBits = StopBits.One;
            }


            sp2.DataBits = Convert.ToInt16(obxDataBits2.Text.Trim()); //设置数据位
            string s2 = obxParity2.Text.Trim();     //设置奇偶校验

            if (s2.CompareTo("无") == 0)
            {
                sp2.Parity = Parity.None;
            }
            else if (s2.CompareTo("奇校验") == 0)
            {
                sp2.Parity = Parity.Odd;
            }
            else if (s2.CompareTo("偶校验") == 0)
            {
                sp2.Parity = Parity.Even;
            }
            else
            {
                sp2.Parity = Parity.None;
            }
            sp2.ReadTimeout = -1;     //  设置超时读取时间
            sp2.RtsEnable = true;

            // 定义 串口2Data Received 事件 ，  当串口收到数据后触发事件
           // sp2.DataReceived += new SerialDataReceivedEventHandler(null,new SerialDataReceivedEventArgs());
        }

        private void ok_Order_Click(object sender, EventArgs e)
        {
            if (obxComPort.Text != obxComPort2.Text) {  
            SetPortProperty();
            SetPortProperty2();
            sp.Open();
            sp2.Open();
            Form1 f = new Form1();
            this.Visible = false;
            f.ShowDialog();         
            this.Close();
            }
            else MessageBox.Show("串口打开冲突！");
        }
    }
   
}
