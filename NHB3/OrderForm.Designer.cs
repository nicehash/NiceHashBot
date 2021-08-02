namespace NHB3
{
    partial class OrderForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboAlgorithm = new System.Windows.Forms.ComboBox();
            this.rbStd = new System.Windows.Forms.RadioButton();
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPools = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.priceLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLimit = new System.Windows.Forms.TextBox();
            this.limitLbl = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.currencyLbl = new System.Windows.Forms.Label();
            this.priceDetailsLbl = new System.Windows.Forms.Label();
            this.limitDetailsLbl = new System.Windows.Forms.Label();
            this.amountDetailsLbl = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.rbUSA = new System.Windows.Forms.RadioButton();
            this.rbEU = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.tbNewAmount = new System.Windows.Forms.TextBox();
            this.btnRefill = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbNewPrice = new System.Windows.Forms.TextBox();
            this.tbNewLimit = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbId = new System.Windows.Forms.TextBox();
            this.amountDetailsLbl2 = new System.Windows.Forms.Label();
            this.tbAvailableAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.limitDetailsLbl2 = new System.Windows.Forms.Label();
            this.priceDetailsLbl2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblPool = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblErrorCreate = new System.Windows.Forms.Label();
            this.rbEUN = new System.Windows.Forms.RadioButton();
            this.rbUSAE = new System.Windows.Forms.RadioButton();
            this.rbSA = new System.Windows.Forms.RadioButton();
            this.rbASIA = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Algorithm";
            // 
            // comboAlgorithm
            // 
            this.comboAlgorithm.FormattingEnabled = true;
            this.comboAlgorithm.Location = new System.Drawing.Point(67, 6);
            this.comboAlgorithm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboAlgorithm.Name = "comboAlgorithm";
            this.comboAlgorithm.Size = new System.Drawing.Size(341, 21);
            this.comboAlgorithm.TabIndex = 4;
            this.comboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithm_SelectedIndexChanged);
            // 
            // rbStd
            // 
            this.rbStd.AutoSize = true;
            this.rbStd.Checked = true;
            this.rbStd.Location = new System.Drawing.Point(57, 9);
            this.rbStd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbStd.Name = "rbStd";
            this.rbStd.Size = new System.Drawing.Size(66, 17);
            this.rbStd.TabIndex = 5;
            this.rbStd.TabStop = true;
            this.rbStd.Text = "standard";
            this.rbStd.UseVisualStyleBackColor = true;
            this.rbStd.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.Location = new System.Drawing.Point(125, 9);
            this.rbFixed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(47, 17);
            this.rbFixed.TabIndex = 6;
            this.rbFixed.Text = "fixed";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.Visible = false;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pool";
            // 
            // comboPools
            // 
            this.comboPools.FormattingEnabled = true;
            this.comboPools.Location = new System.Drawing.Point(67, 91);
            this.comboPools.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboPools.Name = "comboPools";
            this.comboPools.Size = new System.Drawing.Size(341, 21);
            this.comboPools.TabIndex = 8;
            this.comboPools.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(67, 114);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(207, 20);
            this.tbPrice.TabIndex = 10;
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(277, 116);
            this.priceLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(104, 13);
            this.priceLbl.TabIndex = 11;
            this.priceLbl.Text = "currency/speed/day";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Limit";
            // 
            // tbLimit
            // 
            this.tbLimit.Location = new System.Drawing.Point(67, 151);
            this.tbLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(207, 20);
            this.tbLimit.TabIndex = 13;
            this.tbLimit.TextChanged += new System.EventHandler(this.formChanged);
            // 
            // limitLbl
            // 
            this.limitLbl.AutoSize = true;
            this.limitLbl.Location = new System.Drawing.Point(277, 151);
            this.limitLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limitLbl.Name = "limitLbl";
            this.limitLbl.Size = new System.Drawing.Size(76, 13);
            this.limitLbl.TabIndex = 14;
            this.limitLbl.Text = "speed/second";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(67, 188);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(207, 20);
            this.tbAmount.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 187);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Amount";
            // 
            // currencyLbl
            // 
            this.currencyLbl.AutoSize = true;
            this.currencyLbl.Location = new System.Drawing.Point(277, 187);
            this.currencyLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currencyLbl.Name = "currencyLbl";
            this.currencyLbl.Size = new System.Drawing.Size(48, 13);
            this.currencyLbl.TabIndex = 17;
            this.currencyLbl.Text = "currency";
            // 
            // priceDetailsLbl
            // 
            this.priceDetailsLbl.AutoSize = true;
            this.priceDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.priceDetailsLbl.Location = new System.Drawing.Point(66, 134);
            this.priceDetailsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceDetailsLbl.Name = "priceDetailsLbl";
            this.priceDetailsLbl.Size = new System.Drawing.Size(35, 13);
            this.priceDetailsLbl.TabIndex = 18;
            this.priceDetailsLbl.Text = "[price]";
            // 
            // limitDetailsLbl
            // 
            this.limitDetailsLbl.AutoSize = true;
            this.limitDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitDetailsLbl.Location = new System.Drawing.Point(66, 171);
            this.limitDetailsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limitDetailsLbl.Name = "limitDetailsLbl";
            this.limitDetailsLbl.Size = new System.Drawing.Size(42, 13);
            this.limitDetailsLbl.TabIndex = 19;
            this.limitDetailsLbl.Text = "[speed]";
            // 
            // amountDetailsLbl
            // 
            this.amountDetailsLbl.AutoSize = true;
            this.amountDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.amountDetailsLbl.Location = new System.Drawing.Point(66, 208);
            this.amountDetailsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amountDetailsLbl.Name = "amountDetailsLbl";
            this.amountDetailsLbl.Size = new System.Drawing.Size(48, 13);
            this.amountDetailsLbl.TabIndex = 20;
            this.amountDetailsLbl.Text = "[amount]";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(8, 226);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(93, 21);
            this.btnCreate.TabIndex = 21;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // rbUSA
            // 
            this.rbUSA.AutoSize = true;
            this.rbUSA.Enabled = false;
            this.rbUSA.Location = new System.Drawing.Point(170, 9);
            this.rbUSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbUSA.Name = "rbUSA";
            this.rbUSA.Size = new System.Drawing.Size(61, 17);
            this.rbUSA.TabIndex = 23;
            this.rbUSA.Text = "USA-W";
            this.rbUSA.UseVisualStyleBackColor = true;
            this.rbUSA.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // rbEU
            // 
            this.rbEU.AutoSize = true;
            this.rbEU.Checked = true;
            this.rbEU.Enabled = false;
            this.rbEU.Location = new System.Drawing.Point(57, 9);
            this.rbEU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbEU.Name = "rbEU";
            this.rbEU.Size = new System.Drawing.Size(54, 17);
            this.rbEU.TabIndex = 22;
            this.rbEU.Text = "EU-W";
            this.rbEU.UseVisualStyleBackColor = true;
            this.rbEU.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Refill amount";
            // 
            // tbNewAmount
            // 
            this.tbNewAmount.Location = new System.Drawing.Point(95, 4);
            this.tbNewAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNewAmount.Name = "tbNewAmount";
            this.tbNewAmount.Size = new System.Drawing.Size(169, 20);
            this.tbNewAmount.TabIndex = 26;
            // 
            // btnRefill
            // 
            this.btnRefill.Location = new System.Drawing.Point(7, 47);
            this.btnRefill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefill.Name = "btnRefill";
            this.btnRefill.Size = new System.Drawing.Size(93, 21);
            this.btnRefill.TabIndex = 26;
            this.btnRefill.Text = "Refill";
            this.btnRefill.UseVisualStyleBackColor = true;
            this.btnRefill.Click += new System.EventHandler(this.btnRefill_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 6);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "New price";
            // 
            // tbNewPrice
            // 
            this.tbNewPrice.Location = new System.Drawing.Point(95, 4);
            this.tbNewPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNewPrice.Name = "tbNewPrice";
            this.tbNewPrice.Size = new System.Drawing.Size(169, 20);
            this.tbNewPrice.TabIndex = 28;
            // 
            // tbNewLimit
            // 
            this.tbNewLimit.Location = new System.Drawing.Point(95, 25);
            this.tbNewLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNewLimit.Name = "tbNewLimit";
            this.tbNewLimit.Size = new System.Drawing.Size(169, 20);
            this.tbNewLimit.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "New limit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(8, 255);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 96);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbId);
            this.tabPage1.Controls.Add(this.amountDetailsLbl2);
            this.tabPage1.Controls.Add(this.tbAvailableAmount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.tbNewAmount);
            this.tabPage1.Controls.Add(this.btnRefill);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(399, 70);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Refill order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(104, 49);
            this.tbId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(159, 20);
            this.tbId.TabIndex = 32;
            this.tbId.Visible = false;
            // 
            // amountDetailsLbl2
            // 
            this.amountDetailsLbl2.AutoSize = true;
            this.amountDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.amountDetailsLbl2.Location = new System.Drawing.Point(266, 7);
            this.amountDetailsLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amountDetailsLbl2.Name = "amountDetailsLbl2";
            this.amountDetailsLbl2.Size = new System.Drawing.Size(48, 13);
            this.amountDetailsLbl2.TabIndex = 31;
            this.amountDetailsLbl2.Text = "[amount]";
            // 
            // tbAvailableAmount
            // 
            this.tbAvailableAmount.Enabled = false;
            this.tbAvailableAmount.Location = new System.Drawing.Point(95, 25);
            this.tbAvailableAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAvailableAmount.Name = "tbAvailableAmount";
            this.tbAvailableAmount.Size = new System.Drawing.Size(169, 20);
            this.tbAvailableAmount.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Available amount";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.limitDetailsLbl2);
            this.tabPage2.Controls.Add(this.priceDetailsLbl2);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.tbNewPrice);
            this.tabPage2.Controls.Add(this.tbNewLimit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(399, 70);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // limitDetailsLbl2
            // 
            this.limitDetailsLbl2.AutoSize = true;
            this.limitDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitDetailsLbl2.Location = new System.Drawing.Point(266, 28);
            this.limitDetailsLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.limitDetailsLbl2.Name = "limitDetailsLbl2";
            this.limitDetailsLbl2.Size = new System.Drawing.Size(42, 13);
            this.limitDetailsLbl2.TabIndex = 31;
            this.limitDetailsLbl2.Text = "[speed]";
            // 
            // priceDetailsLbl2
            // 
            this.priceDetailsLbl2.AutoSize = true;
            this.priceDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.priceDetailsLbl2.Location = new System.Drawing.Point(266, 7);
            this.priceDetailsLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceDetailsLbl2.Name = "priceDetailsLbl2";
            this.priceDetailsLbl2.Size = new System.Drawing.Size(35, 13);
            this.priceDetailsLbl2.TabIndex = 31;
            this.priceDetailsLbl2.Text = "[price]";
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(303, 47);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 21);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(7, 47);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 21);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbASIA);
            this.groupBox1.Controls.Add(this.rbSA);
            this.groupBox1.Controls.Add(this.rbUSAE);
            this.groupBox1.Controls.Add(this.rbEUN);
            this.groupBox1.Controls.Add(this.rbEU);
            this.groupBox1.Controls.Add(this.rbUSA);
            this.groupBox1.Location = new System.Drawing.Point(11, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(396, 29);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Market";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCreate.Location = new System.Drawing.Point(105, 229);
            this.lblCreate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(120, 13);
            this.lblCreate.TabIndex = 28;
            this.lblCreate.Text = "Fixed order params error";
            this.lblCreate.Visible = false;
            // 
            // lblPool
            // 
            this.lblPool.AutoSize = true;
            this.lblPool.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPool.Location = new System.Drawing.Point(105, 229);
            this.lblPool.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPool.Name = "lblPool";
            this.lblPool.Size = new System.Drawing.Size(87, 13);
            this.lblPool.TabIndex = 29;
            this.lblPool.Text = "No selected pool";
            this.lblPool.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFixed);
            this.groupBox2.Controls.Add(this.rbStd);
            this.groupBox2.Location = new System.Drawing.Point(11, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(396, 29);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // lblErrorCreate
            // 
            this.lblErrorCreate.AutoSize = true;
            this.lblErrorCreate.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorCreate.Location = new System.Drawing.Point(309, 229);
            this.lblErrorCreate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorCreate.Name = "lblErrorCreate";
            this.lblErrorCreate.Size = new System.Drawing.Size(97, 13);
            this.lblErrorCreate.TabIndex = 30;
            this.lblErrorCreate.Text = "Error creating order";
            this.lblErrorCreate.Visible = false;
            // 
            // rbEUN
            // 
            this.rbEUN.AutoSize = true;
            this.rbEUN.Enabled = false;
            this.rbEUN.Location = new System.Drawing.Point(115, 9);
            this.rbEUN.Margin = new System.Windows.Forms.Padding(2);
            this.rbEUN.Name = "rbEUN";
            this.rbEUN.Size = new System.Drawing.Size(51, 17);
            this.rbEUN.TabIndex = 24;
            this.rbEUN.Text = "EU-N";
            this.rbEUN.UseVisualStyleBackColor = true;
            // 
            // rbUSAE
            // 
            this.rbUSAE.AutoSize = true;
            this.rbUSAE.Enabled = false;
            this.rbUSAE.Location = new System.Drawing.Point(235, 8);
            this.rbUSAE.Margin = new System.Windows.Forms.Padding(2);
            this.rbUSAE.Name = "rbUSAE";
            this.rbUSAE.Size = new System.Drawing.Size(57, 17);
            this.rbUSAE.TabIndex = 25;
            this.rbUSAE.Text = "USA-E";
            this.rbUSAE.UseVisualStyleBackColor = true;
            // 
            // rbSA
            // 
            this.rbSA.AutoSize = true;
            this.rbSA.Enabled = false;
            this.rbSA.Location = new System.Drawing.Point(296, 8);
            this.rbSA.Margin = new System.Windows.Forms.Padding(2);
            this.rbSA.Name = "rbSA";
            this.rbSA.Size = new System.Drawing.Size(39, 17);
            this.rbSA.TabIndex = 26;
            this.rbSA.Text = "SA";
            this.rbSA.UseVisualStyleBackColor = true;
            // 
            // rbASIA
            // 
            this.rbASIA.AutoSize = true;
            this.rbASIA.Enabled = false;
            this.rbASIA.Location = new System.Drawing.Point(339, 8);
            this.rbASIA.Margin = new System.Windows.Forms.Padding(2);
            this.rbASIA.Name = "rbASIA";
            this.rbASIA.Size = new System.Drawing.Size(49, 17);
            this.rbASIA.TabIndex = 27;
            this.rbASIA.Text = "ASIA";
            this.rbASIA.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 353);
            this.Controls.Add(this.lblErrorCreate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblPool);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.amountDetailsLbl);
            this.Controls.Add(this.limitDetailsLbl);
            this.Controls.Add(this.priceDetailsLbl);
            this.Controls.Add(this.currencyLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.limitLbl);
            this.Controls.Add(this.tbLimit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboPools);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboAlgorithm);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OrderForm";
            this.Text = "Order";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAlgorithm;
        private System.Windows.Forms.RadioButton rbStd;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPools;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label priceLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLimit;
        private System.Windows.Forms.Label limitLbl;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label currencyLbl;
        private System.Windows.Forms.Label priceDetailsLbl;
        private System.Windows.Forms.Label limitDetailsLbl;
        private System.Windows.Forms.Label amountDetailsLbl;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.RadioButton rbUSA;
        private System.Windows.Forms.RadioButton rbEU;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbNewAmount;
        private System.Windows.Forms.Button btnRefill;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbNewPrice;
        private System.Windows.Forms.TextBox tbNewLimit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblPool;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblErrorCreate;
        private System.Windows.Forms.TextBox tbAvailableAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label amountDetailsLbl2;
        private System.Windows.Forms.Label limitDetailsLbl2;
        private System.Windows.Forms.Label priceDetailsLbl2;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.RadioButton rbUSAE;
        private System.Windows.Forms.RadioButton rbEUN;
        private System.Windows.Forms.RadioButton rbASIA;
        private System.Windows.Forms.RadioButton rbSA;
    }
}