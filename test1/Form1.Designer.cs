namespace Voronoi
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_readFile = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.button_outputFile = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.showFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showCoordinate = new System.Windows.Forms.Label();
            this.pointsName = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.stepByStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MourseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button_readFile
            // 
            this.button_readFile.Location = new System.Drawing.Point(638, 92);
            this.button_readFile.Name = "button_readFile";
            this.button_readFile.Size = new System.Drawing.Size(75, 23);
            this.button_readFile.TabIndex = 7;
            this.button_readFile.Text = "讀檔";
            this.button_readFile.UseVisualStyleBackColor = true;
            this.button_readFile.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(638, 175);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "清空畫布";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_outputFile
            // 
            this.button_outputFile.Location = new System.Drawing.Point(638, 54);
            this.button_outputFile.Name = "button_outputFile";
            this.button_outputFile.Size = new System.Drawing.Size(75, 23);
            this.button_outputFile.TabIndex = 9;
            this.button_outputFile.Text = "輸出";
            this.button_outputFile.UseVisualStyleBackColor = true;
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(638, 12);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(89, 36);
            this.button_run.TabIndex = 10;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // showFile
            // 
            this.showFile.AutoSize = true;
            this.showFile.Location = new System.Drawing.Point(13, 666);
            this.showFile.Name = "showFile";
            this.showFile.Size = new System.Drawing.Size(53, 12);
            this.showFile.TabIndex = 11;
            this.showFile.Text = "檔案路徑";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 688);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "讀檔狀態";
            // 
            // showCoordinate
            // 
            this.showCoordinate.AutoSize = true;
            this.showCoordinate.Location = new System.Drawing.Point(10, 626);
            this.showCoordinate.Name = "showCoordinate";
            this.showCoordinate.Size = new System.Drawing.Size(53, 12);
            this.showCoordinate.TabIndex = 14;
            this.showCoordinate.Text = "滑鼠座標";
            // 
            // pointsName
            // 
            this.pointsName.AutoSize = true;
            this.pointsName.Location = new System.Drawing.Point(10, 710);
            this.pointsName.Name = "pointsName";
            this.pointsName.Size = new System.Drawing.Size(65, 12);
            this.pointsName.TabIndex = 15;
            this.pointsName.Text = "輸入座標點";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(638, 238);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 316);
            this.listBox1.TabIndex = 16;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // stepByStep
            // 
            this.stepByStep.Location = new System.Drawing.Point(749, 12);
            this.stepByStep.Name = "stepByStep";
            this.stepByStep.Size = new System.Drawing.Size(86, 36);
            this.stepByStep.TabIndex = 20;
            this.stepByStep.Text = "Step by step";
            this.stepByStep.UseVisualStyleBackColor = true;
            this.stepByStep.Click += new System.EventHandler(this.stepByStep_Click);
            this.stepByStep.MouseClick += new System.Windows.Forms.MouseEventHandler(this.stepByStep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(884, 741);
            this.Controls.Add(this.stepByStep);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pointsName);
            this.Controls.Add(this.showCoordinate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showFile);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.button_outputFile);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.button_readFile);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Voronoi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_readFile;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button button_outputFile;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.Label showFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label showCoordinate;
        private System.Windows.Forms.Label pointsName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button stepByStep;
    }
}

