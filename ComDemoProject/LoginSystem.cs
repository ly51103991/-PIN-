using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using DataConn;
using ComDemoProject;

namespace ComDemoProject
{
    public partial class LoginSystem : Form
    {      
        public LoginSystem()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {        
                if (password.Text != "")
                {
                    string sql = "select * from users where password='"+password.Text+"';";
                    MySqlDataReader reader= DataBaseSys.GetDataReaderValue(sql);
                    
                    //string[] array = new string[4];
                    if (!reader.Read())
                    {
                        MessageBox.Show("密码错误！");
                    }
                    else
                    {
                        this.Close();
                    ManagerSystem um = new ManagerSystem();
                    MessageBox.Show("双击需要修改的坐标区域即可修改其中坐标地址！");
                    um.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("密码不能为空！", "错误提示");
                }
          
        }
    }
}
