namespace ModelingInformationSystems
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFirstQuest = new System.Windows.Forms.TabPage();
            this.groupBoxPage1Methods = new System.Windows.Forms.GroupBox();
            this.radioButtonKongryen = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodLemera = new System.Windows.Forms.RadioButton();
            this.radioButtonDefaultGeneration = new System.Windows.Forms.RadioButton();
            this.labelPage1Kol = new System.Windows.Forms.Label();
            this.labelPage1Interval = new System.Windows.Forms.Label();
            this.textBoxPage1Intervals = new System.Windows.Forms.TextBox();
            this.textBoxPage1Kol = new System.Windows.Forms.TextBox();
            this.buttonPage1StartDrawGrafics = new System.Windows.Forms.Button();
            this.tabPageSecondQuest = new System.Windows.Forms.TabPage();
            this.labelPage2Offset = new System.Windows.Forms.Label();
            this.textBoxPage2Offset = new System.Windows.Forms.TextBox();
            this.labelPage2WidthOrLambda = new System.Windows.Forms.Label();
            this.textBoxPage2WidthOrLambda = new System.Windows.Forms.TextBox();
            this.groupBoxPage2Methods = new System.Windows.Forms.GroupBox();
            this.radioButtonPage2Treangle = new System.Windows.Forms.RadioButton();
            this.radioButtonPage2Trap = new System.Windows.Forms.RadioButton();
            this.labelPage2Kol = new System.Windows.Forms.Label();
            this.labelIntervals = new System.Windows.Forms.Label();
            this.textBoxPage2Intervals = new System.Windows.Forms.TextBox();
            this.textBoxPage2Kol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageThirdQuest = new System.Windows.Forms.TabPage();
            this.chartGrafics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tabPageFirstQuest.SuspendLayout();
            this.groupBoxPage1Methods.SuspendLayout();
            this.tabPageSecondQuest.SuspendLayout();
            this.groupBoxPage2Methods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafics)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(251, 426);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFirstQuest
            // 
            this.tabPageFirstQuest.Controls.Add(this.groupBoxPage1Methods);
            this.tabPageFirstQuest.Controls.Add(this.labelPage1Kol);
            this.tabPageFirstQuest.Controls.Add(this.labelPage1Interval);
            this.tabPageFirstQuest.Controls.Add(this.textBoxPage1Intervals);
            this.tabPageFirstQuest.Controls.Add(this.textBoxPage1Kol);
            this.tabPageFirstQuest.Controls.Add(this.buttonPage1StartDrawGrafics);
            this.tabPageFirstQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageFirstQuest.Name = "tabPageFirstQuest";
            this.tabPageFirstQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFirstQuest.Size = new System.Drawing.Size(243, 400);
            this.tabPageFirstQuest.TabIndex = 0;
            this.tabPageFirstQuest.Text = "Равномерное";
            this.tabPageFirstQuest.UseVisualStyleBackColor = true;
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
            // labelPage1Kol
            // 
            this.labelPage1Kol.AutoSize = true;
            this.labelPage1Kol.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPage1Kol.Location = new System.Drawing.Point(21, 253);
            this.labelPage1Kol.Name = "labelPage1Kol";
            this.labelPage1Kol.Size = new System.Drawing.Size(159, 19);
            this.labelPage1Kol.TabIndex = 5;
            this.labelPage1Kol.Text = "Количество значений:";
            // 
            // labelPage1Interval
            // 
            this.labelPage1Interval.AutoSize = true;
            this.labelPage1Interval.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPage1Interval.Location = new System.Drawing.Point(21, 193);
            this.labelPage1Interval.Name = "labelPage1Interval";
            this.labelPage1Interval.Size = new System.Drawing.Size(175, 19);
            this.labelPage1Interval.TabIndex = 5;
            this.labelPage1Interval.Text = "Количество интервалов:";
            // 
            // textBoxPage1Intervals
            // 
            this.textBoxPage1Intervals.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage1Intervals.Location = new System.Drawing.Point(29, 220);
            this.textBoxPage1Intervals.Name = "textBoxPage1Intervals";
            this.textBoxPage1Intervals.Size = new System.Drawing.Size(100, 26);
            this.textBoxPage1Intervals.TabIndex = 4;
            // 
            // textBoxPage1Kol
            // 
            this.textBoxPage1Kol.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage1Kol.Location = new System.Drawing.Point(29, 279);
            this.textBoxPage1Kol.Name = "textBoxPage1Kol";
            this.textBoxPage1Kol.Size = new System.Drawing.Size(100, 26);
            this.textBoxPage1Kol.TabIndex = 4;
            // 
            // buttonPage1StartDrawGrafics
            // 
            this.buttonPage1StartDrawGrafics.Location = new System.Drawing.Point(23, 363);
            this.buttonPage1StartDrawGrafics.Name = "buttonPage1StartDrawGrafics";
            this.buttonPage1StartDrawGrafics.Size = new System.Drawing.Size(183, 23);
            this.buttonPage1StartDrawGrafics.TabIndex = 2;
            this.buttonPage1StartDrawGrafics.Text = "Принять";
            this.buttonPage1StartDrawGrafics.UseVisualStyleBackColor = true;
            this.buttonPage1StartDrawGrafics.Click += new System.EventHandler(this.buttonStartDrawGrafics_Click);
            // 
            // tabPageSecondQuest
            // 
            this.tabPageSecondQuest.Controls.Add(this.labelPage2Offset);
            this.tabPageSecondQuest.Controls.Add(this.textBoxPage2Offset);
            this.tabPageSecondQuest.Controls.Add(this.labelPage2WidthOrLambda);
            this.tabPageSecondQuest.Controls.Add(this.textBoxPage2WidthOrLambda);
            this.tabPageSecondQuest.Controls.Add(this.groupBoxPage2Methods);
            this.tabPageSecondQuest.Controls.Add(this.labelPage2Kol);
            this.tabPageSecondQuest.Controls.Add(this.labelIntervals);
            this.tabPageSecondQuest.Controls.Add(this.textBoxPage2Intervals);
            this.tabPageSecondQuest.Controls.Add(this.textBoxPage2Kol);
            this.tabPageSecondQuest.Controls.Add(this.button1);
            this.tabPageSecondQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageSecondQuest.Name = "tabPageSecondQuest";
            this.tabPageSecondQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSecondQuest.Size = new System.Drawing.Size(243, 400);
            this.tabPageSecondQuest.TabIndex = 1;
            this.tabPageSecondQuest.Text = "Симпсона";
            this.tabPageSecondQuest.UseVisualStyleBackColor = true;
            // 
            // labelPage2Offset
            // 
            this.labelPage2Offset.AutoSize = true;
            this.labelPage2Offset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPage2Offset.Location = new System.Drawing.Point(20, 282);
            this.labelPage2Offset.Name = "labelPage2Offset";
            this.labelPage2Offset.Size = new System.Drawing.Size(131, 17);
            this.labelPage2Offset.TabIndex = 19;
            this.labelPage2Offset.Text = "Смещение по оси Х";
            // 
            // textBoxPage2Offset
            // 
            this.textBoxPage2Offset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage2Offset.Location = new System.Drawing.Point(24, 302);
            this.textBoxPage2Offset.Name = "textBoxPage2Offset";
            this.textBoxPage2Offset.Size = new System.Drawing.Size(100, 25);
            this.textBoxPage2Offset.TabIndex = 18;
            // 
            // labelPage2WidthOrLambda
            // 
            this.labelPage2WidthOrLambda.AutoSize = true;
            this.labelPage2WidthOrLambda.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPage2WidthOrLambda.Location = new System.Drawing.Point(20, 234);
            this.labelPage2WidthOrLambda.Name = "labelPage2WidthOrLambda";
            this.labelPage2WidthOrLambda.Size = new System.Drawing.Size(210, 17);
            this.labelPage2WidthOrLambda.TabIndex = 17;
            this.labelPage2WidthOrLambda.Text = "Увеличение ширины диаграммы";
            // 
            // textBoxPage2WidthOrLambda
            // 
            this.textBoxPage2WidthOrLambda.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage2WidthOrLambda.Location = new System.Drawing.Point(23, 254);
            this.textBoxPage2WidthOrLambda.Name = "textBoxPage2WidthOrLambda";
            this.textBoxPage2WidthOrLambda.Size = new System.Drawing.Size(100, 25);
            this.textBoxPage2WidthOrLambda.TabIndex = 16;
            // 
            // groupBoxPage2Methods
            // 
            this.groupBoxPage2Methods.Controls.Add(this.radioButtonPage2Treangle);
            this.groupBoxPage2Methods.Controls.Add(this.radioButtonPage2Trap);
            this.groupBoxPage2Methods.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPage2Methods.Location = new System.Drawing.Point(24, 19);
            this.groupBoxPage2Methods.Name = "groupBoxPage2Methods";
            this.groupBoxPage2Methods.Size = new System.Drawing.Size(173, 112);
            this.groupBoxPage2Methods.TabIndex = 15;
            this.groupBoxPage2Methods.TabStop = false;
            this.groupBoxPage2Methods.Text = "Распределения:";
            // 
            // radioButtonPage2Treangle
            // 
            this.radioButtonPage2Treangle.AutoSize = true;
            this.radioButtonPage2Treangle.Location = new System.Drawing.Point(6, 70);
            this.radioButtonPage2Treangle.Name = "radioButtonPage2Treangle";
            this.radioButtonPage2Treangle.Size = new System.Drawing.Size(97, 19);
            this.radioButtonPage2Treangle.TabIndex = 7;
            this.radioButtonPage2Treangle.TabStop = true;
            this.radioButtonPage2Treangle.Text = "Треугольное";
            this.radioButtonPage2Treangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonPage2Trap
            // 
            this.radioButtonPage2Trap.AutoSize = true;
            this.radioButtonPage2Trap.Location = new System.Drawing.Point(6, 40);
            this.radioButtonPage2Trap.Name = "radioButtonPage2Trap";
            this.radioButtonPage2Trap.Size = new System.Drawing.Size(123, 19);
            this.radioButtonPage2Trap.TabIndex = 6;
            this.radioButtonPage2Trap.TabStop = true;
            this.radioButtonPage2Trap.Text = "Трапецеидальное";
            this.radioButtonPage2Trap.UseVisualStyleBackColor = true;
            // 
            // labelPage2Kol
            // 
            this.labelPage2Kol.AutoSize = true;
            this.labelPage2Kol.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPage2Kol.Location = new System.Drawing.Point(20, 186);
            this.labelPage2Kol.Name = "labelPage2Kol";
            this.labelPage2Kol.Size = new System.Drawing.Size(143, 17);
            this.labelPage2Kol.TabIndex = 13;
            this.labelPage2Kol.Text = "Количество значений:";
            // 
            // labelIntervals
            // 
            this.labelIntervals.AutoSize = true;
            this.labelIntervals.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIntervals.Location = new System.Drawing.Point(20, 140);
            this.labelIntervals.Name = "labelIntervals";
            this.labelIntervals.Size = new System.Drawing.Size(158, 17);
            this.labelIntervals.TabIndex = 14;
            this.labelIntervals.Text = "Количество интервалов:";
            // 
            // textBoxPage2Intervals
            // 
            this.textBoxPage2Intervals.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage2Intervals.Location = new System.Drawing.Point(23, 158);
            this.textBoxPage2Intervals.Name = "textBoxPage2Intervals";
            this.textBoxPage2Intervals.Size = new System.Drawing.Size(100, 25);
            this.textBoxPage2Intervals.TabIndex = 11;
            // 
            // textBoxPage2Kol
            // 
            this.textBoxPage2Kol.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPage2Kol.Location = new System.Drawing.Point(23, 206);
            this.textBoxPage2Kol.Name = "textBoxPage2Kol";
            this.textBoxPage2Kol.Size = new System.Drawing.Size(100, 25);
            this.textBoxPage2Kol.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Принять";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPageThirdQuest
            // 
            this.tabPageThirdQuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageThirdQuest.Name = "tabPageThirdQuest";
            this.tabPageThirdQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThirdQuest.Size = new System.Drawing.Size(243, 400);
            this.tabPageThirdQuest.TabIndex = 2;
            this.tabPageThirdQuest.Text = "3 задание";
            this.tabPageThirdQuest.UseVisualStyleBackColor = true;
            // 
            // chartGrafics
            // 
            chartArea2.Name = "ChartArea1";
            this.chartGrafics.ChartAreas.Add(chartArea2);
            this.chartGrafics.Location = new System.Drawing.Point(269, 34);
            this.chartGrafics.Name = "chartGrafics";
            this.chartGrafics.Size = new System.Drawing.Size(503, 400);
            this.chartGrafics.TabIndex = 3;
            this.chartGrafics.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.chartGrafics);
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
            this.groupBoxPage1Methods.ResumeLayout(false);
            this.groupBoxPage1Methods.PerformLayout();
            this.tabPageSecondQuest.ResumeLayout(false);
            this.tabPageSecondQuest.PerformLayout();
            this.groupBoxPage2Methods.ResumeLayout(false);
            this.groupBoxPage2Methods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFirstQuest;
        private System.Windows.Forms.TabPage tabPageSecondQuest;
        private System.Windows.Forms.Button buttonPage1StartDrawGrafics;
        private System.Windows.Forms.TabPage tabPageThirdQuest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrafics;
        private System.Windows.Forms.Label labelPage1Kol;
        private System.Windows.Forms.Label labelPage1Interval;
        private System.Windows.Forms.TextBox textBoxPage1Intervals;
        private System.Windows.Forms.TextBox textBoxPage1Kol;
        private System.Windows.Forms.GroupBox groupBoxPage1Methods;
        private System.Windows.Forms.RadioButton radioButtonKongryen;
        private System.Windows.Forms.RadioButton radioButtonMethodLemera;
        private System.Windows.Forms.RadioButton radioButtonDefaultGeneration;
        private System.Windows.Forms.Label labelPage2Offset;
        private System.Windows.Forms.TextBox textBoxPage2Offset;
        private System.Windows.Forms.Label labelPage2WidthOrLambda;
        private System.Windows.Forms.TextBox textBoxPage2WidthOrLambda;
        private System.Windows.Forms.GroupBox groupBoxPage2Methods;
        private System.Windows.Forms.RadioButton radioButtonPage2Treangle;
        private System.Windows.Forms.RadioButton radioButtonPage2Trap;
        private System.Windows.Forms.Label labelPage2Kol;
        private System.Windows.Forms.Label labelIntervals;
        private System.Windows.Forms.TextBox textBoxPage2Intervals;
        private System.Windows.Forms.TextBox textBoxPage2Kol;
        private System.Windows.Forms.Button button1;
    }
}

