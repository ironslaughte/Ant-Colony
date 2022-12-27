namespace AntColony
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumCities = new System.Windows.Forms.TextBox();
            this.textBoxNumAnts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.Alpha = new System.Windows.Forms.Label();
            this.textBoxBeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Answer = new System.Windows.Forms.Label();
            this.textBoxRho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCurrentBestLen = new System.Windows.Forms.Label();
            this.richTextBoxResAlg = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelGraph = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNumIter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество городов";
            // 
            // textBoxNumCities
            // 
            this.textBoxNumCities.Location = new System.Drawing.Point(177, 29);
            this.textBoxNumCities.Name = "textBoxNumCities";
            this.textBoxNumCities.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumCities.TabIndex = 1;
            this.textBoxNumCities.Text = "10";
            // 
            // textBoxNumAnts
            // 
            this.textBoxNumAnts.Location = new System.Drawing.Point(177, 55);
            this.textBoxNumAnts.Name = "textBoxNumAnts";
            this.textBoxNumAnts.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumAnts.TabIndex = 3;
            this.textBoxNumAnts.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество муравьев";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(324, 29);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlpha.TabIndex = 5;
            this.textBoxAlpha.Text = "3";
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = true;
            this.Alpha.Location = new System.Drawing.Point(284, 32);
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(34, 13);
            this.Alpha.TabIndex = 4;
            this.Alpha.Text = "Alpha";
            // 
            // textBoxBeta
            // 
            this.textBoxBeta.Location = new System.Drawing.Point(324, 55);
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.Size = new System.Drawing.Size(100, 20);
            this.textBoxBeta.TabIndex = 7;
            this.textBoxBeta.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Beta";
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(580, 29);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(100, 20);
            this.textBoxQ.TabIndex = 9;
            this.textBoxQ.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Q";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(966, 32);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Запустить";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Answer
            // 
            this.Answer.AutoSize = true;
            this.Answer.Location = new System.Drawing.Point(350, 185);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(0, 13);
            this.Answer.TabIndex = 11;
            // 
            // textBoxRho
            // 
            this.textBoxRho.Location = new System.Drawing.Point(580, 55);
            this.textBoxRho.Name = "textBoxRho";
            this.textBoxRho.Size = new System.Drawing.Size(100, 20);
            this.textBoxRho.TabIndex = 13;
            this.textBoxRho.Text = "0,01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Коэф. испарения веромона";
            // 
            // labelCurrentBestLen
            // 
            this.labelCurrentBestLen.AutoSize = true;
            this.labelCurrentBestLen.Location = new System.Drawing.Point(343, 32);
            this.labelCurrentBestLen.Name = "labelCurrentBestLen";
            this.labelCurrentBestLen.Size = new System.Drawing.Size(0, 13);
            this.labelCurrentBestLen.TabIndex = 14;
            // 
            // richTextBoxResAlg
            // 
            this.richTextBoxResAlg.Location = new System.Drawing.Point(553, 112);
            this.richTextBoxResAlg.Name = "richTextBoxResAlg";
            this.richTextBoxResAlg.Size = new System.Drawing.Size(488, 212);
            this.richTextBoxResAlg.TabIndex = 15;
            this.richTextBoxResAlg.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Матрциа смежности графа:";
            // 
            // labelGraph
            // 
            this.labelGraph.AutoSize = true;
            this.labelGraph.Location = new System.Drawing.Point(23, 124);
            this.labelGraph.Name = "labelGraph";
            this.labelGraph.Size = new System.Drawing.Size(0, 13);
            this.labelGraph.TabIndex = 17;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Рандомный",
            "Из файла"});
            this.comboBox1.Location = new System.Drawing.Point(819, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(688, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Граф";
            // 
            // textBoxNumIter
            // 
            this.textBoxNumIter.Location = new System.Drawing.Point(840, 29);
            this.textBoxNumIter.Name = "textBoxNumIter";
            this.textBoxNumIter.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumIter.TabIndex = 21;
            this.textBoxNumIter.Text = "500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(687, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Количество итераций";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 514);
            this.Controls.Add(this.textBoxNumIter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelGraph);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxResAlg);
            this.Controls.Add(this.labelCurrentBestLen);
            this.Controls.Add(this.textBoxRho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxBeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.Alpha);
            this.Controls.Add(this.textBoxNumAnts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumCities);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumCities;
        private System.Windows.Forms.TextBox textBoxNumAnts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.TextBox textBoxBeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label Answer;
        private System.Windows.Forms.TextBox textBoxRho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCurrentBestLen;
        private System.Windows.Forms.RichTextBox richTextBoxResAlg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelGraph;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNumIter;
        private System.Windows.Forms.Label label8;
    }
}

