using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DataConn;
using System.Text.RegularExpressions;

namespace ComDemoProject
{
    public partial class ManagerSystem : Form
    {
        Form1 form = new Form1();
        public ManagerSystem()
        {
            InitializeComponent();
        }

        private void ManagerSystem_Load(object sender, EventArgs e)
        {          
            this.tabControl1.SelectedIndex = 1;
            string getUsers = "select * from users";
            string getMachines = "select * from machines";

            //显示管理员信息
            DataSet dsUser =DataBaseSys.GetDataSetValue(getUsers,"Tables");
            userDataView.DataSource = dsUser.Tables[0];
            userDataView.Columns[0].HeaderText = "编号";
            userDataView.Columns[1].HeaderText = "管理员";
            userDataView.Columns[2].HeaderText = "密码";
            userDataView.ReadOnly = true;
            //显示机种信息
            DataSet dsMac = DataBaseSys.GetDataSetValue(getMachines, "Tables");
            dsMac.Tables[0].Columns[3].ReadOnly = false;
            adressDataView.DataSource = dsMac.Tables[0];
            adressDataView.Columns[0].HeaderText = "编号";
            adressDataView.Columns[1].HeaderText = "机种号";
            adressDataView.Columns[2].HeaderText = "点数";
            adressDataView.Columns[3].HeaderText = "坐标";
            adressDataView.ReadOnly = true;
        }
        string myPoint = "";//选中行坐标值
        bool b = false;//是否双击       
        //双击可编辑
        private void adressDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int colunm = adressDataView.CurrentCell.ColumnIndex;
            if (colunm != 3)
            {
                MessageBox.Show("只允许修改坐标！");return;
            }
            myPoint = "";
            if (adressDataView.Rows.Count > 0)
            {        
                myPoint = adressDataView.CurrentRow.Cells[3].Value.ToString();
                 adressDataView.ReadOnly = false;
                adressDataView.CurrentRow.Cells[3].ReadOnly = false;
                adressDataView.BeginEdit(true);
                b = true;
            }
        }
        public static bool IsInt(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool getTopUnder(string[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                int a = Int32.Parse(value[i]);
                if (i % 2 == 0)
                {
                    if ( a> 75||a<1) return false;

                }else { 
                if (a > 100||a<1) return false;
                }
            }
            return true;
        }
        private void adressDataView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (b == true)
                {
                    b = false;
                    adressDataView.ReadOnly = true;
                    if (adressDataView.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(adressDataView.CurrentRow.Cells[0].Value.ToString());
                        string adressPoint = adressDataView.CurrentRow.Cells[3].Value.ToString();
                        if (myPoint != adressPoint)
                        {
                            if (adressPoint.Equals(""))
                            {
                                MessageBox.Show("坐标不能为空！");
                                adressDataView.CurrentRow.Cells[3].Value = myPoint;
                                return;
                            }
                            string[] styleSet = adressPoint.Split(',');
                            bool b = true;//标记是否为数字
                            bool isSame = true;
                            string isSamePoint = "";
                            for (int i = 0; i < styleSet.Length; i++)
                            {
                                if (styleSet[i].Length < 2) styleSet[i] = "0" + styleSet[i];
                                b = IsInt(styleSet[i]);
                            }
                            string newPoints = string.Join(",", styleSet);
                            if (styleSet.Length % 2 == 1 || !b) { MessageBox.Show("坐标及格式不正确！请重新填写！"); adressDataView.CurrentRow.Cells[3].Value = myPoint; return; }
                            else
                            {
                                if (getTopUnder(styleSet))
                                {
                                    for (int i = 0; i < styleSet.Length; i++)
                                    {
                                        isSamePoint += styleSet[i];
                                    }
                                    string[] isSamePoints = Regex.Replace(isSamePoint.Replace(",", ""), @"(\w{4})", "$1,").Trim(',').Split(',');
                                    HashSet<string> hashSet = new HashSet<string>();
                                    for (int i = 0; i < isSamePoints.Length; i++)
                                    {
                                        hashSet.Add(isSamePoints[i]);
                                        MessageBox.Show(hashSet.Count+"--"+isSamePoints.Length);
                                    }
                                    if (hashSet.Count != isSamePoints.Length) isSame = false;
                                    if (isSame) {
                                    string pointNum = (styleSet.Length / 2) < 10 ? "0" + (styleSet.Length / 2) : (styleSet.Length / 2).ToString();
                                    //更新语句
                                    string sql = "update machines set childNumber='" + pointNum + "' ,adressNumber='" + newPoints + "' where id= '" + id + "'";
                                    MessageBox.Show(sql);
                                    DataBaseSys.ExecuteNonQuery(sql);
                                    adressDataView.CurrentRow.Cells[2].Value = pointNum;
                                    adressDataView.CurrentRow.Cells[3].Value = newPoints;
                                    adressDataView.CurrentRow.Cells[3].ReadOnly = true;
                                    MessageBox.Show("修改成功！");
                                    }
                                    else
                                    {                                        
                                        adressDataView.CurrentRow.Cells[3].Value = myPoint;
                                        isSame = true;
                                        MessageBox.Show("请您修改坐标，不能存在2组或多组一样坐标点！");
                                    }
                                }
                                else
                                {
                                   adressDataView.CurrentRow.Cells[3].Value = myPoint;
                                    isSame = true;
                                    MessageBox.Show("坐标过大或不能为0或负数！");

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败！只支持修改坐标");
                adressDataView.CurrentRow.Cells[3].Value = myPoint;
                return;
            }
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
          //  string sql = "select * from users where user";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            usersManager um = new usersManager();
          DialogResult dr=um.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ManagerSystem_Load(null, null);
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void buttonDele_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定删除该用户吗？", "提示", msb);
            if (dr == DialogResult.OK) { 
            int id = int.Parse(userDataView.SelectedRows[0].Cells[0].Value.ToString());               
            string sql = "delete from users where id='"+id+"';";
                DataBaseSys.ExecuteNonQuery(sql);
                    MessageBox.Show("删除成功！");               
                    ManagerSystem_Load(null, null);
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void buttonUpdata_Click(object sender, EventArgs e)
        {
            string id = userDataView.SelectedRows[0].Cells[0].Value.ToString();
            string uName = userDataView.SelectedRows[0].Cells[1].Value.ToString();
            string uPd = userDataView.SelectedRows[0].Cells[2].Value.ToString();
            bool isUpdata = true;
            usersManager um = new usersManager(id,uName,uPd,isUpdata);
            DialogResult dr = um.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ManagerSystem_Load(null, null);
            }
        }

        private void buttonDelAdress_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "提示", messButton);
                if (dr == DialogResult.OK) { 
            int a= adressDataView.CurrentRow.Index;
            string id= adressDataView.Rows[a].Cells[0].Value.ToString();
            string sql = "delete from machines where id='"+id+"'";
            DataBaseSys.ExecuteNonQuery(sql);
            adressDataView.Rows.Remove(adressDataView.CurrentRow);
            MessageBox.Show("删除成功！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("出现异常，删除失败！");;
            }
        }

        private void textMessage_MouseClick(object sender, MouseEventArgs e)
        {
            textMessage.Text = "";
            textMessage.ForeColor = Color.Black;
        }

        private void buttonSerach_Click(object sender, EventArgs e)
        {
            string machineGet = textMessage.Text;
            string sql = "select * from machines where machineId like'"+ machineGet+"%'";
            DataSet dsMoHu = DataBaseSys.GetDataSetValue(sql, "Tables");
            adressDataView.DataSource = dsMoHu.Tables[0];
            if (adressDataView.Rows.Count == 0)
            {
                MessageBox.Show("无相似机种！");
            }
            if (machineGet == "")
            {
                ManagerSystem_Load(null, null);
            }
        }
    }
}
