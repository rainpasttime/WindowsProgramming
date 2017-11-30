namespace WindowsFormsApplication1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.EasyButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.DifficultButton = new System.Windows.Forms.Button();
            this.NormalButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // EasyButton
            // 
            this.EasyButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.EasyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EasyButton.Font = new System.Drawing.Font("Verdana", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EasyButton.Location = new System.Drawing.Point(1, 1);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(146, 148);
            this.EasyButton.TabIndex = 3;
            this.EasyButton.Text = "E";
            this.EasyButton.UseVisualStyleBackColor = false;
            this.EasyButton.Click += new System.EventHandler(this.EasyButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HelpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpButton.Font = new System.Drawing.Font("Verdana", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.Location = new System.Drawing.Point(145, 147);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(146, 148);
            this.HelpButton.TabIndex = 4;
            this.HelpButton.Text = "H";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // DifficultButton
            // 
            this.DifficultButton.BackColor = System.Drawing.Color.DarkMagenta;
            this.DifficultButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DifficultButton.Font = new System.Drawing.Font("Verdana", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultButton.ForeColor = System.Drawing.Color.Gold;
            this.DifficultButton.Location = new System.Drawing.Point(1, 146);
            this.DifficultButton.Name = "DifficultButton";
            this.DifficultButton.Size = new System.Drawing.Size(146, 150);
            this.DifficultButton.TabIndex = 6;
            this.DifficultButton.Text = "D";
            this.DifficultButton.UseVisualStyleBackColor = false;
            this.DifficultButton.Click += new System.EventHandler(this.DifficultButton_Click);
            // 
            // NormalButton
            // 
            this.NormalButton.BackColor = System.Drawing.Color.SeaGreen;
            this.NormalButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NormalButton.Font = new System.Drawing.Font("Verdana", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.NormalButton.Location = new System.Drawing.Point(145, 1);
            this.NormalButton.Name = "NormalButton";
            this.NormalButton.Size = new System.Drawing.Size(146, 148);
            this.NormalButton.TabIndex = 5;
            this.NormalButton.Text = "N";
            this.NormalButton.UseVisualStyleBackColor = false;
            this.NormalButton.Click += new System.EventHandler(this.NormalButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Location = new System.Drawing.Point(191, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "(normal)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Turquoise;
            this.label3.Location = new System.Drawing.Point(48, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "(easy)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MediumOrchid;
            this.label4.Location = new System.Drawing.Point(34, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "(difficult)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Location = new System.Drawing.Point(192, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "(help)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DifficultButton);
            this.Controls.Add(this.NormalButton);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.EasyButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "8.自选";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EasyButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button DifficultButton;
        private System.Windows.Forms.Button NormalButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

    }
}

