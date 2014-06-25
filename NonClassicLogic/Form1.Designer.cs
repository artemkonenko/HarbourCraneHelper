namespace NonClassicLogic
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.topViewPicture = new System.Windows.Forms.PictureBox();
            this.sidewayViewPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.windSpeed = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.waveHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.deviation = new System.Windows.Forms.TextBox();
            this.height = new System.Windows.Forms.Label();
            this.distanceText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.topViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidewayViewPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(94, 13);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // topViewPicture
            // 
            this.topViewPicture.Location = new System.Drawing.Point(13, 140);
            this.topViewPicture.Name = "topViewPicture";
            this.topViewPicture.Size = new System.Drawing.Size(467, 242);
            this.topViewPicture.TabIndex = 2;
            this.topViewPicture.TabStop = false;
            // 
            // sidewayViewPicture
            // 
            this.sidewayViewPicture.Location = new System.Drawing.Point(486, 140);
            this.sidewayViewPicture.Name = "sidewayViewPicture";
            this.sidewayViewPicture.Size = new System.Drawing.Size(470, 242);
            this.sidewayViewPicture.TabIndex = 3;
            this.sidewayViewPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вид сверху:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вид сбоку:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Скорость ветра:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Время:";
            // 
            // windSpeed
            // 
            this.windSpeed.Enabled = false;
            this.windSpeed.Location = new System.Drawing.Point(274, 15);
            this.windSpeed.Name = "windSpeed";
            this.windSpeed.Size = new System.Drawing.Size(53, 20);
            this.windSpeed.TabIndex = 8;
            // 
            // time
            // 
            this.time.Enabled = false;
            this.time.Location = new System.Drawing.Point(593, 15);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(52, 20);
            this.time.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Высота волны:";
            // 
            // waveHeight
            // 
            this.waveHeight.Enabled = false;
            this.waveHeight.Location = new System.Drawing.Point(454, 15);
            this.waveHeight.Name = "waveHeight";
            this.waveHeight.Size = new System.Drawing.Size(52, 20);
            this.waveHeight.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Отклонение:";
            // 
            // deviation
            // 
            this.deviation.Enabled = false;
            this.deviation.Location = new System.Drawing.Point(274, 38);
            this.deviation.Name = "deviation";
            this.deviation.Size = new System.Drawing.Size(53, 20);
            this.deviation.TabIndex = 13;
            // 
            // height
            // 
            this.height.AutoSize = true;
            this.height.Location = new System.Drawing.Point(368, 41);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(70, 13);
            this.height.TabIndex = 14;
            this.height.Text = "Расстояние:";
            // 
            // distanceText
            // 
            this.distanceText.Enabled = false;
            this.distanceText.Location = new System.Drawing.Point(454, 38);
            this.distanceText.Name = "distanceText";
            this.distanceText.Size = new System.Drawing.Size(52, 20);
            this.distanceText.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "м/с";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "м";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(512, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "м";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(512, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "м";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(651, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "с";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 392);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.distanceText);
            this.Controls.Add(this.height);
            this.Controls.Add(this.deviation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.waveHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.time);
            this.Controls.Add(this.windSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sidewayViewPicture);
            this.Controls.Add(this.topViewPicture);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Повелитель кранов 0.01";
            ((System.ComponentModel.ISupportInitialize)(this.topViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidewayViewPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox topViewPicture;
        private System.Windows.Forms.PictureBox sidewayViewPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox windSpeed;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox waveHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox deviation;
        private System.Windows.Forms.Label height;
        private System.Windows.Forms.TextBox distanceText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

