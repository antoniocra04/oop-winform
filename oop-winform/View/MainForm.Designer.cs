﻿namespace oop_winform
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ItemsTabPage = new System.Windows.Forms.TabPage();
            this.ItemsTab = new oop_winform.View.Tabs.ItemsTab();
            this.CustomersTabPage = new System.Windows.Forms.TabPage();
            this.CustomersTab = new oop_winform.View.Tabs.CustomersTab();
            this.CartTab = new System.Windows.Forms.TabPage();
            this.CartsTab = new oop_winform.View.Tabs.CartTab();
            this.OrdersTab = new System.Windows.Forms.TabPage();
            this.OrderTab = new oop_winform.View.Tabs.OrdersTab();
            this.cartTab1 = new oop_winform.View.Tabs.CartTab();
            this.MainTabControl.SuspendLayout();
            this.ItemsTabPage.SuspendLayout();
            this.CustomersTabPage.SuspendLayout();
            this.CartTab.SuspendLayout();
            this.OrdersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ItemsTabPage);
            this.MainTabControl.Controls.Add(this.CustomersTabPage);
            this.MainTabControl.Controls.Add(this.CartTab);
            this.MainTabControl.Controls.Add(this.OrdersTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(984, 661);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_TabIndexChanged);
            this.MainTabControl.TabIndexChanged += new System.EventHandler(this.MainTabControl_TabIndexChanged);
            // 
            // ItemsTabPage
            // 
            this.ItemsTabPage.Controls.Add(this.ItemsTab);
            this.ItemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ItemsTabPage.Name = "ItemsTabPage";
            this.ItemsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsTabPage.Size = new System.Drawing.Size(976, 635);
            this.ItemsTabPage.TabIndex = 0;
            this.ItemsTabPage.Text = "Items";
            this.ItemsTabPage.UseVisualStyleBackColor = true;
            // 
            // ItemsTab
            // 
            this.ItemsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsTab.Location = new System.Drawing.Point(3, 3);
            this.ItemsTab.MaximumSize = new System.Drawing.Size(954, 661);
            this.ItemsTab.MinimumSize = new System.Drawing.Size(622, 405);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Size = new System.Drawing.Size(954, 629);
            this.ItemsTab.TabIndex = 0;
            // 
            // CustomersTabPage
            // 
            this.CustomersTabPage.Controls.Add(this.CustomersTab);
            this.CustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.CustomersTabPage.Name = "CustomersTabPage";
            this.CustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CustomersTabPage.Size = new System.Drawing.Size(976, 635);
            this.CustomersTabPage.TabIndex = 1;
            this.CustomersTabPage.Text = "Customers";
            this.CustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // CustomersTab
            // 
            this.CustomersTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersTab.Location = new System.Drawing.Point(3, 3);
            this.CustomersTab.MaximumSize = new System.Drawing.Size(1000, 700);
            this.CustomersTab.MinimumSize = new System.Drawing.Size(600, 400);
            this.CustomersTab.Name = "CustomersTab";
            this.CustomersTab.Size = new System.Drawing.Size(970, 629);
            this.CustomersTab.TabIndex = 0;
            // 
            // CartTab
            // 
            this.CartTab.Controls.Add(this.CartsTab);
            this.CartTab.Location = new System.Drawing.Point(4, 22);
            this.CartTab.Name = "CartTab";
            this.CartTab.Padding = new System.Windows.Forms.Padding(3);
            this.CartTab.Size = new System.Drawing.Size(976, 635);
            this.CartTab.TabIndex = 2;
            this.CartTab.Text = "Cart";
            this.CartTab.UseVisualStyleBackColor = true;
            // 
            // CartsTab
            // 
            this.CartsTab.Customers = null;
            this.CartsTab.Items = null;
            this.CartsTab.Location = new System.Drawing.Point(3, 3);
            this.CartsTab.Name = "CartsTab";
            this.CartsTab.Size = new System.Drawing.Size(976, 635);
            this.CartsTab.TabIndex = 0;
            // 
            // OrdersTab
            // 
            this.OrdersTab.Controls.Add(this.OrderTab);
            this.OrdersTab.Location = new System.Drawing.Point(4, 22);
            this.OrdersTab.Name = "OrdersTab";
            this.OrdersTab.Size = new System.Drawing.Size(976, 635);
            this.OrdersTab.TabIndex = 3;
            this.OrdersTab.Text = "Orders";
            this.OrdersTab.UseVisualStyleBackColor = true;
            // 
            // OrderTab
            // 
            this.OrderTab.Customers = null;
            this.OrderTab.Location = new System.Drawing.Point(0, 0);
            this.OrderTab.Name = "OrderTab";
            this.OrderTab.Size = new System.Drawing.Size(980, 635);
            this.OrderTab.TabIndex = 0;
            // 
            // cartTab1
            // 
            this.cartTab1.Customers = null;
            this.cartTab1.Items = null;
            this.cartTab1.Location = new System.Drawing.Point(3, 3);
            this.cartTab1.Name = "cartTab1";
            this.cartTab1.Size = new System.Drawing.Size(976, 635);
            this.cartTab1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.MainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.Text = "Приложение";
            this.MainTabControl.ResumeLayout(false);
            this.ItemsTabPage.ResumeLayout(false);
            this.CustomersTabPage.ResumeLayout(false);
            this.CartTab.ResumeLayout(false);
            this.OrdersTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ItemsTabPage;
        private View.Tabs.ItemsTab ItemsTab;
        private System.Windows.Forms.TabPage CustomersTabPage;
        private View.Tabs.CustomersTab CustomersTab;
        private System.Windows.Forms.TabPage CartTab;
        private View.Tabs.CartTab CartsTab;
        private System.Windows.Forms.TabPage OrdersTab;
        private View.Tabs.OrdersTab OrderTab;
        private View.Tabs.CartTab cartTab1;
    }
}