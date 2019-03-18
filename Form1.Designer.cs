namespace HandGesture
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.original = new System.Windows.Forms.PictureBox();
            this.crop = new System.Windows.Forms.PictureBox();
            this.histogram = new AForge.Controls.Histogram();
            this.histogram1 = new AForge.Controls.Histogram();
            this.openvideo = new System.Windows.Forms.Button();
            this.stopvideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crop)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(1339, 79);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 28);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(1444, 79);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 28);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1444, 47);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1336, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Camera";
            // 
            // original
            // 
            this.original.Location = new System.Drawing.Point(664, 15);
            this.original.Margin = new System.Windows.Forms.Padding(4);
            this.original.Name = "original";
            this.original.Size = new System.Drawing.Size(659, 480);
            this.original.TabIndex = 5;
            this.original.TabStop = false;
            // 
            // crop
            // 
            this.crop.Location = new System.Drawing.Point(1339, 126);
            this.crop.Margin = new System.Windows.Forms.Padding(4);
            this.crop.Name = "crop";
            this.crop.Size = new System.Drawing.Size(219, 158);
            this.crop.TabIndex = 6;
            this.crop.TabStop = false;
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(1339, 307);
            this.histogram.Margin = new System.Windows.Forms.Padding(4);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(219, 91);
            this.histogram.TabIndex = 8;
            this.histogram.Text = "histogram";
            this.histogram.Values = null;
            // 
            // histogram1
            // 
            this.histogram1.Location = new System.Drawing.Point(1339, 405);
            this.histogram1.Margin = new System.Windows.Forms.Padding(4);
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(219, 89);
            this.histogram1.TabIndex = 9;
            this.histogram1.Text = "histogram1";
            this.histogram1.Values = null;
            // 
            // openvideo
            // 
            this.openvideo.Location = new System.Drawing.Point(1339, 15);
            this.openvideo.Margin = new System.Windows.Forms.Padding(4);
            this.openvideo.Name = "openvideo";
            this.openvideo.Size = new System.Drawing.Size(100, 28);
            this.openvideo.TabIndex = 10;
            this.openvideo.Text = "Video File";
            this.openvideo.UseVisualStyleBackColor = true;
            this.openvideo.Click += new System.EventHandler(this.openvideo_Click_1);
            // 
            // stopvideo
            // 
            this.stopvideo.Location = new System.Drawing.Point(1457, 15);
            this.stopvideo.Margin = new System.Windows.Forms.Padding(4);
            this.stopvideo.Name = "stopvideo";
            this.stopvideo.Size = new System.Drawing.Size(55, 28);
            this.stopvideo.TabIndex = 11;
            this.stopvideo.Text = "stop";
            this.stopvideo.UseVisualStyleBackColor = true;
            this.stopvideo.Click += new System.EventHandler(this.stopvideo_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1568, 518);
            this.Controls.Add(this.stopvideo);
            this.Controls.Add(this.openvideo);
            this.Controls.Add(this.histogram1);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.crop);
            this.Controls.Add(this.original);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Hand Gesture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox original;
        private System.Windows.Forms.PictureBox crop;
        private AForge.Controls.Histogram histogram;
        private AForge.Controls.Histogram histogram1;
        private System.Windows.Forms.Button openvideo;
        private System.Windows.Forms.Button stopvideo;
    }
}

