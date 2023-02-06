namespace GachaCoreUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ModeSelector = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pool_MultiGachaTextValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Pool_NameValue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Pool_DrawConfigBtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Pool_CreateTimeValue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Pool_RemarkValue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Pool_SingleGachaTextValue = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Pool_NewPicImgBtn = new System.Windows.Forms.Button();
            this.Pool_BackPicImgBtn = new System.Windows.Forms.Button();
            this.Pool_NewPicYValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Pool_NewPicXValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Pool_NewPicHeightValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Pool_NewPicWidthValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Pool_NewPicPathValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Pool_BackgroundImagePathValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Pool_BaodiCountValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Pool_PerGachaCostValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Pool_MultiGachaNumberValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Pool_MultiOrderValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pool_SingleGachaOrderValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pool_IDValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.PoolListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ModeSelector.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModeSelector
            // 
            this.ModeSelector.Controls.Add(this.tabPage1);
            this.ModeSelector.Controls.Add(this.tabPage2);
            this.ModeSelector.Controls.Add(this.tabPage3);
            this.ModeSelector.Location = new System.Drawing.Point(12, 12);
            this.ModeSelector.Name = "ModeSelector";
            this.ModeSelector.SelectedIndex = 0;
            this.ModeSelector.Size = new System.Drawing.Size(776, 506);
            this.ModeSelector.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.EditBtn);
            this.tabPage1.Controls.Add(this.DeleteBtn);
            this.tabPage1.Controls.Add(this.AddBtn);
            this.tabPage1.Controls.Add(this.PoolListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "卡池";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Pool_MultiGachaTextValue);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.Pool_NameValue);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.Pool_DrawConfigBtn);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.Pool_CreateTimeValue);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.Pool_RemarkValue);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.Pool_SingleGachaTextValue);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.Pool_NewPicImgBtn);
            this.panel1.Controls.Add(this.Pool_BackPicImgBtn);
            this.panel1.Controls.Add(this.Pool_NewPicYValue);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.Pool_NewPicXValue);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Pool_NewPicHeightValue);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Pool_NewPicWidthValue);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.Pool_NewPicPathValue);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.Pool_BackgroundImagePathValue);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.Pool_BaodiCountValue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Pool_PerGachaCostValue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Pool_MultiGachaNumberValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Pool_MultiOrderValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Pool_SingleGachaOrderValue);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Pool_IDValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(271, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 472);
            this.panel1.TabIndex = 4;
            // 
            // Pool_MultiGachaTextValue
            // 
            this.Pool_MultiGachaTextValue.Location = new System.Drawing.Point(13, 627);
            this.Pool_MultiGachaTextValue.Name = "Pool_MultiGachaTextValue";
            this.Pool_MultiGachaTextValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_MultiGachaTextValue.TabIndex = 37;
            this.Pool_MultiGachaTextValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 611);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 17);
            this.label18.TabIndex = 36;
            this.label18.Text = "MultiGachaText";
            // 
            // Pool_NameValue
            // 
            this.Pool_NameValue.Location = new System.Drawing.Point(14, 71);
            this.Pool_NameValue.Name = "Pool_NameValue";
            this.Pool_NameValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_NameValue.TabIndex = 35;
            this.Pool_NameValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 17);
            this.label17.TabIndex = 34;
            this.label17.Text = "Name";
            // 
            // Pool_DrawConfigBtn
            // 
            this.Pool_DrawConfigBtn.Location = new System.Drawing.Point(15, 767);
            this.Pool_DrawConfigBtn.Name = "Pool_DrawConfigBtn";
            this.Pool_DrawConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.Pool_DrawConfigBtn.TabIndex = 33;
            this.Pool_DrawConfigBtn.Text = "修改";
            this.Pool_DrawConfigBtn.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 744);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "DrawConfig";
            // 
            // Pool_CreateTimeValue
            // 
            this.Pool_CreateTimeValue.Enabled = false;
            this.Pool_CreateTimeValue.Location = new System.Drawing.Point(13, 713);
            this.Pool_CreateTimeValue.Name = "Pool_CreateTimeValue";
            this.Pool_CreateTimeValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_CreateTimeValue.TabIndex = 31;
            this.Pool_CreateTimeValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 697);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "CreateTime";
            // 
            // Pool_RemarkValue
            // 
            this.Pool_RemarkValue.Location = new System.Drawing.Point(13, 670);
            this.Pool_RemarkValue.Name = "Pool_RemarkValue";
            this.Pool_RemarkValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_RemarkValue.TabIndex = 29;
            this.Pool_RemarkValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 654);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Remark";
            // 
            // Pool_SingleGachaTextValue
            // 
            this.Pool_SingleGachaTextValue.Location = new System.Drawing.Point(13, 583);
            this.Pool_SingleGachaTextValue.Name = "Pool_SingleGachaTextValue";
            this.Pool_SingleGachaTextValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_SingleGachaTextValue.TabIndex = 27;
            this.Pool_SingleGachaTextValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 567);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 17);
            this.label16.TabIndex = 26;
            this.label16.Text = "SingleGachaText";
            // 
            // Pool_NewPicImgBtn
            // 
            this.Pool_NewPicImgBtn.Location = new System.Drawing.Point(305, 365);
            this.Pool_NewPicImgBtn.Name = "Pool_NewPicImgBtn";
            this.Pool_NewPicImgBtn.Size = new System.Drawing.Size(75, 23);
            this.Pool_NewPicImgBtn.TabIndex = 25;
            this.Pool_NewPicImgBtn.Text = "浏览";
            this.Pool_NewPicImgBtn.UseVisualStyleBackColor = true;
            this.Pool_NewPicImgBtn.Click += new System.EventHandler(this.Pool_NewPicImgBtn_Click);
            // 
            // Pool_BackPicImgBtn
            // 
            this.Pool_BackPicImgBtn.Location = new System.Drawing.Point(305, 324);
            this.Pool_BackPicImgBtn.Name = "Pool_BackPicImgBtn";
            this.Pool_BackPicImgBtn.Size = new System.Drawing.Size(75, 23);
            this.Pool_BackPicImgBtn.TabIndex = 24;
            this.Pool_BackPicImgBtn.Text = "浏览";
            this.Pool_BackPicImgBtn.UseVisualStyleBackColor = true;
            this.Pool_BackPicImgBtn.Click += new System.EventHandler(this.Pool_BackPicImgBtn_Click);
            // 
            // Pool_NewPicYValue
            // 
            this.Pool_NewPicYValue.Location = new System.Drawing.Point(13, 538);
            this.Pool_NewPicYValue.Name = "Pool_NewPicYValue";
            this.Pool_NewPicYValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_NewPicYValue.TabIndex = 23;
            this.Pool_NewPicYValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 522);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "NewPicY";
            // 
            // Pool_NewPicXValue
            // 
            this.Pool_NewPicXValue.Location = new System.Drawing.Point(13, 496);
            this.Pool_NewPicXValue.Name = "Pool_NewPicXValue";
            this.Pool_NewPicXValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_NewPicXValue.TabIndex = 21;
            this.Pool_NewPicXValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "NewPicX";
            // 
            // Pool_NewPicHeightValue
            // 
            this.Pool_NewPicHeightValue.Location = new System.Drawing.Point(13, 453);
            this.Pool_NewPicHeightValue.Name = "Pool_NewPicHeightValue";
            this.Pool_NewPicHeightValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_NewPicHeightValue.TabIndex = 19;
            this.Pool_NewPicHeightValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "NewPicHeight";
            // 
            // Pool_NewPicWidthValue
            // 
            this.Pool_NewPicWidthValue.Location = new System.Drawing.Point(13, 410);
            this.Pool_NewPicWidthValue.Name = "Pool_NewPicWidthValue";
            this.Pool_NewPicWidthValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_NewPicWidthValue.TabIndex = 17;
            this.Pool_NewPicWidthValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 394);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "NewPicWidth";
            // 
            // Pool_NewPicPathValue
            // 
            this.Pool_NewPicPathValue.Location = new System.Drawing.Point(13, 366);
            this.Pool_NewPicPathValue.Name = "Pool_NewPicPathValue";
            this.Pool_NewPicPathValue.Size = new System.Drawing.Size(286, 23);
            this.Pool_NewPicPathValue.TabIndex = 15;
            this.Pool_NewPicPathValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "NewPicPath";
            // 
            // Pool_BackgroundImagePathValue
            // 
            this.Pool_BackgroundImagePathValue.Location = new System.Drawing.Point(13, 325);
            this.Pool_BackgroundImagePathValue.Name = "Pool_BackgroundImagePathValue";
            this.Pool_BackgroundImagePathValue.Size = new System.Drawing.Size(286, 23);
            this.Pool_BackgroundImagePathValue.TabIndex = 13;
            this.Pool_BackgroundImagePathValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "BackgroundImagePath";
            // 
            // Pool_BaodiCountValue
            // 
            this.Pool_BaodiCountValue.Location = new System.Drawing.Point(13, 283);
            this.Pool_BaodiCountValue.Name = "Pool_BaodiCountValue";
            this.Pool_BaodiCountValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_BaodiCountValue.TabIndex = 11;
            this.Pool_BaodiCountValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "BaodiCount";
            // 
            // Pool_PerGachaCostValue
            // 
            this.Pool_PerGachaCostValue.Location = new System.Drawing.Point(13, 240);
            this.Pool_PerGachaCostValue.Name = "Pool_PerGachaCostValue";
            this.Pool_PerGachaCostValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_PerGachaCostValue.TabIndex = 9;
            this.Pool_PerGachaCostValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "PerGachaCost";
            // 
            // Pool_MultiGachaNumberValue
            // 
            this.Pool_MultiGachaNumberValue.Location = new System.Drawing.Point(13, 197);
            this.Pool_MultiGachaNumberValue.Name = "Pool_MultiGachaNumberValue";
            this.Pool_MultiGachaNumberValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_MultiGachaNumberValue.TabIndex = 7;
            this.Pool_MultiGachaNumberValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "MultiGachaNumber";
            // 
            // Pool_MultiOrderValue
            // 
            this.Pool_MultiOrderValue.Location = new System.Drawing.Point(13, 153);
            this.Pool_MultiOrderValue.Name = "Pool_MultiOrderValue";
            this.Pool_MultiOrderValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_MultiOrderValue.TabIndex = 5;
            this.Pool_MultiOrderValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "MultiOrder";
            // 
            // Pool_SingleGachaOrderValue
            // 
            this.Pool_SingleGachaOrderValue.Location = new System.Drawing.Point(13, 112);
            this.Pool_SingleGachaOrderValue.Name = "Pool_SingleGachaOrderValue";
            this.Pool_SingleGachaOrderValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_SingleGachaOrderValue.TabIndex = 3;
            this.Pool_SingleGachaOrderValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "SingleGachaOrder";
            // 
            // Pool_IDValue
            // 
            this.Pool_IDValue.Enabled = false;
            this.Pool_IDValue.Location = new System.Drawing.Point(13, 27);
            this.Pool_IDValue.Name = "Pool_IDValue";
            this.Pool_IDValue.Size = new System.Drawing.Size(367, 23);
            this.Pool_IDValue.TabIndex = 1;
            this.Pool_IDValue.TextChanged += new System.EventHandler(this.Pool_Property_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(687, 58);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 46);
            this.EditBtn.TabIndex = 3;
            this.EditBtn.Text = "编辑";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(687, 110);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 46);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "删除";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(687, 6);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 46);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "添加";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // PoolListBox
            // 
            this.PoolListBox.FormattingEnabled = true;
            this.PoolListBox.ItemHeight = 17;
            this.PoolListBox.Location = new System.Drawing.Point(6, 6);
            this.PoolListBox.Name = "PoolListBox";
            this.PoolListBox.Size = new System.Drawing.Size(259, 463);
            this.PoolListBox.TabIndex = 0;
            this.PoolListBox.SelectedIndexChanged += new System.EventHandler(this.PoolListBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 476);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "目录";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 476);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "单例";
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            this.FileDialog.Filter = "JPG 图片|*.jpg|PNG 图片|*.png|所有文件|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.ModeSelector);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗口";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ModeSelector.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ModeSelector;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox PoolListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox Pool_MultiOrderValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Pool_SingleGachaOrderValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Pool_IDValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pool_PerGachaCostValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Pool_MultiGachaNumberValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Pool_BaodiCountValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Pool_NewPicXValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Pool_NewPicHeightValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Pool_NewPicWidthValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Pool_NewPicPathValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Pool_BackgroundImagePathValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Pool_NewPicYValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Pool_NewPicImgBtn;
        private System.Windows.Forms.Button Pool_BackPicImgBtn;
        private System.Windows.Forms.TextBox Pool_CreateTimeValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Pool_RemarkValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Pool_SingleGachaTextValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Pool_DrawConfigBtn;
        private TextBox Pool_NameValue;
        private Label label17;
        private TextBox Pool_MultiGachaTextValue;
        private Label label18;
        private OpenFileDialog FileDialog;
    }
}