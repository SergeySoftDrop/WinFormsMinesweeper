namespace сапёр3
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.TableControlsSetings = new System.Windows.Forms.TableLayoutPanel();
            this.MapSizePanel = new System.Windows.Forms.Panel();
            this.MapYLabel = new System.Windows.Forms.Label();
            this.MapXLabel = new System.Windows.Forms.Label();
            this.MapYTrackBar = new System.Windows.Forms.TrackBar();
            this.MapXTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BombsQuantityLabel = new System.Windows.Forms.Label();
            this.BombsQuantityTrackBar = new System.Windows.Forms.TrackBar();
            this.SetingsLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CellSizeLabel = new System.Windows.Forms.Label();
            this.CellSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.UserCheckBox = new System.Windows.Forms.CheckBox();
            this.MiddleCheckBox = new System.Windows.Forms.CheckBox();
            this.HardCheckBox = new System.Windows.Forms.CheckBox();
            this.EasyCheckBox = new System.Windows.Forms.CheckBox();
            this.TableControlsSetings.SuspendLayout();
            this.MapSizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapYTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapXTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BombsQuantityTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeTrackBar)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableControlsSetings
            // 
            this.TableControlsSetings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableControlsSetings.AutoSize = true;
            this.TableControlsSetings.BackColor = System.Drawing.Color.LemonChiffon;
            this.TableControlsSetings.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TableControlsSetings.ColumnCount = 1;
            this.TableControlsSetings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableControlsSetings.Controls.Add(this.MapSizePanel, 0, 1);
            this.TableControlsSetings.Controls.Add(this.panel1, 0, 2);
            this.TableControlsSetings.Controls.Add(this.SetingsLabel, 0, 0);
            this.TableControlsSetings.Controls.Add(this.panel2, 0, 3);
            this.TableControlsSetings.Controls.Add(this.panel3, 0, 4);
            this.TableControlsSetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableControlsSetings.Location = new System.Drawing.Point(102, 29);
            this.TableControlsSetings.Margin = new System.Windows.Forms.Padding(0);
            this.TableControlsSetings.Name = "TableControlsSetings";
            this.TableControlsSetings.RowCount = 5;
            this.TableControlsSetings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableControlsSetings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableControlsSetings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableControlsSetings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableControlsSetings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.TableControlsSetings.Size = new System.Drawing.Size(302, 515);
            this.TableControlsSetings.TabIndex = 0;
            // 
            // MapSizePanel
            // 
            this.MapSizePanel.BackColor = System.Drawing.Color.Transparent;
            this.MapSizePanel.Controls.Add(this.MapYLabel);
            this.MapSizePanel.Controls.Add(this.MapXLabel);
            this.MapSizePanel.Controls.Add(this.MapYTrackBar);
            this.MapSizePanel.Controls.Add(this.MapXTrackBar);
            this.MapSizePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapSizePanel.Location = new System.Drawing.Point(1, 31);
            this.MapSizePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MapSizePanel.Name = "MapSizePanel";
            this.MapSizePanel.Size = new System.Drawing.Size(300, 188);
            this.MapSizePanel.TabIndex = 1;
            // 
            // MapYLabel
            // 
            this.MapYLabel.AutoSize = true;
            this.MapYLabel.Location = new System.Drawing.Point(3, 91);
            this.MapYLabel.Name = "MapYLabel";
            this.MapYLabel.Size = new System.Drawing.Size(132, 20);
            this.MapYLabel.TabIndex = 3;
            this.MapYLabel.Text = "По вертикали:";
            this.MapYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapXLabel
            // 
            this.MapXLabel.AutoSize = true;
            this.MapXLabel.Location = new System.Drawing.Point(3, 9);
            this.MapXLabel.Name = "MapXLabel";
            this.MapXLabel.Size = new System.Drawing.Size(150, 20);
            this.MapXLabel.TabIndex = 2;
            this.MapXLabel.Text = "По горизонтали:";
            this.MapXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapYTrackBar
            // 
            this.MapYTrackBar.BackColor = System.Drawing.Color.Blue;
            this.MapYTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapYTrackBar.LargeChange = 1;
            this.MapYTrackBar.Location = new System.Drawing.Point(3, 120);
            this.MapYTrackBar.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.MapYTrackBar.Maximum = 15;
            this.MapYTrackBar.Minimum = 5;
            this.MapYTrackBar.Name = "MapYTrackBar";
            this.MapYTrackBar.Size = new System.Drawing.Size(294, 45);
            this.MapYTrackBar.TabIndex = 1;
            this.MapYTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MapYTrackBar.Value = 5;
            // 
            // MapXTrackBar
            // 
            this.MapXTrackBar.BackColor = System.Drawing.Color.Blue;
            this.MapXTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapXTrackBar.LargeChange = 1;
            this.MapXTrackBar.Location = new System.Drawing.Point(3, 35);
            this.MapXTrackBar.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.MapXTrackBar.Maximum = 15;
            this.MapXTrackBar.Minimum = 5;
            this.MapXTrackBar.Name = "MapXTrackBar";
            this.MapXTrackBar.Size = new System.Drawing.Size(294, 45);
            this.MapXTrackBar.TabIndex = 0;
            this.MapXTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MapXTrackBar.Value = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.BombsQuantityLabel);
            this.panel1.Controls.Add(this.BombsQuantityTrackBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 220);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            this.panel1.TabIndex = 2;
            // 
            // BombsQuantityLabel
            // 
            this.BombsQuantityLabel.AutoSize = true;
            this.BombsQuantityLabel.Location = new System.Drawing.Point(3, 10);
            this.BombsQuantityLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.BombsQuantityLabel.Name = "BombsQuantityLabel";
            this.BombsQuantityLabel.Size = new System.Drawing.Size(164, 20);
            this.BombsQuantityLabel.TabIndex = 4;
            this.BombsQuantityLabel.Text = "Количество Бомб:";
            this.BombsQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BombsQuantityTrackBar
            // 
            this.BombsQuantityTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BombsQuantityTrackBar.BackColor = System.Drawing.Color.Blue;
            this.BombsQuantityTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BombsQuantityTrackBar.LargeChange = 1;
            this.BombsQuantityTrackBar.Location = new System.Drawing.Point(3, 34);
            this.BombsQuantityTrackBar.Maximum = 20;
            this.BombsQuantityTrackBar.Minimum = 4;
            this.BombsQuantityTrackBar.Name = "BombsQuantityTrackBar";
            this.BombsQuantityTrackBar.Size = new System.Drawing.Size(294, 45);
            this.BombsQuantityTrackBar.TabIndex = 3;
            this.BombsQuantityTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.BombsQuantityTrackBar.Value = 5;
            // 
            // SetingsLabel
            // 
            this.SetingsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SetingsLabel.AutoSize = true;
            this.SetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetingsLabel.Location = new System.Drawing.Point(111, 6);
            this.SetingsLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.SetingsLabel.Name = "SetingsLabel";
            this.SetingsLabel.Size = new System.Drawing.Size(79, 24);
            this.SetingsLabel.TabIndex = 0;
            this.SetingsLabel.Text = "Setings";
            this.SetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.CellSizeLabel);
            this.panel2.Controls.Add(this.CellSizeTrackBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 321);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 100);
            this.panel2.TabIndex = 3;
            // 
            // CellSizeLabel
            // 
            this.CellSizeLabel.AutoSize = true;
            this.CellSizeLabel.Location = new System.Drawing.Point(3, 9);
            this.CellSizeLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.CellSizeLabel.Name = "CellSizeLabel";
            this.CellSizeLabel.Size = new System.Drawing.Size(142, 20);
            this.CellSizeLabel.TabIndex = 6;
            this.CellSizeLabel.Text = "Ширина ячейки:";
            this.CellSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CellSizeTrackBar
            // 
            this.CellSizeTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CellSizeTrackBar.BackColor = System.Drawing.Color.Blue;
            this.CellSizeTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CellSizeTrackBar.LargeChange = 1;
            this.CellSizeTrackBar.Location = new System.Drawing.Point(3, 34);
            this.CellSizeTrackBar.Maximum = 80;
            this.CellSizeTrackBar.Minimum = 40;
            this.CellSizeTrackBar.Name = "CellSizeTrackBar";
            this.CellSizeTrackBar.Size = new System.Drawing.Size(294, 45);
            this.CellSizeTrackBar.TabIndex = 5;
            this.CellSizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.CellSizeTrackBar.Value = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.UserCheckBox);
            this.panel3.Controls.Add(this.MiddleCheckBox);
            this.panel3.Controls.Add(this.HardCheckBox);
            this.panel3.Controls.Add(this.EasyCheckBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 422);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 92);
            this.panel3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(80, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Режим игры";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserCheckBox
            // 
            this.UserCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.UserCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserCheckBox.Location = new System.Drawing.Point(106, 65);
            this.UserCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserCheckBox.Name = "UserCheckBox";
            this.UserCheckBox.Size = new System.Drawing.Size(190, 24);
            this.UserCheckBox.TabIndex = 13;
            this.UserCheckBox.Text = "Пользовательский";
            this.UserCheckBox.UseVisualStyleBackColor = false;
            // 
            // MiddleCheckBox
            // 
            this.MiddleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MiddleCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MiddleCheckBox.Location = new System.Drawing.Point(106, 35);
            this.MiddleCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.MiddleCheckBox.Name = "MiddleCheckBox";
            this.MiddleCheckBox.Size = new System.Drawing.Size(115, 24);
            this.MiddleCheckBox.TabIndex = 12;
            this.MiddleCheckBox.Text = "Средний";
            this.MiddleCheckBox.UseVisualStyleBackColor = false;
            // 
            // HardCheckBox
            // 
            this.HardCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.HardCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardCheckBox.Location = new System.Drawing.Point(3, 65);
            this.HardCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.HardCheckBox.Name = "HardCheckBox";
            this.HardCheckBox.Size = new System.Drawing.Size(115, 24);
            this.HardCheckBox.TabIndex = 11;
            this.HardCheckBox.Text = "Тяжёлый";
            this.HardCheckBox.UseVisualStyleBackColor = false;
            // 
            // EasyCheckBox
            // 
            this.EasyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.EasyCheckBox.Checked = true;
            this.EasyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EasyCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EasyCheckBox.Location = new System.Drawing.Point(3, 35);
            this.EasyCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.EasyCheckBox.Name = "EasyCheckBox";
            this.EasyCheckBox.Size = new System.Drawing.Size(100, 24);
            this.EasyCheckBox.TabIndex = 10;
            this.EasyCheckBox.Text = "Лёгкий";
            this.EasyCheckBox.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(524, 587);
            this.Controls.Add(this.TableControlsSetings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.TableControlsSetings.ResumeLayout(false);
            this.TableControlsSetings.PerformLayout();
            this.MapSizePanel.ResumeLayout(false);
            this.MapSizePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapYTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapXTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BombsQuantityTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeTrackBar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableControlsSetings;
        private System.Windows.Forms.Label SetingsLabel;
        private System.Windows.Forms.Panel MapSizePanel;
        private System.Windows.Forms.TrackBar MapXTrackBar;
        private System.Windows.Forms.TrackBar MapYTrackBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar BombsQuantityTrackBar;
        private System.Windows.Forms.Label MapXLabel;
        private System.Windows.Forms.Label MapYLabel;
        private System.Windows.Forms.Label BombsQuantityLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label CellSizeLabel;
        private System.Windows.Forms.TrackBar CellSizeTrackBar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox UserCheckBox;
        private System.Windows.Forms.CheckBox MiddleCheckBox;
        private System.Windows.Forms.CheckBox HardCheckBox;
        private System.Windows.Forms.CheckBox EasyCheckBox;
        private System.Windows.Forms.Label label2;
    }
}