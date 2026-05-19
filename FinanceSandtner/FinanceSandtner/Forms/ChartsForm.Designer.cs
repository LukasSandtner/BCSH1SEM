namespace FinanceSandtner.Forms
{
    partial class ChartsForm
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
            btnPieByCategory = new Button();
            btnPieByCategoryType = new Button();
            btnLineBalanceOverTime = new Button();
            btnStackedByMonth = new Button();
            btnMembersIncomeExpense = new Button();
            btnPrediction = new Button();
            rbPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnPieByCategory
            // 
            btnPieByCategory.BackColor = SystemColors.InactiveCaption;
            btnPieByCategory.Dock = DockStyle.Left;
            btnPieByCategory.Location = new Point(0, 0);
            btnPieByCategory.Margin = new Padding(3, 4, 3, 4);
            btnPieByCategory.Name = "btnPieByCategory";
            btnPieByCategory.Size = new Size(240, 953);
            btnPieByCategory.TabIndex = 0;
            btnPieByCategory.Text = "Koláč – výdaje podle kategorií";
            btnPieByCategory.UseVisualStyleBackColor = false;
            btnPieByCategory.Click += btnPieCategory_Click;
            // 
            // btnPieByCategoryType
            // 
            btnPieByCategoryType.BackColor = SystemColors.InactiveCaption;
            btnPieByCategoryType.Dock = DockStyle.Left;
            btnPieByCategoryType.Location = new Point(240, 0);
            btnPieByCategoryType.Margin = new Padding(3, 4, 3, 4);
            btnPieByCategoryType.Name = "btnPieByCategoryType";
            btnPieByCategoryType.Size = new Size(274, 953);
            btnPieByCategoryType.TabIndex = 1;
            btnPieByCategoryType.Text = "Koláč – výdaje podle typu kategorie";
            btnPieByCategoryType.UseVisualStyleBackColor = false;
            btnPieByCategoryType.Click += btnPieByCategoryType_Click;
            // 
            // btnLineBalanceOverTime
            // 
            btnLineBalanceOverTime.BackColor = SystemColors.InactiveCaption;
            btnLineBalanceOverTime.Dock = DockStyle.Left;
            btnLineBalanceOverTime.Location = new Point(514, 0);
            btnLineBalanceOverTime.Margin = new Padding(3, 4, 3, 4);
            btnLineBalanceOverTime.Name = "btnLineBalanceOverTime";
            btnLineBalanceOverTime.Size = new Size(263, 953);
            btnLineBalanceOverTime.TabIndex = 2;
            btnLineBalanceOverTime.Text = "Spojnice – vývoj zůstatku v čase";
            btnLineBalanceOverTime.UseVisualStyleBackColor = false;
            btnLineBalanceOverTime.Click += btnLineBalanceOverTime_Click;
            // 
            // btnStackedByMonth
            // 
            btnStackedByMonth.BackColor = SystemColors.InactiveCaption;
            btnStackedByMonth.Dock = DockStyle.Left;
            btnStackedByMonth.Location = new Point(777, 0);
            btnStackedByMonth.Margin = new Padding(3, 4, 3, 4);
            btnStackedByMonth.Name = "btnStackedByMonth";
            btnStackedByMonth.Size = new Size(274, 953);
            btnStackedByMonth.TabIndex = 3;
            btnStackedByMonth.Text = "Skládaný – příjmy vs. výdaje (měsíce)";
            btnStackedByMonth.UseVisualStyleBackColor = false;
            btnStackedByMonth.Click += btnStackedByMonth_Click;
            // 
            // btnMembersIncomeExpense
            // 
            btnMembersIncomeExpense.BackColor = SystemColors.InactiveCaption;
            btnMembersIncomeExpense.Dock = DockStyle.Left;
            btnMembersIncomeExpense.Location = new Point(1051, 0);
            btnMembersIncomeExpense.Margin = new Padding(3, 4, 3, 4);
            btnMembersIncomeExpense.Name = "btnMembersIncomeExpense";
            btnMembersIncomeExpense.Size = new Size(240, 953);
            btnMembersIncomeExpense.TabIndex = 4;
            btnMembersIncomeExpense.Text = "Členové – příjmy a výdaje";
            btnMembersIncomeExpense.UseVisualStyleBackColor = false;
            btnMembersIncomeExpense.Click += btnMembersIncomeExpense_Click;
            // 
            // btnPrediction
            // 
            btnPrediction.Dock = DockStyle.Left;
            btnPrediction.Location = new Point(1291, 0);
            btnPrediction.Margin = new Padding(3, 4, 3, 4);
            btnPrediction.Name = "btnPrediction";
            btnPrediction.Size = new Size(217, 953);
            btnPrediction.TabIndex = 5;
            btnPrediction.Text = "Predikce";
            btnPrediction.UseVisualStyleBackColor = true;
            btnPrediction.Click += btnPrediction_Click;
            // 
            // rbPanel
            // 
            rbPanel.Dock = DockStyle.Right;
            rbPanel.Location = new Point(1271, 0);
            rbPanel.Margin = new Padding(3, 4, 3, 4);
            rbPanel.Name = "rbPanel";
            rbPanel.Padding = new Padding(11, 13, 11, 0);
            rbPanel.Size = new Size(411, 953);
            rbPanel.TabIndex = 7;
            rbPanel.Visible = false;
            rbPanel.WrapContents = false;
            // 
            // ChartsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1682, 953);
            Controls.Add(rbPanel);
            Controls.Add(btnPrediction);
            Controls.Add(btnMembersIncomeExpense);
            Controls.Add(btnStackedByMonth);
            Controls.Add(btnLineBalanceOverTime);
            Controls.Add(btnPieByCategoryType);
            Controls.Add(btnPieByCategory);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChartsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Přehled – grafy";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPieByCategory;
        private Button btnPieByCategoryType;
        private Button btnLineBalanceOverTime;
        private Button btnStackedByMonth;
        private Button btnMembersIncomeExpense;
        private Button btnPrediction;
        private FlowLayoutPanel rbPanel;
    }
}