namespace ComDemoProject
{
    partial class usersManager
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
            this.addUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addUserPw = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.isUp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // addUserName
            // 
            this.addUserName.Location = new System.Drawing.Point(131, 56);
            this.addUserName.Name = "addUserName";
            this.addUserName.Size = new System.Drawing.Size(100, 21);
            this.addUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // addUserPw
            // 
            this.addUserPw.Location = new System.Drawing.Point(131, 103);
            this.addUserPw.Name = "addUserPw";
            this.addUserPw.Size = new System.Drawing.Size(100, 21);
            this.addUserPw.TabIndex = 3;
            this.addUserPw.UseSystemPasswordChar = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(37, 159);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(156, 159);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 7;
            this.buttonCancle.Text = "取消";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // isUp
            // 
            this.isUp.AutoSize = true;
            this.isUp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isUp.Location = new System.Drawing.Point(99, 20);
            this.isUp.Name = "isUp";
            this.isUp.Size = new System.Drawing.Size(89, 19);
            this.isUp.TabIndex = 8;
            this.isUp.Text = "新增会员";
            // 
            // usersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.isUp);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.addUserPw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addUserName);
            this.Controls.Add(this.label1);
            this.Name = "usersManager";
            this.Text = "usersManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addUserPw;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Label isUp;
    }
}