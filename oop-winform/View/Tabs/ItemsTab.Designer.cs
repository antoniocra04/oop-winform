﻿namespace oop_winform.View.Tabs
{
    partial class ItemsTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemsListPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.SelectedItemLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DiscriptionLabel = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.CostTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SelectedItemPanel = new System.Windows.Forms.Panel();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ItemsListPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SelectedItemPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsListPanel
            // 
            this.ItemsListPanel.Controls.Add(this.ButtonPanel);
            this.ItemsListPanel.Controls.Add(this.ItemsListBox);
            this.ItemsListPanel.Controls.Add(this.ItemsLabel);
            this.ItemsListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsListPanel.Location = new System.Drawing.Point(3, 3);
            this.ItemsListPanel.Name = "ItemsListPanel";
            this.ItemsListPanel.Size = new System.Drawing.Size(394, 694);
            this.ItemsListPanel.TabIndex = 0;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPanel.ColumnCount = 3;
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonPanel.Controls.Add(this.RemoveButton, 1, 0);
            this.ButtonPanel.Controls.Add(this.AddButton, 0, 0);
            this.ButtonPanel.Location = new System.Drawing.Point(3, 632);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.RowCount = 1;
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonPanel.Size = new System.Drawing.Size(388, 62);
            this.ButtonPanel.TabIndex = 1;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(132, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(123, 56);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(123, 56);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.Location = new System.Drawing.Point(3, 22);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(391, 615);
            this.ItemsListBox.TabIndex = 1;
            this.ItemsListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsListBox_SelectedIndexChanged);
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ItemsLabel.Location = new System.Drawing.Point(3, 3);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(37, 13);
            this.ItemsLabel.TabIndex = 0;
            this.ItemsLabel.Text = "Items";
            // 
            // SelectedItemLabel
            // 
            this.SelectedItemLabel.AutoSize = true;
            this.SelectedItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.SelectedItemLabel.Location = new System.Drawing.Point(10, 3);
            this.SelectedItemLabel.Name = "SelectedItemLabel";
            this.SelectedItemLabel.Size = new System.Drawing.Size(85, 13);
            this.SelectedItemLabel.TabIndex = 0;
            this.SelectedItemLabel.Text = "Selected Item";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(10, 38);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(21, 13);
            this.IdLabel.TabIndex = 1;
            this.IdLabel.Text = "ID:";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(10, 72);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(31, 13);
            this.CostLabel.TabIndex = 2;
            this.CostLabel.Text = "Cost:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 145);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name:";
            // 
            // DiscriptionLabel
            // 
            this.DiscriptionLabel.AutoSize = true;
            this.DiscriptionLabel.Location = new System.Drawing.Point(10, 269);
            this.DiscriptionLabel.Name = "DiscriptionLabel";
            this.DiscriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DiscriptionLabel.TabIndex = 4;
            this.DiscriptionLabel.Text = "Description:";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Enabled = false;
            this.IdTextBox.Location = new System.Drawing.Point(81, 34);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 5;
            // 
            // CostTextBox
            // 
            this.CostTextBox.Enabled = false;
            this.CostTextBox.Location = new System.Drawing.Point(81, 68);
            this.CostTextBox.Name = "CostTextBox";
            this.CostTextBox.Size = new System.Drawing.Size(100, 20);
            this.CostTextBox.TabIndex = 6;
            this.CostTextBox.TextChanged += new System.EventHandler(this.CostTextBox_TextChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(10, 161);
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(577, 94);
            this.NameTextBox.TabIndex = 7;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Enabled = false;
            this.DescriptionTextBox.Location = new System.Drawing.Point(10, 285);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(577, 157);
            this.DescriptionTextBox.TabIndex = 8;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
            // 
            // SelectedItemPanel
            // 
            this.SelectedItemPanel.Controls.Add(this.CategoryComboBox);
            this.SelectedItemPanel.Controls.Add(this.CategoryLabel);
            this.SelectedItemPanel.Controls.Add(this.DescriptionTextBox);
            this.SelectedItemPanel.Controls.Add(this.NameTextBox);
            this.SelectedItemPanel.Controls.Add(this.CostTextBox);
            this.SelectedItemPanel.Controls.Add(this.IdTextBox);
            this.SelectedItemPanel.Controls.Add(this.DiscriptionLabel);
            this.SelectedItemPanel.Controls.Add(this.NameLabel);
            this.SelectedItemPanel.Controls.Add(this.CostLabel);
            this.SelectedItemPanel.Controls.Add(this.IdLabel);
            this.SelectedItemPanel.Controls.Add(this.SelectedItemLabel);
            this.SelectedItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedItemPanel.Location = new System.Drawing.Point(403, 3);
            this.SelectedItemPanel.Name = "SelectedItemPanel";
            this.SelectedItemPanel.Size = new System.Drawing.Size(594, 694);
            this.SelectedItemPanel.TabIndex = 1;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.Enabled = false;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(81, 105);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.TabIndex = 18;
            this.CategoryComboBox.TextChanged += new System.EventHandler(this.CategoryComboBox_TextChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(11, 108);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 17;
            this.CategoryLabel.Text = "Category:";
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutPanel.Controls.Add(this.ItemsListPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.SelectedItemPanel, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1000, 700);
            this.MainTableLayoutPanel.TabIndex = 2;
            // 
            // ItemsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ItemsTab";
            this.Size = new System.Drawing.Size(1000, 700);
            this.ItemsListPanel.ResumeLayout(false);
            this.ItemsListPanel.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.SelectedItemPanel.ResumeLayout(false);
            this.SelectedItemPanel.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ItemsListPanel;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.TableLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label SelectedItemLabel;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DiscriptionLabel;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox CostTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Panel SelectedItemPanel;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label CategoryLabel;
    }
}
