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
using System.IO;
using MySql.Data.MySqlClient;
using DataConn;
using System.Collections;
using System.Text.RegularExpressions;

namespace ComDemoProject
{
    public partial class Form1 : Form
    {        
        ArrayList childNumList = new ArrayList();
        SerialPort sp = new SerialPort();
        SerialPort sp2 = new SerialPort();
        bool vip = false;
        public Form1()
        {   
            InitializeComponent();
        }
        public Form1(bool b)
        {
            InitializeComponent();
            vip = b;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sp = SetPort.sp;
            sp2 = SetPort.sp2;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            radioAuto.Checked = true;

            // 定义Data Received 事件 ，  当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            sp2.DataReceived += new SerialDataReceivedEventHandler(sp2_DataReceived);

            buttonUpdate.Visible = false;
            if (vip) buttonUpdate.Visible = vip;
        }
         //byte数组转16进制
        public  static string  byteToHexString(byte[] rd)
        {
            StringBuilder sb = new StringBuilder(rd.Length * 3);
            foreach (var b in rd)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }
            return sb.ToString().ToUpper();
        }
         //完成子板号与坐标对应方法
         public static string[] getChildNum(string[] str)
           {
            string xPoint = "";
            string yPpoint= "";
            string[] newStr = new string[8];
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 1)
                {
                    int xP =Int32.Parse(str[i - 1]);
                    if (xP < 10) xPoint = "0" + xP;
                    else xPoint = xP.ToString();

                    int yP = Int32.Parse(str[i]);
                    int childNum = yP / 19 + 1;
                    int temp = yP % 19;
                    if (yP <= 19 && yP >= 10) yPpoint = yP.ToString();
                    else if(yP<10) yPpoint = "0" + yP;
                    if (yP > 19)
                    {
                        if (temp < 10) yPpoint = "0" + temp;
                        else yPpoint = temp.ToString();
                    }
                    switch (childNum)
                    {
                        case 1: newStr[0] += (xPoint + yPpoint); break;
                        case 2: newStr[1] += (xPoint + yPpoint); break;
                        case 3: newStr[2] += (xPoint + yPpoint); break;
                        case 4: newStr[3] += (xPoint + yPpoint); break;
                        case 5: newStr[4] += (xPoint + yPpoint); break;
                        case 6: newStr[5] += (xPoint + yPpoint); break;
                        case 7: newStr[6] += (xPoint + yPpoint); break;
                        case 8: newStr[7] += (xPoint + yPpoint); break;
                       default:                                  break;

                    }
                }
            }                     
            return newStr;                           
    }        
        //将超过19的y坐标解析方法（参数是带坐标的数据）
        public string childToPcPointChange(byte[] bty)
        {
            string xPoint = "";
            string yPoint = "";
            string str = "";
            int childId = (int)bty[2]-1;
            int pointNum =(int) bty[3];
            for (int i = 4; i < pointNum*2+4; i++)
            {
                if (i % 2 == 1)
                {
                    int temp = (int)bty[i];
                    if (temp > 10) temp = temp - 6;
                    int b = 19 * childId + temp;

                    if (b < 10) yPoint = "0" + b;
                    else yPoint = b.ToString();
                    int c = (int)bty[i -1];
                    if (c < 16) xPoint = "0" + c;
                    else
                    {
                        if (c >= 112) c = c - 42;
                        else if (c >= 96) c = c - 36;
                        else if (c >= 80) c = c - 30;
                        else if (c >= 64) c = c - 24;
                        else if (c >= 48) c = c - 18;
                        else if (c >= 30) c = c - 12;
                        else if (c >= 16) c = c - 6;
                        xPoint = c.ToString();
                    }
                    str += xPoint + "," + yPoint + ",";
                }
            }            
            return str;
        }
        /*比较2个byte数组是否一样
        public bool CompareArray(byte[] bt1, byte[] bt2)
        {
            if (bt1.Length != bt2.Length)
            {
                return false;
            }
            for (var i = 0; i < bt1.Length; i++)
            {
                if (bt1[i] != bt2[i])
                    return false;
            }
            return true;
        }*/

        string dataBasePoints = "";//数据库坐标
        string strs = "";//回复FF的子板号
        string childRandnum = "";//手动定位成功的子板号
        //扫码枪串口1接收数据
        private void sp_DataReceived(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            this.Invoke((EventHandler)(delegate
            {
                try
                {
                    dataBasePoints = "";
                    lightSet.ForeColor = Color.Black;
                    if (radioAuto.Checked)
                    {
                        childNumList.Clear();
                        RexvData.Text = "";
                        Byte[] rb = new Byte[sp.BytesToRead];
                        UTF8Encoding utf = new UTF8Encoding();
                        sp.Read(rb, 0, rb.Length);//接收到数据从缓冲区以字节数组形式读出来                                                                      
                        string[] ds = utf.GetString(rb).Split(',');
                        string machineNum = ds[0];
                        string pointNumber = ds[1].Substring(0, 2);
                        string adressPoint = ds[1].Substring(2, (ds[1].Length) - 2);
                        string newStyle = Regex.Replace(adressPoint, @"(\w{2})", "$1,").Trim(',');
                        RexvData.Text = machineNum;
                        String sql = "select childNumber,adressNumber from machines where machineId='" + machineNum + "';";
                        MySqlDataReader rder = DataBaseSys.GetDataReaderValue(sql);
                        if (rder.Read())
                        {
                            string[] point = rder[1].ToString().Split(',');//4                      
                            string pointOld = "";
                            for (int i = 0; i < point.Length; i++)
                            {
                                pointOld += point[i];
                            }
                            dataBasePoints = pointOld;
                            string[] pointNums = Regex.Replace(pointOld, @"(\w{4})", "$1,").Trim(',').Split(',');                          
                            string[] twoPoint = Regex.Replace(adressPoint, @"(\w{4})", "$1,").Trim(',').Split(',');
                            if (!Enumerable.SequenceEqual(pointNums, twoPoint))
                            {
                                MessageBoxButtons messButton1 = MessageBoxButtons.OKCancel;
                                DialogResult dr1 = MessageBox.Show("已有该机种，坐标不一致!需要修改吗?", "提示", messButton1);
                                if (dr1 == DialogResult.OK)//如果点击“确定”按钮
                                {
                                    if (!vip) MessageBox.Show("您没有管理员权限无法修改！");
                                    else
                                    {
                                    string sqlAuto = "update machines set childNumber='" + pointNumber + "' ,adressNumber='" + newStyle + "' where machineId= '" + RexvData.Text + "'";
                                    DataBaseSys.ExecuteNonQuery(sqlAuto);
                                    pointNums = twoPoint;
                                    String sqlUpdate = "select childNumber,adressNumber from machines where machineId='" + RexvData.Text + "';";
                                    MySqlDataReader rderUpdate = DataBaseSys.GetDataReaderValue(sqlUpdate);
                                    rder = rderUpdate;
                                    if (rderUpdate.Read()) { 
                                    string[] pointUpdate = rderUpdate[1].ToString().Split(',');//4                      
                                    string pointOldUpdate = "";
                                    for (int i = 0; i < pointUpdate.Length; i++)
                                    {
                                        pointOldUpdate += pointUpdate[i];
                                    }
                                    dataBasePoints = pointOldUpdate;
                                    MessageBox.Show("修改成功！");
                                    }
                                    }
                                }
                            }
                            DataTable dt = new DataTable();
                            dt.Rows.Add();
                            for (int i = 0; i < pointNums.Length; i++)
                            {
                                dt.Columns.Add("P" + (i + 1), System.Type.GetType("System.String"));
                                dt.Rows[0][i] = pointNums[i];
                            }
                            DataSet ds2 = new DataSet();
                            ds2.Tables.Add(dt);
                            //sda.Fill(ds2);
                            dataAdressView1.DataSource = ds2.Tables[0];
                            dataAdressView1.ReadOnly = true;
                            //dataAdressView1.Rows[0].Cells[0].Style.BackColor = Color.Red;

                            //自动模式下解析数据库存放的坐标地址用来与子板通讯
                            string[] adressPointData = rder[1].ToString().Split(',');
                            // string pointNum = msr[0].ToString();
                            string[] adressPoint1 = getChildNum(adressPointData);
                            //adressPoint1 = adressPoint1.Where(sP => !string.IsNullOrEmpty(sP)).ToArray();
                            for (int i = 0; i < adressPoint1.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(adressPoint1[i]))
                                {
                                    PortOrder po = new PortOrder(Direction.AB, "02", "0" + (i + 1), "0" + adressPoint1[i].Length / 4, adressPoint1[i]);
                                    childNumList.Add("0" + (i + 1));
                                    sp2.Write(hexToString(po.getConnOrder()), 0, hexToString(po.getConnOrder()).Length);
                                }
                            }
                            //定时向子板发送05自动读取命令以收到错误坐标指令
                            timer1.Enabled = true;
                            timer1.Start();
                        }
                        else
                        {
                            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                            DialogResult dr = MessageBox.Show("检测到是新机种!确定添加吗?", "提示", messButton);
                            if (dr == DialogResult.OK)//如果点击“确定”按钮
                            {
                                try
                                {
                                    string addSql = "insert into machines(machineId,childNumber,adressNumber) values('" + machineNum + "','" + pointNumber + "','" + newStyle + "')";
                                    DataBaseSys.ExecuteNonQuery(addSql);
                                    MessageBox.Show("添加成功！");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("添加失败！");
                                }
                            }
                            sp.DiscardInBuffer();
                        }
                }
                }
                catch (Exception x)
                {
                    MessageBox.Show("出现异常错误！" + x.ToString());
                }
            }));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //定时向子板发送05自动读取命令以收到错误坐标指令
            for (int i = 0; i < childNumList.Count; i++)
            {
                //System.Threading.Thread.Sleep(2000);
                PortOrder po = new PortOrder(Direction.AB, "05", childNumList[i].ToString(), "", "");
                sp2.Write(hexToString(po.getConnOrder()), 0, hexToString(po.getConnOrder()).Length);
            }
        }

        string adressPoints = "";//记录回复03带坐标的板子所有坐标以存入数据库
        string autoAdressPoints = "";//记录回复错误的坐标
        int b = 0;
        ArrayList sameMesList = new ArrayList();
        //下位机串口2接收数据
        private void sp2_DataReceived(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            this.Invoke((EventHandler)(delegate
            {  System.Threading.Thread.Sleep(100);                             
                Byte[] rb = new Byte[sp2.BytesToRead];
                sp2.Read(rb, 0, rb.Length);
                //手动状态下
                if (radioHand.Checked)
                {
                    //存储回复FF信号的板子编号（04）
                    if (rb[3] == 0XFF)
                    {
                        strs += rb[2].ToString();
                    }
                    else//(03)
                    {
                        string xYPoints = childToPcPointChange(rb);
                        childRandnum += rb[2].ToString();                       
                        adressPoints += xYPoints;
                        MessageBox.Show("定位成功子板id为" + childRandnum + "+-------收到的板子ID为：" + strs);
                        if (strs == childRandnum&&RexvData.Text!="")
                        {
                            lightSet.ForeColor = Color.Green;
                            string pointDingWei = "";
                            for (int i = 0; i < adressPoints.Split(',').Length; i++)
                            {
                                pointDingWei += adressPoints.Split(',')[i];
                            }
                            string[] pointDingWeiStrs = Regex.Replace(pointDingWei, @"(\w{4})", "$1,").Trim(',').Split(',');
                            DataTable dt = new DataTable();
                            dt.Rows.Add();
                            for (int i = 0; i < pointDingWeiStrs.Length; i++)
                            {
                                dt.Columns.Add("P" + (i + 1), System.Type.GetType("System.String"));
                                dt.Rows[0][i] = pointDingWeiStrs[i];
                            }
                            DataSet ds2 = new DataSet();
                            ds2.Tables.Add(dt);
                            //sda.Fill(ds2);
                            dataAdressView1.DataSource = ds2.Tables[0];
                            dataAdressView1.ReadOnly = true;
                            string machineId = RexvData.Text;
                            string newAdrsssPints = adressPoints.TrimEnd(',');
                            int n = adressPoints.Split(',').Length / 2;
                            string pointNumber = n > 10 ? n.ToString() : "0" + n;
                            String sqlHandMes = "select id from machines where machineId='" + RexvData.Text + "';";
                            MySqlDataReader msdrHand=DataBaseSys.GetDataReaderValue(sqlHandMes);
                            if (msdrHand.HasRows)
                            {
                                MessageBoxButtons ButtonHandAdress = MessageBoxButtons.OKCancel;
                                DialogResult drHand = MessageBox.Show("定位成功，存在相关的机种其坐标不一致，需要修改吗？", "提示", ButtonHandAdress);
                                if (drHand == DialogResult.OK) {
                                    if (!vip) MessageBox.Show("您没有管理员权限无法修改！");
                                    else
                                    {
                                        string sql = "update machines set childNumber='" + pointNumber + "' ,adressNumber='" + newAdrsssPints + "' where machineId= '" + RexvData.Text + "'";
                                        DataBaseSys.ExecuteNonQuery(sql);
                                        MessageBox.Show("修改成功！");
                                    }                                                              }
                            }
                            else
                            {                         
                            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                            DialogResult dr = MessageBox.Show("定位成功，无相关的机种，确定添加吗?", "提示", messButton);
                            if (dr == DialogResult.OK)//如果点击“确定”按钮
                            {
                                string addSql = "insert into machines(machineId,childNumber,adressNumber) values('" + machineId + "','" + pointNumber + "','" + newAdrsssPints + "')";
                                DataBaseSys.ExecuteNonQuery(addSql);
                                MessageBox.Show("添加成功！");
                                }                                
                            }
                            adressPoints = "";
                            MessageBoxButtons messButtonAdd = MessageBoxButtons.OKCancel;
                            DialogResult dr2 = MessageBox.Show("需要继续手动添加新机种吗？", "提示", messButtonAdd);
                            if (dr2 == DialogResult.OK)
                            {
                                insertButton.Enabled = false;
                                radioHand_MouseClick(null, null);                              
                            }
                            else radioAuto.Checked = true;
                        }
                    }
                }
                //自动状态下
                else
                {
                    b++;
                    if (rb[3] == 0X00)//纠错成功恢复00（05）
                    {
                        childNumList.Remove("0" + rb[2]);
                        b = b - 1;                    
                        if (childNumList.Count==0)
                        {
                            MessageBox.Show("STOP");
                            for (int k = 0; k < dataAdressView1.ColumnCount; k++)
                            {
                                dataAdressView1.Rows[0].Cells[k].Style.ForeColor = Color.Black;                                                                                              
                            }
                            lightSet.ForeColor = Color.Green;
                            timer1.Enabled = false;
                            timer1.Stop();
                            childNumList.Clear();
                            return;
                        }                                                 
                        }
                    else//有错误子板回复带坐标的（05)
                    {
                        string[] pointNums = Regex.Replace(dataBasePoints, @"(\w{4})", "$1,").Trim(',').Split(',');//把数据库查的坐标以一组4位以逗号分隔
                        string xYPoints = childToPcPointChange(rb);
                        autoAdressPoints += xYPoints;
                        string[] autoPoints= Regex.Replace(autoAdressPoints.Replace(",",""), @"(\w{4})", "$1,").Trim(',').Split(',');//把下位机传来查的坐标以一组4位以逗号分隔                                  
                        for (int i = 0; i < pointNums.Length; i++)
                        {
                            for (int j = 0; j < autoPoints.Length; j++)
                            {
                                if (pointNums[i] == autoPoints[j])
                                {
                                    sameMesList.Add(autoPoints[j]);
                                    break ;
                                }
                            }
                        }
                        /*去重
                        for (int i = 0; i < sameMesList.Count - 1; i++)
                        {
                            for (int j = i + 1; j < sameMesList.Count; j++)
                            {
                                if (sameMesList[i].Equals(sameMesList[j]))
                                {
                                    sameMesList.RemoveAt(j);
                                    j--;
                                }
                            }
                        }*/
                    }
                    if (b == childNumList.Count)
                    {
                        string s = "";
                        foreach (var item in sameMesList)
                        {
                            s+= item.ToString()+",";
                        }
                        MessageBox.Show("进入改颜色,相同的部分有"+s);
                        for (int k = 0; k < dataAdressView1.ColumnCount; k++)
                        {
                            //string strData = dataAdressView1[j, 0].Value.ToString();
                            for (int j = 0; j < sameMesList.Count; j++)
                            {
                                if (dataAdressView1.Rows[0].Cells[k].Value.ToString() == sameMesList[j].ToString())
                                {
                                    dataAdressView1.Rows[0].Cells[k].Style.ForeColor = Color.Red;
                                    lightSet.ForeColor = Color.Red;
                                    break;
                                }
                                else dataAdressView1.Rows[0].Cells[k].Style.ForeColor = Color.Black;
                            }
                        }
                        autoAdressPoints = "";
                        sameMesList.Clear();
                        b = 0;
                    }
                }
                sp2.DiscardInBuffer();
            }));
        }  
         
        public static byte[] hexToString(string s)
        {
            byte[] btr = new byte[s.Length / 2];
            for (int i = 0; i < btr.Length; i++)
            {
                int temp = Convert.ToInt32(s.Substring(i * 2, 2), 16);
                btr[i] = (byte)temp;
            }
            return btr;
        }
        private void insertButton_Click(object sender, EventArgs e)
        {       
            if (RexvData.Text == "")
            {
                MessageBox.Show("机种号不能为空！请输入机种号");
            }
            else
            {
                for (int i = 0; i < strs.Length; i++) //strs共享的板子数据编号
                {
                    System.Threading.Thread.Sleep(2000);
                    PortOrder po = new PortOrder(Direction.AB, "03","0"+strs[i],"","");
                byte[] bt = hexToString(po.getConnOrder());
                sp2.Write(bt, 0, bt.Length);
                }
            }
        }

        private void radioHand_MouseClick(object sender, MouseEventArgs e)
        {
            strs = "";
            childRandnum = "";
            timer1.Stop();
            timer1.Enabled = false;
            lightSet.ForeColor = Color.Black;
                for (int i = 1; i < 9; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    PortOrder po = new PortOrder(Direction.AB, "04", "0" + i, "", "");
                    byte[] bt = hexToString(po.getConnOrder());
                    sp2.Write(bt, 0, bt.Length);
                }
            RexvData.ReadOnly = false;
            insertButton.Enabled = true;
        }
        private void radioAuto_MouseClick(object sender, MouseEventArgs e)
        {
            insertButton.Enabled = false;
            timer1.Stop();
            timer1.Enabled=false;
            strs = "";
            RexvData.ReadOnly = true;
            RexvData.Text = "";
          //  buttonUpdate.Enabled = false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ManagerSystem mana = new ManagerSystem();
            mana.ShowDialog();
        }
    }
    }


