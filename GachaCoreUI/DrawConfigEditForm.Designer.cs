namespace GachaCoreUI
{
    partial class DrawConfigEditForm
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
            this.CurrentPoolDisplay = new System.Windows.Forms.Label();
            this.StartPointXValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StartPointYValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DrawYIntervalValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawXIntervalValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxXValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.XChangeValueValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.YChangeValueValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OrderOptionalValue = new System.Windows.Forms.ComboBox();
            this.DefaultBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentPoolDisplay
            // 
            this.CurrentPoolDisplay.AutoSize = true;
            this.CurrentPoolDisplay.Location = new System.Drawing.Point(12, 9);
            this.CurrentPoolDisplay.Name = "CurrentPoolDisplay";
            this.CurrentPoolDisplay.Size = new System.Drawing.Size(43, 17);
            this.CurrentPoolDisplay.TabIndex = 0;
            this.CurrentPoolDisplay.Text = "label1";
            // 
            // StartPointXValue
            // 
            this.StartPointXValue.Location = new System.Drawing.Point(12, 60);
            this.StartPointXValue.Name = "StartPointXValue";
            this.StartPointXValue.Size = new System.Drawing.Size(408, 23);
            this.StartPointXValue.TabIndex = 19;
            this.StartPointXValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "StartPointX";
            // 
            // StartPointYValue
            // 
            this.StartPointYValue.Location = new System.Drawing.Point(12, 111);
            this.StartPointYValue.Name = "StartPointYValue";
            this.StartPointYValue.Size = new System.Drawing.Size(408, 23);
            this.StartPointYValue.TabIndex = 21;
            this.StartPointYValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "StartPointY";
            // 
            // DrawYIntervalValue
            // 
            this.DrawYIntervalValue.Location = new System.Drawing.Point(12, 213);
            this.DrawYIntervalValue.Name = "DrawYIntervalValue";
            this.DrawYIntervalValue.Size = new System.Drawing.Size(408, 23);
            this.DrawYIntervalValue.TabIndex = 25;
            this.DrawYIntervalValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "DrawYInterval";
            // 
            // DrawXIntervalValue
            // 
            this.DrawXIntervalValue.Location = new System.Drawing.Point(12, 162);
            this.DrawXIntervalValue.Name = "DrawXIntervalValue";
            this.DrawXIntervalValue.Size = new System.Drawing.Size(408, 23);
            this.DrawXIntervalValue.TabIndex = 23;
            this.DrawXIntervalValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "DrawXInterval";
            // 
            // MaxXValue
            // 
            this.MaxXValue.Location = new System.Drawing.Point(12, 264);
            this.MaxXValue.Name = "MaxXValue";
            this.MaxXValue.Size = new System.Drawing.Size(408, 23);
            this.MaxXValue.TabIndex = 27;
            this.MaxXValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "MaxX";
            // 
            // XChangeValueValue
            // 
            this.XChangeValueValue.Location = new System.Drawing.Point(12, 365);
            this.XChangeValueValue.Name = "XChangeValueValue";
            this.XChangeValueValue.Size = new System.Drawing.Size(408, 23);
            this.XChangeValueValue.TabIndex = 31;
            this.XChangeValueValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "XChangeValue";
            // 
            // YChangeValueValue
            // 
            this.YChangeValueValue.Location = new System.Drawing.Point(12, 314);
            this.YChangeValueValue.Name = "YChangeValueValue";
            this.YChangeValueValue.Size = new System.Drawing.Size(408, 23);
            this.YChangeValueValue.TabIndex = 29;
            this.YChangeValueValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "YChangeValue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "OrderOptional";
            // 
            // OrderOptionalValue
            // 
            this.OrderOptionalValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrderOptionalValue.FormattingEnabled = true;
            this.OrderOptionalValue.Items.AddRange(new object[] {
            "Increasing",
            "Descending",
            "None"});
            this.OrderOptionalValue.Location = new System.Drawing.Point(12, 418);
            this.OrderOptionalValue.Name = "OrderOptionalValue";
            this.OrderOptionalValue.Size = new System.Drawing.Size(408, 25);
            this.OrderOptionalValue.TabIndex = 33;
            this.OrderOptionalValue.SelectedIndexChanged += new System.EventHandler(this.OrderOptionalValue_SelectedIndexChanged);
            // 
            // DefaultBtn
            // 
            this.DefaultBtn.Location = new System.Drawing.Point(12, 459);
            this.DefaultBtn.Name = "DefaultBtn";
            this.DefaultBtn.Size = new System.Drawing.Size(197, 27);
            this.DefaultBtn.TabIndex = 34;
            this.DefaultBtn.Text = "重置";
            this.DefaultBtn.UseVisualStyleBackColor = true;
            this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(223, 459);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(197, 27);
            this.SaveBtn.TabIndex = 35;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // DrawConfigEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 498);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DefaultBtn);
            this.Controls.Add(this.OrderOptionalValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.XChangeValueValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YChangeValueValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MaxXValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DrawYIntervalValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DrawXIntervalValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartPointYValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartPointXValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CurrentPoolDisplay);
            this.Name = "DrawConfigEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DrawConfigEditForm";
            this.Load += new System.EventHandler(this.DrawConfigEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label CurrentPoolDisplay;
        private TextBox StartPointXValue;
        private Label label9;
        private TextBox StartPointYValue;
        private Label label1;
        private TextBox DrawYIntervalValue;
        private Label label2;
        private TextBox DrawXIntervalValue;
        private Label label3;
        private TextBox MaxXValue;
        private Label label4;
        private TextBox XChangeValueValue;
        private Label label5;
        private TextBox YChangeValueValue;
        private Label label6;
        private Label label7;
        private ComboBox OrderOptionalValue;
        private Button DefaultBtn;
        private Button SaveBtn;
    }
}