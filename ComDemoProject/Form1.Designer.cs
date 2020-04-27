namespace ComDemoProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.radioAuto = new System.Windows.Forms.RadioButton();
            this.radioHand = new System.Windows.Forms.RadioButton();
            this.lightSet = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataAdressView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.RexvData = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdressView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(72, 147);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(67, 30);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "修改";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Visible = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // insertButton
            // 
            this.insertButton.Enabled = false;
            this.insertButton.Location = new System.Drawing.Point(200, 147);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(67, 30);
            this.insertButton.TabIndex = 19;
            this.insertButton.Text = "添加";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // radioAuto
            // 
            this.radioAuto.AutoSize = true;
            this.radioAuto.Location = new System.Drawing.Point(72, 85);
            this.radioAuto.Name = "radioAuto";
            this.radioAuto.Size = new System.Drawing.Size(47, 16);
            this.radioAuto.TabIndex = 18;
            this.radioAuto.TabStop = true;
            this.radioAuto.Text = "自动";
            this.radioAuto.UseVisualStyleBackColor = true;
            this.radioAuto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioAuto_MouseClick);
            // 
            // radioHand
            // 
            this.radioHand.AutoSize = true;
            this.radioHand.Location = new System.Drawing.Point(142, 85);
            this.radioHand.Name = "radioHand";
            this.radioHand.Size = new System.Drawing.Size(47, 16);
            this.radioHand.TabIndex = 17;
            this.radioHand.TabStop = true;
            this.radioHand.Text = "手动";
            this.radioHand.UseVisualStyleBackColor = true;
            this.radioHand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioHand_MouseClick);
            // 
            // lightSet
            // 
            this.lightSet.Font = new System.Drawing.Font("宋体", 200F);
            this.lightSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lightSet.Location = new System.Drawing.Point(50, -118);
            this.lightSet.Name = "lightSet";
            this.lightSet.Size = new System.Drawing.Size(486, 405);
            this.lightSet.TabIndex = 23;
            this.lightSet.Text = ".";
            this.lightSet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataAdressView1);
            this.groupBox5.Location = new System.Drawing.Point(29, 230);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 110);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "坐标区";
            // 
            // dataAdressView1
            // 
            this.dataAdressView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAdressView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataAdressView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdressView1.Location = new System.Drawing.Point(6, 17);
            this.dataAdressView1.Name = "dataAdressView1";
            this.dataAdressView1.RowTemplate.Height = 23;
            this.dataAdressView1.Size = new System.Drawing.Size(291, 87);
            this.dataAdressView1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "机种号:";
            // 
            // RexvData
            // 
            this.RexvData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RexvData.Location = new System.Drawing.Point(124, 20);
            this.RexvData.Name = "RexvData";
            this.RexvData.ReadOnly = true;
            this.RexvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RexvData.Size = new System.Drawing.Size(143, 21);
            this.RexvData.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(353, 382);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioHand);
            this.Controls.Add(this.radioAuto);
            this.Controls.Add(this.RexvData);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lightSet);
            this.Name = "Form1";
            this.Text = "智能插PIN指示";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAdressView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.RadioButton radioAuto;
        private System.Windows.Forms.RadioButton radioHand;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataAdressView1;
        private System.Windows.Forms.Label lightSet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RexvData;
    }
}

