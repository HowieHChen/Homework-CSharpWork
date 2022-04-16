namespace Homework7
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
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.textBox_Done = new System.Windows.Forms.TextBox();
            this.textBox_Error = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.button_Check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_URL
            // 
            this.textBox_URL.Location = new System.Drawing.Point(12, 12);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(444, 21);
            this.textBox_URL.TabIndex = 0;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(12, 39);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(444, 40);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "开始爬取";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(71, 85);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(717, 187);
            this.textBox_Log.TabIndex = 2;
            // 
            // textBox_Done
            // 
            this.textBox_Done.Location = new System.Drawing.Point(71, 278);
            this.textBox_Done.Multiline = true;
            this.textBox_Done.Name = "textBox_Done";
            this.textBox_Done.ReadOnly = true;
            this.textBox_Done.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Done.Size = new System.Drawing.Size(717, 160);
            this.textBox_Done.TabIndex = 3;
            // 
            // textBox_Error
            // 
            this.textBox_Error.Location = new System.Drawing.Point(71, 444);
            this.textBox_Error.Multiline = true;
            this.textBox_Error.Name = "textBox_Error";
            this.textBox_Error.ReadOnly = true;
            this.textBox_Error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Error.Size = new System.Drawing.Size(717, 160);
            this.textBox_Error.TabIndex = 4;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(462, 12);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(326, 21);
            this.textBox_ID.TabIndex = 5;
            // 
            // button_Check
            // 
            this.button_Check.Location = new System.Drawing.Point(462, 39);
            this.button_Check.Name = "button_Check";
            this.button_Check.Size = new System.Drawing.Size(326, 40);
            this.button_Check.TabIndex = 6;
            this.button_Check.Text = "检查身份证号有效性";
            this.button_Check.UseVisualStyleBackColor = true;
            this.button_Check.Click += new System.EventHandler(this.button_Check_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "已经爬取";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "已被过滤";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "日志输出";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Check);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_Error);
            this.Controls.Add(this.textBox_Done);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_URL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.TextBox textBox_Done;
        private System.Windows.Forms.TextBox textBox_Error;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Button button_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

