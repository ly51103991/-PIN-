namespace ComDemoProject
{
    partial class ManagerSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.userMes = new System.Windows.Forms.TabPage();
            this.buttonDele = new System.Windows.Forms.Button();
            this.userDataView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdata = new System.Windows.Forms.Button();
            this.adressMes = new System.Windows.Forms.TabPage();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.buttonDelAdress = new System.Windows.Forms.Button();
            this.buttonSerach = new System.Windows.Forms.Button();
            this.adressDataView = new System.Windows.Forms.DataGridView();
            this.buttonGet = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.userMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataView)).BeginInit();
            this.adressMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adressDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(221, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "后台管理系统";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.userMes);
            this.tabControl1.Controls.Add(this.adressMes);
            this.tabControl1.Location = new System.Drawing.Point(12, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 308);
            this.tabControl1.TabIndex = 1;
            // 
            // userMes
            // 
            this.userMes.Controls.Add(this.buttonDele);
            this.userMes.Controls.Add(this.userDataView);
            this.userMes.Controls.Add(this.buttonAdd);
            this.userMes.Controls.Add(this.buttonUpdata);
            this.userMes.Location = new System.Drawing.Point(4, 22);
            this.userMes.Name = "userMes";
            this.userMes.Padding = new System.Windows.Forms.Padding(3);
            this.userMes.Size = new System.Drawing.Size(549, 282);
            this.userMes.TabIndex = 0;
            this.userMes.Text = "用户信息";
            this.userMes.UseVisualStyleBackColor = true;
            // 
            // buttonDele
            // 
            this.buttonDele.Location = new System.Drawing.Point(359, 242);
            this.buttonDele.Name = "buttonDele";
            this.buttonDele.Size = new System.Drawing.Size(75, 23);
            this.buttonDele.TabIndex = 4;
            this.buttonDele.Text = "删除";
            this.buttonDele.UseVisualStyleBackColor = true;
            this.buttonDele.Click += new System.EventHandler(this.buttonDele_Click);
            // 
            // userDataView
            // 
            this.userDataView.AllowUserToAddRows = false;
            this.userDataView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataView.Location = new System.Drawing.Point(3, 3);
            this.userDataView.MultiSelect = false;
            this.userDataView.Name = "userDataView";
            this.userDataView.RowTemplate.Height = 23;
            this.userDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userDataView.Size = new System.Drawing.Size(446, 228);
            this.userDataView.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(21, 242);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdata
            // 
            this.buttonUpdata.Location = new System.Drawing.Point(182, 242);
            this.buttonUpdata.Name = "buttonUpdata";
            this.buttonUpdata.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdata.TabIndex = 5;
            this.buttonUpdata.Text = "修改";
            this.buttonUpdata.UseVisualStyleBackColor = true;
            this.buttonUpdata.Click += new System.EventHandler(this.buttonUpdata_Click);
            // 
            // adressMes
            // 
            this.adressMes.AutoScroll = true;
            this.adressMes.Controls.Add(this.textMessage);
            this.adressMes.Controls.Add(this.buttonDelAdress);
            this.adressMes.Controls.Add(this.buttonSerach);
            this.adressMes.Controls.Add(this.adressDataView);
            this.adressMes.Controls.Add(this.buttonGet);
            this.adressMes.Controls.Add(this.textSearch);
            this.adressMes.Location = new System.Drawing.Point(4, 22);
            this.adressMes.Name = "adressMes";
            this.adressMes.Padding = new System.Windows.Forms.Padding(3);
            this.adressMes.Size = new System.Drawing.Size(549, 282);
            this.adressMes.TabIndex = 1;
            this.adressMes.Text = "坐标信息";
            this.adressMes.UseVisualStyleBackColor = true;
            // 
            // textMessage
            // 
            this.textMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMessage.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textMessage.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textMessage.Location = new System.Drawing.Point(45, 226);
            this.textMessage.MaxLength = 5;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(79, 19);
            this.textMessage.TabIndex = 7;
            this.textMessage.Text = "机种号前1~5位";
            this.textMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textMessage_MouseClick);
            // 
            // buttonDelAdress
            // 
            this.buttonDelAdress.Location = new System.Drawing.Point(414, 226);
            this.buttonDelAdress.Name = "buttonDelAdress";
            this.buttonDelAdress.Size = new System.Drawing.Size(75, 23);
            this.buttonDelAdress.TabIndex = 6;
            this.buttonDelAdress.Text = "删除";
            this.buttonDelAdress.UseVisualStyleBackColor = true;
            this.buttonDelAdress.Click += new System.EventHandler(this.buttonDelAdress_Click);
            // 
            // buttonSerach
            // 
            this.buttonSerach.Location = new System.Drawing.Point(130, 224);
            this.buttonSerach.Name = "buttonSerach";
            this.buttonSerach.Size = new System.Drawing.Size(75, 23);
            this.buttonSerach.TabIndex = 3;
            this.buttonSerach.Text = "查询";
            this.buttonSerach.UseVisualStyleBackColor = true;
            this.buttonSerach.Click += new System.EventHandler(this.buttonSerach_Click);
            // 
            // adressDataView
            // 
            this.adressDataView.AllowUserToAddRows = false;
            this.adressDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adressDataView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adressDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adressDataView.Location = new System.Drawing.Point(3, 0);
            this.adressDataView.MultiSelect = false;
            this.adressDataView.Name = "adressDataView";
            this.adressDataView.RowTemplate.Height = 23;
            this.adressDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.adressDataView.Size = new System.Drawing.Size(545, 207);
            this.adressDataView.TabIndex = 0;
            this.adressDataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adressDataView_CellDoubleClick);
            this.adressDataView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.adressDataView_CellValidated);
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(118, 155);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(75, 23);
            this.buttonGet.TabIndex = 1;
            this.buttonGet.Text = "查询";
            this.buttonGet.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(29, 157);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(83, 21);
            this.textSearch.TabIndex = 2;
            // 
            // ManagerSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(613, 464);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "ManagerSystem";
            this.Text = "ManagerSystem";
            this.Load += new System.EventHandler(this.ManagerSystem_Load);
            this.tabControl1.ResumeLayout(false);
            this.userMes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDataView)).EndInit();
            this.adressMes.ResumeLayout(false);
            this.adressMes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adressDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage userMes;
        private System.Windows.Forms.DataGridView userDataView;
        private System.Windows.Forms.TabPage adressMes;
        private System.Windows.Forms.DataGridView adressDataView;
        private System.Windows.Forms.Button buttonDele;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Button buttonUpdata;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button buttonDelAdress;
        private System.Windows.Forms.Button buttonSerach;
    }
}