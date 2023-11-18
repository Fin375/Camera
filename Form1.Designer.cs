namespace kamera
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
            this.pictureBoxCam = new System.Windows.Forms.PictureBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonSnapshot = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonChangeParameters = new System.Windows.Forms.Button();
            this.buttonChangeResolution = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCam
            // 
            this.pictureBoxCam.Location = new System.Drawing.Point(27, 23);
            this.pictureBoxCam.Name = "pictureBoxCam";
            this.pictureBoxCam.Size = new System.Drawing.Size(637, 586);
            this.pictureBoxCam.TabIndex = 0;
            this.pictureBoxCam.TabStop = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(715, 53);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(112, 52);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Połącz";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(855, 53);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(112, 52);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "Rozłącz";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonSnapshot
            // 
            this.buttonSnapshot.Location = new System.Drawing.Point(80, 21);
            this.buttonSnapshot.Name = "buttonSnapshot";
            this.buttonSnapshot.Size = new System.Drawing.Size(112, 52);
            this.buttonSnapshot.TabIndex = 3;
            this.buttonSnapshot.Text = "Snapshot";
            this.buttonSnapshot.UseVisualStyleBackColor = true;
            this.buttonSnapshot.Click += new System.EventHandler(this.buttonSnapshot_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(10, 33);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(112, 52);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Rozpocznij";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(150, 33);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(112, 52);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Zakończ";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonChangeParameters
            // 
            this.buttonChangeParameters.Location = new System.Drawing.Point(8, 32);
            this.buttonChangeParameters.Name = "buttonChangeParameters";
            this.buttonChangeParameters.Size = new System.Drawing.Size(112, 52);
            this.buttonChangeParameters.TabIndex = 7;
            this.buttonChangeParameters.Text = "Zmień parametry";
            this.buttonChangeParameters.UseVisualStyleBackColor = true;
            this.buttonChangeParameters.Click += new System.EventHandler(this.buttonChangeParameters_Click);
            // 
            // buttonChangeResolution
            // 
            this.buttonChangeResolution.Location = new System.Drawing.Point(148, 32);
            this.buttonChangeResolution.Name = "buttonChangeResolution";
            this.buttonChangeResolution.Size = new System.Drawing.Size(112, 52);
            this.buttonChangeResolution.TabIndex = 8;
            this.buttonChangeResolution.Text = "Zmień rozdzielczość";
            this.buttonChangeResolution.UseVisualStyleBackColor = true;
            this.buttonChangeResolution.Click += new System.EventHandler(this.buttonChangeResolution_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSnapshot);
            this.groupBox1.Location = new System.Drawing.Point(704, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robienie zdjęć";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Location = new System.Drawing.Point(705, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 111);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nagrywanie";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonChangeResolution);
            this.groupBox3.Controls.Add(this.buttonChangeParameters);
            this.groupBox3.Location = new System.Drawing.Point(707, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 101);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ustawienia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 643);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.pictureBoxCam);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form1_Closed);
            this.Load += new System.EventHandler(this.form1_load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCam;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonSnapshot;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonChangeParameters;
        private System.Windows.Forms.Button buttonChangeResolution;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

