namespace VaultApp.VisualLifecycleStatus.Controls
{
    partial class LCDShowControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_mainPictureBox = new System.Windows.Forms.PictureBox();
            this.m_topPanel = new System.Windows.Forms.Panel();
            this.m_despTextBox = new System.Windows.Forms.TextBox();
            this.m_nameLabel = new System.Windows.Forms.Label();
            this.m_mainPanel = new System.Windows.Forms.Panel();
            this.m_rightPanel = new System.Windows.Forms.Panel();
            this.m_splitter = new System.Windows.Forms.Splitter();
            this.m_leftPanel = new System.Windows.Forms.Panel();
            this.m_leftDownPanel = new System.Windows.Forms.Panel();
            this.m_transInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_leftUpPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_mainPictureBox)).BeginInit();
            this.m_topPanel.SuspendLayout();
            this.m_mainPanel.SuspendLayout();
            this.m_rightPanel.SuspendLayout();
            this.m_leftPanel.SuspendLayout();
            this.m_leftDownPanel.SuspendLayout();
            this.m_leftUpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_mainPictureBox
            // 
            this.m_mainPictureBox.BackColor = System.Drawing.Color.White;
            this.m_mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.m_mainPictureBox.Name = "m_mainPictureBox";
            this.m_mainPictureBox.Size = new System.Drawing.Size(696, 468);
            this.m_mainPictureBox.TabIndex = 0;
            this.m_mainPictureBox.TabStop = false;
            this.m_mainPictureBox.SizeChanged += new System.EventHandler(this.m_mainPictureBox_SizeChanged);
            this.m_mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.m_mainPictureBox_Paint);
            this.m_mainPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_mainPictureBox_MouseDoubleClick);
            this.m_mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_mainPictureBox_MouseMove);
            // 
            // m_topPanel
            // 
            this.m_topPanel.BackColor = System.Drawing.Color.White;
            this.m_topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_topPanel.Controls.Add(this.m_despTextBox);
            this.m_topPanel.Controls.Add(this.m_nameLabel);
            this.m_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_topPanel.Location = new System.Drawing.Point(0, 0);
            this.m_topPanel.Name = "m_topPanel";
            this.m_topPanel.Size = new System.Drawing.Size(947, 60);
            this.m_topPanel.TabIndex = 1;
            // 
            // m_despTextBox
            // 
            this.m_despTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_despTextBox.BackColor = System.Drawing.Color.White;
            this.m_despTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_despTextBox.Location = new System.Drawing.Point(6, 20);
            this.m_despTextBox.Multiline = true;
            this.m_despTextBox.Name = "m_despTextBox";
            this.m_despTextBox.ReadOnly = true;
            this.m_despTextBox.Size = new System.Drawing.Size(936, 35);
            this.m_despTextBox.TabIndex = 1;
            // 
            // m_nameLabel
            // 
            this.m_nameLabel.AutoSize = true;
            this.m_nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_nameLabel.Location = new System.Drawing.Point(6, 1);
            this.m_nameLabel.Name = "m_nameLabel";
            this.m_nameLabel.Size = new System.Drawing.Size(53, 16);
            this.m_nameLabel.TabIndex = 0;
            this.m_nameLabel.Text = "Name:";
            this.m_nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_mainPanel
            // 
            this.m_mainPanel.AutoScroll = true;
            this.m_mainPanel.AutoSize = true;
            this.m_mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_mainPanel.Controls.Add(this.m_rightPanel);
            this.m_mainPanel.Controls.Add(this.m_splitter);
            this.m_mainPanel.Controls.Add(this.m_leftPanel);
            this.m_mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mainPanel.Location = new System.Drawing.Point(0, 60);
            this.m_mainPanel.Name = "m_mainPanel";
            this.m_mainPanel.Size = new System.Drawing.Size(947, 472);
            this.m_mainPanel.TabIndex = 2;
            // 
            // m_rightPanel
            // 
            this.m_rightPanel.AutoScroll = true;
            this.m_rightPanel.AutoScrollMinSize = new System.Drawing.Size(500, 300);
            this.m_rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_rightPanel.Controls.Add(this.m_mainPictureBox);
            this.m_rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_rightPanel.Location = new System.Drawing.Point(247, 0);
            this.m_rightPanel.Name = "m_rightPanel";
            this.m_rightPanel.Size = new System.Drawing.Size(698, 470);
            this.m_rightPanel.TabIndex = 3;
            // 
            // m_splitter
            // 
            this.m_splitter.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.m_splitter.Location = new System.Drawing.Point(242, 0);
            this.m_splitter.Name = "m_splitter";
            this.m_splitter.Size = new System.Drawing.Size(5, 470);
            this.m_splitter.TabIndex = 2;
            this.m_splitter.TabStop = false;
            this.m_splitter.DoubleClick += new System.EventHandler(this.m_splitter_DoubleClick);
            // 
            // m_leftPanel
            // 
            this.m_leftPanel.BackColor = System.Drawing.Color.White;
            this.m_leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_leftPanel.Controls.Add(this.m_leftDownPanel);
            this.m_leftPanel.Controls.Add(this.m_leftUpPanel);
            this.m_leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_leftPanel.Location = new System.Drawing.Point(0, 0);
            this.m_leftPanel.Name = "m_leftPanel";
            this.m_leftPanel.Size = new System.Drawing.Size(242, 470);
            this.m_leftPanel.TabIndex = 1;
            this.m_leftPanel.Resize += new System.EventHandler(this.m_leftPanel_Resize);
            // 
            // m_leftDownPanel
            // 
            this.m_leftDownPanel.Controls.Add(this.m_transInfoRichTextBox);
            this.m_leftDownPanel.Controls.Add(this.label6);
            this.m_leftDownPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_leftDownPanel.Location = new System.Drawing.Point(0, 0);
            this.m_leftDownPanel.Name = "m_leftDownPanel";
            this.m_leftDownPanel.Size = new System.Drawing.Size(240, 339);
            this.m_leftDownPanel.TabIndex = 1;
            // 
            // m_transInfoRichTextBox
            // 
            this.m_transInfoRichTextBox.BackColor = System.Drawing.Color.White;
            this.m_transInfoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_transInfoRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_transInfoRichTextBox.Location = new System.Drawing.Point(0, 19);
            this.m_transInfoRichTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.m_transInfoRichTextBox.Name = "m_transInfoRichTextBox";
            this.m_transInfoRichTextBox.ReadOnly = true;
            this.m_transInfoRichTextBox.Size = new System.Drawing.Size(240, 320);
            this.m_transInfoRichTextBox.TabIndex = 0;
            this.m_transInfoRichTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Description:";
            // 
            // m_leftUpPanel
            // 
            this.m_leftUpPanel.BackColor = System.Drawing.Color.LightGray;
            this.m_leftUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_leftUpPanel.Controls.Add(this.label5);
            this.m_leftUpPanel.Controls.Add(this.label4);
            this.m_leftUpPanel.Controls.Add(this.label3);
            this.m_leftUpPanel.Controls.Add(this.label2);
            this.m_leftUpPanel.Controls.Add(this.label1);
            this.m_leftUpPanel.Controls.Add(this.textBox2);
            this.m_leftUpPanel.Controls.Add(this.textBox3);
            this.m_leftUpPanel.Controls.Add(this.textBox4);
            this.m_leftUpPanel.Controls.Add(this.textBox1);
            this.m_leftUpPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_leftUpPanel.Location = new System.Drawing.Point(0, 339);
            this.m_leftUpPanel.Name = "m_leftUpPanel";
            this.m_leftUpPanel.Size = new System.Drawing.Size(240, 129);
            this.m_leftUpPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Unallow Transaction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Allow Transaction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Normal State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Symbols:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(4, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightGray;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(4, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(20, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Blue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(4, 51);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(20, 20);
            this.textBox4.TabIndex = 0;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gold;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(4, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LCDShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.m_mainPanel);
            this.Controls.Add(this.m_topPanel);
            this.Name = "LCDShowControl";
            this.Size = new System.Drawing.Size(947, 532);
            ((System.ComponentModel.ISupportInitialize)(this.m_mainPictureBox)).EndInit();
            this.m_topPanel.ResumeLayout(false);
            this.m_topPanel.PerformLayout();
            this.m_mainPanel.ResumeLayout(false);
            this.m_rightPanel.ResumeLayout(false);
            this.m_leftPanel.ResumeLayout(false);
            this.m_leftDownPanel.ResumeLayout(false);
            this.m_leftDownPanel.PerformLayout();
            this.m_leftUpPanel.ResumeLayout(false);
            this.m_leftUpPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_mainPictureBox;
        private System.Windows.Forms.Panel m_topPanel;
        private System.Windows.Forms.TextBox m_despTextBox;
        private System.Windows.Forms.Label m_nameLabel;
        private System.Windows.Forms.Panel m_mainPanel;
        private System.Windows.Forms.Panel m_rightPanel;
        private System.Windows.Forms.Splitter m_splitter;
        private System.Windows.Forms.Panel m_leftPanel;
        private System.Windows.Forms.Panel m_leftDownPanel;
        private System.Windows.Forms.Panel m_leftUpPanel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox m_transInfoRichTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}
