
namespace BikeInputs
{
    partial class Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.btn_Toggle = new System.Windows.Forms.Button();
            this.lbl_debug = new System.Windows.Forms.Label();
            this.lbl_rpm = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_buttonpress_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_isCycling = new System.Windows.Forms.Label();
            this.lbl_debug_title = new System.Windows.Forms.Label();
            this.lbl_cyclesCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_slowThreshold = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_stopTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_maxTimeDif = new System.Windows.Forms.Label();
            this.lbl_fastThreshold = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_speedStatus = new System.Windows.Forms.Label();
            this.lbl_mediumThreshold = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bar_speed = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_reverseTime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.sp_bike = new System.IO.Ports.SerialPort(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_isReversing = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_input = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Toggle
            // 
            this.btn_Toggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Toggle.Location = new System.Drawing.Point(858, 204);
            this.btn_Toggle.Name = "btn_Toggle";
            this.btn_Toggle.Size = new System.Drawing.Size(125, 48);
            this.btn_Toggle.TabIndex = 0;
            this.btn_Toggle.Text = "off";
            this.btn_Toggle.UseVisualStyleBackColor = true;
            this.btn_Toggle.Click += new System.EventHandler(this.btn_Toggle_Click);
            // 
            // lbl_debug
            // 
            this.lbl_debug.AutoSize = true;
            this.lbl_debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debug.Location = new System.Drawing.Point(509, 586);
            this.lbl_debug.Name = "lbl_debug";
            this.lbl_debug.Size = new System.Drawing.Size(79, 18);
            this.lbl_debug.TabIndex = 1;
            this.lbl_debug.Text = "deubugtext";
            // 
            // lbl_rpm
            // 
            this.lbl_rpm.AutoSize = true;
            this.lbl_rpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rpm.Location = new System.Drawing.Point(601, 389);
            this.lbl_rpm.Name = "lbl_rpm";
            this.lbl_rpm.Size = new System.Drawing.Size(21, 24);
            this.lbl_rpm.TabIndex = 2;
            this.lbl_rpm.Text = "0";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbl_buttonpress_title
            // 
            this.lbl_buttonpress_title.AutoSize = true;
            this.lbl_buttonpress_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buttonpress_title.Location = new System.Drawing.Point(853, 181);
            this.lbl_buttonpress_title.Name = "lbl_buttonpress_title";
            this.lbl_buttonpress_title.Size = new System.Drawing.Size(137, 25);
            this.lbl_buttonpress_title.TabIndex = 3;
            this.lbl_buttonpress_title.Text = "Toggle input:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bike stats:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "RPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(413, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "isCycling:";
            // 
            // lbl_isCycling
            // 
            this.lbl_isCycling.AutoSize = true;
            this.lbl_isCycling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_isCycling.Location = new System.Drawing.Point(509, 509);
            this.lbl_isCycling.Name = "lbl_isCycling";
            this.lbl_isCycling.Size = new System.Drawing.Size(44, 18);
            this.lbl_isCycling.TabIndex = 7;
            this.lbl_isCycling.Text = "false";
            // 
            // lbl_debug_title
            // 
            this.lbl_debug_title.AutoSize = true;
            this.lbl_debug_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debug_title.Location = new System.Drawing.Point(381, 579);
            this.lbl_debug_title.Name = "lbl_debug_title";
            this.lbl_debug_title.Size = new System.Drawing.Size(122, 25);
            this.lbl_debug_title.TabIndex = 8;
            this.lbl_debug_title.Text = "Debug box:";
            // 
            // lbl_cyclesCount
            // 
            this.lbl_cyclesCount.AutoSize = true;
            this.lbl_cyclesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cyclesCount.Location = new System.Drawing.Point(509, 531);
            this.lbl_cyclesCount.Name = "lbl_cyclesCount";
            this.lbl_cyclesCount.Size = new System.Drawing.Size(17, 18);
            this.lbl_cyclesCount.TabIndex = 10;
            this.lbl_cyclesCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "cycles count:";
            // 
            // lbl_slowThreshold
            // 
            this.lbl_slowThreshold.AutoSize = true;
            this.lbl_slowThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_slowThreshold.Location = new System.Drawing.Point(239, 579);
            this.lbl_slowThreshold.Name = "lbl_slowThreshold";
            this.lbl_slowThreshold.Size = new System.Drawing.Size(17, 18);
            this.lbl_slowThreshold.TabIndex = 17;
            this.lbl_slowThreshold.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "slowThreshold:";
            // 
            // lbl_stopTime
            // 
            this.lbl_stopTime.AutoSize = true;
            this.lbl_stopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopTime.Location = new System.Drawing.Point(239, 533);
            this.lbl_stopTime.Name = "lbl_stopTime";
            this.lbl_stopTime.Size = new System.Drawing.Size(17, 18);
            this.lbl_stopTime.TabIndex = 15;
            this.lbl_stopTime.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(140, 527);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "stopTime:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(118, 503);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 24);
            this.label9.TabIndex = 13;
            this.label9.Text = "maxTimeDif:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(125, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Variables:";
            // 
            // lbl_maxTimeDif
            // 
            this.lbl_maxTimeDif.AutoSize = true;
            this.lbl_maxTimeDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maxTimeDif.Location = new System.Drawing.Point(239, 507);
            this.lbl_maxTimeDif.Name = "lbl_maxTimeDif";
            this.lbl_maxTimeDif.Size = new System.Drawing.Size(17, 18);
            this.lbl_maxTimeDif.TabIndex = 11;
            this.lbl_maxTimeDif.Text = "0";
            // 
            // lbl_fastThreshold
            // 
            this.lbl_fastThreshold.AutoSize = true;
            this.lbl_fastThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fastThreshold.Location = new System.Drawing.Point(239, 625);
            this.lbl_fastThreshold.Name = "lbl_fastThreshold";
            this.lbl_fastThreshold.Size = new System.Drawing.Size(17, 18);
            this.lbl_fastThreshold.TabIndex = 19;
            this.lbl_fastThreshold.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(105, 621);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 24);
            this.label13.TabIndex = 18;
            this.label13.Text = "fastThreshold:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(855, 278);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 25);
            this.label19.TabIndex = 21;
            this.label19.Text = "Inputs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "speed status:";
            // 
            // lbl_speedStatus
            // 
            this.lbl_speedStatus.AutoSize = true;
            this.lbl_speedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speedStatus.Location = new System.Drawing.Point(610, 179);
            this.lbl_speedStatus.Name = "lbl_speedStatus";
            this.lbl_speedStatus.Size = new System.Drawing.Size(86, 24);
            this.lbl_speedStatus.TabIndex = 27;
            this.lbl_speedStatus.Text = "noCycle";
            // 
            // lbl_mediumThreshold
            // 
            this.lbl_mediumThreshold.AutoSize = true;
            this.lbl_mediumThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mediumThreshold.Location = new System.Drawing.Point(239, 603);
            this.lbl_mediumThreshold.Name = "lbl_mediumThreshold";
            this.lbl_mediumThreshold.Size = new System.Drawing.Size(17, 18);
            this.lbl_mediumThreshold.TabIndex = 30;
            this.lbl_mediumThreshold.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 597);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 24);
            this.label11.TabIndex = 29;
            this.label11.Text = "mediumThreshold:";
            // 
            // bar_speed
            // 
            this.bar_speed.BackColor = System.Drawing.Color.White;
            this.bar_speed.ForeColor = System.Drawing.Color.Green;
            this.bar_speed.Location = new System.Drawing.Point(-2, 394);
            this.bar_speed.MarqueeAnimationSpeed = 10;
            this.bar_speed.Name = "bar_speed";
            this.bar_speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bar_speed.Size = new System.Drawing.Size(1163, 19);
            this.bar_speed.Step = 5;
            this.bar_speed.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bar_speed.TabIndex = 31;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-245, -93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1452, 1444);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_reverseTime
            // 
            this.lbl_reverseTime.AutoSize = true;
            this.lbl_reverseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reverseTime.Location = new System.Drawing.Point(239, 556);
            this.lbl_reverseTime.Name = "lbl_reverseTime";
            this.lbl_reverseTime.Size = new System.Drawing.Size(17, 18);
            this.lbl_reverseTime.TabIndex = 36;
            this.lbl_reverseTime.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(112, 549);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 24);
            this.label14.TabIndex = 35;
            this.label14.Text = "reverseTime:";
            // 
            // sp_bike
            // 
            this.sp_bike.DtrEnable = true;
            this.sp_bike.PortName = "COM5";
            this.sp_bike.RtsEnable = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(458, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 29);
            this.label7.TabIndex = 38;
            this.label7.Text = "isReversing:";
            // 
            // lbl_isReversing
            // 
            this.lbl_isReversing.AutoSize = true;
            this.lbl_isReversing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_isReversing.Location = new System.Drawing.Point(610, 209);
            this.lbl_isReversing.Name = "lbl_isReversing";
            this.lbl_isReversing.Size = new System.Drawing.Size(53, 24);
            this.lbl_isReversing.TabIndex = 37;
            this.lbl_isReversing.Text = "false";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Coral;
            this.label16.Location = new System.Drawing.Point(386, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(380, 55);
            this.label16.TabIndex = 39;
            this.label16.Text = "Fantasy Cycling";
            // 
            // lbl_input
            // 
            this.lbl_input.AutoSize = true;
            this.lbl_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_input.Location = new System.Drawing.Point(937, 283);
            this.lbl_input.Name = "lbl_input";
            this.lbl_input.Size = new System.Drawing.Size(34, 18);
            this.lbl_input.TabIndex = 20;
            this.lbl_input.Text = "null";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(718, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 25);
            this.label12.TabIndex = 40;
            this.label12.Text = "Credits:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(808, 482);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 18);
            this.label15.TabIndex = 41;
            this.label15.Text = "code: Juhana Moilanen";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(808, 504);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 18);
            this.label17.TabIndex = 42;
            this.label17.Text = "background: Ted  Helms";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 729);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_isReversing);
            this.Controls.Add(this.lbl_reverseTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbl_mediumThreshold);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_speedStatus);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbl_input);
            this.Controls.Add(this.lbl_fastThreshold);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbl_slowThreshold);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_stopTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_maxTimeDif);
            this.Controls.Add(this.lbl_cyclesCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_debug_title);
            this.Controls.Add(this.lbl_isCycling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_buttonpress_title);
            this.Controls.Add(this.lbl_rpm);
            this.Controls.Add(this.lbl_debug);
            this.Controls.Add(this.btn_Toggle);
            this.Controls.Add(this.bar_speed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form";
            this.ShowIcon = false;
            this.Text = " FantasyCycling";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Toggle;
        private System.Windows.Forms.Label lbl_debug;
        private System.Windows.Forms.Label lbl_rpm;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbl_buttonpress_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_isCycling;
        private System.Windows.Forms.Label lbl_debug_title;
        private System.Windows.Forms.Label lbl_cyclesCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_slowThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_stopTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_maxTimeDif;
        private System.Windows.Forms.Label lbl_fastThreshold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_speedStatus;
        private System.Windows.Forms.Label lbl_mediumThreshold;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar bar_speed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_reverseTime;
        private System.Windows.Forms.Label label14;
        private System.IO.Ports.SerialPort sp_bike;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_isReversing;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_input;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
    }
}

