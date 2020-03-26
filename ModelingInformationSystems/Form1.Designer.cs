namespace ByMarin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFirstQuest = new System.Windows.Forms.TabPage();
            this.labelKolNumber = new System.Windows.Forms.Label();
            this.label_Intervals = new System.Windows.Forms.Label();
            this.textBoxIntervals = new System.Windows.Forms.TextBox();
            this.textBoxKolNumber = new System.Windows.Forms.TextBox();
            this.chartGrafics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStartDrawGrafics = new System.Windows.Forms.Button();
            this.tabPageSecondQuest = new System.Windows.Forms.TabPage();
            this.tabPageThirdQuest = new System.Windows.Forms.TabPage();
            this.radioButtonDefaultGeneration = new System.Windows.Forms.RadioButton();
            this.radioButtonKongryen = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodLemera = new System.Windows.Forms.RadioButton();
            this.groupBoxPage1Methods = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.tabPageFirstQuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafics)).BeginInit();
            this.groupBoxPage1Methods.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFirstQuest);
            this.tabControl.Controls.Add(this.tabPageSecondQuest);
            this.tabControl.Controls.Add(this.tabPageThirdQuest);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 426);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFirstQuest
            // 
            this.tabPageFirstQuest.Controls.Add(this.groupBoxPage1Methods);
            this.tabPageFirstQuest.Controls.Add(this.labelKolNumber);
            this.tabPageFirstQuest.Controls.Add(this.label_Intervals);
            this.tabPageFirstQuest.Controls.Add(this.textBoxIntervals);
            this.tabPageFirstQuest.Controls.Add(this.textBoxKolNumber);
            this.tabPageFirstQuest.Controls.Add(this.chartGrafics);
            this.tabPageFirstQuest.Controls.Add(this.buttonStartDrawGrafics);
            this.tabPageFirstQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageFirstQuest.Name = "tabPageFirstQuest";
            this.tabPageFirstQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFirstQuest.Size = new System.Drawing.Size(768, 400);
            this.tabPageFirstQuest.TabIndex = 0;
            this.tabPageFirstQuest.Text = "Равномерное";
            this.tabPageFirstQuest.UseVisualStyleBackColor = true;
            // 
            // labelKolNumber
            // 
            this.labelKolNumber.AutoSize = true;
            this.labelKolNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKolNumber.Location = new System.Drawing.Point(21, 253);
            this.labelKolNumber.Name = "labelKolNumber";
            this.labelKolNumber.Size = new System.Drawing.Size(159, 19);
            this.labelKolNumber.TabIndex = 5;
            this.labelKolNumber.Text = "Количество значений:";
            // 
            // label_Intervals
            // 
            this.label_Intervals.AutoSize = true;
            this.label_Intervals.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Intervals.Location = new System.Drawing.Point(21, 193);
            this.label_Intervals.Name = "label_Intervals";
            this.label_Intervals.Size = new System.Drawing.Size(175, 19);
            this.label_Intervals.TabIndex = 5;
            this.label_Intervals.Text = "Количество интервалов:";
            // 
            // textBoxIntervals
            // 
            this.textBoxIntervals.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIntervals.Location = new System.Drawing.Point(29, 220);
            this.textBoxIntervals.Name = "textBoxIntervals";
            this.textBoxIntervals.Size = new System.Drawing.Size(100, 26);
            this.textBoxIntervals.TabIndex = 4;
            // 
            // textBoxKolNumber
            // 
            this.textBoxKolNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKolNumber.Location = new System.Drawing.Point(29, 279);
            this.textBoxKolNumber.Name = "textBoxKolNumber";
            this.textBoxKolNumber.Size = new System.Drawing.Size(100, 26);
            this.textBoxKolNumber.TabIndex = 4;
            // 
            // chartGrafics
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGrafics.ChartAreas.Add(chartArea1);
            this.chartGrafics.Location = new System.Drawing.Point(248, 6);
            this.chartGrafics.Name = "chartGrafics";
            this.chartGrafics.Size = new System.Drawing.Size(514, 380);
            this.chartGrafics.TabIndex = 3;
            this.chartGrafics.TabStop = false;
            // 
            // buttonStartDrawGrafics
            // 
            this.buttonStartDrawGrafics.Location = new System.Drawing.Point(23, 363);
            this.buttonStartDrawGrafics.Name = "buttonStartDrawGrafics";
            this.buttonStartDrawGrafics.Size = new System.Drawing.Size(183, 23);
            this.buttonStartDrawGrafics.TabIndex = 2;
            this.buttonStartDrawGrafics.Text = "Принять";
            this.buttonStartDrawGrafics.UseVisualStyleBackColor = true;
            this.buttonStartDrawGrafics.Click += new System.EventHandler(this.buttonStartDrawGrafics_Click);
            // 
            // tabPageSecondQuest
            // 
            this.tabPageSecondQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageSecondQuest.Name = "tabPageSecondQuest";
            this.tabPageSecondQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSecondQuest.Size = new System.Drawing.Size(768, 400);
            this.tabPageSecondQuest.TabIndex = 1;
            this.tabPageSecondQuest.Text = "2 задание";
            this.tabPageSecondQuest.UseVisualStyleBackColor = true;
            // 
            // tabPageThirdQuest
            // 
            this.tabPageThirdQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageThirdQuest.Name = "tabPageThirdQuest";
            this.tabPageThirdQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThirdQuest.Size = new System.Drawing.Size(768, 400);
            this.tabPageThirdQuest.TabIndex = 2;
            this.tabPageThirdQuest.Text = "3 задание";
            this.tabPageThirdQuest.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefaultGeneration
            // 
            this.radioButtonDefaultGeneration.AutoSize = true;
            this.radioButtonDefaultGeneration.Location = new System.Drawing.Point(6, 40);
            this.radioButtonDefaultGeneration.Name = "radioButtonDefaultGeneration";
            this.radioButtonDefaultGeneration.Size = new System.Drawing.Size(157, 19);
            this.radioButtonDefaultGeneration.TabIndex = 6;
            this.radioButtonDefaultGeneration.TabStop = true;
            this.radioButtonDefaultGeneration.Text = "Стандартный генератор";
            this.radioButtonDefaultGeneration.UseVisualStyleBackColor = true;
            // 
            // radioButtonKongryen
            // 
            this.radioButtonKongryen.AutoSize = true;
            this.radioButtonKongryen.Location = new System.Drawing.Point(6, 70);
            this.radioButtonKongryen.Name = "radioButtonKongryen";
            this.radioButtonKongryen.Size = new System.Drawing.Size(178, 19);
            this.radioButtonKongryen.TabIndex = 7;
            this.radioButtonKongryen.TabStop = true;
            this.radioButtonKongryen.Text = "Метод простых конгруэций";
            this.radioButtonKongryen.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodLemera
            // 
            this.radioButtonMethodLemera.AutoSize = true;
            this.radioButtonMethodLemera.Location = new System.Drawing.Point(6, 100);
            this.radioButtonMethodLemera.Name = "radioButtonMethodLemera";
            this.radioButtonMethodLemera.Size = new System.Drawing.Size(184, 19);
            this.radioButtonMethodLemera.TabIndex = 8;
            this.radioButtonMethodLemera.TabStop = true;
            this.radioButtonMethodLemera.Text = "Последовательность Лемера";
            this.radioButtonMethodLemera.UseVisualStyleBackColor = true;
            // 
            // groupBoxPage1Methods
            // 
            this.groupBoxPage1Methods.Controls.Add(this.radioButtonKongryen);
            this.groupBoxPage1Methods.Controls.Add(this.radioButtonMethodLemera);
            this.groupBoxPage1Methods.Controls.Add(this.radioButtonDefaultGeneration);
            this.groupBoxPage1Methods.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPage1Methods.Location = new System.Drawing.Point(23, 23);
            this.groupBoxPage1Methods.Name = "groupBoxPage1Methods";
            this.groupBoxPage1Methods.Size = new System.Drawing.Size(197, 158);
            this.groupBoxPage1Methods.TabIndex = 9;
            this.groupBoxPage1Methods.TabStop = false;
            this.groupBoxPage1Methods.Text = "Методы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программа";
            this.tabControl.ResumeLayout(false);
            this.tabPageFirstQuest.ResumeLayout(false);
            this.tabPageFirstQuest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafics)).EndInit();
            this.groupBoxPage1Methods.ResumeLayout(false);
            this.groupBoxPage1Methods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFirstQuest;
        private System.Windows.Forms.TabPage tabPageSecondQuest;
        private System.Windows.Forms.Button buttonStartDrawGrafics;
        private System.Windows.Forms.TabPage tabPageThirdQuest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrafics;
        private System.Windows.Forms.Label labelKolNumber;
        private System.Windows.Forms.Label label_Intervals;
        private System.Windows.Forms.TextBox textBoxIntervals;
        private System.Windows.Forms.TextBox textBoxKolNumber;
        private System.Windows.Forms.GroupBox groupBoxPage1Methods;
        private System.Windows.Forms.RadioButton radioButtonKongryen;
        private System.Windows.Forms.RadioButton radioButtonMethodLemera;
        private System.Windows.Forms.RadioButton radioButtonDefaultGeneration;
    }
}

