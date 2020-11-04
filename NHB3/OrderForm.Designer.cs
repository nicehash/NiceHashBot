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
            this.tbAvailableAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblPool = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblErrorCreate = new System.Windows.Forms.Label();
            this.amountDetailsLbl2 = new System.Windows.Forms.Label();
            this.priceDetailsLbl2 = new System.Windows.Forms.Label();
            this.limitDetailsLbl2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
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
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Algorithm";
            // 
            // comboAlgorithm
            // 
            this.comboAlgorithm.FormattingEnabled = true;
            this.comboAlgorithm.Location = new System.Drawing.Point(101, 9);
            this.comboAlgorithm.Name = "comboAlgorithm";
            this.comboAlgorithm.Size = new System.Drawing.Size(509, 28);
            this.comboAlgorithm.TabIndex = 4;
            this.comboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithm_SelectedIndexChanged);
            // 
            // rbStd
            // 
            this.rbStd.AutoSize = true;
            this.rbStd.Checked = true;
            this.rbStd.Location = new System.Drawing.Point(85, 14);
            this.rbStd.Name = "rbStd";
            this.rbStd.Size = new System.Drawing.Size(97, 24);
            this.rbStd.TabIndex = 5;
            this.rbStd.TabStop = true;
            this.rbStd.Text = "standard";
            this.rbStd.UseVisualStyleBackColor = true;
            this.rbStd.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.Location = new System.Drawing.Point(188, 14);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(67, 24);
            this.rbFixed.TabIndex = 6;
            this.rbFixed.Text = "fixed";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pool";
            // 
            // comboPools
            // 
            this.comboPools.FormattingEnabled = true;
            this.comboPools.Location = new System.Drawing.Point(101, 140);
            this.comboPools.Name = "comboPools";
            this.comboPools.Size = new System.Drawing.Size(509, 28);
            this.comboPools.TabIndex = 8;
            this.comboPools.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(101, 175);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(308, 26);
            this.tbPrice.TabIndex = 10;
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(415, 178);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(146, 20);
            this.priceLbl.TabIndex = 11;
            this.priceLbl.Text = "currency/speed/day";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Limit";
            // 
            // tbLimit
            // 
            this.tbLimit.Location = new System.Drawing.Point(101, 232);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(308, 26);
            this.tbLimit.TabIndex = 13;
            this.tbLimit.TextChanged += new System.EventHandler(this.formChanged);
            // 
            // limitLbl
            // 
            this.limitLbl.AutoSize = true;
            this.limitLbl.Location = new System.Drawing.Point(415, 233);
            this.limitLbl.Name = "limitLbl";
            this.limitLbl.Size = new System.Drawing.Size(109, 20);
            this.limitLbl.TabIndex = 14;
            this.limitLbl.Text = "speed/second";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(101, 289);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(308, 26);
            this.tbAmount.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Amount";
            // 
            // currencyLbl
            // 
            this.currencyLbl.AutoSize = true;
            this.currencyLbl.Location = new System.Drawing.Point(415, 288);
            this.currencyLbl.Name = "currencyLbl";
            this.currencyLbl.Size = new System.Drawing.Size(69, 20);
            this.currencyLbl.TabIndex = 17;
            this.currencyLbl.Text = "currency";
            // 
            // priceDetailsLbl
            // 
            this.priceDetailsLbl.AutoSize = true;
            this.priceDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.priceDetailsLbl.Location = new System.Drawing.Point(99, 206);
            this.priceDetailsLbl.Name = "priceDetailsLbl";
            this.priceDetailsLbl.Size = new System.Drawing.Size(47, 17);
            this.priceDetailsLbl.TabIndex = 18;
            this.priceDetailsLbl.Text = "[price]";
            // 
            // limitDetailsLbl
            // 
            this.limitDetailsLbl.AutoSize = true;
            this.limitDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitDetailsLbl.Location = new System.Drawing.Point(99, 263);
            this.limitDetailsLbl.Name = "limitDetailsLbl";
            this.limitDetailsLbl.Size = new System.Drawing.Size(55, 17);
            this.limitDetailsLbl.TabIndex = 19;
            this.limitDetailsLbl.Text = "[speed]";
            // 
            // amountDetailsLbl
            // 
            this.amountDetailsLbl.AutoSize = true;
            this.amountDetailsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDetailsLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.amountDetailsLbl.Location = new System.Drawing.Point(99, 320);
            this.amountDetailsLbl.Name = "amountDetailsLbl";
            this.amountDetailsLbl.Size = new System.Drawing.Size(63, 17);
            this.amountDetailsLbl.TabIndex = 20;
            this.amountDetailsLbl.Text = "[amount]";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 347);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(140, 32);
            this.btnCreate.TabIndex = 21;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // rbUSA
            // 
            this.rbUSA.AutoSize = true;
            this.rbUSA.Location = new System.Drawing.Point(148, 14);
            this.rbUSA.Name = "rbUSA";
            this.rbUSA.Size = new System.Drawing.Size(68, 24);
            this.rbUSA.TabIndex = 23;
            this.rbUSA.Text = "USA";
            this.rbUSA.UseVisualStyleBackColor = true;
            this.rbUSA.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // rbEU
            // 
            this.rbEU.AutoSize = true;
            this.rbEU.Checked = true;
            this.rbEU.Location = new System.Drawing.Point(85, 14);
            this.rbEU.Name = "rbEU";
            this.rbEU.Size = new System.Drawing.Size(57, 24);
            this.rbEU.TabIndex = 22;
            this.rbEU.TabStop = true;
            this.rbEU.Text = "EU";
            this.rbEU.UseVisualStyleBackColor = true;
            this.rbEU.CheckedChanged += new System.EventHandler(this.formChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Refill amount";
            // 
            // tbNewAmount
            // 
            this.tbNewAmount.Location = new System.Drawing.Point(142, 6);
            this.tbNewAmount.Name = "tbNewAmount";
            this.tbNewAmount.Size = new System.Drawing.Size(251, 26);
            this.tbNewAmount.TabIndex = 26;
            // 
            // btnRefill
            // 
            this.btnRefill.Location = new System.Drawing.Point(10, 72);
            this.btnRefill.Name = "btnRefill";
            this.btnRefill.Size = new System.Drawing.Size(140, 32);
            this.btnRefill.TabIndex = 26;
            this.btnRefill.Text = "Refill";
            this.btnRefill.UseVisualStyleBackColor = true;
            this.btnRefill.Click += new System.EventHandler(this.btnRefill_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "New price";
            // 
            // tbNewPrice
            // 
            this.tbNewPrice.Location = new System.Drawing.Point(142, 6);
            this.tbNewPrice.Name = "tbNewPrice";
            this.tbNewPrice.Size = new System.Drawing.Size(251, 26);
            this.tbNewPrice.TabIndex = 28;
            // 
            // tbNewLimit
            // 
            this.tbNewLimit.Location = new System.Drawing.Point(142, 38);
            this.tbNewLimit.Name = "tbNewLimit";
            this.tbNewLimit.Size = new System.Drawing.Size(251, 26);
            this.tbNewLimit.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "New limit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 392);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 147);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 114);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Refill order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbAvailableAmount
            // 
            this.tbAvailableAmount.Enabled = false;
            this.tbAvailableAmount.Location = new System.Drawing.Point(142, 38);
            this.tbAvailableAmount.Name = "tbAvailableAmount";
            this.tbAvailableAmount.Size = new System.Drawing.Size(251, 26);
            this.tbAvailableAmount.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 114);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(455, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 32);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(10, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 32);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEU);
            this.groupBox1.Controls.Add(this.rbUSA);
            this.groupBox1.Location = new System.Drawing.Point(16, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 44);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Market";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCreate.Location = new System.Drawing.Point(158, 353);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(182, 20);
            this.lblCreate.TabIndex = 28;
            this.lblCreate.Text = "Fixed order params error";
            this.lblCreate.Visible = false;
            // 
            // lblPool
            // 
            this.lblPool.AutoSize = true;
            this.lblPool.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPool.Location = new System.Drawing.Point(158, 353);
            this.lblPool.Name = "lblPool";
            this.lblPool.Size = new System.Drawing.Size(127, 20);
            this.lblPool.TabIndex = 29;
            this.lblPool.Text = "No selected pool";
            this.lblPool.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFixed);
            this.groupBox2.Controls.Add(this.rbStd);
            this.groupBox2.Location = new System.Drawing.Point(16, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 44);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // lblErrorCreate
            // 
            this.lblErrorCreate.AutoSize = true;
            this.lblErrorCreate.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorCreate.Location = new System.Drawing.Point(464, 353);
            this.lblErrorCreate.Name = "lblErrorCreate";
            this.lblErrorCreate.Size = new System.Drawing.Size(146, 20);
            this.lblErrorCreate.TabIndex = 30;
            this.lblErrorCreate.Text = "Error creating order";
            this.lblErrorCreate.Visible = false;
            // 
            // amountDetailsLbl2
            // 
            this.amountDetailsLbl2.AutoSize = true;
            this.amountDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.amountDetailsLbl2.Location = new System.Drawing.Point(399, 11);
            this.amountDetailsLbl2.Name = "amountDetailsLbl2";
            this.amountDetailsLbl2.Size = new System.Drawing.Size(63, 17);
            this.amountDetailsLbl2.TabIndex = 31;
            this.amountDetailsLbl2.Text = "[amount]";
            // 
            // priceDetailsLbl2
            // 
            this.priceDetailsLbl2.AutoSize = true;
            this.priceDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.priceDetailsLbl2.Location = new System.Drawing.Point(399, 11);
            this.priceDetailsLbl2.Name = "priceDetailsLbl2";
            this.priceDetailsLbl2.Size = new System.Drawing.Size(47, 17);
            this.priceDetailsLbl2.TabIndex = 31;
            this.priceDetailsLbl2.Text = "[price]";
            // 
            // limitDetailsLbl2
            // 
            this.limitDetailsLbl2.AutoSize = true;
            this.limitDetailsLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitDetailsLbl2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitDetailsLbl2.Location = new System.Drawing.Point(399, 43);
            this.limitDetailsLbl2.Name = "limitDetailsLbl2";
            this.limitDetailsLbl2.Size = new System.Drawing.Size(55, 17);
            this.limitDetailsLbl2.TabIndex = 31;
            this.limitDetailsLbl2.Text = "[speed]";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(156, 75);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(237, 26);
            this.tbId.TabIndex = 32;
            this.tbId.Visible = false;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 543);
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
    }
}