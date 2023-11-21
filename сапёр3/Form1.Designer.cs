namespace сапёр3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FlagCounterLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.TableLayoutPanel();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SetingsBtn = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlagCounterLabel
            // 
            this.FlagCounterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlagCounterLabel.AutoSize = true;
            this.FlagCounterLabel.BackColor = System.Drawing.Color.Transparent;
            this.FlagCounterLabel.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlagCounterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FlagCounterLabel.Location = new System.Drawing.Point(140, 37);
            this.FlagCounterLabel.Name = "FlagCounterLabel";
            this.FlagCounterLabel.Size = new System.Drawing.Size(121, 25);
            this.FlagCounterLabel.TabIndex = 0;
            this.FlagCounterLabel.Text = "Флажков: 0";
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TimerLabel.Location = new System.Drawing.Point(548, 37);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(88, 25);
            this.TimerLabel.TabIndex = 2;
            this.TimerLabel.Text = "00:00:00";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.Khaki;
            this.Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Panel.ColumnCount = 3;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Panel.Controls.Add(this.TimerLabel, 1, 0);
            this.Panel.Controls.Add(this.FlagCounterLabel, 0, 0);
            this.Panel.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Panel.MaximumSize = new System.Drawing.Size(1200, 100);
            this.Panel.Name = "Panel";
            this.Panel.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.Panel.RowCount = 1;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.Size = new System.Drawing.Size(1184, 100);
            this.Panel.TabIndex = 4;
            // 
            // RestartBtn
            // 
            this.RestartBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RestartBtn.BackColor = System.Drawing.Color.Transparent;
            this.RestartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestartBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestartBtn.Location = new System.Drawing.Point(149, 4);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(92, 31);
            this.RestartBtn.TabIndex = 5;
            this.RestartBtn.TabStop = false;
            this.RestartBtn.Text = "Restart";
            this.RestartBtn.UseVisualStyleBackColor = false;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SetingsBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RestartBtn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(788, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 78);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // SetingsBtn
            // 
            this.SetingsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SetingsBtn.BackColor = System.Drawing.Color.Transparent;
            this.SetingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetingsBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetingsBtn.Location = new System.Drawing.Point(149, 43);
            this.SetingsBtn.Name = "SetingsBtn";
            this.SetingsBtn.Size = new System.Drawing.Size(92, 31);
            this.SetingsBtn.TabIndex = 6;
            this.SetingsBtn.TabStop = false;
            this.SetingsBtn.Text = "Setings";
            this.SetingsBtn.UseVisualStyleBackColor = false;
            this.SetingsBtn.Click += new System.EventHandler(this.SetingsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 450);
            this.Controls.Add(this.Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Miner";
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FlagCounterLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.TableLayoutPanel Panel;
        private System.Windows.Forms.Button RestartBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SetingsBtn;
    }
}

