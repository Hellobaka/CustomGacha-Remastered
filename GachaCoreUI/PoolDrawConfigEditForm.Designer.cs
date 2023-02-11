namespace GachaCoreUI
{
    partial class PoolDrawConfigEditForm
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
            this.XChangeValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.YChangeValue = new System.Windows.Forms.TextBox();
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
            this.CurrentPoolDisplay.Location = new System.Drawing.Point(15, 11);
            this.CurrentPoolDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentPoolDisplay.Name = "CurrentPoolDisplay";
            this.CurrentPoolDisplay.Size = new System.Drawing.Size(53, 20);
            this.CurrentPoolDisplay.TabIndex = 0;
            this.CurrentPoolDisplay.Text = "label1";
            // 
            // StartPointXValue
            // 
            this.StartPointXValue.Location = new System.Drawing.Point(15, 71);
            this.StartPointXValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartPointXValue.Name = "StartPointXValue";
            this.StartPointXValue.Size = new System.Drawing.Size(523, 27);
            this.StartPointXValue.TabIndex = 19;
            this.StartPointXValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "StartPointX";
            // 
            // StartPointYValue
            // 
            this.StartPointYValue.Location = new System.Drawing.Point(15, 131);
            this.StartPointYValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartPointYValue.Name = "StartPointYValue";
            this.StartPointYValue.Size = new System.Drawing.Size(523, 27);
            this.StartPointYValue.TabIndex = 21;
            this.StartPointYValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "StartPointY";
            // 
            // DrawYIntervalValue
            // 
            this.DrawYIntervalValue.Location = new System.Drawing.Point(15, 251);
            this.DrawYIntervalValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DrawYIntervalValue.Name = "DrawYIntervalValue";
            this.DrawYIntervalValue.Size = new System.Drawing.Size(523, 27);
            this.DrawYIntervalValue.TabIndex = 25;
            this.DrawYIntervalValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 227);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "DrawYInterval";
            // 
            // DrawXIntervalValue
            // 
            this.DrawXIntervalValue.Location = new System.Drawing.Point(15, 191);
            this.DrawXIntervalValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DrawXIntervalValue.Name = "DrawXIntervalValue";
            this.DrawXIntervalValue.Size = new System.Drawing.Size(523, 27);
            this.DrawXIntervalValue.TabIndex = 23;
            this.DrawXIntervalValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "DrawXInterval";
            // 
            // MaxXValue
            // 
            this.MaxXValue.Location = new System.Drawing.Point(15, 311);
            this.MaxXValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaxXValue.Name = "MaxXValue";
            this.MaxXValue.Size = new System.Drawing.Size(523, 27);
            this.MaxXValue.TabIndex = 27;
            this.MaxXValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "MaxX";
            // 
            // XChangeValue
            // 
            this.XChangeValue.Location = new System.Drawing.Point(15, 429);
            this.XChangeValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.XChangeValue.Name = "XChangeValue";
            this.XChangeValue.Size = new System.Drawing.Size(523, 27);
            this.XChangeValue.TabIndex = 31;
            this.XChangeValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 406);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "XChange";
            // 
            // YChangeValue
            // 
            this.YChangeValue.Location = new System.Drawing.Point(15, 369);
            this.YChangeValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.YChangeValue.Name = "YChangeValue";
            this.YChangeValue.Size = new System.Drawing.Size(523, 27);
            this.YChangeValue.TabIndex = 29;
            this.YChangeValue.Leave += new System.EventHandler(this.DrawConfigPropertyChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 346);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "YChange";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 468);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
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
            this.OrderOptionalValue.Location = new System.Drawing.Point(15, 492);
            this.OrderOptionalValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OrderOptionalValue.Name = "OrderOptionalValue";
            this.OrderOptionalValue.Size = new System.Drawing.Size(523, 28);
            this.OrderOptionalValue.TabIndex = 33;
            this.OrderOptionalValue.SelectedIndexChanged += new System.EventHandler(this.OrderOptionalValue_SelectedIndexChanged);
            // 
            // DefaultBtn
            // 
            this.DefaultBtn.Location = new System.Drawing.Point(15, 540);
            this.DefaultBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DefaultBtn.Name = "DefaultBtn";
            this.DefaultBtn.Size = new System.Drawing.Size(253, 32);
            this.DefaultBtn.TabIndex = 34;
            this.DefaultBtn.Text = "重置";
            this.DefaultBtn.UseVisualStyleBackColor = true;
            this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(287, 540);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(253, 32);
            this.SaveBtn.TabIndex = 35;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PoolDrawConfigEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 586);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DefaultBtn);
            this.Controls.Add(this.OrderOptionalValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.XChangeValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YChangeValue);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PoolDrawConfigEditForm";
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
        private TextBox XChangeValue;
        private Label label5;
        private TextBox YChangeValue;
        private Label label6;
        private Label label7;
        private ComboBox OrderOptionalValue;
        private Button DefaultBtn;
        private Button SaveBtn;
    }
}