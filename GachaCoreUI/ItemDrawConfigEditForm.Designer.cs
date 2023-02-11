namespace GachaCoreUI
{
    partial class ItemDrawConfigEditForm
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.DefaultBtn = new System.Windows.Forms.Button();
            this.DrawOrderValue = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ImagePointYValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ImagePointXValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BackgroundImageHeightValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackgroundImageWidthValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageHeightValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageWidthValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CurrentGachaItemDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(287, 478);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(253, 32);
            this.SaveBtn.TabIndex = 54;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // DefaultBtn
            // 
            this.DefaultBtn.Location = new System.Drawing.Point(15, 478);
            this.DefaultBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DefaultBtn.Name = "DefaultBtn";
            this.DefaultBtn.Size = new System.Drawing.Size(253, 32);
            this.DefaultBtn.TabIndex = 53;
            this.DefaultBtn.Text = "重置";
            this.DefaultBtn.UseVisualStyleBackColor = true;
            this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
            // 
            // DrawOrderValue
            // 
            this.DrawOrderValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawOrderValue.FormattingEnabled = true;
            this.DrawOrderValue.Items.AddRange(new object[] {
            "ImageAboveBackground",
            "ImageBelowBackground"});
            this.DrawOrderValue.Location = new System.Drawing.Point(15, 430);
            this.DrawOrderValue.Margin = new System.Windows.Forms.Padding(4);
            this.DrawOrderValue.Name = "DrawOrderValue";
            this.DrawOrderValue.Size = new System.Drawing.Size(523, 28);
            this.DrawOrderValue.TabIndex = 52;
            this.DrawOrderValue.SelectedIndexChanged += new System.EventHandler(this.DrawOptionalValue_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 406);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "DrawOrder";
            // 
            // ImagePointYValue
            // 
            this.ImagePointYValue.Location = new System.Drawing.Point(15, 371);
            this.ImagePointYValue.Margin = new System.Windows.Forms.Padding(4);
            this.ImagePointYValue.Name = "ImagePointYValue";
            this.ImagePointYValue.Size = new System.Drawing.Size(523, 27);
            this.ImagePointYValue.TabIndex = 48;
            this.ImagePointYValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 348);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "ImagePointY";
            // 
            // ImagePointXValue
            // 
            this.ImagePointXValue.Location = new System.Drawing.Point(15, 313);
            this.ImagePointXValue.Margin = new System.Windows.Forms.Padding(4);
            this.ImagePointXValue.Name = "ImagePointXValue";
            this.ImagePointXValue.Size = new System.Drawing.Size(523, 27);
            this.ImagePointXValue.TabIndex = 46;
            this.ImagePointXValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "ImagePointX";
            // 
            // BackgroundImageHeightValue
            // 
            this.BackgroundImageHeightValue.Location = new System.Drawing.Point(15, 253);
            this.BackgroundImageHeightValue.Margin = new System.Windows.Forms.Padding(4);
            this.BackgroundImageHeightValue.Name = "BackgroundImageHeightValue";
            this.BackgroundImageHeightValue.Size = new System.Drawing.Size(523, 27);
            this.BackgroundImageHeightValue.TabIndex = 44;
            this.BackgroundImageHeightValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "BackgroundImageHeight";
            // 
            // BackgroundImageWidthValue
            // 
            this.BackgroundImageWidthValue.Location = new System.Drawing.Point(15, 193);
            this.BackgroundImageWidthValue.Margin = new System.Windows.Forms.Padding(4);
            this.BackgroundImageWidthValue.Name = "BackgroundImageWidthValue";
            this.BackgroundImageWidthValue.Size = new System.Drawing.Size(523, 27);
            this.BackgroundImageWidthValue.TabIndex = 42;
            this.BackgroundImageWidthValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "BackgroundImageWidth";
            // 
            // ImageHeightValue
            // 
            this.ImageHeightValue.Location = new System.Drawing.Point(15, 133);
            this.ImageHeightValue.Margin = new System.Windows.Forms.Padding(4);
            this.ImageHeightValue.Name = "ImageHeightValue";
            this.ImageHeightValue.Size = new System.Drawing.Size(523, 27);
            this.ImageHeightValue.TabIndex = 40;
            this.ImageHeightValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "ImageHeight";
            // 
            // ImageWidthValue
            // 
            this.ImageWidthValue.Location = new System.Drawing.Point(15, 73);
            this.ImageWidthValue.Margin = new System.Windows.Forms.Padding(4);
            this.ImageWidthValue.Name = "ImageWidthValue";
            this.ImageWidthValue.Size = new System.Drawing.Size(523, 27);
            this.ImageWidthValue.TabIndex = 38;
            this.ImageWidthValue.Leave += new System.EventHandler(this.DrawConfig_PropertyChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "ImageWidth";
            // 
            // CurrentGachaItemDisplay
            // 
            this.CurrentGachaItemDisplay.AutoSize = true;
            this.CurrentGachaItemDisplay.Location = new System.Drawing.Point(15, 13);
            this.CurrentGachaItemDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentGachaItemDisplay.Name = "CurrentGachaItemDisplay";
            this.CurrentGachaItemDisplay.Size = new System.Drawing.Size(53, 20);
            this.CurrentGachaItemDisplay.TabIndex = 36;
            this.CurrentGachaItemDisplay.Text = "label1";
            // 
            // GachaItemDrawConfigEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 528);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DefaultBtn);
            this.Controls.Add(this.DrawOrderValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ImagePointYValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ImagePointXValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BackgroundImageHeightValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BackgroundImageWidthValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ImageHeightValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImageWidthValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CurrentGachaItemDisplay);
            this.Name = "GachaItemDrawConfigEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GachaItemDrawConfigEditForm";
            this.Load += new System.EventHandler(this.GachaItemDrawConfigEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveBtn;
        private Button DefaultBtn;
        private ComboBox DrawOrderValue;
        private Label label7;
        private TextBox ImagePointYValue;
        private Label label6;
        private TextBox ImagePointXValue;
        private Label label4;
        private TextBox BackgroundImageHeightValue;
        private Label label2;
        private TextBox BackgroundImageWidthValue;
        private Label label3;
        private TextBox ImageHeightValue;
        private Label label1;
        private TextBox ImageWidthValue;
        private Label label9;
        private Label CurrentGachaItemDisplay;
    }
}