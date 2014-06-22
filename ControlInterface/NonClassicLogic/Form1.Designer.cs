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
            this.cargoSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.waveHeight = new System.Windows.Forms.TextBox();
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
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(95, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
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
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вид сверху";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вид сбоку";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Скорость ветра";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Скорость спуска";
            // 
            // windSpeed
            // 
            this.windSpeed.Enabled = false;
            this.windSpeed.Location = new System.Drawing.Point(184, 46);
            this.windSpeed.Name = "windSpeed";
            this.windSpeed.Size = new System.Drawing.Size(100, 20);
            this.windSpeed.TabIndex = 8;
            // 
            // cargoSpeed
            // 
            this.cargoSpeed.Enabled = false;
            this.cargoSpeed.Location = new System.Drawing.Point(304, 46);
            this.cargoSpeed.Name = "cargoSpeed";
            this.cargoSpeed.Size = new System.Drawing.Size(100, 20);
            this.cargoSpeed.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(421, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Высота волны";
            // 
            // waveHeight
            // 
            this.waveHeight.Enabled = false;
            this.waveHeight.Location = new System.Drawing.Point(424, 46);
            this.waveHeight.Name = "waveHeight";
            this.waveHeight.Size = new System.Drawing.Size(100, 20);
            this.waveHeight.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 392);
            this.Controls.Add(this.waveHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cargoSpeed);
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
        private System.Windows.Forms.TextBox cargoSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox waveHeight;
    }
}

