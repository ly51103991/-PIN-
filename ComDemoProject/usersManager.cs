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

namespace ComDemoProject
{
    public partial class usersManager : Form
    {
        Form1 form = new Form1();
        public usersManager()
        {
            InitializeComponent();
        }

        public usersManager(String id, String name, String pwd,bool isUpdata)
        {
            InitializeComponent();
            addUserName.Text = name;
            addUserPw.Text  = pwd;
            isUp .Text= isUpdata? "修改用户":"0";
            addUserName.ReadOnly = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (addUserName.Text != "" && addUserPw.Text != "")
            {
                if (isUp.Text != "修改用户")
                { 
                string sql = "insert into users(userName,password) values('" + addUserName.Text + "','" + addUserPw.Text+"');";
                DataBaseSys.ExecuteNonQuery(sql);
                MessageBox.Show("添加成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
                }
                else
                {
                    isUp.Text = "修改会员密码";
                    string sql = "update users set `password`='" + addUserPw.Text +  "'where userName='" + addUserName.Text + "'";
                    DataBaseSys.ExecuteNonQuery(sql);
                    MessageBox.Show("修改成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("用户名和密码不能为空！");
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
