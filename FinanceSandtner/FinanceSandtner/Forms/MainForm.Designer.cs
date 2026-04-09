namespace FinanceSandtner
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridViewTransaction = new DataGridView();
            btnAddTransaction = new Button();
            btnHandleMembers = new Button();
            btnHandleCategories = new Button();
            btnCharts = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            lblAmountMin = new Label();
            lblAmountMax = new Label();
            label4 = new Label();
            pnlFilter = new Panel();
            btnClearFilter = new Button();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            cmbTypeFilter = new ComboBox();
            cmbCategoryFilter = new ComboBox();
            trkAmountMax = new TrackBar();
            txtNameFilter = new TextBox();
            trkAmountMin = new TrackBar();
            btnToggleFilter = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAvgExp = new Label();
            lblThisMonthExp = new Label();
            lblTopEarner = new Label();
            lblTopSpender = new Label();
            lblTopIncome = new Label();
            lblTopExpense = new Label();
            lblTopCat = new Label();
            lblTurnover = new Label();
            labelLeftOver = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransaction).BeginInit();
            groupBox1.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkAmountMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkAmountMin).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTransaction
            // 
            dataGridViewTransaction.AllowDrop = true;
            dataGridViewTransaction.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewTransaction.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTransaction.BackgroundColor = SystemColors.ScrollBar;
            dataGridViewTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransaction.Location = new Point(0, 29);
            dataGridViewTransaction.Name = "dataGridViewTransaction";
            dataGridViewTransaction.Size = new Size(756, 156);
            dataGridViewTransaction.TabIndex = 0;
            dataGridViewTransaction.CellDoubleClick += dataGridViewTransaction_CellDoubleClick_1;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnAddTransaction.ForeColor = Color.Black;
            btnAddTransaction.Location = new Point(285, 35);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(133, 35);
            btnAddTransaction.TabIndex = 3;
            btnAddTransaction.Text = "Nová transakce";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // btnHandleMembers
            // 
            btnHandleMembers.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnHandleMembers.ForeColor = Color.Black;
            btnHandleMembers.Location = new Point(192, 35);
            btnHandleMembers.Name = "btnHandleMembers";
            btnHandleMembers.Size = new Size(86, 35);
            btnHandleMembers.TabIndex = 4;
            btnHandleMembers.Text = "Členové";
            btnHandleMembers.UseVisualStyleBackColor = true;
            btnHandleMembers.Click += btnHandleMembers_Click_1;
            // 
            // btnHandleCategories
            // 
            btnHandleCategories.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnHandleCategories.ForeColor = Color.Black;
            btnHandleCategories.Location = new Point(7, 35);
            btnHandleCategories.Name = "btnHandleCategories";
            btnHandleCategories.Size = new Size(86, 35);
            btnHandleCategories.TabIndex = 5;
            btnHandleCategories.Text = "Kategorie";
            btnHandleCategories.UseVisualStyleBackColor = true;
            btnHandleCategories.Click += btnHandleCategories_Click_1;
            // 
            // btnCharts
            // 
            btnCharts.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnCharts.ForeColor = Color.Black;
            btnCharts.Location = new Point(99, 35);
            btnCharts.Name = "btnCharts";
            btnCharts.Size = new Size(86, 35);
            btnCharts.TabIndex = 6;
            btnCharts.Text = "Grafy";
            btnCharts.UseVisualStyleBackColor = true;
            btnCharts.Click += btnCharts_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(424, 35);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 35);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Odstranit ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(531, 35);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Konec";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom;
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnHandleCategories);
            groupBox1.Controls.Add(btnCharts);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAddTransaction);
            groupBox1.Controls.Add(btnHandleMembers);
            groupBox1.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(88, 405);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(623, 93);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ovládací panel";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 17);
            label1.TabIndex = 0;
            label1.Text = "Podle jména:";
            // 
            // lblAmountMin
            // 
            lblAmountMin.Anchor = AnchorStyles.Left;
            lblAmountMin.AutoSize = true;
            lblAmountMin.Location = new Point(12, 73);
            lblAmountMin.Name = "lblAmountMin";
            lblAmountMin.Size = new Size(78, 17);
            lblAmountMin.TabIndex = 1;
            lblAmountMin.Text = "Min. částka";
            // 
            // lblAmountMax
            // 
            lblAmountMax.Anchor = AnchorStyles.Left;
            lblAmountMax.AutoSize = true;
            lblAmountMax.Location = new Point(12, 139);
            lblAmountMax.Name = "lblAmountMax";
            lblAmountMax.Size = new Size(80, 17);
            lblAmountMax.TabIndex = 11;
            lblAmountMax.Text = "Max. částka";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(11, 207);
            label4.Name = "label4";
            label4.Size = new Size(109, 17);
            label4.TabIndex = 12;
            label4.Text = "Podle kategorie:";
            // 
            // pnlFilter
            // 
            pnlFilter.AutoScroll = true;
            pnlFilter.Controls.Add(btnClearFilter);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(label7);
            pnlFilter.Controls.Add(label6);
            pnlFilter.Controls.Add(label5);
            pnlFilter.Controls.Add(cmbTypeFilter);
            pnlFilter.Controls.Add(cmbCategoryFilter);
            pnlFilter.Controls.Add(trkAmountMax);
            pnlFilter.Controls.Add(txtNameFilter);
            pnlFilter.Controls.Add(trkAmountMin);
            pnlFilter.Controls.Add(label4);
            pnlFilter.Controls.Add(lblAmountMax);
            pnlFilter.Controls.Add(lblAmountMin);
            pnlFilter.Controls.Add(label1);
            pnlFilter.Dock = DockStyle.Left;
            pnlFilter.Location = new Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(137, 510);
            pnlFilter.TabIndex = 12;
            pnlFilter.Visible = false;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Anchor = AnchorStyles.Left;
            btnClearFilter.AutoSize = true;
            btnClearFilter.Location = new Point(12, 475);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(117, 27);
            btnClearFilter.TabIndex = 24;
            btnClearFilter.Text = "Reset filtru";
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Left;
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(12, 425);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(118, 24);
            dtpTo.TabIndex = 22;
            // 
            // dtpFrom
            // 
            dtpFrom.AllowDrop = true;
            dtpFrom.Anchor = AnchorStyles.Left;
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(12, 366);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(117, 24);
            dtpFrom.TabIndex = 21;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(11, 346);
            label7.Name = "label7";
            label7.Size = new Size(30, 17);
            label7.TabIndex = 20;
            label7.Text = "Od:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(12, 405);
            label6.Name = "label6";
            label6.Size = new Size(30, 17);
            label6.TabIndex = 19;
            label6.Text = "Do:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(11, 271);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 18;
            label5.Text = "Podle typu:";
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.Anchor = AnchorStyles.Left;
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Location = new Point(11, 291);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(118, 25);
            cmbTypeFilter.TabIndex = 17;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.Anchor = AnchorStyles.Left;
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(11, 227);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(117, 25);
            cmbCategoryFilter.TabIndex = 16;
            // 
            // trkAmountMax
            // 
            trkAmountMax.Anchor = AnchorStyles.Left;
            trkAmountMax.LargeChange = 100;
            trkAmountMax.Location = new Point(12, 159);
            trkAmountMax.Maximum = 500000;
            trkAmountMax.Name = "trkAmountMax";
            trkAmountMax.Size = new Size(113, 45);
            trkAmountMax.SmallChange = 100;
            trkAmountMax.TabIndex = 100;
            // 
            // txtNameFilter
            // 
            txtNameFilter.Anchor = AnchorStyles.Left;
            txtNameFilter.Location = new Point(12, 29);
            txtNameFilter.Name = "txtNameFilter";
            txtNameFilter.Size = new Size(117, 24);
            txtNameFilter.TabIndex = 14;
            // 
            // trkAmountMin
            // 
            trkAmountMin.Anchor = AnchorStyles.Left;
            trkAmountMin.LargeChange = 100;
            trkAmountMin.Location = new Point(12, 93);
            trkAmountMin.Maximum = 500000;
            trkAmountMin.Name = "trkAmountMin";
            trkAmountMin.Size = new Size(117, 45);
            trkAmountMin.SmallChange = 10;
            trkAmountMin.TabIndex = 13;
            // 
            // btnToggleFilter
            // 
            btnToggleFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleFilter.Image = (Image)resources.GetObject("btnToggleFilter.Image");
            btnToggleFilter.Location = new Point(726, 0);
            btnToggleFilter.Name = "btnToggleFilter";
            btnToggleFilter.Size = new Size(30, 23);
            btnToggleFilter.TabIndex = 13;
            btnToggleFilter.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dataGridViewTransaction);
            panel1.Controls.Add(btnToggleFilter);
            panel1.Location = new Point(11, 213);
            panel1.Name = "panel1";
            panel1.Size = new Size(756, 186);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(labelLeftOver);
            panel2.Location = new Point(11, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(756, 197);
            panel2.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.000618F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0006256F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0006256F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.9981289F));
            tableLayoutPanel1.Controls.Add(lblAvgExp, 3, 1);
            tableLayoutPanel1.Controls.Add(lblThisMonthExp, 2, 1);
            tableLayoutPanel1.Controls.Add(lblTopEarner, 1, 1);
            tableLayoutPanel1.Controls.Add(lblTopSpender, 0, 1);
            tableLayoutPanel1.Controls.Add(lblTopIncome, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTopExpense, 1, 0);
            tableLayoutPanel1.Controls.Add(lblTopCat, 2, 0);
            tableLayoutPanel1.Controls.Add(lblTurnover, 3, 0);
            tableLayoutPanel1.Location = new Point(279, 23);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(460, 150);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // lblAvgExp
            // 
            lblAvgExp.AutoSize = true;
            lblAvgExp.Dock = DockStyle.Fill;
            lblAvgExp.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblAvgExp.ForeColor = Color.Black;
            lblAvgExp.Location = new Point(348, 75);
            lblAvgExp.Name = "lblAvgExp";
            lblAvgExp.Size = new Size(109, 75);
            lblAvgExp.TabIndex = 7;
            lblAvgExp.Text = "label6";
            lblAvgExp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThisMonthExp
            // 
            lblThisMonthExp.AutoSize = true;
            lblThisMonthExp.Dock = DockStyle.Fill;
            lblThisMonthExp.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblThisMonthExp.ForeColor = Color.Black;
            lblThisMonthExp.Location = new Point(233, 75);
            lblThisMonthExp.Name = "lblThisMonthExp";
            lblThisMonthExp.Size = new Size(109, 75);
            lblThisMonthExp.TabIndex = 6;
            lblThisMonthExp.Text = "label5";
            lblThisMonthExp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTopEarner
            // 
            lblTopEarner.AutoSize = true;
            lblTopEarner.Dock = DockStyle.Fill;
            lblTopEarner.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblTopEarner.ForeColor = Color.Black;
            lblTopEarner.Location = new Point(118, 75);
            lblTopEarner.Name = "lblTopEarner";
            lblTopEarner.Size = new Size(109, 75);
            lblTopEarner.TabIndex = 5;
            lblTopEarner.Text = "label4";
            lblTopEarner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTopSpender
            // 
            lblTopSpender.AutoSize = true;
            lblTopSpender.Dock = DockStyle.Fill;
            lblTopSpender.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblTopSpender.ForeColor = Color.Black;
            lblTopSpender.Location = new Point(3, 75);
            lblTopSpender.Name = "lblTopSpender";
            lblTopSpender.Size = new Size(109, 75);
            lblTopSpender.TabIndex = 4;
            lblTopSpender.Text = "label3";
            lblTopSpender.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTopIncome
            // 
            lblTopIncome.AutoSize = true;
            lblTopIncome.Dock = DockStyle.Fill;
            lblTopIncome.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTopIncome.ForeColor = Color.Black;
            lblTopIncome.Location = new Point(3, 0);
            lblTopIncome.Name = "lblTopIncome";
            lblTopIncome.Size = new Size(109, 75);
            lblTopIncome.TabIndex = 0;
            lblTopIncome.Text = "lblTopIncome";
            lblTopIncome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTopExpense
            // 
            lblTopExpense.AutoSize = true;
            lblTopExpense.Dock = DockStyle.Fill;
            lblTopExpense.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTopExpense.ForeColor = Color.Black;
            lblTopExpense.Location = new Point(118, 0);
            lblTopExpense.Name = "lblTopExpense";
            lblTopExpense.Size = new Size(109, 75);
            lblTopExpense.TabIndex = 1;
            lblTopExpense.Text = "lblTopExpence";
            lblTopExpense.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTopCat
            // 
            lblTopCat.AutoSize = true;
            lblTopCat.Dock = DockStyle.Fill;
            lblTopCat.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblTopCat.ForeColor = Color.Black;
            lblTopCat.Location = new Point(233, 0);
            lblTopCat.Name = "lblTopCat";
            lblTopCat.Size = new Size(109, 75);
            lblTopCat.TabIndex = 2;
            lblTopCat.Text = "lblTopCat";
            lblTopCat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTurnover
            // 
            lblTurnover.AutoSize = true;
            lblTurnover.Dock = DockStyle.Fill;
            lblTurnover.Font = new Font("Ebrima", 9.75F, FontStyle.Bold);
            lblTurnover.ForeColor = Color.Black;
            lblTurnover.Location = new Point(348, 0);
            lblTurnover.Name = "lblTurnover";
            lblTurnover.Size = new Size(109, 75);
            lblTurnover.TabIndex = 3;
            lblTurnover.Text = "lblTurnOver";
            lblTurnover.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLeftOver
            // 
            labelLeftOver.AllowDrop = true;
            labelLeftOver.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelLeftOver.AutoEllipsis = true;
            labelLeftOver.AutoSize = true;
            labelLeftOver.Font = new Font("Ebrima", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelLeftOver.ForeColor = Color.Black;
            labelLeftOver.Location = new Point(13, 23);
            labelLeftOver.Margin = new Padding(0);
            labelLeftOver.Name = "labelLeftOver";
            labelLeftOver.Size = new Size(234, 37);
            labelLeftOver.TabIndex = 11;
            labelLeftOver.Text = "Celkový zůstatek";
            labelLeftOver.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(137, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(777, 510);
            panel3.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 510);
            Controls.Add(panel3);
            Controls.Add(pnlFilter);
            Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Finance";
            FormClosing += MainForm_FormClosing_1;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransaction).EndInit();
            groupBox1.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkAmountMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkAmountMin).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTransaction;
        private Button btnAddTransaction;
        private Button btnHandleMembers;
        private Button btnHandleCategories;
        private Button btnCharts;
        private Button btnDelete;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Label label1;
        private Label lblAmountMin;
        private Label lblAmountMax;
        private Label label4;
        private Panel pnlFilter;
        private TrackBar trkAmountMax;
        private TextBox txtNameFilter;
        private TrackBar trkAmountMin;
        private ComboBox cmbCategoryFilter;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox cmbTypeFilter;
        private DateTimePicker dtpFrom;
        private Button btnClearFilter;
        private DateTimePicker dtpTo;
        private Button btnToggleFilter;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAvgExp;
        private Label lblThisMonthExp;
        private Label lblTopEarner;
        private Label lblTopSpender;
        private Label lblTopIncome;
        private Label lblTopExpense;
        private Label lblTopCat;
        private Label lblTurnover;
        private Label labelLeftOver;
        private Panel panel3;
    }
}
